/**
 * @file
 * @brief MenuLanguageSelectDialogScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuLanguageSelectDialogScriptCreateDescクラス
 */
public class MenuLanguageSelectDialogScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuScript menuScript = null;
}

/**
 * @brief MenuLanguageSelectDialogScriptクラス
 */
public class MenuLanguageSelectDialogScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private CanvasGroup _canvasGroup = null;
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private Image _closeButtonCoverImage = null;

    public new ToffMonaka.UnityBase.Scene.MenuLanguageSelectDialogScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;
    private Sequence _openCloseSequence = null;

    /**
     * @brief コンストラクタ
     */
    public MenuLanguageSelectDialogScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_LANGUAGE_SELECT_DIALOG);

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
        this._menuScript = this.createDesc.menuScript;

        this._nameText.SetText("言語");

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuLanguageSelectDialogScriptCreateDesc;

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
		switch (this.GetOpenType()) {
		case 1: {
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteOpen();
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
		switch (this.GetCloseType()) {
		case 1: {
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteClose();
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
     * @brief OnCloseButtonPointerClickEvent関数
     */
    public void OnCloseButtonPointerClickEvent()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        this._menuScript.RunLanguageSelectDialogCloseButton();

        return;
    }

    /**
     * @brief OnCloseButtonPointerEnterEvent関数
     */
    public void OnCloseButtonPointerEnterEvent()
    {
        this._closeButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCloseButtonPointerExitEvent関数
     */
    public void OnCloseButtonPointerExitEvent()
    {
        this._closeButtonCoverImage.gameObject.SetActive(false);

        return;
    }
}
}
