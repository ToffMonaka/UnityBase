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
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _jumpPower = 6.5f;

    public new PlayerNodeScriptCreateDesc createDesc{get; private set;} = null;

    private Rigidbody2D _rigidbody;
    private Rigidbody2D.SlideMovement _slideMovement;
    private RaycastHit2D[] _raycastHitArray = new RaycastHit2D[8];
    private bool _groundFlag = false;
    private ContactFilter2D _groundContactFilter;
    private Vector2 _moveVelocity = Vector2.zero;

    private InputAction _moveInputAction = null;
    private InputAction _jumpInputAction = null;

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

        this._rigidbody = this.gameObject.GetComponent<Rigidbody2D>();

        this._slideMovement = new Rigidbody2D.SlideMovement {
            maxIterations = 3,
            surfaceSlideAngle = 90.0f,
            surfaceUp = Vector2.up,
            surfaceAnchor = Vector2.down,
            useLayerMask = true,
            layerMask = LayerMask.GetMask("Ground"),
            gravity = Vector2.zero,
            gravitySlipAngle = 0.0f
        };

        for (int raycast_hit_i = 0; raycast_hit_i < this._raycastHitArray.Length; ++raycast_hit_i) {
            this._raycastHitArray[raycast_hit_i] = new RaycastHit2D();
        }

        this._groundContactFilter = new ContactFilter2D();

        this._groundContactFilter.useLayerMask = true;
        this._groundContactFilter.layerMask = LayerMask.GetMask("Ground");
        this._groundContactFilter.useTriggers = false;

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
        this._moveVelocity.x = this._moveInputAction.ReadValue<Vector2>().x * this._moveSpeed;

        if (this._jumpInputAction.WasPressedThisFrame()) {
            if (this._groundFlag) {
                this._moveVelocity.y = this._jumpPower;
            }
        }

        base._OnUpdate();

        return;
    }

    /**
     * @brief _OnFixedUpdate関数
     */
    protected override void _OnFixedUpdate()
    {
        this._UpdateGroundFlag();

        if ((this._groundFlag) && (this._moveVelocity.y == 0.0f)) {
            this._rigidbody.Slide(this._moveVelocity, Time.deltaTime, this._slideMovement);
        } else {
            this._moveVelocity.y += Physics2D.gravity.y * Time.deltaTime;

            var velocity = this._moveVelocity * Time.deltaTime;
            var velocity_normal = velocity.normalized;
            var distance = velocity.magnitude;

            if (distance > 0.0f) {
                var hit_cnt = this._rigidbody.Cast(velocity_normal, this._groundContactFilter, this._raycastHitArray, distance + 0.01f);

                if (hit_cnt > 0) {
                    var hit_normal = this._raycastHitArray[0].normal;

                    if ((hit_normal.y > 0.5f) && (velocity_normal.y < 0.0f)) {
                        velocity = velocity_normal * (this._raycastHitArray[0].distance - 0.01f);

                        this._moveVelocity.y = 0.0f;
                    } else if ((hit_normal.y < -0.5f) && (velocity_normal.y > 0.0f)) {
                        velocity = velocity_normal * (this._raycastHitArray[0].distance - 0.01f);

                        this._moveVelocity.y = 0.0f;
                    } else if ((hit_normal.x < -0.5f) && (velocity_normal.x > 0.0f)) {
                        velocity = new Vector2(velocity_normal.x * (this._raycastHitArray[0].distance - 0.01f), velocity.y);

                        this._moveVelocity.x = 0.0f;

                        var velocity2 = new Vector2(0.0f, velocity.y);
                        var velocity_normal2 = new Vector2(0.0f, (velocity.y < 0.0f) ? -1.0f : ((velocity.y > 0.0f) ? 1.0f : 0.0f));
                        var distance2 = (velocity.y < 0.0f) ? -velocity.y : velocity.y;

                        if (distance2 > 0.0f) {
                            var hit_cnt2 = this._rigidbody.Cast(velocity_normal2, this._groundContactFilter, this._raycastHitArray, distance2 + 0.01f);

                            if (hit_cnt2 > 0) {
                                var hit_normal2 = this._raycastHitArray[0].normal;

                                if ((hit_normal2.y > 0.5f) && (velocity_normal2.y < 0.0f)) {
                                    velocity2 = velocity_normal2 * (this._raycastHitArray[0].distance - 0.01f);

                                    this._moveVelocity.y = 0.0f;
                                } else if ((hit_normal2.y < -0.5f) && (velocity_normal2.y > 0.0f)) {
                                    velocity2 = velocity_normal2 * (this._raycastHitArray[0].distance - 0.01f);

                                    this._moveVelocity.y = 0.0f;
                                }
                            }
                        }

                        velocity = new Vector2(velocity.x, velocity2.y);
                    } else if ((hit_normal.x > 0.5f) && (velocity_normal.x < 0.0f)) {
                        velocity = new Vector2(velocity_normal.x * (this._raycastHitArray[0].distance - 0.01f), velocity.y);

                        this._moveVelocity.x = 0.0f;

                        var velocity2 = new Vector2(0.0f, velocity.y);
                        var velocity_normal2 = new Vector2(0.0f, (velocity.y < 0.0f) ? -1.0f : ((velocity.y > 0.0f) ? 1.0f : 0.0f));
                        var distance2 = (velocity.y < 0.0f) ? -velocity.y : velocity.y;

                        if (distance2 > 0.0f) {
                            var hit_cnt2 = this._rigidbody.Cast(velocity_normal2, this._groundContactFilter, this._raycastHitArray, distance2 + 0.01f);

                            if (hit_cnt2 > 0) {
                                var hit_normal2 = this._raycastHitArray[0].normal;

                                if ((hit_normal2.y > 0.5f) && (velocity_normal2.y < 0.0f)) {
                                    velocity2 = velocity_normal2 * (this._raycastHitArray[0].distance - 0.01f);

                                    this._moveVelocity.y = 0.0f;
                                } else if ((hit_normal2.y < -0.5f) && (velocity_normal2.y > 0.0f)) {
                                    velocity2 = velocity_normal2 * (this._raycastHitArray[0].distance - 0.01f);

                                    this._moveVelocity.y = 0.0f;
                                }
                            }
                        }

                        velocity = new Vector2(velocity.x, velocity2.y);
                    }

                }

                this._rigidbody.position += velocity;
            }
        }

        this._UpdateGroundFlag();

        base._OnFixedUpdate();

        return;
    }


    /**
     * @brief _UpdateGroundFlag関数
     */
    private void _UpdateGroundFlag()
    {
        this._groundFlag = false;

        var hit_cnt = this._rigidbody.Cast(Vector2.down, this._groundContactFilter, this._raycastHitArray, 0.01f);

        if (hit_cnt > 0) {
            var hit_normal = this._raycastHitArray[0].normal;

            if (hit_normal.y > 0.5f) {
                this._groundFlag = true;

                this._rigidbody.position += Vector2.down * (this._raycastHitArray[0].distance - 0.01f);
            }
        }

        return;
    }

    /**
     * @brief _UpdatePositiont関数
     * @param move_velocity (move_velocity)
     * @param y_flg (y_flag)
     */
    /*
    private void _UpdatePosition(Vector2 move_velocity, bool y_flg)
    {
        var distance = move_velocity.magnitude;

        if (distance <= 0.0f) {
            return;
        }

        var hit_cnt = this._rigidbody.Cast(move_velocity.normalized, this._groundContactFilter, this._raycastHitArray, distance + 0.01f);

        for (var hit_i = 0; hit_i < hit_cnt; ++hit_i) {
            var hit_normal = this._raycastHitArray[hit_i].normal;

            if (hit_normal.y > 0.65f) {
                this._groundFlag = true;

                if (y_flg) {
                    this._groundNormal = hit_normal;

                    hit_normal.x = 0.0f;
                }
            }

            if (this._groundFlag) {
                var projection = Vector2.Dot(this._moveVelocity, hit_normal);

                if (projection < 0.0f) {
                    this._moveVelocity -= projection * hit_normal;
                }
            } else {
                this._moveVelocity.x = 0.0f;
                this._moveVelocity.y = Mathf.Min(this._moveVelocity.y, 0.0f);
            }

            var hit_distance = this._raycastHitArray[hit_i].distance - 0.01f;

            distance = (hit_distance < distance) ? hit_distance : distance;
        }

        this._rigidbody.position += move_velocity.normalized * distance;

        return;
    }
    */

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
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
}
}
}
