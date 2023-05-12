﻿/**
 * @file
 * @brief SubSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief SubSceneScriptCreateDescクラス
 */
public class SubSceneScriptCreateDesc : ToffMonaka.Lib.Scene.ScriptCreateDesc
{
}

/**
 * @brief SubScenScripteクラス
 */
public abstract class SubSceneScript : ToffMonaka.Lib.Scene.Script
{
    [SerializeField] private GameObject _coreNode = null;

    public new ToffMonaka.Lib.Scene.SubSceneScriptCreateDesc createDesc{get; private set;} = null;
    private int _openType = 0;
    private bool _openFlag = false;
    private bool _openedFlag = false;
    private int _closeType = 0;
    private bool _closeFlag = false;
    private bool _closedFlag = true;

    /**
     * @brief コンストラクタ
     */
    public SubSceneScript()
    {
        this._SetScriptType((int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SUB_SCENE);

        return;
    }

    /**
     * @brief _OnAwake2関数
     */
    protected override void _OnAwake2()
    {
        this.gameObject.SetActive(false);
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
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.Lib.Scene.SubSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
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
        if (this._openFlag) {
            this._OnUpdateOpen();
        }

        if (this._closeFlag) {
            this._OnUpdateClose();
        }

        return;
    }

    /**
     * @brief _OnFixedUpdate2関数
     */
    protected override void _OnFixedUpdate2()
    {
        return;
    }

    /**
     * @brief _OnLateUpdate2関数
     */
    protected override void _OnLateUpdate2()
    {
        return;
    }

    /**
     * @brief Open関数
     * @param open_type (open_type)
     */
    public void Open(int open_type)
    {
        this._coreNode.SetActive(true);

        this._openType = open_type;
        this._openFlag = true;
        this._openedFlag = false;
        this._closeFlag = false;
        this._closedFlag = true;

        this._OnOpen();

        return;
    }

    /**
     * @brief CompleteOpen関数
     */
    protected void CompleteOpen()
    {
        if (!this._openFlag) {
            return;
        }

        this._openFlag = false;
        this._openedFlag = true;

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected virtual void _OnOpen()
    {
        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected virtual void _OnUpdateOpen()
    {
        return;
    }

    /**
     * @brief Close関数
     * @param close_type (close_type)
     */
    public void Close(int close_type)
    {
        this._closeType = close_type;
        this._openFlag = false;
        this._openedFlag = true;
        this._closeFlag = true;
        this._closedFlag = false;

        this._OnClose();

        return;
    }

    /**
     * @brief CompleteClose関数
     */
    protected void CompleteClose()
    {
        if (!this._closeFlag) {
            return;
        }

        this._closeFlag = false;
        this._closedFlag = true;

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
     * @brief _OnUpdateClose関数
     */
    protected virtual void _OnUpdateClose()
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

    /**
     * @brief GetOpenType関数
     * @return open_type (open_type)
     */
    public int GetOpenType()
    {
        return (this._openType);
    }

    /**
     * @brief GetOpenFlag関数
     * @return open_flg (open_flag)
     */
    public bool GetOpenFlag()
    {
        return (this._openFlag);
    }

    /**
     * @brief GetOpenedFlag関数
     * @return opened_flg (opened_flag)
     */
    public bool GetOpenedFlag()
    {
        return (this._openedFlag);
    }

    /**
     * @brief GetCloseType関数
     * @return close_type (close_type)
     */
    public int GetCloseType()
    {
        return (this._closeType);
    }

    /**
     * @brief GetCloseFlag関数
     * @return close_flg (close_flag)
     */
    public bool GetCloseFlag()
    {
        return (this._closeFlag);
    }

    /**
     * @brief GetClosedFlag関数
     * @return closed_flg (closed_flag)
     */
    public bool GetClosedFlag()
    {
        return (this._closedFlag);
    }
}
}
