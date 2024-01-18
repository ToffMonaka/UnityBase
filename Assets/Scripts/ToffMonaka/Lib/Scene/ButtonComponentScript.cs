/**
 * @file
 * @brief ButtonComponentScriptファイル
 */


using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief ButtonComponentScriptCreateDescクラス
 */
public class ButtonComponentScriptCreateDesc : Lib.Scene.ComponentScriptCreateDesc
{
}

/**
 * @brief ButtonComponentScriptクラス
 */
public class ButtonComponentScript : Lib.Scene.ComponentScript, IPointerDownHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [System.Serializable] public class PointerEvent : UnityEvent<PointerEventData> {}

    [SerializeField] private PointerEvent _pointerDownEvent = new PointerEvent();
    [SerializeField] private PointerEvent _pointerClickEvent = new PointerEvent();
    [SerializeField] private PointerEvent _pointerEnterEvent = new PointerEvent();
    [SerializeField] private PointerEvent _pointerExitEvent = new PointerEvent();

    public new Lib.Scene.ButtonComponentScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public ButtonComponentScript()
    {
        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.BUTTON_COMPONENT);
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.ButtonComponentScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        return;
    }

    /**
     * @brief OnPointerDown関数
     * @param event_dat (event_data)
     */
    public void OnPointerDown(PointerEventData event_dat)
    {
        this._pointerDownEvent.Invoke(event_dat);

        return;
    }

    /**
     * @brief OnPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnPointerClick(PointerEventData event_dat)
    {
        this._pointerClickEvent.Invoke(event_dat);

        return;
    }

    /**
     * @brief OnPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnPointerEnter(PointerEventData event_dat)
    {
        this._pointerEnterEvent.Invoke(event_dat);

        return;
    }

    /**
     * @brief OnPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnPointerExit(PointerEventData event_dat)
    {
        this._pointerExitEvent.Invoke(event_dat);

        return;
    }
}
}
}
