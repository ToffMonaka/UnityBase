/**
 * @file
 * @brief MenuEndStageScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuEndStageScriptCreateDescクラス
 */
public class MenuEndStageScriptCreateDesc : ToffMonaka.UnityBase.Scene.MenuStageScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuScript menuScript = null;
}

/**
 * @brief MenuEndStageScriptクラス
 */
public class MenuEndStageScript : ToffMonaka.UnityBase.Scene.MenuStageScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private ScrollRect _editScrollRect = null;
    [SerializeField] private Toggle _restartToggle = null;
    [SerializeField] private TMP_Text _restartToggleNameText = null;
    [SerializeField] private Toggle _endToggle = null;
    [SerializeField] private TMP_Text _endToggleNameText = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new ToffMonaka.UnityBase.Scene.MenuEndStageScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;

    /**
     * @brief コンストラクタ
     */
    public MenuEndStageScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_END_STAGE);
        this._SetStageType(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.END);

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

        this._nameText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_NAME_ARRAY[(int)this.GetStageType()]);

        this._restartToggleNameText.SetText("再起動");
        this._endToggleNameText.SetText("終了");

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
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuEndStageScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._editScrollRect.verticalNormalizedPosition = 1.0f;
        this._restartToggle.SetIsOnWithoutNotify(false);
        this._endToggle.SetIsOnWithoutNotify(false);

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

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

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
        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetCloseType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(8.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(-rect_transform.sizeDelta.x - 8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

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
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteClose();
        }

        return;
    }

    /**
     * @brief OnRestartToggleValueChangedEvent関数
     */
    public void OnRestartToggleValueChangedEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        if (this._restartToggle.isOn) {
            ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

            this._endToggle.SetIsOnWithoutNotify(false);
        } else {
            ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);
        }

        return;
    }

    /**
     * @brief OnEndToggleValueChangedEvent関数
     */
    public void OnEndToggleValueChangedEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        if (this._endToggle.isOn) {
            ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

            this._restartToggle.SetIsOnWithoutNotify(false);
        } else {
            ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);
        }

        return;
    }

    /**
     * @brief OnOkButtonPointerClickEvent関数
     */
    public void OnOkButtonPointerClickEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        if (this._restartToggle.isOn) {
            ToffMonaka.Lib.Scene.Util.GetManager().ChangeMainScene(ToffMonaka.UnityBase.Constant.Util.SCENE.NAME.MAIN);
        } else if (this._endToggle.isOn) {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        this._menuScript.RunStageOkButton();

        return;
    }

    /**
     * @brief OnOkButtonPointerEnterEvent関数
     */
    public void OnOkButtonPointerEnterEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        this._okButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnOkButtonPointerExitEvent関数
     */
    public void OnOkButtonPointerExitEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        this._okButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnCancelButtonPointerClickEvent関数
     */
    public void OnCancelButtonPointerClickEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        this._menuScript.RunStageCancelButton();

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnterEvent関数
     */
    public void OnCancelButtonPointerEnterEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCancelButtonPointerExitEvent関数
     */
    public void OnCancelButtonPointerExitEvent()
    {
        if (this.GetClosedFlag()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }
}
}
