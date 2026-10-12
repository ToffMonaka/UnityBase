/**
 * @file
 * @brief SceneManagerファイル
 */

using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief SceneManagerCreateDescクラス
 */
public class SceneManagerCreateDesc : ToffMonaka.Tml.Scene.SceneManagerCreateDesc
{
}

/**
 * @brief SceneManagerクラス
 */
public class SceneManager : ToffMonaka.Tml.Scene.SceneManager
{
    public new SceneManagerCreateDesc createDesc{get; private set;} = null;

    private bool _enhancedTouchSupportEnableFlag = false;
    private InputAction _moveInputAction = null;
    private InputAction _jumpInputAction = null;
    private InputAction _cameraInputAction = null;

    /**
     * @brief コンストラクタ
     */
    public SceneManager()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        if (this._moveInputAction != null) {
            this._moveInputAction.Disable();

            this._moveInputAction  = null;
        }

        if (this._jumpInputAction != null) {
            this._jumpInputAction.Disable();

            this._jumpInputAction  = null;
        }

        if (this._cameraInputAction != null) {
            this._cameraInputAction.Disable();

            this._cameraInputAction  = null;
        }

        if (this._enhancedTouchSupportEnableFlag) {
            EnhancedTouchSupport.Disable();

            this._enhancedTouchSupportEnableFlag = false;
        }

        base.Init();

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

        EnhancedTouchSupport.Enable();

        this._enhancedTouchSupportEnableFlag = true;

        this._moveInputAction = InputSystem.actions.FindAction("Player/Move");
        this._moveInputAction.Enable();

        this._jumpInputAction = InputSystem.actions.FindAction("Player/Jump");
        this._jumpInputAction.Enable();

        this._cameraInputAction = InputSystem.actions.FindAction("Player/Camera");
        this._cameraInputAction.Enable();

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.SceneManagerCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SceneManagerCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SceneManagerCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief GetMainSceneNodeScript関数
     * @return main_scene_node_script (main_scene_node_script)
     */
    public new MainSceneNodeScript GetMainSceneNodeScript()
    {
        return (base.GetMainSceneNodeScript() as MainSceneNodeScript);
    }

    /**
     * @brief GetSubSceneNodeScript関数
     * @return sub_scene_node_script (sub_scene_node_script)
     */
    public new SubSceneNodeScript GetSubSceneNodeScript()
    {
        return (base.GetSubSceneNodeScript() as SubSceneNodeScript);
    }

    /**
     * @brief GetMoveInputAction関数
     * @return move_input_act (move_input_action)
     */
    public InputAction GetMoveInputAction()
    {
        return (this._moveInputAction);
    }

    /**
     * @brief GetJumpInputAction関数
     * @return jump_input_act (jump_input_action)
     */
    public InputAction GetJumpInputAction()
    {
        return (this._jumpInputAction);
    }

    /**
     * @brief GetCameraInputAction関数
     * @return camera_input_act (camera_input_action)
     */
    public InputAction GetCameraInputAction()
    {
        return (this._cameraInputAction);
    }
}
}
}
