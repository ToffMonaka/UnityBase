/**
 * @file
 * @brief NodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief NodeScriptCreateDescクラス
 */
public class NodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
}

/**
 * @brief NodeScriptクラス
 */
public class NodeScript : Lib.Scene.ObjectNodeScript
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
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIDE_MENU_NODE);
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

                    this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.SELECT);

                    UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
                } else {
                    this._backgroundImage.gameObject.SetActive(false);

                    this.CloseBoard();

                    UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.SELECT);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.SELECT);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.SELECT);

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
                this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.SELECT);

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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
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
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

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
    public void OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE board_type)
    {
        this.CloseBoard();

		switch (board_type) {
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.SELECT: {
            this._openBoardNodeScript = this._selectBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_SELECT2: {
            this._openBoardNodeScript = this._optionSelect2BoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_SELECT2: {
            this._openBoardNodeScript = this._infoSelect2BoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_SYSTEM_STAGE: {
            this._optionSystemStageBoardNodeScript.SetLanguageType(UnityBase.Global.systemConfigFile.data.systemLanguageType);

            this._openBoardNodeScript = this._optionSystemStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_INPUT_STAGE: {
            this._openBoardNodeScript = this._optionInputStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_GRAPHIC_STAGE: {
            this._openBoardNodeScript = this._optionGraphicStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_SOUND_STAGE: {
            this._optionSoundStageBoardNodeScript.SetSoundBgmVolume(UnityBase.Global.systemConfigFile.data.soundBgmVolume);
            this._optionSoundStageBoardNodeScript.SetSoundBgmMuteFlag(UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag);
            this._optionSoundStageBoardNodeScript.SetSoundSeVolume(UnityBase.Global.systemConfigFile.data.soundSeVolume);
            this._optionSoundStageBoardNodeScript.SetSoundSeMuteFlag(UnityBase.Global.systemConfigFile.data.soundSeMuteFlag);

            this._openBoardNodeScript = this._optionSoundStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_FAQ_STAGE: {
            this._openBoardNodeScript = this._infoFaqStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_STAFF_STAGE: {
            this._openBoardNodeScript = this._infoStaffStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_LICENSE_STAGE: {
            this._openBoardNodeScript = this._infoLicenseStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_PRIVACY_POLICY_STAGE: {
            this._openBoardNodeScript = this._infoPrivacyPolicyStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.EXIT_STAGE: {
            this._openBoardNodeScript = this._exitStageBoardNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.CHEAT_STAGE: {
            this._openBoardNodeScript = this._cheatStageBoardNodeScript;

			break;
		}
		}

        if (this._openBoardNodeScript != null) {
            this._openBoardNodeScript.Open(1);
        }

        return;
    }

    /**
     * @brief OpenBoard関数
     * @param select2_board_type (select2_board_type)
     */
    public void OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE select2_board_type)
    {
		switch (select2_board_type) {
		case UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_SELECT2);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.INFO: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_SELECT2);

			break;
		}
		}

        return;
    }

    /**
     * @brief OpenBoard関数
     * @param stage_board_type (stage_board_type)
     */
    public void OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE stage_board_type)
    {
		switch (stage_board_type) {
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_SYSTEM: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_SYSTEM_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_INPUT: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_INPUT_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_GRAPHIC: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_GRAPHIC_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.OPTION_SOUND: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.OPTION_SOUND_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.INFO_FAQ: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_FAQ_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.INFO_STAFF: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_STAFF_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.INFO_LICENSE: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_LICENSE_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.INFO_PRIVACY_POLICY: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.INFO_PRIVACY_POLICY_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.EXIT: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.EXIT_STAGE);

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.CHEAT: {
            this.OpenBoard(UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.CHEAT_STAGE);

			break;
		}
		}

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

    /**
     * @brief ChangeStage関数
     * @param stage_type (stage_type)
     */
    /*
    public void ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE stage_type)
    {
        if (this._openStageNodeScript != null) {
            this._openStageNodeScript.Close(0);

            this._openStageNodeScript = null;
        }

		switch (stage_type) {
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.OPTION_SYSTEM: {
            this._optionStageNodeScript.SetLanguageType(UnityBase.Global.systemConfigFile.data.systemLanguageType);
            this._optionStageNodeScript.SetSoundBgmVolume(UnityBase.Global.systemConfigFile.data.soundBgmVolume);
            this._optionStageNodeScript.SetSoundBgmMuteFlag(UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag);
            this._optionStageNodeScript.SetSoundSeVolume(UnityBase.Global.systemConfigFile.data.soundSeVolume);
            this._optionStageNodeScript.SetSoundSeMuteFlag(UnityBase.Global.systemConfigFile.data.soundSeMuteFlag);

            this._openStageNodeScript = this._optionStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.INFO_FAQ: {
            this._openStageNodeScript = this._faqStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.INFO_STAFF: {
            this._openStageNodeScript = this._staffStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.INFO_LICENSE: {
            this._openStageNodeScript = this._licenseStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.INFO_PRIVACY_POLICY: {
            this._openStageNodeScript = this._privacyPolicyStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.EXIT: {
            this._openStageNodeScript = this._exitStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.CHEAT: {
            this._openStageNodeScript = this._cheatStageNodeScript;

			break;
		}
		}

        if (this._openStageNodeScript == null) {
            this._openSelectNodeScript = this._selectNodeScript;

            this._openSelectNodeScript.Open(1);

            return;
        }

        if (this._openSelectNodeScript != null) {
            this._openSelectNodeScript.Close(1);

            this._openSelectNodeScript = null;
        }

        this._openStageNodeScript.Open(1);

        return;
    }
    */
}
}
}
