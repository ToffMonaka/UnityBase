/**
 * @file
 * @brief ButtonPartsScriptファイル
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace ToffMonaka {
namespace Tml.Scene {
/**
 * @brief ButtonPartsScriptCreateDescクラス
 */
public class ButtonPartsScriptCreateDesc : PartsScriptCreateDesc
{
}

/**
 * @brief ButtonPartsScriptクラス
 */
public class ButtonPartsScript : PartsScript, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [System.Serializable] public class PointerEvent : UnityEvent<PointerEventData> {}

    [SerializeField] private Image _coverImage = null;
    [SerializeField] private PointerEvent _pointerDownEvent = new();
    [SerializeField] private PointerEvent _pointerUpEvent = new();
    [SerializeField] private PointerEvent _pointerClickEvent = new();
    [SerializeField] private PointerEvent _pointerEnterEvent = new();
    [SerializeField] private PointerEvent _pointerExitEvent = new();

    public new ButtonPartsScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.BUTTON_PARTS);
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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new ButtonPartsScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as ButtonPartsScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        if (this._coverImage != null) {
            this._coverImage.gameObject.SetActive(false);
        }

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        base._OnDeactive();

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

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

        this._pointerDownEvent.Invoke(event_dat);

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

        this._pointerUpEvent.Invoke(event_dat);

        return;
    }

    /**
     * @brief OnPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._pointerClickEvent.Invoke(event_dat);

        return;
    }

    /**
     * @brief OnPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnPointerEnter(PointerEventData event_dat)
    {
        if (this._coverImage != null) {
            this._coverImage.gameObject.SetActive(true);
        }

        this._pointerEnterEvent.Invoke(event_dat);

        return;
    }

    /**
     * @brief OnPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnPointerExit(PointerEventData event_dat)
    {
        if (this._coverImage != null) {
            this._coverImage.gameObject.SetActive(false);
        }

        this._pointerExitEvent.Invoke(event_dat);

        return;
    }
}
}
}
