/**
 * @file
 * @brief InputManagerファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
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
    public ToffMonaka.Lib.Scene.InputManagerCreateDesc createDesc{get; private set;} = null;

    private GameObject _inputNode = null;

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

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public virtual int Create(ToffMonaka.Lib.Scene.InputManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            this._inputNode = desc.inputNode;
        }

        int create_res = this._OnCreate();

        if (create_res < 0) {
            this.Init();

            return (create_res);
        }

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
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
    public virtual void SetCreateDesc(ToffMonaka.Lib.Scene.InputManagerCreateDesc create_desc)
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
}
}
