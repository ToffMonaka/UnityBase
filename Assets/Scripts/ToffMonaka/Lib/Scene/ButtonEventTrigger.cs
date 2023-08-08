﻿/**
 * @file
 * @brief ButtonEventTriggerファイル
 */


using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief ButtonEventTriggerクラス
 */
public class ButtonEventTrigger : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [System.Serializable] public class PointerEvent : UnityEvent<PointerEventData> {}

    [SerializeField] private PointerEvent _pointerClickEvent = new PointerEvent();
    [SerializeField] private PointerEvent _pointerEnterEvent = new PointerEvent();
    [SerializeField] private PointerEvent _pointerExitEvent = new PointerEvent();

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
