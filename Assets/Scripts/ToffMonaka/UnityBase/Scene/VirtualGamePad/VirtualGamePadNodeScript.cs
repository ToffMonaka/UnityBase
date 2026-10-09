/**
 * @file
 * @brief VirtualGamePadNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

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

    private bool _cameraCursorFlag = false;
    private int _cameraCursorTouchId = 0;

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

        this._cameraCursorNode.SetActive(false);

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
        if (this._cameraCursorFlag) {
            this._cameraCursorNode.SetActive(true);

            var touch_pos = Vector2.zero;

            if (EnhancedTouch.Touch.activeTouches.Count > 0) {
                foreach (var touch in EnhancedTouch.Touch.activeTouches) {
                    if (touch.touchId != this._cameraCursorTouchId) {
                        continue;
                    }

                    touch_pos = touch.screenPosition;

                    break;
                }
            } else {
                touch_pos = Mouse.current.position.ReadValue();
            }

            this._cameraCursorNode.transform.position = touch_pos;
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

        var extended_event_dat = event_dat as ExtendedPointerEventData;

        if (extended_event_dat.button != ExtendedPointerEventData.InputButton.Left) {
            return;
        }

        this._cameraCursorFlag = true;
        this._cameraCursorTouchId = extended_event_dat.touchId;

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

        var extended_event_dat = event_dat as ExtendedPointerEventData;

        if (extended_event_dat.button != ExtendedPointerEventData.InputButton.Left) {
            return;
        }

        this._cameraCursorFlag = false;
        this._cameraCursorTouchId = 0;

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

        var extended_event_dat = event_dat as ExtendedPointerEventData;

        if (extended_event_dat.button != ExtendedPointerEventData.InputButton.Left) {
            return;
        }

        this._cameraCursorFlag = false;
        this._cameraCursorTouchId = 0;

        return;
    }

    /**
     * @brief GetCameraCursorFlag関数
     * @return camera_cursor_flg (camera_cursor_flag)
     */
    public bool GetCameraCursorFlag()
    {
        return (this._cameraCursorFlag);
    }

    /**
     * @brief GetCameraCursorTouchId関数
     * @return camera_cursor_touch_id (camera_cursor_touch_id)
     */
    public int GetCameraCursorTouchId()
    {
        return (this._cameraCursorTouchId);
    }
}
}
}
