/**
 * @file
 * @brief InputManagerファイル
 */


using UnityEngine;
using UnityEngine.EventSystems;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief InputManagerCreateDescクラス
 */
public class InputManagerCreateDesc
{
    public GameObject inputNode = null;
}

/**
 * @brief InputManagerクラス
 */
public class InputManager
{
    public Lib.Scene.InputManagerCreateDesc createDesc{get; private set;} = null;

    private GameObject _inputNode = null;
    private EventSystem _eventSystem = null;

    /**
     * @brief コンストラクタ
     */
    public InputManager()
    {
        return;
    }

    /**
     * @brief _Release関数
     */
    private void _Release()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._Release();

        this._inputNode = null;
        this._eventSystem = null;

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public virtual int Create(Lib.Scene.InputManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            this._inputNode = desc.inputNode;

            this._eventSystem = EventSystem.current;
            this._eventSystem.enabled = false;
        }

        int create_result_val = this._OnCreate();

        if (create_result_val < 0) {
            this.Init();

            return (create_result_val);
        }

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected virtual int _OnCreate()
    {
        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public virtual void SetCreateDesc(Lib.Scene.InputManagerCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
    }

    /**
     * @brief GetInputNode関数
     * @return input_node (input_node)
     */
    public GameObject GetInputNode()
    {
        return (this._inputNode);
    }

    /**
     * @brief GetEventSystem関数
     * @return event_sys (event_system)
     */
    public EventSystem GetEventSystem()
    {
        return (this._eventSystem);
    }

    /**
     * @brief EnableEventSystem関数
     */
    public void EnableEventSystem()
    {
        this._eventSystem.enabled = true;

        return;
    }

    /**
     * @brief DisableEventSystem関数
     */
    public void DisableEventSystem()
    {
        this._eventSystem.enabled = false;

        return;
    }

    /**
     * @brief IsFocusNode関数
     * @param node (node)
     * @return focus_flg (focus_flg)<br>
     * false=フォーカス無し,true=フォーカス有り
     */
    public bool IsFocusNode(GameObject node)
    {
        return (this._eventSystem.currentSelectedGameObject == node);
    }
}
}
}
