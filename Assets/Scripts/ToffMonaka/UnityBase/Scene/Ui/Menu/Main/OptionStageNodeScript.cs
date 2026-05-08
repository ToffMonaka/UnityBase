/**
 * @file
 * @brief OptionStageNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Main {
/**
 * @brief OptionStageNodeScriptCreateDescクラス
 */
public class OptionStageNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Main.StageNodeScriptCreateDesc
{
}

/**
 * @brief OptionStageNodeScriptクラス
 */
public class OptionStageNodeScript : UnityBase.Scene.Ui.Menu.Main.StageNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private TMP_Text _languageNameText = null;
    [SerializeField] private TMP_Text _languageButtonNameText = null;
    [SerializeField] private TMP_Text _soundNameText = null;
    [SerializeField] private TMP_Text _soundBgmVolumeNameText = null;
    [SerializeField] private Slider _soundBgmVolumeSlider = null;
    [SerializeField] private TMP_Text _soundBgmMuteNameText = null;
    [SerializeField] private Toggle _soundBgmMuteToggle = null;
    [SerializeField] private TMP_Text _soundSeVolumeNameText = null;
    [SerializeField] private Slider _soundSeVolumeSlider = null;
    [SerializeField] private TMP_Text _soundSeMuteNameText = null;
    [SerializeField] private Toggle _soundSeMuteToggle = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new UnityBase.Scene.Ui.Menu.Main.OptionStageNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Util.LANGUAGE_TYPE _languageType = UnityBase.Util.LANGUAGE_TYPE.NONE;
    private float _soundBgmVolume = 1.0f;
    private bool _soundBgmMuteFlag = false;
    private float _soundSeVolume = 1.0f;
    private bool _soundSeMuteFlag = false;
    private uint _restartFlag = 0U;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_OPTION_STAGE_NODE);
    }

    /**
     * @brief _OnGetStageType関数
     * @return stage_type (stage_type)
     */
    protected override UnityBase.Util.SCENE.MENU_STAGE_TYPE _OnGetStageType()
    {
        return (UnityBase.Util.SCENE.MENU_STAGE_TYPE.OPTION);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Main.OptionStageNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Main.OptionStageNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._scrollRect.verticalNormalizedPosition = 1.0f;

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
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
        base._OnOpened();

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
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        base._OnClosed();

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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        {// LanguageSelectDialog Add
            var script_create_desc = new UnityBase.Scene.Ui.Dialog.SelectDialogNodeScriptCreateDesc();

            void on_click_item(UnityBase.Scene.Ui.Dialog.SelectDialogNodeScript owner, UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScript item_node_script)
            {
                var item_node_script_engine = item_node_script.GetEngine() as UnityBase.Scene.Ui.Dialog.LanguageSelectDialogItemEngine;

                this.SetLanguageType(item_node_script_engine.GetLanguageType());

                return;
            }

            script_create_desc.engine = new UnityBase.Scene.Ui.Dialog.LanguageSelectDialogEngine();
            script_create_desc.onClickItem = on_click_item;

            var script = UnityBase.Global.GetSubSceneNodeScript().GetDialogSystemNodeScript().AddDialog(script_create_desc) as UnityBase.Scene.Ui.Dialog.SelectDialogNodeScript;

            script.AddItem(new UnityBase.Scene.Ui.Dialog.LanguageSelectDialogItemEngine(UnityBase.Util.LANGUAGE_TYPE.ENGLISH));
            script.AddItem(new UnityBase.Scene.Ui.Dialog.LanguageSelectDialogItemEngine(UnityBase.Util.LANGUAGE_TYPE.JAPANESE));
        }

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

        UnityBase.Global.GetSceneManager().SetSoundBgmVolume(this._soundBgmVolume);

        if (this._soundBgmVolume != old_val) {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundBgmVolume(System.Math.Max(this._soundBgmVolume - 0.1f, 0.0f));

        UnityBase.Global.GetSceneManager().SetSoundBgmVolume(this._soundBgmVolume);

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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundBgmVolume(System.Math.Min(this._soundBgmVolume + 0.1f, 1.0f));

        UnityBase.Global.GetSceneManager().SetSoundBgmVolume(this._soundBgmVolume);

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

        UnityBase.Global.GetSceneManager().SetSoundBgmMuteFlag(this._soundBgmMuteToggle.isOn);

        if (this._soundBgmMuteToggle.isOn) {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
        } else {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
        }

        this.SetSoundBgmMuteFlag(this._soundBgmMuteToggle.isOn);

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
     
        UnityBase.Global.GetSceneManager().SetSoundSeVolume(this._soundSeVolume);

        if (this._soundSeVolume != old_val) {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundSeVolume(System.Math.Max(this._soundSeVolume - 0.1f, 0.0f));

        UnityBase.Global.GetSceneManager().SetSoundSeVolume(this._soundSeVolume);

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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this.SetSoundSeVolume(System.Math.Min(this._soundSeVolume + 0.1f, 1.0f));

        UnityBase.Global.GetSceneManager().SetSoundSeVolume(this._soundSeVolume);

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

        UnityBase.Global.GetSceneManager().SetSoundSeMuteFlag(this._soundSeMuteToggle.isOn);

        if (this._soundSeMuteToggle.isOn) {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
        } else {
            UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
        }

        this.SetSoundSeMuteFlag(this._soundSeMuteToggle.isOn);

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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        UnityBase.Global.systemConfigFile.data.systemLanguageType = this._languageType;
        UnityBase.Global.systemConfigFile.data.soundBgmVolume = this._soundBgmVolume;
        UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag = this._soundBgmMuteFlag;
        UnityBase.Global.systemConfigFile.data.soundSeVolume = this._soundSeVolume;
        UnityBase.Global.systemConfigFile.data.soundSeMuteFlag = this._soundSeMuteFlag;

        UnityBase.Global.systemConfigFile.Write(true);

        if (this._restartFlag != 0U) {
            UnityBase.Global.GetSceneManager().StartMainScene();
        }

        this._onCloseStage(this);

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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        UnityBase.Global.GetSceneManager().SetSoundBgmVolume(UnityBase.Global.systemConfigFile.data.soundBgmVolume);
        UnityBase.Global.GetSceneManager().SetSoundBgmMuteFlag(UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag);
        UnityBase.Global.GetSceneManager().SetSoundSeVolume(UnityBase.Global.systemConfigFile.data.soundSeVolume);
        UnityBase.Global.GetSceneManager().SetSoundSeMuteFlag(UnityBase.Global.systemConfigFile.data.soundSeMuteFlag);

        this._onCloseStage(this);

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

        this._SetRestartFlag((this._languageType != UnityBase.Global.systemConfigFile.data.systemLanguageType) ? (this._restartFlag | 0x0001U) : (this._restartFlag & ~0x0001U));

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
