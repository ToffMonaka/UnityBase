/**
 * @file
 * @brief SelectSubSceneStageSelectScriptファイル
 */


using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief SelectSubSceneStageSelectScriptCreateDescクラス
 */
public class SelectSubSceneStageSelectScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.SelectSubSceneScript selectSubSceneScript = null;
}

/**
 * @brief SelectSubSceneStageSelectScriptクラス
 */
public class SelectSubSceneStageSelectScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private TextMeshProUGUI _nameText = null;
    [SerializeField] private GameObject _stageButtonNode = null;

    public new ToffMonaka.UnityBase.Scene.SelectSubSceneStageSelectScriptCreateDesc createDesc{get; private set;} = null;
    private ToffMonaka.UnityBase.Scene.SelectSubSceneScript _selectSubSceneScript = null;
    private List<ToffMonaka.UnityBase.Scene.SelectSubSceneStageButtonScript> _stageButtonScriptContainer = new List<ToffMonaka.UnityBase.Scene.SelectSubSceneStageButtonScript>();
    private int _stageIndex = 0;

    /**
     * @brief コンストラクタ
     */
    public SelectSubSceneStageSelectScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_SUB_SCENE_STAGE_SELECT);

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
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.SelectSubSceneStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.SelectSubSceneStageButtonScriptCreateDesc();

            script_create_desc.selectSubSceneScript = this._selectSubSceneScript;
            script_create_desc.index = 0;
            script_create_desc.name = "Test2D";

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButton Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.SelectSubSceneStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.SelectSubSceneStageButtonScriptCreateDesc();

            script_create_desc.selectSubSceneScript = this._selectSubSceneScript;
            script_create_desc.index = 1;
            script_create_desc.name = "Test3D";

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
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.SelectSubSceneStageSelectScriptCreateDesc;

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
     * @brief GetStageIndex関数
     * @return stage_index (stage_index)
     */
    public int GetStageIndex()
    {
        return (this._stageIndex);
    }

    /**
     * @brief SetStageIndex関数
     * @param stage_index (stage_index)
     */
    public void SetStageIndex(int stage_index)
    {
        this._stageIndex = stage_index;

        return;
    }
}
}
