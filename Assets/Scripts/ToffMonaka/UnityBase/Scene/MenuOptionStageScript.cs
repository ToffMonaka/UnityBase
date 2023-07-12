/**
 * @file
 * @brief MenuOptionStageScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuOptionStageScriptCreateDescクラス
 */
public class MenuOptionStageScriptCreateDesc : ToffMonaka.UnityBase.Scene.MenuStageScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuScript menuScript = null;
}

/**
 * @brief MenuOptionStageScriptクラス
 */
public class MenuOptionStageScript : ToffMonaka.UnityBase.Scene.MenuStageScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private ScrollRect _editScrollRect = null;
    [SerializeField] private TMP_Text _languageNameText = null;
    [SerializeField] private TMP_Text _languageButtonNameText = null;
    [SerializeField] private Image _languageButtonCoverImage = null;
    [SerializeField] private TMP_Text _soundNameText = null;
    [SerializeField] private Slider _soundBgmVolumeSlider = null;
    [SerializeField] private TMP_Text _soundBgmVolumeSliderNameText = null;
    [SerializeField] private Toggle _soundBgmMuteToggle = null;
    [SerializeField] private TMP_Text _soundBgmMuteToggleNameText = null;
    [SerializeField] private Slider _soundSeVolumeSlider = null;
    [SerializeField] private TMP_Text _soundSeVolumeSliderNameText = null;
    [SerializeField] private Toggle _soundSeMuteToggle = null;
    [SerializeField] private TMP_Text _soundSeMuteToggleNameText = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;
    [SerializeField] private GameObject _languageSelectDialogNode = null;

    public new ToffMonaka.UnityBase.Scene.MenuOptionStageScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;
    private ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE _languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.NONE;
    private float _soundBgmVolume = 1.0f;
    private bool _soundBgmMuteFlag = false;
    private float _soundSeVolume = 1.0f;
    private bool _soundSeMuteFlag = false;
    private uint _restartFlag = 0U;
    private ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectDialogScript _languageSelectDialogScript = null;

    /**
     * @brief コンストラクタ
     */
    public MenuOptionStageScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_OPTION_STAGE);
        this._SetStageType(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.OPTION);

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

        this._languageNameText.SetText("言語");
        this._soundNameText.SetText("サウンド");
        this._soundBgmMuteToggleNameText.SetText("BGMミュート");
        this._soundSeMuteToggleNameText.SetText("SEミュート");

        this._okButtonNameText.SetText(ToffMonaka.UnityBase.Global.GetString(ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.OK));
        this._cancelButtonNameText.SetText(ToffMonaka.UnityBase.Global.GetString(ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.CANCEL));

        {// languageSelectDialogScript Create
            var script = this._languageSelectDialogNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectDialogScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectDialogScriptCreateDesc();

            script_create_desc.menuOptionStageScript = this;

            script.Create(script_create_desc);

            this._languageSelectDialogScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuOptionStageScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._editScrollRect.verticalNormalizedPosition = 1.0f;
        this.SetLanguageType(ToffMonaka.UnityBase.Global.systemConfigFile.data.systemLanguageType);
        this.SetSoundBgmVolume(ToffMonaka.UnityBase.Global.systemConfigFile.data.soundBgmVolume);
        this.SetSoundBgmMuteFlag(ToffMonaka.UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag);
        this.SetSoundSeVolume(ToffMonaka.UnityBase.Global.systemConfigFile.data.soundSeVolume);
        this.SetSoundSeMuteFlag(ToffMonaka.UnityBase.Global.systemConfigFile.data.soundSeMuteFlag);
        this._languageButtonCoverImage.gameObject.SetActive(false);
        this._okButtonCoverImage.gameObject.SetActive(false);
        this._cancelButtonCoverImage.gameObject.SetActive(false);

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
     * @brief OnLanguageButtonPointerClickEvent関数
     */
    public void OnLanguageButtonPointerClickEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._languageSelectDialogScript.Open(1);

        return;
    }

    /**
     * @brief OnLanguageButtonPointerEnterEvent関数
     */
    public void OnLanguageButtonPointerEnterEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        this._languageButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnLanguageButtonPointerExitEvent関数
     */
    public void OnLanguageButtonPointerExitEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        this._languageButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnSoundBgmVolumeSliderValueChangedEvent関数
     */
    public void OnSoundBgmVolumeSliderValueChangedEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundBgmVolume(this._soundBgmVolumeSlider.value / 10.0f);

        ToffMonaka.Lib.Scene.Util.GetSoundManager().SetBgmVolume(this._soundBgmVolume);

        return;
    }

    /**
     * @brief OnSoundBgmMuteToggleValueChangedEvent関数
     */
    public void OnSoundBgmMuteToggleValueChangedEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        if (this._soundBgmMuteToggle.isOn) {
            ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);
        } else {
            ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);
        }

        this.SetSoundBgmMuteFlag(this._soundBgmMuteToggle.isOn);

        ToffMonaka.Lib.Scene.Util.GetSoundManager().SetBgmMuteFlag(this._soundBgmMuteFlag);

        return;
    }

    /**
     * @brief OnSoundSeVolumeSliderValueChangedEvent関数
     */
    public void OnSoundSeVolumeSliderValueChangedEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundSeVolume(this._soundSeVolumeSlider.value / 10.0f);
     
        ToffMonaka.Lib.Scene.Util.GetSoundManager().SetSeVolume(this._soundSeVolume);

        return;
    }

    /**
     * @brief OnSoundSeMuteToggleValueChangedEvent関数
     */
    public void OnSoundSeMuteToggleValueChangedEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        if (this._soundSeMuteToggle.isOn) {
            ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);
        } else {
            ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);
        }

        this.SetSoundSeMuteFlag(this._soundSeMuteToggle.isOn);

        ToffMonaka.Lib.Scene.Util.GetSoundManager().SetSeMuteFlag(this._soundSeMuteFlag);

        return;
    }

    /**
     * @brief OnOkButtonPointerClickEvent関数
     */
    public void OnOkButtonPointerClickEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        bool write_flg = false;

        if (this._languageType != ToffMonaka.UnityBase.Global.systemConfigFile.data.systemLanguageType) {
            ToffMonaka.UnityBase.Global.systemConfigFile.data.systemLanguageType = this._languageType;

            write_flg = true;
        }

        if (this._soundBgmVolume != ToffMonaka.UnityBase.Global.systemConfigFile.data.soundBgmVolume) {
            ToffMonaka.UnityBase.Global.systemConfigFile.data.soundBgmVolume = this._soundBgmVolume;

            write_flg = true;
        }

        if (this._soundBgmMuteFlag != ToffMonaka.UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag) {
            ToffMonaka.UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag = this._soundBgmMuteFlag;

            write_flg = true;
        }

        if (this._soundSeVolume != ToffMonaka.UnityBase.Global.systemConfigFile.data.soundSeVolume) {
            ToffMonaka.UnityBase.Global.systemConfigFile.data.soundSeVolume = this._soundSeVolume;

            write_flg = true;
        }

        if (this._soundSeMuteFlag != ToffMonaka.UnityBase.Global.systemConfigFile.data.soundSeMuteFlag) {
            ToffMonaka.UnityBase.Global.systemConfigFile.data.soundSeMuteFlag = this._soundSeMuteFlag;

            write_flg = true;
        }

        if (write_flg) {
            ToffMonaka.UnityBase.Global.systemConfigFile.Write();
        }

        if (this._restartFlag != 0U) {
            ToffMonaka.Lib.Scene.Util.GetManager().ChangeMainScene(ToffMonaka.UnityBase.Constant.Util.SCENE.NAME.MAIN);
        }

        this._menuScript.RunStageOkButton();

        return;
    }

    /**
     * @brief OnOkButtonPointerEnterEvent関数
     */
    public void OnOkButtonPointerEnterEvent()
    {
        if (!this.IsControllable()) {
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
        if (!this.IsControllable()) {
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
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        ToffMonaka.Lib.Scene.Util.GetSoundManager().SetBgmVolume(ToffMonaka.UnityBase.Global.systemConfigFile.data.soundBgmVolume);
        ToffMonaka.Lib.Scene.Util.GetSoundManager().SetBgmMuteFlag(ToffMonaka.UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag);
        ToffMonaka.Lib.Scene.Util.GetSoundManager().SetSeVolume(ToffMonaka.UnityBase.Global.systemConfigFile.data.soundSeVolume);
        ToffMonaka.Lib.Scene.Util.GetSoundManager().SetSeMuteFlag(ToffMonaka.UnityBase.Global.systemConfigFile.data.soundSeMuteFlag);

        this._menuScript.RunStageCancelButton();

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnterEvent関数
     */
    public void OnCancelButtonPointerEnterEvent()
    {
        if (!this.IsControllable()) {
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
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(false);

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

        this._languageButtonNameText.SetText(ToffMonaka.Lib.Constant.Util.LANGUAGE_NAME_ARRAY[(int)this._languageType]);

        this._SetRestartFlag((this._languageType != ToffMonaka.UnityBase.Global.systemConfigFile.data.systemLanguageType) ? (this._restartFlag | 0x0001U) : (this._restartFlag & ~0x0001U));

        return;
    }

    /**
     * @brief GetSoundBgmVolume関数
     * @return sound_bgm_volume (sound_bgm_volume)
     */
    public float GetSoundBgmVolume()
    {
        return (this._soundBgmVolume);
    }

    /**
     * @brief SetSoundBgmVolume関数
     * @param sound_bgm_volume (sound_bgm_volume)
     */
    public void SetSoundBgmVolume(float sound_bgm_volume)
    {
        this._soundBgmVolume = (float)System.Math.Clamp(System.Math.Round(sound_bgm_volume, 1, System.MidpointRounding.AwayFromZero), 0.0, 1.0);

        this._soundBgmVolumeSliderNameText.SetText("BGMボリューム " + (this._soundBgmVolume * 10.0f));
        this._soundBgmVolumeSlider.SetValueWithoutNotify(this._soundBgmVolume * 10.0f);

        return;
    }

    /**
     * @brief GetSoundBgmMuteFlag関数
     * @return sound_bgm_mute_flg (sound_bgm_mute_flag)
     */
    public bool GetSoundBgmMuteFlag()
    {
        return (this._soundBgmMuteFlag);
    }

    /**
     * @brief SetSoundBgmMuteFlag関数
     * @param sound_bgm_mute_flg (sound_bgm_mute_flag)
     */
    public void SetSoundBgmMuteFlag(bool sound_bgm_mute_flg)
    {
        this._soundBgmMuteFlag = sound_bgm_mute_flg;

        this._soundBgmMuteToggle.SetIsOnWithoutNotify(this._soundBgmMuteFlag);

        return;
    }

    /**
     * @brief GetSoundSeVolume関数
     * @return sound_se_volume (sound_se_volume)
     */
    public float GetSoundSeVolume()
    {
        return (this._soundSeVolume);
    }

    /**
     * @brief SetSoundSeVolume関数
     * @param sound_se_volume (sound_se_volume)
     */
    public void SetSoundSeVolume(float sound_se_volume)
    {
        this._soundSeVolume = (float)System.Math.Clamp(System.Math.Round(sound_se_volume, 1, System.MidpointRounding.AwayFromZero), 0.0, 1.0);

        this._soundSeVolumeSliderNameText.SetText("SEボリューム " + (this._soundSeVolume * 10.0f));
        this._soundSeVolumeSlider.SetValueWithoutNotify(this._soundSeVolume * 10.0f);

        return;
    }

    /**
     * @brief GetSoundSeMuteFlag関数
     * @return sound_se_mute_flg (sound_se_mute_flag)
     */
    public bool GetSoundSeMuteFlag()
    {
        return (this._soundSeMuteFlag);
    }

    /**
     * @brief SetSoundSeMuteFlag関数
     * @param sound_se_mute_flg (sound_se_mute_flag)
     */
    public void SetSoundSeMuteFlag(bool sound_se_mute_flg)
    {
        this._soundSeMuteFlag = sound_se_mute_flg;

        this._soundSeMuteToggle.SetIsOnWithoutNotify(this._soundSeMuteFlag);

        return;
    }

    /**
     * @brief _SetRestartFlag関数
     * @param restart_flg (restart_flag)
     */
    private void _SetRestartFlag(uint restart_flg)
    {
        this._restartFlag = restart_flg;

        if (this._restartFlag != 0U) {
            this._okButtonNameText.SetText(ToffMonaka.UnityBase.Global.GetString(ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.OK_RESTART));
            this._okButtonNameText.fontSize = 20.0f;
        } else {
            this._okButtonNameText.SetText(ToffMonaka.UnityBase.Global.GetString(ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.OK));
            this._okButtonNameText.fontSize = 32.0f;
        }

        return;
    }

    /**
     * @brief RunLanguageSelectCloseButton関数
     */
    public void RunLanguageSelectCloseButton()
    {
        this._languageSelectDialogScript.Close(1);

        return;
    }

    /**
     * @brief RunLanguageSelectLanguageButton関数
     * @param language_type (language_type)
     */
    public void RunLanguageSelectLanguageButton(ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE language_type)
    {
        this.SetLanguageType(language_type);

        this._languageSelectDialogScript.Close(1);

        return;
    }
}
}
