/**
 * @file
 * @brief SideMenuNodeScriptファイル
 */

using UnityEngine;
using UnityEngine.UI;
using ToffMonaka.UnityBase.Sound;

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief SideMenuNodeScriptCreateDescクラス
 */
public class SideMenuNodeScriptCreateDesc : ToffMonaka.Tml.Scene.NodeScriptCreateDesc
{
}

/**
 * @brief SideMenuNodeScriptクラス
 */
public class SideMenuNodeScript : ToffMonaka.Tml.Scene.NodeScript
{
    [SerializeField] private Image _backgroundImage = null;
    [SerializeField] private OpenCloseButtonNodeScript _openCloseButtonNodeScript = null;
    [SerializeField] private SelectBoardNodeScript _selectBoardNodeScript = null;
    [SerializeField] private OptionSelect2BoardNodeScript _optionSelect2BoardNodeScript = null;
    [SerializeField] private InfoSelect2BoardNodeScript _infoSelect2BoardNodeScript = null;
    [SerializeField] private OptionSystemStageBoardNodeScript _optionSystemStageBoardNodeScript = null;
    [SerializeField] private OptionInputStageBoardNodeScript _optionInputStageBoardNodeScript = null;
    [SerializeField] private OptionGraphicStageBoardNodeScript _optionGraphicStageBoardNodeScript = null;
    [SerializeField] private OptionSoundStageBoardNodeScript _optionSoundStageBoardNodeScript = null;
    [SerializeField] private InfoFaqStageBoardNodeScript _infoFaqStageBoardNodeScript = null;
    [SerializeField] private InfoStaffStageBoardNodeScript _infoStaffStageBoardNodeScript = null;
    [SerializeField] private InfoLicenseStageBoardNodeScript _infoLicenseStageBoardNodeScript = null;
    [SerializeField] private InfoPrivacyPolicyStageBoardNodeScript _infoPrivacyPolicyStageBoardNodeScript = null;
    [SerializeField] private ExitStageBoardNodeScript _exitStageBoardNodeScript = null;
    [SerializeField] private CheatStageBoardNodeScript _cheatStageBoardNodeScript = null;

    public new SideMenuNodeScriptCreateDesc createDesc{get; private set;} = null;

    private BoardNodeScript _openBoardNodeScript = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SIDE_MENU_NODE);
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

        this._backgroundImage.gameObject.SetActive(false);

        {// OpenCloseButtonNodeScript Create
            var script = this._openCloseButtonNodeScript;
            var script_create_desc = new OpenCloseButtonNodeScriptCreateDesc();

            script_create_desc.onClick = (owner) =>
            {
                if (!this._backgroundImage.gameObject.activeSelf) {
                    this._backgroundImage.gameObject.SetActive(true);

                    this.OpenBoard(SceneUtil.SIDE_MENU_BOARD_TYPE.SELECT);

                    SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.OK2);
                } else {
                    this._backgroundImage.gameObject.SetActive(false);

                    this.CloseBoard();

                    SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);
                }

                return;
            };

            script.Create(script_create_desc);
            script.Open(1);
        }

        {// SelectBoardNodeScript Create
            var script = this._selectBoardNodeScript;
            var script_create_desc = new SelectBoardNodeScriptCreateDesc();

            script_create_desc.onOpenSelect2Board = (owner, select2_board_type) =>
            {
                this.OpenBoard(select2_board_type);

                return;
            };
            script_create_desc.onOpenStageBoard = (owner, stage_board_type) =>
            {
                this.OpenBoard(stage_board_type);

                return;
            };

            script.Create(script_create_desc);
        }

        {// OptionSelect2BoardNodeScript Create
            var script = this._optionSelect2BoardNodeScript;
            var script_create_desc = new OptionSelect2BoardNodeScriptCreateDesc();

            script_create_desc.onOpenStageBoard = (owner, stage_board_type) =>
            {
                this.OpenBoard(stage_board_type);

                return;
            };
            script_create_desc.onCloseSelect2Board = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_BOARD_TYPE.SELECT);

                return;
            };

            script.Create(script_create_desc);
        }

        {// InfoSelect2BoardNodeScript Create
            var script = this._infoSelect2BoardNodeScript;
            var script_create_desc = new InfoSelect2BoardNodeScriptCreateDesc();

            script_create_desc.onOpenStageBoard = (owner, stage_board_type) =>
            {
                this.OpenBoard(stage_board_type);

                return;
            };
            script_create_desc.onCloseSelect2Board = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_BOARD_TYPE.SELECT);

                return;
            };

            script.Create(script_create_desc);
        }

        {// OptionSystemStageBoardNodeScript Create
            var script = this._optionSystemStageBoardNodeScript;
            var script_create_desc = new OptionSystemStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);
        }

        {// OptionInputStageBoardNodeScript Create
            var script = this._optionInputStageBoardNodeScript;
            var script_create_desc = new OptionInputStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);
        }

        {// OptionGraphicStageBoardNodeScript Create
            var script = this._optionGraphicStageBoardNodeScript;
            var script_create_desc = new OptionGraphicStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);
        }

        {// OptionSoundStageBoardNodeScript Create
            var script = this._optionSoundStageBoardNodeScript;
            var script_create_desc = new OptionSoundStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);
        }

        {// InfoFaqStageBoardNodeScript Create
            var script = this._infoFaqStageBoardNodeScript;
            var script_create_desc = new InfoFaqStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);
        }

        {// InfoStaffStageBoardNodeScript Create
            var script = this._infoStaffStageBoardNodeScript;
            var script_create_desc = new InfoStaffStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);
        }

        {// InfoLicenseStageBoardNodeScript Create
            var script = this._infoLicenseStageBoardNodeScript;
            var script_create_desc = new InfoLicenseStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);
        }

        {// InfoPrivacyPolicyStageBoardNodeScript Create
            var script = this._infoPrivacyPolicyStageBoardNodeScript;
            var script_create_desc = new InfoPrivacyPolicyStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);
        }

        {// ExitStageBoardNodeScript Create
            var script = this._exitStageBoardNodeScript;
            var script_create_desc = new ExitStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_BOARD_TYPE.SELECT);

                return;
            };

            script.Create(script_create_desc);
        }

        {// CheatStageBoardNodeScript Create
            var script = this._cheatStageBoardNodeScript;
            var script_create_desc = new CheatStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_BOARD_TYPE.SELECT);

                return;
            };

            script.Create(script_create_desc);
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
            this.SetCreateDesc(new SideMenuNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SideMenuNodeScriptCreateDesc;

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
     * @brief OpenBoard関数
     * @param board_type (board_type)
     */
    public void OpenBoard(SceneUtil.SIDE_MENU_BOARD_TYPE board_type)
    {
        this.CloseBoard();

        BoardNodeScript[] board_node_script_ary = {
            null,
            this._selectBoardNodeScript,
            this._optionSelect2BoardNodeScript,
            this._infoSelect2BoardNodeScript,
            this._optionSystemStageBoardNodeScript,
            this._optionInputStageBoardNodeScript,
            this._optionGraphicStageBoardNodeScript,
            this._optionSoundStageBoardNodeScript,
            this._infoFaqStageBoardNodeScript,
            this._infoStaffStageBoardNodeScript,
            this._infoLicenseStageBoardNodeScript,
            this._infoPrivacyPolicyStageBoardNodeScript,
            this._exitStageBoardNodeScript,
            this._cheatStageBoardNodeScript
        };

        this._openBoardNodeScript = board_node_script_ary[(int)board_type];

        if (this._openBoardNodeScript != null) {
            this._openBoardNodeScript.Open(1);
        }

        return;
    }

    /**
     * @brief OpenBoard関数
     * @param select2_board_type (select2_board_type)
     */
    public void OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE select2_board_type)
    {
        SceneUtil.SIDE_MENU_BOARD_TYPE[] board_type_ary = {
            SceneUtil.SIDE_MENU_BOARD_TYPE.NONE,
            SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_SELECT2,
            SceneUtil.SIDE_MENU_BOARD_TYPE.INFO_SELECT2
        };

        this.OpenBoard(board_type_ary[(int)select2_board_type]);

        return;
    }

    /**
     * @brief OpenBoard関数
     * @param stage_board_type (stage_board_type)
     */
    public void OpenBoard(SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE stage_board_type)
    {
        SceneUtil.SIDE_MENU_BOARD_TYPE[] board_type_ary = {
            SceneUtil.SIDE_MENU_BOARD_TYPE.NONE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_SYSTEM_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_INPUT_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_GRAPHIC_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.OPTION_SOUND_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.INFO_FAQ_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.INFO_STAFF_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.INFO_LICENSE_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.INFO_PRIVACY_POLICY_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.EXIT_STAGE,
		    SceneUtil.SIDE_MENU_BOARD_TYPE.CHEAT_STAGE
        };

        this.OpenBoard(board_type_ary[(int)stage_board_type]);

        return;
    }

    /**
     * @brief CloseBoard関数
     */
    public void CloseBoard()
    {
        if (this._openBoardNodeScript == null) {
            return;
        }

        this._openBoardNodeScript.Close(1);

        this._openBoardNodeScript = null;

        return;
    }
}
}
}
