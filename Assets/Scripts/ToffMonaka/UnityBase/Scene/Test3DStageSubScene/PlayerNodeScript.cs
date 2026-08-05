/**
 * @file
 * @brief PlayerNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.InputSystem;

namespace ToffMonaka {
namespace UnityBase.Scene.Test3DStageSubScene {
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
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private float _skinWidth = 0.015f;
    [SerializeField] private float _moveSpeed = 3.0f;
    [SerializeField] private float _moveIterationCount = 3;
    [SerializeField] private float _jumpPower = 6.5f;
    [SerializeField] private float _jumpDeceleratePower = 0.5f;
    [SerializeField] private float _fallLimit = -10.0f;

    public new PlayerNodeScriptCreateDesc createDesc{get; private set;} = null;

    private Bounds _bounds;
    private bool _movePositionFlag = false;
    private Vector3 _movePosition = Vector3.zero;
    private Vector3 _moveVelocity = Vector3.zero;
    private bool _jumpFlag = false;
    private bool _jumpDecelerateFlag = false;
    private bool _groundFlag = false;
    private Vector3 _groundPosition = Vector3.zero;
    private int _groundPositionIntervalCount = 0;

    private InputAction _moveInputAction = null;
    private InputAction _jumpInputAction = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.TEST_3D_STAGE_PLAYER_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        this._bounds = this._collider.bounds;
        this._bounds.Expand(-2.0f * this._skinWidth);

        this._groundPosition = this._rigidbody.position;
        this._groundPositionIntervalCount = 0;

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
        this.RunMoveAction(this._moveInputAction.ReadValue<Vector2>().x, this._moveInputAction.ReadValue<Vector2>().y);

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
            this._rigidbody.position = this._movePosition;

            this._movePositionFlag = false;
        }

        if (!this._groundFlag) {
            this._moveVelocity.y += Physics2D.gravity.y * Time.deltaTime;
        }

        this._UpdateRigidbodyPosition(this._moveVelocity * Time.deltaTime, 0, (this._groundFlag) && (this._moveVelocity.y == 0.0f));

        this._UpdateGroundFlag();

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
     * @brief _UpdateRigidbodyPosition関数
     * @param vel (velocity)
     * @param cnt (count)
     * @param slide_flg (slide_flag)
     */
    private void _UpdateRigidbodyPosition(Vector3 vel, int cnt, bool slide_flg)
    {
	    if (cnt >= this._moveIterationCount) {
		    return;
	    }

        if (slide_flg) {
            var vel_normal = vel.normalized;
            var vel_dist = vel.magnitude;

            if (vel_dist > 0.0f) {
                var top_pos = this._rigidbody.position + (Vector3.down * (this._collider.height * 0.5f - this._collider.radius));
                var bottom_pos = this._rigidbody.position + (Vector3.up * (this._collider.height * 0.5f - this._collider.radius));

        	    if (Physics.CapsuleCast(bottom_pos, top_pos, this._bounds.extents.x, vel_normal, out RaycastHit hit, vel_dist + this._skinWidth, LayerMask.GetMask("Ground"))) {
                    var hit_normal = this._GetHitNormalForSurface(hit);
                    var hit_dist = hit.distance;

                    var hit_vel = vel_normal * (hit_dist - this._skinWidth);

		            if (hit_vel.magnitude <= this._skinWidth) {
			            hit_vel = Vector3.zero;
		            }

                    if ((hit_normal.y > 0.5f) || ((hit_normal.y < -0.5f))) {
                        this._rigidbody.position += hit_vel;

                        this._UpdateRigidbodyPosition(this._GetProjectVelocityOnPlane(vel - hit_vel, hit.normal), cnt + 1, slide_flg);
                    } else {
                        this._rigidbody.position += hit_vel;

                        this._UpdateRigidbodyPosition(this._GetProjectVelocityOnPlane(vel - hit_vel, hit.normal), cnt + 1, slide_flg);
                    }
                } else {
                    this._rigidbody.position += vel;
                }
            }
        } else {
            var vel_normal = vel.normalized;
            var vel_dist = vel.magnitude;

            if (vel_dist > 0.0f) {
                var top_pos = this._rigidbody.position + (Vector3.down * (this._collider.height * 0.5f - this._collider.radius));
                var bottom_pos = this._rigidbody.position + (Vector3.up * (this._collider.height * 0.5f - this._collider.radius));

        	    if (Physics.CapsuleCast(bottom_pos, top_pos, this._bounds.extents.x, vel_normal, out RaycastHit hit, vel_dist + this._skinWidth, LayerMask.GetMask("Ground"))) {
                    var hit_normal = this._GetHitNormalForSurface(hit);
                    var hit_dist = hit.distance;

                    var hit_vel = vel_normal * (hit_dist - this._skinWidth);

		            if (hit_vel.magnitude <= this._skinWidth) {
			            hit_vel = Vector3.zero;
		            }

                    if ((hit_normal.y > 0.5f) || ((hit_normal.y < -0.5f))) {
                        this._rigidbody.position += hit_vel;

                        this._moveVelocity = Vector3.zero;
                    } else {
                        this._rigidbody.position += hit_vel;

                        this._UpdateRigidbodyPosition(this._GetProjectVelocityOnPlane(vel - hit_vel, hit.normal), cnt + 1, slide_flg);
                    }
                } else {
                    this._rigidbody.position += vel;
                }
            }
        }

        return;
    }

    /**
     * @brief _GetHitNormalForSurface関数
     * @param hit (hit)
     * @return hit_normal (hit_normal)
     */
    private Vector3 _GetHitNormalForSurface(RaycastHit hit)
    {
        if (hit.collider is MeshCollider) {
            var collider = hit.collider as MeshCollider;
            var mesh = collider.sharedMesh;
            var tris = mesh.triangles;
            var verts = mesh.vertices;

            var v0 = verts[tris[hit.triangleIndex * 3]];
            var v1 = verts[tris[hit.triangleIndex * 3 + 1]];
            var v2 = verts[tris[hit.triangleIndex * 3 + 2]];

            var n = Vector3.Cross(v1 - v0, v2 - v1).normalized;

            return (hit.transform.TransformDirection(n));
        }
        
        var p = hit.point + hit.normal * 0.01f;

        var hit2_flg = Physics.Raycast(p, -hit.normal, out RaycastHit hit2, 0.011f, LayerMask.GetMask("Ground"));

        if (!hit2_flg) {
            return (hit.normal);
        }

        return (hit2.normal);
    }

    /**
     * @brief _GetProjectVelocityOnPlane関数
     * @param vec (vector)
     * @param plane_normal (plane_normal)
     * @param proj_vel (project_velocity)
     */
    private Vector3 _GetProjectVelocityOnPlane(Vector3 vec, Vector3 plane_normal)
    {
        return ((Vector3.ProjectOnPlane(vec, plane_normal).normalized) * vec.magnitude);
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

        var top_pos = this._rigidbody.position + (Vector3.down * (this._collider.height * 0.5f - this._collider.radius));
        var bottom_pos = this._rigidbody.position + (Vector3.up * (this._collider.height * 0.5f - this._collider.radius));

        if (Physics.CapsuleCast(bottom_pos, top_pos, this._bounds.extents.x, Vector3.down, out RaycastHit hit, 0.01f + this._skinWidth, LayerMask.GetMask("Ground"))) {
            var hit_normal = this._GetHitNormalForSurface(hit);

            if (hit_normal.y > 0.5f) {
                this._groundFlag = true;
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
    public void RunSpawnAction(Vector3 pos)
    {
        this._movePositionFlag = true;
        this._movePosition = pos;
        this._moveVelocity = Vector3.zero;

        this._jumpFlag = false;
        this._jumpDecelerateFlag = false;

        this._groundFlag = false;

        return;
    }

    /**
     * @brief RunMoveAction関数
     * @param x (x)
     * @param z (z)
     */
    public void RunMoveAction(float x, float z)
    {
        this._moveVelocity.x = x * this._moveSpeed;
        this._moveVelocity.z = z * this._moveSpeed;

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

    /*
    int maxBounces = 5;
    float skinWidth = 0.015f;
    float maxSlopeAngle = 55;

    private Vector3 CollideAndSlide(Vector3 vel, Vector3 pos, int depth, bool gravityPass, Vector3 velInit)
    {
        Bounds bounds;

        bounds = collider.bounds;
        bounds.Expand(-2 * skinWidth);

	    if (depth >= maxBounces) {
		    return (Vector3.zero);
	    }

	    float dist = vel.magnitude + skinWidth;

	    RaycastHit hit;

	    if (Physics.SphereCast(pos, bounds.extents.x, vel.normalized, out hit, dist, layerMask)) {
		    Vector3 snapToSurface = vel.normalized * (hit.distance - skinWidth);
		    Vector3 leftover = vel - snapToSurface;
		    float angle = Vector3.Angle(Vector3.up, hit.normal);

		    if (snapToSurface.magnitude <= skinWidth) {
			    snapToSurface = Vector3.zero;
		    }

		    if (angle <= maxSlopeAngle) {
			    if (gravityPass) {
				    return (snapToSurface);
			    }

			    leftover = ProjectAndScale(leftover, hit.normal);
		    } else {
			    float scale = 1 - Vector3.Dot(new Vector3(hit.normal.x, 0, hit.normal.z).normalized, -new Vector3(velInit.x, 0, velInit.z).normalized);

		        if ((isGrounded) && (!gravityPass)) {
			        leftover = ProjectAndScale(new Vector3(leftover.x, 0, leftover.z), new Vector3(hit.normal.x, 0, hit.normal.z)).normalized;

			        leftover *= scale;
		        } else {
			        leftover = ProjectAndScale(leftover, hit.normal) * scale;
		        }
		    }

		    return (snapToSurface + CollideAndSlide(leftover, pos + snapToSurface, depth + 1, gravityPass, velInit));
	    }

	    return (vel);
    }

    private Vector3 ProjectAndScale(Vector3 vec, Vector3 normal)
    {
	    float mag = vec.mag;

	    vec = Vector3.ProjectOnPlane(vec, normal).normalized;
	    vec *= mag;

        return (vec);
    }
    */
}
}
}
