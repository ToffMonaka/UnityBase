/**
 * @file
 * @brief OptionSoundStageBoardNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief OptionSoundStageBoardNodeScriptCreateDescクラス
 */
public class OptionSoundStageBoardNodeScriptCreateDesc : StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief OptionSoundStageBoardNodeScriptクラス
 */
public class OptionSoundStageBoardNodeScript : StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private TMP_Text _bgmVolumeNameText = null;
    [SerializeField] private TMP_Text _bgmVolumeValueText = null;
    [SerializeField] private Slider _bgmVolumeSlider = null;
    [SerializeField] private TMP_Text _seVolumeNameText = null;
    [SerializeField] private TMP_Text _seVolumeValueText = null;
    [SerializeField] private Slider _seVolumeSlider = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new OptionSoundStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private float _bgmVolume = 0.5f;
    private float _seVolume = 0.5f;
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

        this._bgmVolumeNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.BGM) + DataUtil.GetJoinSpaceText() + DataUtil.GetText(DataUtil.MST_TEXT_ID.VOLUME));
        this._seVolumeNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.SE) + DataUtil.GetJoinSpaceText() + DataUtil.GetText(DataUtil.MST_TEXT_ID.VOLUME));

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
            this.SetCreateDesc(new OptionSoundStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as OptionSoundStageBoardNodeScriptCreateDesc;

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

        this._SetBgmVolume(DataUtil.systemConfigFile.data.soundBgmVolume);
        this._SetSeVolume(DataUtil.systemConfigFile.data.soundSeVolume);

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
     * @brief OnBgmVolumeSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnBgmVolumeSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._bgmVolume;

        this._SetBgmVolume(this._bgmVolumeSlider.value / 10.0f);

        SceneUtil.GetManager().SetSoundBgmVolume(this._bgmVolume);

        if (this._bgmVolume != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnBgmVolumeSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnBgmVolumeSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetBgmVolume(System.Math.Max(this._bgmVolume - 0.1f, 0.0f));

        SceneUtil.GetManager().SetSoundBgmVolume(this._bgmVolume);

        return;
    }

    /**
     * @brief OnBgmVolumeSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnBgmVolumeSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetBgmVolume(System.Math.Min(this._bgmVolume + 0.1f, 1.0f));

        SceneUtil.GetManager().SetSoundBgmVolume(this._bgmVolume);

        return;
    }

    /**
     * @brief OnSeVolumeSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnSeVolumeSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._seVolume;

        this._SetSeVolume(this._seVolumeSlider.value / 10.0f);
     
        SceneUtil.GetManager().SetSoundSeVolume(this._seVolume);

        if (this._seVolume != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnSeVolumeSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnSeVolumeSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetSeVolume(System.Math.Max(this._seVolume - 0.1f, 0.0f));

        SceneUtil.GetManager().SetSoundSeVolume(this._seVolume);

        return;
    }

    /**
     * @brief OnSeVolumeSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnSeVolumeSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetSeVolume(System.Math.Min(this._seVolume + 0.1f, 1.0f));

        SceneUtil.GetManager().SetSoundSeVolume(this._seVolume);

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

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        DataUtil.systemConfigFile.data.soundBgmVolume = this._bgmVolume;
        DataUtil.systemConfigFile.data.soundSeVolume = this._seVolume;

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

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.CANCEL);

        SceneUtil.GetManager().SetSoundBgmVolume(DataUtil.systemConfigFile.data.soundBgmVolume);
        SceneUtil.GetManager().SetSoundSeVolume(DataUtil.systemConfigFile.data.soundSeVolume);

        this._onCloseStageBoard(this);

        return;
    }

    /**
     * @brief _SetBgmVolume関数
     * @param bgm_vol (bgm_volume)
     */
    private void _SetBgmVolume(float bgm_vol)
    {
        this._bgmVolume = (float)System.Math.Clamp(System.Math.Round(bgm_vol, 1, System.MidpointRounding.AwayFromZero), 0.0, 1.0);

        this._bgmVolumeValueText.SetText((this._bgmVolume * 10.0f).ToString());
        this._bgmVolumeSlider.SetValueWithoutNotify(this._bgmVolume * 10.0f);

        return;
    }

    /**
     * @brief _SetSeVolume関数
     * @param se_vol (se_volume)
     */
    private void _SetSeVolume(float se_vol)
    {
        this._seVolume = (float)System.Math.Clamp(System.Math.Round(se_vol, 1, System.MidpointRounding.AwayFromZero), 0.0, 1.0);

        this._seVolumeValueText.SetText((this._seVolume * 10.0f).ToString());
        this._seVolumeSlider.SetValueWithoutNotify(this._seVolume * 10.0f);

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
