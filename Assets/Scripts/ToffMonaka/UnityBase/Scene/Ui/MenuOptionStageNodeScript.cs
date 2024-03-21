/**
 * @file
 * @brief MenuOptionStageNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuOptionStageNodeScriptCreateDescクラス
 */
public class MenuOptionStageNodeScriptCreateDesc : UnityBase.Scene.Ui.MenuStageNodeScriptCreateDesc
{
}

/**
 * @brief MenuOptionStageNodeScriptクラス
 */
public class MenuOptionStageNodeScript : UnityBase.Scene.Ui.MenuStageNodeScript
{
    [SerializeField] private ScrollRect _editScrollRect = null;
    [SerializeField] private TMP_Text _languageNameText = null;
    [SerializeField] private TMP_Text _languageButtonNameText = null;
    [SerializeField] private Image _languageButtonCoverImage = null;
    [SerializeField] private TMP_Text _soundNameText = null;
    [SerializeField] private TMP_Text _soundBgmVolumeNameText = null;
    [SerializeField] private Slider _soundBgmVolumeSlider = null;
    [SerializeField] private Image _soundBgmVolumeSliderLeftButtonCoverImage = null;
    [SerializeField] private Image _soundBgmVolumeSliderRightButtonCoverImage = null;
    [SerializeField] private TMP_Text _soundBgmMuteNameText = null;
    [SerializeField] private Toggle _soundBgmMuteToggle = null;
    [SerializeField] private TMP_Text _soundSeVolumeNameText = null;
    [SerializeField] private Slider _soundSeVolumeSlider = null;
    [SerializeField] private Image _soundSeVolumeSliderLeftButtonCoverImage = null;
    [SerializeField] private Image _soundSeVolumeSliderRightButtonCoverImage = null;
    [SerializeField] private TMP_Text _soundSeMuteNameText = null;
    [SerializeField] private Toggle _soundSeMuteToggle = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.MenuOptionStageNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Util.LANGUAGE_TYPE _languageType = UnityBase.Util.LANGUAGE_TYPE.NONE;
    private float _soundBgmVolume = 1.0f;
    private bool _soundBgmMuteFlag = false;
    private float _soundSeVolume = 1.0f;
    private bool _soundSeMuteFlag = false;
    private uint _restartFlag = 0U;
    private GameObject _languageSelectDialogNode = null;
    private UnityBase.Scene.Ui.SelectDialogNodeScript _languageSelectDialogNodeScript = null;

    /**
     * @brief コンストラクタ
     */
    public MenuOptionStageNodeScript()
    {
        this._SetStageType(UnityBase.Util.SCENE.MENU_STAGE_TYPE.OPTION);

        return;
    }
    
    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_OPTION_STAGE_NODE);
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        if (this._languageSelectDialogNodeScript != null) {
            Lib.Scene.Util.ReleasePrefabNode(ref this._languageSelectDialogNode);

            this._languageSelectDialogNodeScript = null;
        }

        base._OnDestroy();

        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        this._languageNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.LANGUAGE));
        this._soundNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.SOUND));
        this._soundBgmMuteNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.BGM_MUTE));
        this._soundSeMuteNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.SE_MUTE));
        this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuOptionStageNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._editScrollRect.verticalNormalizedPosition = 1.0f;
        this.SetLanguageType(UnityBase.Global.systemDataFile.data.systemLanguageType);
        this.SetSoundBgmVolume(UnityBase.Global.systemDataFile.data.soundBgmVolume);
        this.SetSoundBgmMuteFlag(UnityBase.Global.systemDataFile.data.soundBgmMuteFlag);
        this.SetSoundSeVolume(UnityBase.Global.systemDataFile.data.soundSeVolume);
        this.SetSoundSeMuteFlag(UnityBase.Global.systemDataFile.data.soundSeMuteFlag);
        this._languageButtonCoverImage.gameObject.SetActive(false);
        this._soundBgmVolumeSliderLeftButtonCoverImage.gameObject.SetActive(false);
        this._soundBgmVolumeSliderRightButtonCoverImage.gameObject.SetActive(false);
        this._soundSeVolumeSliderLeftButtonCoverImage.gameObject.SetActive(false);
        this._soundSeVolumeSliderRightButtonCoverImage.gameObject.SetActive(false);
        this._okButtonCoverImage.gameObject.SetActive(false);
        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        base._OnDeactive();

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        base._OnUpdateOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        base._OnUpdateClose();

        return;
    }

    /**
     * @brief OnLanguageButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnLanguageButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        // LanguageSelectDialogNodeScript Create
        if (this._languageSelectDialogNodeScript == null) {
            this._languageSelectDialogNode = Lib.Scene.Util.GetPrefabNode(UnityBase.Util.FILE_PATH.SELECT_DIALOG_PREFAB, this.GetMenuNodeScript().GetSubSceneNodeScript().GetDialogNode());

            var script = this._languageSelectDialogNode.GetComponent<UnityBase.Scene.Ui.SelectDialogNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.SelectDialogNodeScriptCreateDesc();

            void on_click_item(UnityBase.Scene.Ui.SelectDialogNodeScript dialog_node_script, UnityBase.Scene.Ui.SelectDialogItemNodeScript item_node_script)
            {
                var item_node_script_engine = item_node_script.GetEngine() as UnityBase.Scene.Ui.LanguageSelectDialogItemEngine;

                this.SetLanguageType(item_node_script_engine.GetLanguageType());

                return;
            }

            script_create_desc.engine = new UnityBase.Scene.Ui.LanguageSelectDialogEngine(on_click_item);

            script.Create(script_create_desc);

            this._languageSelectDialogNodeScript = script;

            this._languageSelectDialogNodeScript.AddItem(new UnityBase.Scene.Ui.LanguageSelectDialogItemEngine(UnityBase.Util.LANGUAGE_TYPE.ENGLISH));
            this._languageSelectDialogNodeScript.AddItem(new UnityBase.Scene.Ui.LanguageSelectDialogItemEngine(UnityBase.Util.LANGUAGE_TYPE.JAPANESE));
        }

        if (this._languageSelectDialogNodeScript != null) {
            this._languageSelectDialogNodeScript.Open(1);
        }

        return;
    }

    /**
     * @brief OnLanguageButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnLanguageButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._languageButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnLanguageButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnLanguageButtonPointerExit(PointerEventData event_dat)
    {
        this._languageButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnSoundBgmVolumeSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnSoundBgmVolumeSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._soundBgmVolume;

        this.SetSoundBgmVolume(this._soundBgmVolumeSlider.value / 10.0f);

        Lib.Scene.Util.GetSoundManager().SetBgmVolume(this._soundBgmVolume);

        if (this._soundBgmVolume != old_val) {
            Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnSoundBgmVolumeSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnSoundBgmVolumeSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundBgmVolume(System.Math.Max(this._soundBgmVolume - 0.1f, 0.0f));

        Lib.Scene.Util.GetSoundManager().SetBgmVolume(this._soundBgmVolume);

        return;
    }

    /**
     * @brief OnSoundBgmVolumeSliderLeftButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnSoundBgmVolumeSliderLeftButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._soundBgmVolumeSliderLeftButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnSoundBgmVolumeSliderLeftButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnSoundBgmVolumeSliderLeftButtonPointerExit(PointerEventData event_dat)
    {
        this._soundBgmVolumeSliderLeftButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnSoundBgmVolumeSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnSoundBgmVolumeSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundBgmVolume(System.Math.Min(this._soundBgmVolume + 0.1f, 1.0f));

        Lib.Scene.Util.GetSoundManager().SetBgmVolume(this._soundBgmVolume);

        return;
    }

    /**
     * @brief OnSoundBgmVolumeSliderRightButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnSoundBgmVolumeSliderRightButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._soundBgmVolumeSliderRightButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnSoundBgmVolumeSliderRightButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnSoundBgmVolumeSliderRightButtonPointerExit(PointerEventData event_dat)
    {
        this._soundBgmVolumeSliderRightButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnSoundBgmMuteToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnSoundBgmMuteToggleValueChanged(bool event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._soundBgmMuteFlag;

        this.SetSoundBgmMuteFlag(this._soundBgmMuteToggle.isOn);

        Lib.Scene.Util.GetSoundManager().SetBgmMuteFlag(this._soundBgmMuteFlag);

        if (this._soundBgmMuteFlag != old_val) {
            if (this._soundBgmMuteFlag) {
                Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
            } else {
                Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
            }
        }

        return;
    }

    /**
     * @brief OnSoundSeVolumeSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnSoundSeVolumeSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._soundSeVolume;

        this.SetSoundSeVolume(this._soundSeVolumeSlider.value / 10.0f);
     
        Lib.Scene.Util.GetSoundManager().SetSeVolume(this._soundSeVolume);

        if (this._soundSeVolume != old_val) {
            Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnSoundSeVolumeSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnSoundSeVolumeSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundSeVolume(System.Math.Max(this._soundSeVolume - 0.1f, 0.0f));

        Lib.Scene.Util.GetSoundManager().SetSeVolume(this._soundSeVolume);

        return;
    }

    /**
     * @brief OnSoundSeVolumeSliderLeftButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnSoundSeVolumeSliderLeftButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._soundSeVolumeSliderLeftButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnSoundSeVolumeSliderLeftButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnSoundSeVolumeSliderLeftButtonPointerExit(PointerEventData event_dat)
    {
        this._soundSeVolumeSliderLeftButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnSoundSeVolumeSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnSoundSeVolumeSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundSeVolume(System.Math.Min(this._soundSeVolume + 0.1f, 1.0f));

        Lib.Scene.Util.GetSoundManager().SetSeVolume(this._soundSeVolume);

        return;
    }

    /**
     * @brief OnSoundSeVolumeSliderRightButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnSoundSeVolumeSliderRightButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._soundSeVolumeSliderRightButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnSoundSeVolumeSliderRightButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnSoundSeVolumeSliderRightButtonPointerExit(PointerEventData event_dat)
    {
        this._soundSeVolumeSliderRightButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnSoundSeMuteToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnSoundSeMuteToggleValueChanged(bool event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._soundSeMuteFlag;

        this.SetSoundSeMuteFlag(this._soundSeMuteToggle.isOn);

        Lib.Scene.Util.GetSoundManager().SetSeMuteFlag(this._soundSeMuteFlag);

        if (this._soundSeMuteFlag != old_val) {
            if (this._soundSeMuteFlag) {
                Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
            } else {
                Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
            }
        }

        return;
    }

    /**
     * @brief OnOkButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        UnityBase.Global.systemDataFile.data.systemLanguageType = this._languageType;
        UnityBase.Global.systemDataFile.data.soundBgmVolume = this._soundBgmVolume;
        UnityBase.Global.systemDataFile.data.soundBgmMuteFlag = this._soundBgmMuteFlag;
        UnityBase.Global.systemDataFile.data.soundSeVolume = this._soundSeVolume;
        UnityBase.Global.systemDataFile.data.soundSeMuteFlag = this._soundSeMuteFlag;

        UnityBase.Global.systemDataFile.Write(true);

        if (this._restartFlag != 0U) {
            Lib.Scene.Util.GetManager().ChangeMainScene(UnityBase.Util.SCENE.NAME.MAIN);
        }

        this.GetMenuNodeScript().RunStageOkButton();

        return;
    }

    /**
     * @brief OnOkButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._okButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnOkButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerExit(PointerEventData event_dat)
    {
        this._okButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnCancelButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        Lib.Scene.Util.GetSoundManager().SetBgmVolume(UnityBase.Global.systemDataFile.data.soundBgmVolume);
        Lib.Scene.Util.GetSoundManager().SetBgmMuteFlag(UnityBase.Global.systemDataFile.data.soundBgmMuteFlag);
        Lib.Scene.Util.GetSoundManager().SetSeVolume(UnityBase.Global.systemDataFile.data.soundSeVolume);
        Lib.Scene.Util.GetSoundManager().SetSeMuteFlag(UnityBase.Global.systemDataFile.data.soundSeMuteFlag);

        this.GetMenuNodeScript().RunStageCancelButton();

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCancelButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerExit(PointerEventData event_dat)
    {
        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief GetLanguageType関数
     * @return language_type (language_type)
     */
    public UnityBase.Util.LANGUAGE_TYPE GetLanguageType()
    {
        return (this._languageType);
    }

    /**
     * @brief SetLanguageType関数
     * @param language_type (language_type)
     */
    public void SetLanguageType(UnityBase.Util.LANGUAGE_TYPE language_type)
    {
        this._languageType = language_type;

        this._languageButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.LANGUAGE_NAME_MST_TEXT_ID_ARRAY[(int)this._languageType]));

        this._SetRestartFlag((this._languageType != UnityBase.Global.systemDataFile.data.systemLanguageType) ? (this._restartFlag | 0x0001U) : (this._restartFlag & ~0x0001U));

        return;
    }

    /**
     * @brief GetSoundBgmVolume関数
     * @return sound_bgm_vol (sound_bgm_volume)
     */
    public float GetSoundBgmVolume()
    {
        return (this._soundBgmVolume);
    }

    /**
     * @brief SetSoundBgmVolume関数
     * @param sound_bgm_vol (sound_bgm_volume)
     */
    public void SetSoundBgmVolume(float sound_bgm_vol)
    {
        this._soundBgmVolume = (float)System.Math.Clamp(System.Math.Round(sound_bgm_vol, 1, System.MidpointRounding.AwayFromZero), 0.0, 1.0);

        this._soundBgmVolumeNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.BGM_VOLUME) + " " + (this._soundBgmVolume * 10.0f).ToString());
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
     * @return sound_se_vol (sound_se_volume)
     */
    public float GetSoundSeVolume()
    {
        return (this._soundSeVolume);
    }

    /**
     * @brief SetSoundSeVolume関数
     * @param sound_se_vol (sound_se_volume)
     */
    public void SetSoundSeVolume(float sound_se_vol)
    {
        this._soundSeVolume = (float)System.Math.Clamp(System.Math.Round(sound_se_vol, 1, System.MidpointRounding.AwayFromZero), 0.0, 1.0);

        this._soundSeVolumeNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.SE_VOLUME) + " " + (this._soundSeVolume * 10.0f).ToString());
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
            this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK_RESTART));
            this._okButtonNameText.fontSize = 20.0f;
        } else {
            this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
            this._okButtonNameText.fontSize = 32.0f;
        }

        return;
    }
}
}
}
