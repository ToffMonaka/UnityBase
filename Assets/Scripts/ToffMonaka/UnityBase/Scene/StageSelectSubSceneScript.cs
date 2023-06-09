/**
 * @file
 * @brief StageSelectSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief StageSelectSubSceneScriptCreateDescクラス
 */
public class StageSelectSubSceneScriptCreateDesc : ToffMonaka.UnityBase.Scene.SelectSubSceneScriptCreateDesc
{
}

/**
 * @brief StageSelectSubSceneScriptクラス
 */
public class StageSelectSubSceneScript : ToffMonaka.UnityBase.Scene.SelectSubSceneScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private GameObject _stageButtonNode = null;
    [SerializeField] private GameObject _menuNode = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new ToffMonaka.UnityBase.Scene.StageSelectSubSceneScriptCreateDesc createDesc{get; private set;} = null;

    private List<ToffMonaka.UnityBase.Scene.StageSelectStageButtonScript> _stageButtonScriptContainer = new List<ToffMonaka.UnityBase.Scene.StageSelectStageButtonScript>();
    private ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE _stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;
    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;
    private Sequence _openCloseSequence = null;

    /**
     * @brief コンストラクタ
     */
    public StageSelectSubSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.STAGE_SELECT_SUB_SCENE);
        this._SetSelectType(ToffMonaka.UnityBase.Constant.Util.SCENE.SELECT_TYPE.STAGE);

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
        var canvas_node = this.transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.GetManager().GetMainSceneScript().GetMainCamera();

        this._nameText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.SELECT_NAME_ARRAY[(int)this.GetSelectType()]);

        this._stageButtonNode.SetActive(false);

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.StageSelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.StageSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_2D;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.StageSelectStageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.StageSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_3D;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// MenuScript Create
            var script = this._menuNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._menuScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.StageSelectSubSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlayBgm((int)ToffMonaka.UnityBase.Constant.Util.SOUND.BGM_INDEX.SELECT);

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
		switch (this.GetOpenType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 255);

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.AppendInterval(0.05f);
            this._openCloseSequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));
            this._openCloseSequence.SetLink(this.gameObject);

			break;
		}
		default: {
            this._openCloseFadeImage.gameObject.SetActive(false);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
		switch (this.GetOpenType()) {
		case 1: {
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteOpen();

                this._openCloseFadeImage.gameObject.SetActive(false);
            }

			break;
		}
		default: {
            this.CompleteOpen();

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
		switch (this.GetCloseType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 0);

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
            this._openCloseSequence.AppendInterval(0.05f);
            this._openCloseSequence.SetLink(this.gameObject);

			break;
		}
		default: {
            this._openCloseFadeImage.gameObject.SetActive(false);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
		switch (this.GetCloseType()) {
		case 1: {
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteClose();

                // Test2DStageSubSceneScript Create
                if (this._stageType == ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_2D) {
                    var script = this.GetManager().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_2D_STAGE_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.Test2DStageSubSceneScript;
                    var script_create_desc = new ToffMonaka.UnityBase.Scene.Test2DStageSubSceneScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }

                // Test3DStageSubSceneScript Create
                if (this._stageType == ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_3D) {
                    var script = this.GetManager().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_3D_STAGE_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.Test3DStageSubSceneScript;
                    var script_create_desc = new ToffMonaka.UnityBase.Scene.Test3DStageSubSceneScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }
            }

			break;
		}
		default: {
            this.CompleteClose();

			break;
		}
		}

        return;
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        this.Close(1);

        return;
    }
}
}
