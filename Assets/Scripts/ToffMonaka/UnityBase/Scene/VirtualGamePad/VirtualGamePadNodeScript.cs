/**
 * @file
 * @brief VirtualGamePadNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ToffMonaka {
namespace UnityBase.Scene.VirtualGamePad {
/**
 * @brief VirtualGamePadNodeScriptCreateDescクラス
 */
public class VirtualGamePadNodeScriptCreateDesc : ToffMonaka.Tml.Scene.NodeScriptCreateDesc
{
}

/**
 * @brief VirtualGamePadNodeScriptクラス
 */
public class VirtualGamePadNodeScript : ToffMonaka.Tml.Scene.NodeScript
{
    [SerializeField] private GameObject _cameraCursorNode = null;

    public new VirtualGamePadNodeScriptCreateDesc createDesc{get; private set;} = null;

    private InputAction _cameraPointerInputAction = null;
    private InputAction _cameraCursorInputAction = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.VIRTUAL_GAME_PAD_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        this._cameraCursorNode.SetActive(false);

        this._cameraPointerInputAction = InputSystem.actions.FindAction("UI/CameraPointer");
        this._cameraPointerInputAction.Disable();

        this._cameraCursorInputAction = InputSystem.actions.FindAction("UI/CameraCursor");
        this._cameraCursorInputAction.Disable();

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
            this.SetCreateDesc(new VirtualGamePadNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as VirtualGamePadNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        if (this._cameraCursorInputAction.phase == InputActionPhase.Started) {
            this._cameraCursorNode.SetActive(true);
            this._cameraCursorNode.transform.position = new Vector3(this._cameraCursorInputAction.ReadValue<Vector2>().x, this._cameraCursorInputAction.ReadValue<Vector2>().y, 0.0f);
        } else {
            this._cameraCursorNode.SetActive(false);
        }

        base._OnUpdate();

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

    /**
     * @brief OnCameraCursorPointerDown関数
     * @param event_dat (event_data)
     */
    public void OnCameraCursorPointerDown(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (event_dat.button != PointerEventData.InputButton.Left) {
            return;
        }

        this._cameraPointerInputAction.Enable();
        this._cameraCursorInputAction.Enable();

        return;
    }

    /**
     * @brief OnCameraCursorPointerUp関数
     * @param event_dat (event_data)
     */
    public void OnCameraCursorPointerUp(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (event_dat.button != PointerEventData.InputButton.Left) {
            return;
        }

        this._cameraPointerInputAction.Disable();
        this._cameraCursorInputAction.Disable();

        return;
    }

    /**
     * @brief OnCameraCursorPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnCameraCursorPointerExit(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (event_dat.button != PointerEventData.InputButton.Left) {
            return;
        }

        this._cameraPointerInputAction.Disable();
        this._cameraCursorInputAction.Disable();

        return;
    }
}
}
}
