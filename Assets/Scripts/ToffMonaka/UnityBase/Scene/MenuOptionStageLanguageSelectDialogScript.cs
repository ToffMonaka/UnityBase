/**
 * @file
 * @brief MenuOptionStageLanguageSelectDialogScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuOptionStageLanguageSelectDialogScriptCreateDescクラス
 */
public class MenuOptionStageLanguageSelectDialogScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuOptionStageScript parentScript = null;
}

/**
 * @brief MenuOptionStageLanguageSelectDialogScriptクラス
 */
public class MenuOptionStageLanguageSelectDialogScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private CanvasGroup _canvasGroup = null;
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private GameObject _languageButtonNode = null;
    [SerializeField] private Image _closeButtonCoverImage = null;

    public new ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectDialogScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuOptionStageScript _parentScript = null;
    private List<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScript> _languageButtonScriptContainer = new List<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScript>();
    private ToffMonaka.UnityBase.Constant.Util.LANGUAGE_TYPE _languageType = ToffMonaka.UnityBase.Constant.Util.LANGUAGE_TYPE.NONE;
    private Sequence _openCloseSequence = null;

    /**
     * @brief コンストラクタ
     */
    public MenuOptionStageLanguageSelectDialogScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_OPTION_STAGE_LANGUAGE_SELECT_DIALOG);

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
        this._parentScript = this.createDesc.parentScript;

        this._nameText.SetText("言語");

        this._languageButtonNode.SetActive(false);

        {// LanguageButtonScript Create
            var script = GameObject.Instantiate(this._languageButtonNode, this._languageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScriptCreateDesc();

            script_create_desc.parentScript = this;
            script_create_desc.languageType = ToffMonaka.UnityBase.Constant.Util.LANGUAGE_TYPE.ENGLISH;

            script.Create(script_create_desc);
            script.Open(0);

            this._languageButtonScriptContainer.Add(script);
        }

        {// LanguageButtonScript Create
            var script = GameObject.Instantiate(this._languageButtonNode, this._languageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScriptCreateDesc();

            script_create_desc.parentScript = this;
            script_create_desc.languageType = ToffMonaka.UnityBase.Constant.Util.LANGUAGE_TYPE.JAPANESE;

            script.Create(script_create_desc);
            script.Open(0);

            this._languageButtonScriptContainer.Add(script);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectDialogScriptCreateDesc;

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
            this._canvasGroup.alpha = 0.0f;

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(this._canvasGroup.DOFade(1.0f, 0.1f));
            this._openCloseSequence.SetLink(this.gameObject);

			break;
		}
		default: {
            this._canvasGroup.alpha = 1.0f;

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
        if (!this._openCloseSequence.IsActive()) {
            this.CompleteOpen();
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
            this._canvasGroup.alpha = 1.0f;

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(this._canvasGroup.DOFade(0.0f, 0.1f));
            this._openCloseSequence.SetLink(this.gameObject);

			break;
		}
		default: {
            this._canvasGroup.alpha = 0.0f;

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
        if (!this._openCloseSequence.IsActive()) {
            this.CompleteClose();
        }

        return;
    }

    /**
     * @brief OnCloseButtonPointerClickEvent関数
     */
    public void OnCloseButtonPointerClickEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        this.Close(1);

        return;
    }

    /**
     * @brief OnCloseButtonPointerEnterEvent関数
     */
    public void OnCloseButtonPointerEnterEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        this._closeButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCloseButtonPointerExitEvent関数
     */
    public void OnCloseButtonPointerExitEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        this._closeButtonCoverImage.gameObject.SetActive(false);

        return;
    }
}
}
