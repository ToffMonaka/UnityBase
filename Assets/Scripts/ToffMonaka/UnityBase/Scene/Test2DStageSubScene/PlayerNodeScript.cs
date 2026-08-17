/**
 * @file
 * @brief PlayerNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.InputSystem;

namespace ToffMonaka {
namespace UnityBase.Scene.Test2DStageSubScene {
/**
 * @brief PlayerNodeScriptCreateDescクラス
 */
public class PlayerNodeScriptCreateDesc : ToffMonaka.Tml.Scene.NodeScriptCreateDesc
{
}

/**
 * @brief PlayerNodeScriptクラス
 */
public class PlayerNodeScript : ToffMonaka.Tml.Scene.NodeScript
{
#pragma warning disable 0414
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CapsuleCollider2D _collider;
    [SerializeField] private float _skinWidth = 0.015f;
    [SerializeField] private float _moveSpeed = 4.0f;
    [SerializeField] private int _moveIterationCount = 3;
    [SerializeField] private float _moveStepHeight = 0.5f;
    [SerializeField] private float _jumpPower = 6.5f;
    [SerializeField] private float _jumpDeceleratePower = 0.5f;
    [SerializeField] private float _fallLimit = -10.0f;

    public new PlayerNodeScriptCreateDesc createDesc{get; private set;} = null;

    private bool _movePositionFlag = false;
    private Vector2 _movePosition = Vector2.zero;
    private Vector2 _moveVelocity = Vector2.zero;
    private bool _jumpFlag = false;
    private bool _jumpDecelerateFlag = false;
    private bool _groundFlag = false;
    private Vector2 _groundNormal = Vector2.up;
    private Vector2 _groundPosition = Vector2.zero;
    private int _groundPositionIntervalCount = 0;
    private int _groundLayerMask = 0;

    private InputAction _moveInputAction = null;
    private InputAction _jumpInputAction = null;
#pragma warning restore 0414

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.TEST_2D_STAGE_PLAYER_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        this._groundPosition = this._rigidbody.position;
        this._groundPositionIntervalCount = 0;
        this._groundLayerMask = LayerMask.GetMask("Ground");

        this._moveInputAction = InputSystem.actions.FindAction("Player/Move");
        this._moveInputAction.Enable();

        this._jumpInputAction = InputSystem.actions.FindAction("Player/Jump");
        this._jumpInputAction.Enable();

        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        base._OnDestroy();

        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new PlayerNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as PlayerNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        this.RunMoveAction(this._moveInputAction.ReadValue<Vector2>().x);

        if (this._jumpInputAction.WasPressedThisFrame()) {
            this.RunJumpAction(1.0f);
        } else if (this._jumpInputAction.WasReleasedThisFrame()) {
            this.RunJumpDecelerateAction(1.0f);
        }

        base._OnUpdate();

        return;
    }

    /**
     * @brief _OnFixedUpdate関数
     */
    protected override void _OnFixedUpdate()
    {
        if (this._movePositionFlag) {
            this._SetRigidbodyPosition(this._movePosition);

            this._movePositionFlag = false;
        }

        if (!this._groundFlag) {
            this._moveVelocity.y += Physics2D.gravity.y * Time.deltaTime;
        }

        this._UpdateRigidbodyPosition();

        if (this._groundFlag) {
            --this._groundPositionIntervalCount;

            if (this._groundPositionIntervalCount <= 0) {
                this._groundPosition = this._rigidbody.position;
                this._groundPositionIntervalCount = 30;
            }
        }

        if (this._rigidbody.position.y <= this._fallLimit) {
            this.EnterFallZone();
        }

        this._UpdateJumpFlag();
        this._UpdateJumpDecelerateFlag();

        base._OnFixedUpdate();

        return;
    }

    /**
     * @brief _SetRigidbodyPosition関数
     * @param pos (position)
     */
    private void _SetRigidbodyPosition(Vector2 pos)
    {
        this._rigidbody.position = pos;

        this._UpdateGroundFlag();

        return;
    }

    /**
     * @brief _UpdateRigidbodyPosition関数
     */
    private void _UpdateRigidbodyPosition()
    {
        if ((this._groundFlag) && (this._moveVelocity.y == 0.0f)) {
            this._UpdateRigidbodyPosition(this._GetSurfaceVelocity(this._moveVelocity, this._groundNormal, true) * Time.deltaTime, 0, true);
        } else {
            this._UpdateRigidbodyPosition(this._moveVelocity * Time.deltaTime, 0, false);
        }

        this._UpdateGroundFlag();

        return;
    }

    /**
     * @brief _UpdateRigidbodyPosition関数
     * @param vel (velocity)
     * @param cnt (count)
     * @param slide_flg (slide_flag)
     */
    private void _UpdateRigidbodyPosition(Vector2 vel, int cnt, bool slide_flg)
    {
	    if (cnt >= this._moveIterationCount) {
		    return;
	    }

        var vel_normal = vel.normalized;
        var vel_dist = vel.magnitude;

        if (vel_dist <= 0.0f) {
		    return;
        }

        if (slide_flg) {
            if (this._CapsuleCast(this._rigidbody.position, vel_normal, vel_dist, out RaycastHit2D hit)) {
                var hit_vel = (hit.distance > this._skinWidth) ? (vel_normal * (hit.distance - this._skinWidth)) : Vector2.zero;

                this._rigidbody.position += hit_vel;

                var hit_surf_normal = this._GetSurfaceNormal(hit);

                if ((hit_surf_normal.y > 0.5f) || (hit_surf_normal.y < -0.5f)) {
                    this._UpdateRigidbodyPosition(this._GetSurfaceVelocity(vel - hit_vel, hit.normal, true), cnt + 1, slide_flg);
                } else {
                    var leftover_vel = vel - hit_vel;
                    var leftover_vel_normal = leftover_vel.normalized;
                    var leftover_vel_dist = leftover_vel.magnitude;

                    if (this._CapsuleCast(this._rigidbody.position + new Vector2(0.0f, this._moveStepHeight), leftover_vel_normal, leftover_vel_dist, out RaycastHit2D hit2)) {
                        this._UpdateRigidbodyPosition(this._GetSurfaceVelocity(leftover_vel, hit.normal, true), cnt + 1, slide_flg);
                    } else {
                        if (this._CapsuleCast(this._rigidbody.position + new Vector2(leftover_vel.x, this._moveStepHeight), Vector2.down, this._moveStepHeight, out RaycastHit2D hit3)) {
                            var hit3_surf_normal = this._GetSurfaceNormal(hit3);

                            if (hit3_surf_normal.y > 0.5f) {
                                var hit3_vel = (hit3.distance > this._skinWidth) ? (Vector2.down * (hit3.distance - this._skinWidth)) : Vector2.zero;

                                this._rigidbody.position += (new Vector2(leftover_vel.x, this._moveStepHeight)) + hit3_vel;
                            } else {
                                this._UpdateRigidbodyPosition(this._GetSurfaceVelocity(leftover_vel, hit.normal, true), cnt + 1, slide_flg);
                            }
                        } else {
                            this._UpdateRigidbodyPosition(this._GetSurfaceVelocity(leftover_vel, hit.normal, true), cnt + 1, slide_flg);
                        }
                    }
                }
            } else {
                this._rigidbody.position += vel;

                if (this._CapsuleCast(this._rigidbody.position, Vector2.down, this._moveStepHeight, out RaycastHit2D hit2)) {
                    var hit2_surf_normal = this._GetSurfaceNormal(hit2);

                    if (hit2_surf_normal.y > 0.5f) {
                        var hit2_vel = (hit2.distance > this._skinWidth) ? (Vector2.down * (hit2.distance - this._skinWidth)) : Vector2.zero;

                        this._rigidbody.position += hit2_vel;

                    }
                }
            }
        } else {
            if (this._CapsuleCast(this._rigidbody.position, vel_normal, vel_dist, out RaycastHit2D hit)) {
                var hit_vel = (hit.distance > this._skinWidth) ? (vel_normal * (hit.distance - this._skinWidth)) : Vector2.zero;

                this._rigidbody.position += hit_vel;

                var hit_surf_normal = this._GetSurfaceNormal(hit);

                if ((hit_surf_normal.y > 0.5f) || (hit_surf_normal.y < -0.5f)) {
                    this._moveVelocity = Vector2.zero;
                } else {
                    this._UpdateRigidbodyPosition(this._GetSurfaceVelocity(vel - hit_vel, hit.normal, false), cnt + 1, slide_flg);
                }
            } else {
                this._rigidbody.position += vel;
            }
        }

        return;
    }

    /**
     * @brief _CapsuleCast関数
     * @param pos (position)
     * @param dir (direction)
     * @param dist (distance)
     * @param hit (hit)
     * @return hit_flg (hit_flag)
     */
    private bool _CapsuleCast(Vector2 pos, Vector2 dir, float dist, out RaycastHit2D hit)
    {
        hit = Physics2D.CapsuleCast(pos, this._collider.size, this._collider.direction, 0.0f, dir, dist + this._skinWidth, this._groundLayerMask);

        return (hit.collider != null);
    }

    /**
     * @brief _GetSurfaceNormal関数
     * @param hit (hit)
     * @return surf_normal (surface_normal)
     */
    private Vector2 _GetSurfaceNormal(RaycastHit2D hit)
    {
        var p = hit.point + hit.normal * 0.01f;

        var surf_hit = Physics2D.Raycast(p, -hit.normal, 0.015f, this._groundLayerMask);

        if (surf_hit.collider == null) {
            return (hit.normal);
        }

        return (surf_hit.normal);
    }

    /**
     * @brief _GetSurfaceVelocity関数
     * @param vel (velocity)
     * @param surf_normal (surf_normal)
     * @param keep_speed_flg (keep_speed_flag)
     * @return surf_vel (surf_velocity)
     */
    private Vector3 _GetSurfaceVelocity(Vector3 vel, Vector3 surf_normal, bool keep_speed_flg)
    {
        var surf_vel = Vector3.ProjectOnPlane(vel, surf_normal);

        if (keep_speed_flg) {
            surf_vel = surf_vel.normalized * vel.magnitude;
        }

        return (surf_vel);
    }

    /**
     * @brief _UpdateJumpFlag関数
     */
    private void _UpdateJumpFlag()
    {
        if (this._jumpFlag) {
            if (!this._groundFlag) {
                this._jumpFlag = false;
            }
        } else {
            if (this._groundFlag) {
                this._jumpFlag = true;
            }
        }

        return;
    }

    /**
     * @brief _UpdateJumpDecelerateFlag関数
     */
    private void _UpdateJumpDecelerateFlag()
    {
        if (this._jumpDecelerateFlag) {
            if (this._moveVelocity.y <= 0.0f) {
                this._jumpDecelerateFlag = false;
            }
        }

        return;
    }

    /**
     * @brief _UpdateGroundFlag関数
     */
    private void _UpdateGroundFlag()
    {
        this._groundFlag = false;

        if (this._CapsuleCast(this._rigidbody.position, Vector2.down, 0.01f, out RaycastHit2D hit)) {
            var hit_surf_normal = this._GetSurfaceNormal(hit);

            if (hit_surf_normal.y > 0.5f) {
                var hit_vel = (hit.distance > this._skinWidth) ? (Vector2.down * (hit.distance - this._skinWidth)) : Vector2.zero;

                this._rigidbody.position += hit_vel;

                this._groundFlag = true;
                this._groundNormal = hit_surf_normal;
            }
        }

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        this.RunSpawnAction(this._groundPosition);

        base._OnOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

        return;
    }

    /**
     * @brief RunSpawnAction関数
     * @param pos (position)
     */
    public void RunSpawnAction(Vector2 pos)
    {
        this._movePositionFlag = true;
        this._movePosition = pos;
        this._moveVelocity = Vector2.zero;

        this._jumpFlag = false;
        this._jumpDecelerateFlag = false;

        this._groundFlag = false;

        this._animator.SetBool("moveLeftFlag", false);
        this._animator.SetBool("moveRightFlag", false);

        return;
    }

    /**
     * @brief RunMoveAction関数
     * @param x (x)
     */
    public void RunMoveAction(float x)
    {
        this._moveVelocity.x = x * this._moveSpeed;

        if (this._moveVelocity.x > 0.0f) {
            this._animator.SetBool("moveLeftFlag", false);
            this._animator.SetBool("moveRightFlag", true);
        } else if (this._moveVelocity.x < 0.0f) {
            this._animator.SetBool("moveLeftFlag", true);
            this._animator.SetBool("moveRightFlag", false);
        } else {
            this._animator.SetBool("moveLeftFlag", false);
            this._animator.SetBool("moveRightFlag", false);
        }

        return;
    }

    /**
     * @brief RunJumpAction関数
     * @param y (y)
     */
    public void RunJumpAction(float y)
    {
        if ((!this._jumpFlag)
        || (y <= 0.0f)) {
            return;
        }

        this._moveVelocity.y = y * this._jumpPower;

        this._jumpFlag = false;
        this._jumpDecelerateFlag = true;

        return;
    }

    /**
     * @brief RunJumpDecelerateAction関数
     * @param y (y)
     */
    public void RunJumpDecelerateAction(float y)
    {
        if ((!this._jumpDecelerateFlag)
        || (y <= 0.0f)) {
            return;
        }

        this._moveVelocity.y *= y * this._jumpDeceleratePower;

        this._jumpDecelerateFlag = false;

        return;
    }

    /**
     * @brief EnterFallZone関数
     */
    public void EnterFallZone()
    {
        this.RunSpawnAction(this._groundPosition);

        return;
    }
}
}
}
