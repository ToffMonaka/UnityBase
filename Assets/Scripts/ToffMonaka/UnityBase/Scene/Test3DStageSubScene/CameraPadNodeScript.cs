/**
 * @file
 * @brief CameraPadNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ToffMonaka {
namespace UnityBase.Scene.Test3DStageSubScene {
/**
 * @brief CameraPadNodeScriptCreateDescクラス
 */
public class CameraPadNodeScriptCreateDesc : ToffMonaka.Tml.Scene.NodeScriptCreateDesc
{
}

/**
 * @brief CameraPadNodeScriptクラス
 */
public class CameraPadNodeScript : ToffMonaka.Tml.Scene.NodeScript
{
    [SerializeField] private GameObject _cursorNode = null;

    public new CameraPadNodeScriptCreateDesc createDesc{get; private set;} = null;

    private InputAction _lookInputAction = null;
    private InputAction _lookPositionInputAction = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.TEST_3D_STAGE_CAMEARA_PAD_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        this._cursorNode.SetActive(false);

        this._lookInputAction = InputSystem.actions.FindAction("Player/Look");
        this._lookInputAction.Disable();

        this._lookPositionInputAction = InputSystem.actions.FindAction("Player/LookPosition");
        this._lookPositionInputAction.Disable();

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
            this.SetCreateDesc(new CameraPadNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as CameraPadNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        if ((this._lookPositionInputAction.phase == InputActionPhase.Started)
        || (this._lookPositionInputAction.phase == InputActionPhase.Performed)) {
            this._cursorNode.SetActive(true);
            this._cursorNode.transform.position = new Vector3(this._lookPositionInputAction.ReadValue<Vector2>().x, this._lookPositionInputAction.ReadValue<Vector2>().y, 0.0f);
        } else {
            this._cursorNode.SetActive(false);
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
     * @brief OnPointerDown関数
     * @param event_dat (event_data)
     */
    public void OnPointerDown(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (event_dat.button != PointerEventData.InputButton.Left) {
            return;
        }

        this._lookInputAction.Enable();
        this._lookPositionInputAction.Enable();

        return;
    }

    /**
     * @brief OnPointerUp関数
     * @param event_dat (event_data)
     */
    public void OnPointerUp(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (event_dat.button != PointerEventData.InputButton.Left) {
            return;
        }

        this._lookInputAction.Disable();
        this._lookPositionInputAction.Disable();

        return;
    }

    /**
     * @brief OnPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnPointerExit(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (event_dat.button != PointerEventData.InputButton.Left) {
            return;
        }

        this._lookInputAction.Disable();
        this._lookPositionInputAction.Disable();

        return;
    }
}
}
}
