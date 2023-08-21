﻿/**
 * @file
 * @brief SubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Stage.Test2D {
/**
 * @brief SubSceneScriptCreateDescクラス
 */
public class SubSceneScriptCreateDesc : UnityBase.Scene.Stage.SubSceneScriptCreateDesc
{
}

/**
 * @brief SubSceneScriptクラス
 */
public class SubSceneScript : UnityBase.Scene.Stage.SubSceneScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_Text _messageText = null;
    [SerializeField] private GameObject _backButtonNode = null;
    [SerializeField] private GameObject _menuNode = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new UnityBase.Scene.Stage.Test2D.SubSceneScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Stage.Test2D.BackButtonScript _backButtonScript = null;
    private UnityBase.Scene.MenuScript _menuScript = null;

    /**
     * @brief コンストラクタ
     */
    public SubSceneScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.TEST_2D_STAGE_SUB_SCENE);
        this._SetStageType(UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_2D);

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

        this._nameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.SCENE.STAGE_NAME_MST_STRING_ID_ARRAY[(int)this.GetStageType()]));
        this._messageText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.MST_STRING_ID.IN_PREPARATION));

        {// BackButtonScript Create
            var script = this._backButtonNode.GetComponent<UnityBase.Scene.Stage.Test2D.BackButtonScript>();
            var script_create_desc = new UnityBase.Scene.Stage.Test2D.BackButtonScriptCreateDesc();

            script_create_desc.subSceneScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._backButtonScript = script;
        }

        {// MenuScript Create
            var script = this._menuNode.GetComponent<UnityBase.Scene.MenuScript>();
            var script_create_desc = new UnityBase.Scene.MenuScriptCreateDesc();

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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Stage.Test2D.SubSceneScriptCreateDesc;

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
		switch (this.GetOpenType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 255);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.AppendInterval(0.05f);
            open_close_sequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

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
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteOpen();

            this._openCloseFadeImage.gameObject.SetActive(false);
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

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
            open_close_sequence.AppendInterval(0.05f);
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

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
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteClose();

		    switch (this.GetClosedType()) {
            case 1: {
                {// SelectSubSceneScript Create
                    var script = this.GetManager().ChangeSubScene(UnityBase.Constant.Util.FILE_PATH.SELECT_SUB_SCENE_PREFAB) as UnityBase.Scene.Select.SubSceneScript;
                    var script_create_desc = new UnityBase.Scene.Select.SubSceneScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }

			    break;
		    }
		    }
        }

        return;
    }

    /**
     * @brief RunBackButton関数
     */
    public void RunBackButton()
    {
        this.Close(1, 1);

        return;
    }
}
}
}
