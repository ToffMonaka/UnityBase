/**
 * @file
 * @brief MenuSelectStageSelectScriptファイル
 */


using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuSelectStageSelectScriptCreateDescクラス
 */
public class MenuSelectStageSelectScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuSelectScript selectScript = null;
}

/**
 * @brief MenuSelectStageSelectScriptクラス
 */
public class MenuSelectStageSelectScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private TextMeshProUGUI _nameText = null;
    [SerializeField] private GameObject _stageButtonNode = null;

    public new ToffMonaka.UnityBase.Scene.MenuSelectStageSelectScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuSelectScript _selectScript = null;
    private List<ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScript> _stageButtonScriptContainer = new List<ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScript>();

    /**
     * @brief コンストラクタ
     */
    public MenuSelectStageSelectScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_SELECT_STAGE_SELECT);

        return;
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        return;
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
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        this._nameText.SetText("メニュー");

        this._selectScript = this.createDesc.selectScript;

        this._stageButtonNode.gameObject.SetActive(false);

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.OPTION;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.FAQ;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.STAFF;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.LICENSE;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        // StageButtonScript Create
        if (ToffMonaka.UnityBase.Constant.Util.DEBUG_FLAG) {
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.CHEAT;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuSelectStageSelectScriptCreateDesc;

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
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        this._selectScript.RunStageButton(stage_type);

        return;
    }
}
}
