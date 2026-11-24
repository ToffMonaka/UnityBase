/**
 * @file
 * @brief OptionGraphicStageBoardNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief OptionGraphicStageBoardNodeScriptCreateDescクラス
 */
public class OptionGraphicStageBoardNodeScriptCreateDesc : StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief OptionGraphicStageBoardNodeScriptクラス
 */
public class OptionGraphicStageBoardNodeScript : StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private TMP_Text _vSyncNameText = null;
    [SerializeField] private Toggle _vSyncToggle = null;
    [SerializeField] private TMP_Text _frameRateNameText = null;
    [SerializeField] private TMP_Text _frameRateValueText = null;
    [SerializeField] private Slider _frameRateSlider = null;
    [SerializeField] private TMP_Text _uiMarginNameText = null;
    [SerializeField] private TMP_Text _uiMarginTopNameText = null;
    [SerializeField] private TMP_Text _uiMarginTopValueText = null;
    [SerializeField] private Slider _uiMarginTopSlider = null;
    [SerializeField] private TMP_Text _uiMarginBottomNameText = null;
    [SerializeField] private TMP_Text _uiMarginBottomValueText = null;
    [SerializeField] private Slider _uiMarginBottomSlider = null;
    [SerializeField] private TMP_Text _uiMarginLeftNameText = null;
    [SerializeField] private TMP_Text _uiMarginLeftValueText = null;
    [SerializeField] private Slider _uiMarginLeftSlider = null;
    [SerializeField] private TMP_Text _uiMarginRightNameText = null;
    [SerializeField] private TMP_Text _uiMarginRightValueText = null;
    [SerializeField] private Slider _uiMarginRightSlider = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new OptionGraphicStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private bool _vSyncFlag = true;
    private int _frameRate = 60;
    private float _uiMarginTop = 8.0f;
    private float _uiMarginBottom = 8.0f;
    private float _uiMarginLeft = 80.0f;
    private float _uiMarginRight = 80.0f;
    private bool _restartFlag = false;

    /**
     * @brief _OnGetScriptType関数
     * @return script_type (script_type)
     */
    protected override ToffMonaka.Tml.Scene.SceneUtil.SCRIPT_TYPE _OnGetScriptType()
    {
        return ((ToffMonaka.Tml.Scene.SceneUtil.SCRIPT_TYPE)SceneUtil.SCRIPT_TYPE.SIDE_MENU_OPTION_GRAPHIC_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_GRAPHIC_STAGE);
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
        return (SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_GRAPHIC);
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

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OPTION) + " > " + DataUtil.GetText(DataUtil.MST_TEXT_ID.GRAPHIC));

        this._vSyncNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.V_SYNC));
        this._frameRateNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.FRAME_RATE));
        this._uiMarginNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.UI_MARGIN));
        this._uiMarginTopNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.TOP));
        this._uiMarginBottomNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.BOTTOM));
        this._uiMarginLeftNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.LEFT));
        this._uiMarginRightNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.RIGHT));

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
            this.SetCreateDesc(new OptionGraphicStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as OptionGraphicStageBoardNodeScriptCreateDesc;

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

        this._SetVSyncFlag(DataUtil.systemConfigFile.data.graphicVSyncFlag);
        this._SetFrameRate(DataUtil.systemConfigFile.data.graphicFrameRate);
        this._SetUiMarginTop(DataUtil.systemConfigFile.data.graphicUiMarginTop);
        this._SetUiMarginBottom(DataUtil.systemConfigFile.data.graphicUiMarginBottom);
        this._SetUiMarginLeft(DataUtil.systemConfigFile.data.graphicUiMarginLeft);
        this._SetUiMarginRight(DataUtil.systemConfigFile.data.graphicUiMarginRight);

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
     * @brief OnVSyncToggleValueChanged関数
     * @param event_val (event_value)
     */
    public void OnVSyncToggleValueChanged(bool event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        if (this._vSyncToggle.isOn) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        } else {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.CANCEL);
        }

        this._SetVSyncFlag(this._vSyncToggle.isOn);

        return;
    }

    /**
     * @brief OnFrameRateSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnFrameRateSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._frameRate;

        this._SetFrameRate((int)this._frameRateSlider.value);

        if (this._frameRate != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnFrameRateSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnFrameRateSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetFrameRate(System.Math.Max(this._frameRate - 30, 30));

        return;
    }

    /**
     * @brief OnFrameRateSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnFrameRateSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetFrameRate(System.Math.Min(this._frameRate + 30, 120));

        return;
    }

    /**
     * @brief OnUiMarginTopSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnUiMarginTopSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._uiMarginTop;

        this._SetUiMarginTop(this._uiMarginTopSlider.value);

        if (this._uiMarginTop != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnUiMarginTopSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnUiMarginTopSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetUiMarginTop(System.Math.Max(this._uiMarginTop - 1.0f, 0.0f));

        return;
    }

    /**
     * @brief OnUiMarginTopSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnUiMarginTopSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetUiMarginTop(System.Math.Min(this._uiMarginTop + 1.0f, 100.0f));

        return;
    }

    /**
     * @brief OnUiMarginBottomSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnUiMarginBottomSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._uiMarginBottom;

        this._SetUiMarginBottom(this._uiMarginBottomSlider.value);

        if (this._uiMarginBottom != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnUiMarginBottomSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnUiMarginBottomSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetUiMarginBottom(System.Math.Max(this._uiMarginBottom - 1.0f, 0.0f));

        return;
    }

    /**
     * @brief OnUiMarginBottomSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnUiMarginBottomSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetUiMarginBottom(System.Math.Min(this._uiMarginBottom + 1.0f, 100.0f));

        return;
    }

    /**
     * @brief OnUiMarginLeftSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnUiMarginLeftSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._uiMarginLeft;

        this._SetUiMarginLeft(this._uiMarginLeftSlider.value);

        if (this._uiMarginLeft != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnUiMarginLeftSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnUiMarginLeftSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetUiMarginLeft(System.Math.Max(this._uiMarginLeft - 1.0f, 0.0f));

        return;
    }

    /**
     * @brief OnUiMarginLeftSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnUiMarginLeftSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetUiMarginLeft(System.Math.Min(this._uiMarginLeft + 1.0f, 100.0f));

        return;
    }

    /**
     * @brief OnUiMarginRightSliderValueChanged関数
     * @param event_val (event_value)
     */
    public void OnUiMarginRightSliderValueChanged(float event_val)
    {
        if (!this.IsControllable()) {
            return;
        }

        var old_val = this._uiMarginRight;

        this._SetUiMarginRight(this._uiMarginRightSlider.value);

        if (this._uiMarginRight != old_val) {
            SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);
        }

        return;
    }

    /**
     * @brief OnUiMarginRightSliderLeftButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnUiMarginRightSliderLeftButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetUiMarginRight(System.Math.Max(this._uiMarginRight - 1.0f, 0.0f));

        return;
    }

    /**
     * @brief OnUiMarginRightSliderRightButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnUiMarginRightSliderRightButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SceneUtil.SOUND_SE_INDEX.OK2);

        this._SetUiMarginRight(System.Math.Min(this._uiMarginRight + 1.0f, 100.0f));

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

        DataUtil.systemConfigFile.data.graphicVSyncFlag = this._vSyncFlag;
        DataUtil.systemConfigFile.data.graphicFrameRate = this._frameRate;
        DataUtil.systemConfigFile.data.graphicUiMarginTop = this._uiMarginTop;
        DataUtil.systemConfigFile.data.graphicUiMarginBottom = this._uiMarginBottom;
        DataUtil.systemConfigFile.data.graphicUiMarginLeft = this._uiMarginLeft;
        DataUtil.systemConfigFile.data.graphicUiMarginRight = this._uiMarginRight;

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

        this._onCloseStageBoard(this);

        return;
    }

    /**
     * @brief _SetVSyncFlag関数
     * @param v_sync_flg (v_sync_flag)
     */
    private void _SetVSyncFlag(bool v_sync_flg)
    {
        this._vSyncFlag = v_sync_flg;

        this._vSyncToggle.SetIsOnWithoutNotify(this._vSyncFlag);

        return;
    }

    /**
     * @brief _SetFrameRate関数
     * @param frame_rate (frame_rate)
     */
    private void _SetFrameRate(int frame_rate)
    {
        this._frameRate = System.Math.Clamp((int)(System.Math.Round(frame_rate / 30.0, System.MidpointRounding.AwayFromZero) * 30.0), 30, 120);

        this._frameRateValueText.SetText("{0}", this._frameRate);
        this._frameRateSlider.SetValueWithoutNotify(this._frameRate);

        return;
    }

    /**
     * @brief _SetUiMarginTop関数
     * @param ui_margin_top (ui_margin_top)
     */
    private void _SetUiMarginTop(float ui_margin_top)
    {
        this._uiMarginTop = (float)System.Math.Clamp(System.Math.Round(ui_margin_top, 0, System.MidpointRounding.AwayFromZero), 0.0, 100.0);

        this._uiMarginTopValueText.SetText("{0}", this._uiMarginTop);
        this._uiMarginTopSlider.SetValueWithoutNotify(this._uiMarginTop);

        return;
    }

    /**
     * @brief _SetUiMarginBottom関数
     * @param ui_margin_bottom (ui_margin_bottom)
     */
    private void _SetUiMarginBottom(float ui_margin_bottom)
    {
        this._uiMarginBottom = (float)System.Math.Clamp(System.Math.Round(ui_margin_bottom, 0, System.MidpointRounding.AwayFromZero), 0.0, 100.0);

        this._uiMarginBottomValueText.SetText("{0}", this._uiMarginBottom);
        this._uiMarginBottomSlider.SetValueWithoutNotify(this._uiMarginBottom);

        return;
    }

    /**
     * @brief _SetUiMarginLeft関数
     * @param ui_margin_left (ui_margin_left)
     */
    private void _SetUiMarginLeft(float ui_margin_left)
    {
        this._uiMarginLeft = (float)System.Math.Clamp(System.Math.Round(ui_margin_left, 0, System.MidpointRounding.AwayFromZero), 0.0, 100.0);

        this._uiMarginLeftValueText.SetText("{0}", this._uiMarginLeft);
        this._uiMarginLeftSlider.SetValueWithoutNotify(this._uiMarginLeft);

        return;
    }

    /**
     * @brief _SetUiMarginRight関数
     * @param ui_margin_right (ui_margin_right)
     */
    private void _SetUiMarginRight(float ui_margin_right)
    {
        this._uiMarginRight = (float)System.Math.Clamp(System.Math.Round(ui_margin_right, 0, System.MidpointRounding.AwayFromZero), 0.0, 100.0);

        this._uiMarginRightValueText.SetText("{0}", this._uiMarginRight);
        this._uiMarginRightSlider.SetValueWithoutNotify(this._uiMarginRight);

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
