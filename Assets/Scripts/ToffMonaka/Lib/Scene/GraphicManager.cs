﻿/**
 * @file
 * @brief GraphicManagerファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief GraphicManagerCreateDescクラス
 */
public class GraphicManagerCreateDesc
{
    public GameObject graphicNode = null;
}

/**
 * @brief GraphicManagerクラス
 */
public class GraphicManager
{
    public ToffMonaka.Lib.Scene.GraphicManagerCreateDesc createDesc{get; private set;} = null;

    private GameObject _graphicNode = null;

    /**
     * @brief コンストラクタ
     */
    public GraphicManager()
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

        this._graphicNode = null;

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public virtual int Create(ToffMonaka.Lib.Scene.GraphicManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            this._graphicNode= desc.graphicNode;
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
    public virtual void SetCreateDesc(ToffMonaka.Lib.Scene.GraphicManagerCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
    }

    /**
     * @brief GetGraphicNode関数
     * @return graphic_node (graphic_node)
     */
    public GameObject GetGraphicNode()
    {
        return (this._graphicNode);
    }
}
}
