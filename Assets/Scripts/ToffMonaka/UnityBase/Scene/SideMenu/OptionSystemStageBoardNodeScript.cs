/**
 * @file
 * @brief OptionSystemStageBoardNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Data;
using ToffMonaka.UnityBase.Sound;
using ToffMonaka.UnityBase.Scene.DialogSystem;

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief OptionSystemStageBoardNodeScriptCreateDescクラス
 */
public class OptionSystemStageBoardNodeScriptCreateDesc : StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief OptionSystemStageBoardNodeScriptクラス
 */
public class OptionSystemStageBoardNodeScript : StageBoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private TMP_Text _languageNameText = null;
    [SerializeField] private TMP_Text _languageButtonNameText = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new OptionSystemStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private Util.LANGUAGE_TYPE _languageType = Util.LANGUAGE_TYPE.NONE;
    private bool _restartFlag = false;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SIDE_MENU_OPTION_SYSTEM_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_SYSTEM_STAGE);
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
        return (SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_SYSTEM);
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

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.OPTION) + " > " + DataUtil.GetText(DataUtil.MST_TEXT_ID.SYSTEM));

        this._languageNameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.LANGUAGE));
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
            this.SetCreateDesc(new OptionSystemStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as OptionSystemStageBoardNodeScriptCreateDesc;

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

        this.SetLanguageType(DataUtil.systemConfigFile.data.systemLanguageType);

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
     * @brief OnLanguageButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnLanguageButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

        {// LanguageSelectDialog Add
            var script_create_desc = new SelectDialogNodeScriptCreateDesc();

            script_create_desc.extension = new LanguageSelectDialogExtension();
            script_create_desc.onClickItem = (owner, item_node_script) =>
            {
                var item_node_script_extension = item_node_script.GetExtension() as LanguageSelectDialogItemExtension;

                this.SetLanguageType(item_node_script_extension.GetLanguageType());

                return;
            };

            var script = SceneUtil.GetSubSceneNodeScript().GetDialogSystemNodeScript().AddDialog(script_create_desc) as SelectDialogNodeScript;

            script.AddItem(new LanguageSelectDialogItemExtension(Util.LANGUAGE_TYPE.ENGLISH));
            script.AddItem(new LanguageSelectDialogItemExtension(Util.LANGUAGE_TYPE.JAPANESE));
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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);

        DataUtil.systemConfigFile.data.systemLanguageType = this._languageType;

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

        this._onCloseStageBoard(this);

        return;
    }

    /**
     * @brief GetLanguageType関数
     * @return language_type (language_type)
     */
    public Util.LANGUAGE_TYPE GetLanguageType()
    {
        return (this._languageType);
    }

    /**
     * @brief SetLanguageType関数
     * @param language_type (language_type)
     */
    public void SetLanguageType(Util.LANGUAGE_TYPE language_type)
    {
        this._languageType = language_type;

        this._languageButtonNameText.SetText(DataUtil.GetText(Util.LANGUAGE_NAME_MST_TEXT_ID_ARRAY[(int)this._languageType]));

        this._SetRestartFlag((this._languageType != DataUtil.systemConfigFile.data.systemLanguageType));

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
