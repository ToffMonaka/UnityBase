/**
 * @file
 * @brief OptionSoundStageBoardNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Sound;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief OptionSoundStageBoardNodeScriptCreateDescクラス
 */
public class OptionSoundStageBoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief OptionSoundStageBoardNodeScriptクラス
 */
public class OptionSoundStageBoardNodeScript : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
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

    public new UnityBase.Scene.Ui.Menu.Side.OptionSoundStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private float _soundBgmVolume = 1.0f;
    private bool _soundBgmMuteFlag = false;
    private float _soundSeVolume = 1.0f;
    private bool _soundSeMuteFlag = false;
    private bool _restartFlag = false;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SIDE_MENU_OPTION_SOUND_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_SOUND_STAGE);
    }

    /**
     * @brief _OnGetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    protected override SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE _OnGetSelect2BoardType()
    {
        return (SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnGetStageBoardType関数
     * @return stage_board_type (stage_board_type)
     */
    protected override SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE _OnGetStageBoardType()
    {
        return (SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_SOUND);
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

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OPTION) + " > " + DataUtil.GetText(DataUtil.MST_TEXT_ID.SOUND));

        this._soundBgmMuteNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.BGM_MUTE));
        this._soundSeMuteNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.SE_MUTE));
        this._okButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.OptionSoundStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.OptionSoundStageBoardNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

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

        this._scrollRect.verticalNormalizedPosition = 1.0f;

        this.SetSoundBgmVolume(DataUtil.systemConfigFile.data.soundBgmVolume);
        this.SetSoundBgmMuteFlag(DataUtil.systemConfigFile.data.soundBgmMuteFlag);
        this.SetSoundSeVolume(DataUtil.systemConfigFile.data.soundSeVolume);
        this.SetSoundSeMuteFlag(DataUtil.systemConfigFile.data.soundSeMuteFlag);

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

        SceneUtil.GetManager().SetSoundBgmVolume(this._soundBgmVolume);

        if (this._soundBgmVolume != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);
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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

        this.SetSoundBgmVolume(System.Math.Max(this._soundBgmVolume - 0.1f, 0.0f));

        SceneUtil.GetManager().SetSoundBgmVolume(this._soundBgmVolume);

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

        this.SetSoundBgmVolume(System.Math.Min(this._soundBgmVolume + 0.1f, 1.0f));

        SceneUtil.GetManager().SetSoundBgmVolume(this._soundBgmVolume);

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

        SceneUtil.GetManager().SetSoundBgmMuteFlag(this._soundBgmMuteToggle.isOn);

        if (this._soundBgmMuteToggle.isOn) {
            SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);
        } else {
            SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);
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
     
        SceneUtil.GetManager().SetSoundSeVolume(this._soundSeVolume);

        if (this._soundSeVolume != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);
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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

        this.SetSoundSeVolume(System.Math.Max(this._soundSeVolume - 0.1f, 0.0f));

        SceneUtil.GetManager().SetSoundSeVolume(this._soundSeVolume);

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

        this.SetSoundSeVolume(System.Math.Min(this._soundSeVolume + 0.1f, 1.0f));

        SceneUtil.GetManager().SetSoundSeVolume(this._soundSeVolume);

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

        SceneUtil.GetManager().SetSoundSeMuteFlag(this._soundSeMuteToggle.isOn);

        if (this._soundSeMuteToggle.isOn) {
            SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);
        } else {
            SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);
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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

        DataUtil.systemConfigFile.data.soundBgmVolume = this._soundBgmVolume;
        DataUtil.systemConfigFile.data.soundBgmMuteFlag = this._soundBgmMuteFlag;
        DataUtil.systemConfigFile.data.soundSeVolume = this._soundSeVolume;
        DataUtil.systemConfigFile.data.soundSeMuteFlag = this._soundSeMuteFlag;

        DataUtil.systemConfigFile.Write(true);

        if (this._restartFlag) {
            SceneUtil.GetManager().StartMainScene();
        } else {
            this._onCloseStageBoard(this);
        }

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);

        SceneUtil.GetManager().SetSoundBgmVolume(DataUtil.systemConfigFile.data.soundBgmVolume);
        SceneUtil.GetManager().SetSoundBgmMuteFlag(DataUtil.systemConfigFile.data.soundBgmMuteFlag);
        SceneUtil.GetManager().SetSoundSeVolume(DataUtil.systemConfigFile.data.soundSeVolume);
        SceneUtil.GetManager().SetSoundSeMuteFlag(DataUtil.systemConfigFile.data.soundSeMuteFlag);

        this._onCloseStageBoard(this);

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

        this._soundBgmVolumeNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.BGM_VOLUME) + " " + (this._soundBgmVolume * 10.0f).ToString());
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

        this._soundSeVolumeNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.SE_VOLUME) + " " + (this._soundSeVolume * 10.0f).ToString());
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
    private void _SetRestartFlag(bool restart_flg)
    {
        this._restartFlag = restart_flg;

        if (this._restartFlag) {
            this._okButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OK) + "\n" + DataUtil.GetText(DataUtil.MST_TEXT_ID.RESTART));
            this._okButtonNameText.fontSize = 20.0f;
        } else {
            this._okButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OK));
            this._okButtonNameText.fontSize = 32.0f;
        }

        return;
    }
}
}
}
