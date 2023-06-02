﻿/**
 * @file
 * @brief MenuCheatStageScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuCheatStageScriptCreateDescクラス
 */
public class MenuCheatStageScriptCreateDesc : ToffMonaka.UnityBase.Scene.MenuStageScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuScript menuScript = null;
}

/**
 * @brief MenuCheatStageScriptクラス
 */
public class MenuCheatStageScript : ToffMonaka.UnityBase.Scene.MenuStageScript
{
    [SerializeField] private TextMeshProUGUI _nameText = null;
    [SerializeField] private TextMeshProUGUI _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TextMeshProUGUI _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new ToffMonaka.UnityBase.Scene.MenuCheatStageScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;
    private Sequence _openCloseSequence = null;

    /**
     * @brief コンストラクタ
     */
    public MenuCheatStageScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_CHEAT_STAGE);
        this._SetStageType(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.CHEAT);

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

        this._nameText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE_NAME_ARRAY[(int)this.GetStageType()]);
        this._okButtonNameText.SetText("OK");
        this._cancelButtonNameText.SetText("キャンセル");

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuCheatStageScriptCreateDesc;

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
        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetOpenType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 8.0f, rect_transform.anchoredPosition.y);

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(rect_transform.DOAnchorPosX(8.0f, 0.1f));

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(8.0f, rect_transform.anchoredPosition.y);

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
        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetCloseType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(8.0f, rect_transform.anchoredPosition.y);

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(rect_transform.DOAnchorPosX(-rect_transform.sizeDelta.x - 8.0f, 0.1f));

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 8.0f, rect_transform.anchoredPosition.y);

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
     * @brief OnOkButtonPointerClickEvent関数
     */
    public void OnOkButtonPointerClickEvent()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._menuScript.RunOkButton();

        return;
    }

    /**
     * @brief OnOkButtonPointerEnterEvent関数
     */
    public void OnOkButtonPointerEnterEvent()
    {
        this._okButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnOkButtonPointerExitEvent関数
     */
    public void OnOkButtonPointerExitEvent()
    {
        this._okButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnCancelButtonPointerClickEvent関数
     */
    public void OnCancelButtonPointerClickEvent()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._menuScript.RunCancelButton();

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnterEvent関数
     */
    public void OnCancelButtonPointerEnterEvent()
    {
        this._cancelButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCancelButtonPointerExitEvent関数
     */
    public void OnCancelButtonPointerExitEvent()
    {
        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }
}
}
