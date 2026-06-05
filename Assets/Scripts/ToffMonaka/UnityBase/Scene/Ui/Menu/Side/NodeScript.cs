/**
 * @file
 * @brief NodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using ToffMonaka.UnityBase.Sound;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief NodeScriptCreateDescクラス
 */
public class NodeScriptCreateDesc : ToffMonaka.Tml.Scene.ObjectNodeScriptCreateDesc
{
}

/**
 * @brief NodeScriptクラス
 */
public class NodeScript : ToffMonaka.Tml.Scene.ObjectNodeScript
{
    [SerializeField] private Image _backgroundImage = null;
    [SerializeField] private GameObject _openCloseButtonNode = null;
    [SerializeField] private GameObject _selectBoardNode = null;
    [SerializeField] private GameObject _optionSelect2BoardNode = null;
    [SerializeField] private GameObject _infoSelect2BoardNode = null;
    [SerializeField] private GameObject _optionSystemStageBoardNode = null;
    [SerializeField] private GameObject _optionInputStageBoardNode = null;
    [SerializeField] private GameObject _optionGraphicStageBoardNode = null;
    [SerializeField] private GameObject _optionSoundStageBoardNode = null;
    [SerializeField] private GameObject _infoFaqStageBoardNode = null;
    [SerializeField] private GameObject _infoStaffStageBoardNode = null;
    [SerializeField] private GameObject _infoLicenseStageBoardNode = null;
    [SerializeField] private GameObject _infoPrivacyPolicyStageBoardNode = null;
    [SerializeField] private GameObject _exitStageBoardNode = null;
    [SerializeField] private GameObject _cheatStageBoardNode = null;

    public new UnityBase.Scene.Ui.Menu.Side.NodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Menu.Side.OpenCloseButtonNodeScript _openCloseButtonNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.SelectBoardNodeScript _selectBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.OptionSelect2BoardNodeScript _optionSelect2BoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.InfoSelect2BoardNodeScript _infoSelect2BoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.OptionSystemStageBoardNodeScript _optionSystemStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.OptionInputStageBoardNodeScript _optionInputStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.OptionGraphicStageBoardNodeScript _optionGraphicStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.OptionSoundStageBoardNodeScript _optionSoundStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.InfoFaqStageBoardNodeScript _infoFaqStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.InfoStaffStageBoardNodeScript _infoStaffStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.InfoLicenseStageBoardNodeScript _infoLicenseStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.InfoPrivacyPolicyStageBoardNodeScript _infoPrivacyPolicyStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.ExitStageBoardNodeScript _exitStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.CheatStageBoardNodeScript _cheatStageBoardNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.BoardNodeScript _openBoardNodeScript = null;

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
            var script = this._openCloseButtonNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.OpenCloseButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.OpenCloseButtonNodeScriptCreateDesc();

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

            this._openCloseButtonNodeScript = script;
        }

        {// SelectBoardNodeScript Create
            var script = this._selectBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.SelectBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.SelectBoardNodeScriptCreateDesc();

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

            this._selectBoardNodeScript = script;
        }

        {// OptionSelect2BoardNodeScript Create
            var script = this._optionSelect2BoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.OptionSelect2BoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.OptionSelect2BoardNodeScriptCreateDesc();

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

            this._optionSelect2BoardNodeScript = script;
        }

        {// InfoSelect2BoardNodeScript Create
            var script = this._infoSelect2BoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.InfoSelect2BoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.InfoSelect2BoardNodeScriptCreateDesc();

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

            this._infoSelect2BoardNodeScript = script;
        }

        {// OptionSystemStageBoardNodeScript Create
            var script = this._optionSystemStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.OptionSystemStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.OptionSystemStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);

            this._optionSystemStageBoardNodeScript = script;
        }

        {// OptionInputStageBoardNodeScript Create
            var script = this._optionInputStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.OptionInputStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.OptionInputStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);

            this._optionInputStageBoardNodeScript = script;
        }

        {// OptionGraphicStageBoardNodeScript Create
            var script = this._optionGraphicStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.OptionGraphicStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.OptionGraphicStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);

            this._optionGraphicStageBoardNodeScript = script;
        }

        {// OptionSoundStageBoardNodeScript Create
            var script = this._optionSoundStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.OptionSoundStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.OptionSoundStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);

            this._optionSoundStageBoardNodeScript = script;
        }

        {// InfoFaqStageBoardNodeScript Create
            var script = this._infoFaqStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.InfoFaqStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.InfoFaqStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);

            this._infoFaqStageBoardNodeScript = script;
        }

        {// InfoStaffStageBoardNodeScript Create
            var script = this._infoStaffStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.InfoStaffStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.InfoStaffStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);

            this._infoStaffStageBoardNodeScript = script;
        }

        {// InfoLicenseStageBoardNodeScript Create
            var script = this._infoLicenseStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.InfoLicenseStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.InfoLicenseStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);

            this._infoLicenseStageBoardNodeScript = script;
        }

        {// InfoPrivacyPolicyStageBoardNodeScript Create
            var script = this._infoPrivacyPolicyStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.InfoPrivacyPolicyStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.InfoPrivacyPolicyStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);

            this._infoPrivacyPolicyStageBoardNodeScript = script;
        }

        {// ExitStageBoardNodeScript Create
            var script = this._exitStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.ExitStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.ExitStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_BOARD_TYPE.SELECT);

                return;
            };

            script.Create(script_create_desc);

            this._exitStageBoardNodeScript = script;
        }

        {// CheatStageBoardNodeScript Create
            var script = this._cheatStageBoardNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.CheatStageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.CheatStageBoardNodeScriptCreateDesc();

            script_create_desc.onCloseStageBoard = (owner) =>
            {
                this.OpenBoard(SceneUtil.SIDE_MENU_BOARD_TYPE.SELECT);

                return;
            };

            script.Create(script_create_desc);

            this._cheatStageBoardNodeScript = script;
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
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.NodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.NodeScriptCreateDesc;

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

        UnityBase.Scene.Ui.Menu.Side.BoardNodeScript[] board_node_script_ary = {
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
