/**
 * @file
 * @brief SelectStageSelectScriptファイル
 */


using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief SelectStageSelectScriptCreateDescクラス
 */
public class SelectStageSelectScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.SelectSubSceneScript selectSubSceneScript = null;
}

/**
 * @brief SelectStageSelectScriptクラス
 */
public class SelectStageSelectScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private TextMeshProUGUI _nameText = null;
    [SerializeField] private GameObject _stageButtonNode = null;

    public new ToffMonaka.UnityBase.Scene.SelectStageSelectScriptCreateDesc createDesc{get; private set;} = null;
    private ToffMonaka.UnityBase.Scene.SelectSubSceneScript _selectSubSceneScript = null;
    private List<ToffMonaka.UnityBase.Scene.SelectStageButtonScript> _stageButtonScriptContainer = new List<ToffMonaka.UnityBase.Scene.SelectStageButtonScript>();
    private ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE _stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public SelectStageSelectScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_STAGE_SELECT);

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
        this._selectSubSceneScript = this.createDesc.selectSubSceneScript;
        this._nameText.SetText("ステージ");

        this._stageButtonNode.gameObject.SetActive(false);

        {// StageButton Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.SelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.SelectStageButtonScriptCreateDesc();

            script_create_desc.selectSubSceneScript = this._selectSubSceneScript;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_2D;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButton Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.SelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.SelectStageButtonScriptCreateDesc();

            script_create_desc.selectSubSceneScript = this._selectSubSceneScript;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_3D;

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
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.SelectStageSelectScriptCreateDesc;

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
     * @brief GetStageType関数
     * @return stage_type (stage_type)
     */
    public ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE GetStageIndex()
    {
        return (this._stageType);
    }

    /**
     * @brief SetStageType関数
     * @param stage_type (stage_type)
     */
    public void SetStageIndex(ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        return;
    }
}
}
