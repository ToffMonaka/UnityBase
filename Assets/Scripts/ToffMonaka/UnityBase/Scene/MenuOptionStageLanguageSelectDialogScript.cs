/**
 * @file
 * @brief MenuOptionStageLanguageSelectDialogScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuOptionStageLanguageSelectDialogScriptCreateDescクラス
 */
public class MenuOptionStageLanguageSelectDialogScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuOptionStageScript menuOptionStageScript = null;
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

    private ToffMonaka.UnityBase.Scene.MenuOptionStageScript _menuOptionStageScript = null;
    private List<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScript> _languageButtonScriptContainer = new List<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScript>();
    private ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE _languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.NONE;

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
        this._menuOptionStageScript = this.createDesc.menuOptionStageScript;

        this._nameText.SetText("言語");

        this._languageButtonNode.SetActive(false);

        {// LanguageButtonScript Create
            var script = GameObject.Instantiate(this._languageButtonNode, this._languageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScriptCreateDesc();

            script_create_desc.menuOptionStageLanguageSelectScript = this;
            script_create_desc.languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.ENGLISH;

            script.Create(script_create_desc);
            script.Open(0);

            this._languageButtonScriptContainer.Add(script);
        }

        {// LanguageButtonScript Create
            var script = GameObject.Instantiate(this._languageButtonNode, this._languageButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScriptCreateDesc();

            script_create_desc.menuOptionStageLanguageSelectScript = this;
            script_create_desc.languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.JAPANESE;

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
        this.SetLanguageType(ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.NONE);
        this._closeButtonCoverImage.gameObject.SetActive(false);

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

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(this._canvasGroup.DOFade(1.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

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
        if (!this.IsActiveOpenCloseSequence()) {
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

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(this._canvasGroup.DOFade(0.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

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
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteClose();
        }

        return;
    }

    /**
     * @brief OnCloseButtonPointerClickEvent関数
     */
    public void OnCloseButtonPointerClickEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        this._menuOptionStageScript.RunLanguageSelectCloseButton();

        return;
    }

    /**
     * @brief OnCloseButtonPointerEnterEvent関数
     */
    public void OnCloseButtonPointerEnterEvent()
    {
        if (!this.IsControllable()) {
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
        if (!this.IsControllable()) {
            return;
        }

        this._closeButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief GetLanguageType関数
     * @return language_type (language_type)
     */
    public ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE GetLanguageType()
    {
        return (this._languageType);
    }

    /**
     * @brief SetLanguageType関数
     * @param language_type (language_type)
     */
    public void SetLanguageType(ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE language_type)
    {
        this._languageType = language_type;

        return;
    }

    /**
     * @brief RunLanguageButton関数
     * @param language_type (language_type)
     */
    public void RunLanguageButton(ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE language_type)
    {
        this.SetLanguageType(language_type);

        this._menuOptionStageScript.RunLanguageSelectLanguageButton(this._languageType);

        return;
    }
}
}
