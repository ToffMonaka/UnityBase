/**
 * @file
 * @brief DynamicSubLayerScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief DynamicSubLayerScriptクラス
 */
public abstract class DynamicSubLayerScript : ToffMonaka.Lib.Scene.Script
{
    [SerializeField] private GameObject _coreNode = null;

    /**
     * @brief コンストラクタ
     */
    public DynamicSubLayerScript()
    {
        this._SetScriptType((int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.DYNAMIC_SUB_LAYER);

        return;
    }

    /**
     * @brief _OnAwake2関数
     */
    protected override void _OnAwake2()
    {
        this.SetActiveFlag(false);
        this._coreNode.SetActive(false);

        return;
    }

    /**
     * @brief _OnRelease2関数
     */
    protected override void _OnRelease2()
    {
        return;
    }

    /**
     * @brief _OnCreate2関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate2()
    {
        return (0);
    }

    /**
     * @brief _OnActive2関数
     */
    protected override void _OnActive2()
    {
        return;
    }

    /**
     * @brief _OnDeactive2関数
     */
    protected override void _OnDeactive2()
    {
        return;
    }

    /**
     * @brief _OnFirstUpdate2関数
     */
    protected override void _OnFirstUpdate2()
    {
        return;
    }

    /**
     * @brief _OnUpdate2関数
     */
    protected override void _OnUpdate2()
    {
        return;
    }

    /**
     * @brief Open関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Open()
    {
        int open_res = this._OnOpen();

        if (open_res < 0) {
            return (open_res);
        }

        this._coreNode.SetActive(true);

        return (0);
    }

    /**
     * @brief _OnOpen関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected virtual int _OnOpen()
    {
        return (0);
    }

    /**
     * @brief Close関数
     */
    public void Close()
    {
        this._OnClose();

        this._coreNode.SetActive(false);

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected virtual void _OnClose()
    {
        return;
    }

    /**
     * @brief GetCoreNode関数
     * @return core_node (core_node)
     */
    public GameObject GetCoreNode()
    {
        return (this._coreNode);
    }
}
}
