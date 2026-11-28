/**
 * @file
 * @brief OptionInputStageBoardNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief OptionInputStageBoardNodeScriptCreateDescクラス
 */
public class OptionInputStageBoardNodeScriptCreateDesc : StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief OptionInputStageBoardNodeScriptクラス
 */
public class OptionInputStageBoardNodeScript : StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private TMP_Text _test2DCameraNameText = null;
    [SerializeField] private TMP_Text _test2DCameraSpeedNameText = null;
    [SerializeField] private TMP_Text _test2DCameraSpeedValueText = null;
    [SerializeField] private Slider _test2DCameraSpeedSlider = null;
    [SerializeField] private TMP_Text _test2DCameraInvertXNameText = null;
    [SerializeField] private Toggle _test2DCameraInvertXToggle = null;
    [SerializeField] private TMP_Text _test2DCameraInvertYNameText = null;
    [SerializeField] private Toggle _test2DCameraInvertYToggle = null;
    [SerializeField] private TMP_Text _test3DCameraNameText = null;
    [SerializeField] private TMP_Text _test3DCameraSpeedNameText = null;
    [SerializeField] private TMP_Text _test3DCameraSpeedValueText = null;
    [SerializeField] private Slider _test3DCameraSpeedSlider = null;
    [SerializeField] private TMP_Text _test3DCameraInvertXNameText = null;
    [SerializeField] private Toggle _test3DCameraInvertXToggle = null;
    [SerializeField] private TMP_Text _test3DCameraInvertYNameText = null;
    [SerializeField] private Toggle _test3DCameraInvertYToggle = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new OptionInputStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private float _test2DCameraSpeed = 0.5f;
    private bool _test2DCameraInvertXFlag = false;
    private bool _test2DCameraInvertYFlag = false;
    private float _test3DCameraSpeed = 0.5f;
    private bool _test3DCameraInvertXFlag = false;
    private bool _test3DCameraInvertYFlag = true;

    /**
     * @brief _OnGetScriptType関数
     * @return script_type (script_type)
     */
    protected override ToffMonaka.Tml.Scene.SceneUtil.SCRIPT_TYPE _OnGetScriptType()
    {
        return ((ToffMonaka.Tml.Scene.SceneUtil.SCRIPT_TYPE)SceneUtil.SCRIPT_TYPE.SIDE_MENU_OPTION_INPUT_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_INPUT_STAGE);
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
        return (SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_INPUT);
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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new OptionInputStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as OptionInputStageBoardNodeScriptCreateDesc;

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

        this._SetTest2DCameraSpeed(DataUtil.systemConfigFile.data.inputTest2DCameraSpeed);
        this._SetTest2DCameraInvertXFlag(DataUtil.systemConfigFile.data.inputTest2DCameraInvertXFlag);
        this._SetTest2DCameraInvertYFlag(DataUtil.systemConfigFile.data.inputTest2DCameraInvertYFlag);
        this._SetTest3DCameraSpeed(DataUtil.systemConfigFile.data.inputTest3DCameraSpeed);
        this._SetTest3DCameraInvertXFlag(DataUtil.systemConfigFile.data.inputTest3DCameraInvertXFlag);
        this._SetTest3DCameraInvertYFlag(DataUtil.systemConfigFile.data.inputTest3DCameraInvertYFlag);

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
     * @brief _ResetText関数
     */
    protected override void _ResetText()
    {
        base._ResetText();

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OPTION) + " > " + DataUtil.GetText(DataUtil.MST_TEXT_ID.INPUT));

        this._test2DCameraNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.TEST_2D) + DataUtil.GetJoinSpaceText() + DataUtil.GetText(DataUtil.MST_TEXT_ID.CAMERA));
        this._test2DCameraSpeedNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.SPEED));
        this._test2DCameraInvertXNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.INVERT) + DataUtil.GetJoinSpaceText() + DataUtil.GetText(DataUtil.MST_TEXT_ID.X));
        this._test2DCameraInvertYNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.INVERT) + DataUtil.GetJoinSpaceText() + DataUtil.GetText(DataUtil.MST_TEXT_ID.Y));
        this._test3DCameraNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.TEST_3D) + DataUtil.GetJoinSpaceText() + DataUtil.GetText(DataUtil.MST_TEXT_ID.CAMERA));
        this._test3DCameraSpeedNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.SPEED));
        this._test3DCameraInvertXNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.INVERT) + DataUtil.GetJoinSpaceText() + DataUtil.GetText(DataUtil.MST_TEXT_ID.X));
        this._test3DCameraInvertYNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.INVERT) + DataUtil.GetJoinSpaceText() + DataUtil.GetText(DataUtil.MST_TEXT_ID.Y));

        this._okButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.CANCEL));

        return;
    }

    /**
     * @brief OnTest2DCameraSpeedSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnTest2DCameraSpeedSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._test2DCameraSpeed;

        this._SetTest2DCameraSpeed(this._test2DCameraSpeedSlider.value / 10.0f);

        if (this._test2DCameraSpeed != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnTest2DCameraSpeedSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnTest2DCameraSpeedSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetTest2DCameraSpeed(System.Math.Max(this._test2DCameraSpeed - 0.1f, 0.1f));

        return;
    }

    /**
     * @brief OnTest2DCameraSpeedSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnTest2DCameraSpeedSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetTest2DCameraSpeed(System.Math.Min(this._test2DCameraSpeed + 0.1f, 1.0f));

        return;
    }

    /**
     * @brief OnTest2DCameraInvertXToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnTest2DCameraInvertXToggleValueChanged(bool event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (this._test2DCameraInvertXToggle.isOn) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        } else {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.CANCEL);
        }

        this._SetTest2DCameraInvertXFlag(this._test2DCameraInvertXToggle.isOn);

        return;
    }

    /**
     * @brief OnTest2DCameraInvertYToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnTest2DCameraInvertYToggleValueChanged(bool event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (this._test2DCameraInvertYToggle.isOn) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        } else {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.CANCEL);
        }

        this._SetTest2DCameraInvertYFlag(this._test2DCameraInvertYToggle.isOn);

        return;
    }

    /**
     * @brief OnTest3DCameraSpeedSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnTest3DCameraSpeedSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._test3DCameraSpeed;

        this._SetTest3DCameraSpeed(this._test3DCameraSpeedSlider.value / 10.0f);

        if (this._test3DCameraSpeed != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnTest3DCameraSpeedSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnTest3DCameraSpeedSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetTest3DCameraSpeed(System.Math.Max(this._test3DCameraSpeed - 0.1f, 0.1f));

        return;
    }

    /**
     * @brief OnTest3DCameraSpeedSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnTest3DCameraSpeedSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetTest3DCameraSpeed(System.Math.Min(this._test3DCameraSpeed + 0.1f, 1.0f));

        return;
    }

    /**
     * @brief OnTest3DCameraInvertXToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnTest3DCameraInvertXToggleValueChanged(bool event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (this._test3DCameraInvertXToggle.isOn) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        } else {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.CANCEL);
        }

        this._SetTest3DCameraInvertXFlag(this._test3DCameraInvertXToggle.isOn);

        return;
    }

    /**
     * @brief OnTest3DCameraInvertYToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnTest3DCameraInvertYToggleValueChanged(bool event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (this._test3DCameraInvertYToggle.isOn) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        } else {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.CANCEL);
        }

        this._SetTest3DCameraInvertYFlag(this._test3DCameraInvertYToggle.isOn);

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

        DataUtil.systemConfigFile.data.inputTest2DCameraSpeed = this._test2DCameraSpeed;
        DataUtil.systemConfigFile.data.inputTest2DCameraInvertXFlag = this._test2DCameraInvertXFlag;
        DataUtil.systemConfigFile.data.inputTest2DCameraInvertYFlag = this._test2DCameraInvertYFlag;
        DataUtil.systemConfigFile.data.inputTest3DCameraSpeed = this._test3DCameraSpeed;
        DataUtil.systemConfigFile.data.inputTest3DCameraInvertXFlag = this._test3DCameraInvertXFlag;
        DataUtil.systemConfigFile.data.inputTest3DCameraInvertYFlag = this._test3DCameraInvertYFlag;

        //DataUtil.systemConfigFile.Write(true);

        this._onCloseStageBoard(this);

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

        this._onCloseStageBoard(this);

        return;
    }

    /**
     * @brief _SetTest2DCameraSpeed関数
     * @param test_2d_camera_speed (test_2d_camera_speed)
     */
    private void _SetTest2DCameraSpeed(float test_2d_camera_speed)
    {
        this._test2DCameraSpeed = (float)System.Math.Clamp(System.Math.Round(test_2d_camera_speed, 1, System.MidpointRounding.AwayFromZero), 0.1, 1.0);

        this._test2DCameraSpeedValueText.SetText("{0}", this._test2DCameraSpeed * 10.0f);
        this._test2DCameraSpeedSlider.SetValueWithoutNotify(this._test2DCameraSpeed * 10.0f);

        return;
    }

    /**
     * @brief _SetTest2DCameraInvertXFlag関数
     * @param test_2d_camera_invert_x_flg (test_2d_camera_invert_x_flag)
     */
    private void _SetTest2DCameraInvertXFlag(bool test_2d_camera_invert_x_flg)
    {
        this._test2DCameraInvertXFlag = test_2d_camera_invert_x_flg;

        this._test2DCameraInvertXToggle.SetIsOnWithoutNotify(this._test2DCameraInvertXFlag);

        return;
    }

    /**
     * @brief _SetTest2DCameraInvertYFlag関数
     * @param test_2d_camera_invert_y_flg (test_2d_camera_invert_y_flag)
     */
    private void _SetTest2DCameraInvertYFlag(bool test_2d_camera_invert_y_flg)
    {
        this._test2DCameraInvertYFlag = test_2d_camera_invert_y_flg;

        this._test2DCameraInvertYToggle.SetIsOnWithoutNotify(this._test2DCameraInvertYFlag);

        return;
    }

    /**
     * @brief _SetTest3DCameraSpeed関数
     * @param test_3d_camera_speed (test_3d_camera_speed)
     */
    private void _SetTest3DCameraSpeed(float test_3d_camera_speed)
    {
        this._test3DCameraSpeed = (float)System.Math.Clamp(System.Math.Round(test_3d_camera_speed, 1, System.MidpointRounding.AwayFromZero), 0.1, 1.0);

        this._test3DCameraSpeedValueText.SetText("{0}", this._test3DCameraSpeed * 10.0f);
        this._test3DCameraSpeedSlider.SetValueWithoutNotify(this._test3DCameraSpeed * 10.0f);

        return;
    }

    /**
     * @brief _SetTest3DCameraInvertXFlag関数
     * @param test_3d_camera_invert_x_flg (test_3d_camera_invert_x_flag)
     */
    private void _SetTest3DCameraInvertXFlag(bool test_3d_camera_invert_x_flg)
    {
        this._test3DCameraInvertXFlag = test_3d_camera_invert_x_flg;

        this._test3DCameraInvertXToggle.SetIsOnWithoutNotify(this._test3DCameraInvertXFlag);

        return;
    }

    /**
     * @brief _SetTest3DCameraInvertYFlag関数
     * @param test_3d_camera_invert_y_flg (test_3d_camera_invert_y_flag)
     */
    private void _SetTest3DCameraInvertYFlag(bool test_3d_camera_invert_y_flg)
    {
        this._test3DCameraInvertYFlag = test_3d_camera_invert_y_flg;

        this._test3DCameraInvertYToggle.SetIsOnWithoutNotify(this._test3DCameraInvertYFlag);

        return;
    }
}
}
}
