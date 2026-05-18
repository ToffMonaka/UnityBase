/**
 * @file
 * @brief CheatStageBoardNodeScriptファイル
 */


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief CheatStageBoardNodeScriptCreateDescクラス
 */
public class CheatStageBoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc
{
}

/**
 * @brief CheatStageBoardNodeScriptクラス
 */
public class CheatStageBoardNodeScript : UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScript
{
    [SerializeField] private TMP_Text _commandNameText = null;
    [SerializeField] private TMP_Text _commandResultText = null;
    [SerializeField] private TMP_InputField _commandInputField = null;
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private GameObject _itemNode = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;

    public new UnityBase.Scene.Ui.Menu.Side.CheatStageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Menu.Side.CheatCommand _cheatCommand = new UnityBase.Scene.Ui.Menu.Side.CheatCommand("");
    private UnityBase.Scene.Ui.Menu.Side.CheatCommandCalculateOption _cheatCommandCalculateOption = new UnityBase.Scene.Ui.Menu.Side.CheatCommandCalculateOption();
    private double _calculateValue = 0.0;
    private int _calculateResultValue = 0;
    private List<UnityBase.Scene.Ui.Menu.Side.CheatStageBoardItemNodeScript> _itemNodeScriptContainer = new List<UnityBase.Scene.Ui.Menu.Side.CheatStageBoardItemNodeScript>();

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIDE_MENU_CHEAT_STAGE_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (UnityBase.Util.SCENE.SIDE_MENU_BOARD_TYPE.CHEAT_STAGE);
    }

    /**
     * @brief _OnGetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    protected override UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE _OnGetSelect2BoardType()
    {
        return (UnityBase.Util.SCENE.SIDE_MENU_SELECT2_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnGetStageBoardType関数
     * @return stage_board_type (stage_board_type)
     */
    protected override UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE _OnGetStageBoardType()
    {
        return (UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE.CHEAT);
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

        this._nameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CHEAT));

        this._commandNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.COMMAND));
        this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        this._itemNode.SetActive(false);

        {// ItemNodeScript Create
            UnityBase.Scene.Ui.Menu.Side.CheatCommandUtil.ADD_CODE_TYPE[] add_code_type_ary = {
                UnityBase.Scene.Ui.Menu.Side.CheatCommandUtil.ADD_CODE_TYPE.FUNCTION_DELETE_DATA
            };

            foreach (var add_code_type in add_code_type_ary) {
                var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Ui.Menu.Side.CheatStageBoardItemNodeScript>();
                var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.CheatStageBoardItemNodeScriptCreateDesc();

                script_create_desc.addCodeType = add_code_type;
                script_create_desc.onClick = (owner) =>
                {
                    if (this._cheatCommand.GetCode().Length <= 0) {
                        this.SetCheatCommand(UnityBase.Scene.Ui.Menu.Side.CheatCommandUtil.ADD_CODE_TEXT_ARRAY[(int)owner.GetAddCodeType()] + ";");
                    } else {
                        this.SetCheatCommand(this._cheatCommand.GetCode() + " " + UnityBase.Scene.Ui.Menu.Side.CheatCommandUtil.ADD_CODE_TEXT_ARRAY[(int)owner.GetAddCodeType()] + ";");
                    }

                    return;
                };

                script.Create(script_create_desc);
                script.Open(0);

                this._itemNodeScriptContainer.Add(script);
            }
        }

        this.SetCheatCommand(this._cheatCommand.GetCode());

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.CheatStageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.CheatStageBoardNodeScriptCreateDesc;

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

        this.SetCheatCommand("");
        this._cheatCommandCalculateOption.Init();

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
     * @brief OnCommandInputFieldEndEdit関数
     * @param event_val (event_value)
     */
    public void OnCommandInputFieldEndEdit(string event_val)
    {
        this.SetCheatCommand(this._commandInputField.text);

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

        this._cheatCommand.Calculate(out this._calculateValue, this._cheatCommandCalculateOption, false);

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

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this._onCloseStageBoard(this);

        return;
    }

    /**
     * @brief GetCheatCommand関数
     * @return cheat_cmd (cheat_command)
     */
    public UnityBase.Scene.Ui.Menu.Side.CheatCommand GetCheatCommand()
    {
        return (this._cheatCommand);
    }

    /**
     * @brief SetCheatCommand関数
     * @param code (code)
     */
    public void SetCheatCommand(string code)
    {
        this._cheatCommand.SetCode(code);

        this._commandInputField.SetTextWithoutNotify(this._cheatCommand.GetCode());

        this._calculateResultValue = this._cheatCommand.Calculate(out this._calculateValue, this._cheatCommandCalculateOption, true);

        if (this._calculateResultValue < 0) {
            this._commandResultText.SetText("BAD");
            this._commandResultText.color = new UnityEngine.Color(252.0f / 255.0f, 8.0f / 255.0f, 8.0f / 255.0f, 1.0f);

            return;
        }

        this._commandResultText.SetText("GOOD");
        this._commandResultText.color = new UnityEngine.Color(8.0f / 255.0f, 252.0f / 255.0f, 8.0f / 255.0f, 1.0f);

        return;
    }
}
}
}
