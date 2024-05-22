/**
 * @file
 * @brief CheatStageNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief CheatStageNodeScriptCreateDescクラス
 */
public class CheatStageNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.StageNodeScriptCreateDesc
{
}

/**
 * @brief CheatStageNodeScriptクラス
 */
public class CheatStageNodeScript : UnityBase.Scene.Ui.Menu.StageNodeScript
{
    [SerializeField] private TMP_Text _commandNameText = null;
    [SerializeField] private TMP_Text _commandResultText = null;
    [SerializeField] private TMP_InputField _commandInputField = null;
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private GameObject _itemNode = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.Menu.CheatStageNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Menu.CheatCommand _cheatCommand = new UnityBase.Scene.Ui.Menu.CheatCommand("");
    private UnityBase.Scene.Ui.Menu.CheatCommandCalculateOption _cheatCommandCalculateOption = new UnityBase.Scene.Ui.Menu.CheatCommandCalculateOption();
    private double _calculateValue = 0.0;
    private int _calculateResultValue = 0;
    private List<UnityBase.Scene.Ui.Menu.CheatStageItemNodeScript> _itemNodeScriptContainer = new List<UnityBase.Scene.Ui.Menu.CheatStageItemNodeScript>();

    /**
     * @brief コンストラクタ
     */
    public CheatStageNodeScript() : base(UnityBase.Util.SCENE.MENU_STAGE_TYPE.CHEAT)
    {
        return;
    }
    
    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_CHEAT_STAGE_NODE);
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

        this._commandNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.COMMAND));
        this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        this._itemNode.SetActive(false);

        {// ItemNodeScript Create
            UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE[] add_code_type_ary = {
                UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE.FUNCTION_DELETE_DATA
            };

            void on_click(UnityBase.Scene.Ui.Menu.CheatStageItemNodeScript owner)
            {
                if (this._cheatCommand.GetCode().Length <= 0) {
                    this.SetCheatCommand(UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TEXT_ARRAY[(int)owner.GetAddCodeType()] + ";");
                } else {
                    this.SetCheatCommand(this._cheatCommand.GetCode() + " " + UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TEXT_ARRAY[(int)owner.GetAddCodeType()] + ";");
                }

                return;
            }

            foreach (var add_code_type in add_code_type_ary) {
                var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Ui.Menu.CheatStageItemNodeScript>();
                var script_create_desc = new UnityBase.Scene.Ui.Menu.CheatStageItemNodeScriptCreateDesc();

                script_create_desc.addCodeType = add_code_type;
                script_create_desc.onClick = on_click;

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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.CheatStageNodeScriptCreateDesc;

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
        this._okButtonCoverImage.gameObject.SetActive(false);
        this._cancelButtonCoverImage.gameObject.SetActive(false);

        this.SetCheatCommand("");
        this._cheatCommandCalculateOption.Init();

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

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this._cheatCommand.Calculate(out this._calculateValue, this._cheatCommandCalculateOption, false);

        this.GetMenuNodeScript().ChangeStage(UnityBase.Util.SCENE.MENU_STAGE_TYPE.NONE);

        return;
    }

    /**
     * @brief OnOkButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._okButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnOkButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnOkButtonPointerExit(PointerEventData event_dat)
    {
        this._okButtonCoverImage.gameObject.SetActive(false);

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

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this.GetMenuNodeScript().ChangeStage(UnityBase.Util.SCENE.MENU_STAGE_TYPE.NONE);

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCancelButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnCancelButtonPointerExit(PointerEventData event_dat)
    {
        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief GetCheatCommand関数
     * @return cheat_cmd (cheat_command)
     */
    public UnityBase.Scene.Ui.Menu.CheatCommand GetCheatCommand()
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
        } else {

        }

        this._commandResultText.SetText("GOOD");
        this._commandResultText.color = new UnityEngine.Color(8.0f / 255.0f, 252.0f / 255.0f, 8.0f / 255.0f, 1.0f);

        return;
    }
}
}
}
