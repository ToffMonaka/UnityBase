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
    [SerializeField] private CharacterController _characterController;

    public new PlayerNodeScriptCreateDesc createDesc{get; private set;} = null;

    private Vector3 _moveVelocity = Vector3.zero;

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
        this._moveVelocity.x = this._moveInputAction.ReadValue<Vector2>().x;
        this._moveVelocity.y += Physics2D.gravity.y * Time.deltaTime;
        this._moveVelocity.z = this._moveInputAction.ReadValue<Vector2>().y;

        this._characterController.Move(this._moveVelocity);

        base._OnUpdate();

        return;
    }

    /**
     * @brief _OnFixedUpdate関数
     */
    protected override void _OnFixedUpdate()
    {
        base._OnFixedUpdate();

        return;
    }

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
