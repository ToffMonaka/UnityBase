/**
 * @file
 * @brief MenuCheatStageNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuCheatStageNodeScriptCreateDescクラス
 */
public class MenuCheatStageNodeScriptCreateDesc : UnityBase.Scene.Ui.MenuStageNodeScriptCreateDesc
{
}

/**
 * @brief MenuCheatStageNodeScriptクラス
 */
public class MenuCheatStageNodeScript : UnityBase.Scene.Ui.MenuStageNodeScript
{
    [SerializeField] private TMP_Text _commandNameText = null;
    [SerializeField] private TMP_InputField _commandInputField = null;
    [SerializeField] private ScrollRect _commandScrollRect = null;
    [SerializeField] private GameObject _commandButtonNode = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.Ui.MenuCheatStageNodeScriptCreateDesc createDesc{get; private set;} = null;

    private List<UnityBase.Scene.Ui.MenuCheatStageCommandButtonNodeScript> _commandButtonNodeScriptContainer = new List<UnityBase.Scene.Ui.MenuCheatStageCommandButtonNodeScript>();

    /**
     * @brief コンストラクタ
     */
    public MenuCheatStageNodeScript() : base((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.MENU_CHEAT_STAGE)
    {
        this._SetStageType(UnityBase.Util.SCENE.MENU_STAGE_TYPE.CHEAT);

        return;
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

        this._commandNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.COMMAND));

        this._commandButtonNode.SetActive(false);

        {// CommandButtonNodeScript Create
            var script = GameObject.Instantiate(this._commandButtonNode, this._commandButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.MenuCheatStageCommandButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuCheatStageCommandButtonNodeScriptCreateDesc();

            script_create_desc.stageNodeScript = this;
            script_create_desc.commandType = UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.DATA_DELETE;

            script.Create(script_create_desc);
            script.Open(0);

            this._commandButtonNodeScriptContainer.Add(script);
        }

        this._okButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuCheatStageNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._commandInputField.SetTextWithoutNotify("");
        this._commandScrollRect.verticalNormalizedPosition = 1.0f;
        this._okButtonCoverImage.gameObject.SetActive(false);
        this._cancelButtonCoverImage.gameObject.SetActive(false);

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
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        base._OnUpdateOpen();

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
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        base._OnUpdateClose();

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

        var cmd_type = UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.NONE;
        var cmd_param_ary = System.Array.Empty<string>();

        for (int command_type_i = 1; command_type_i < UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE_COUNT; ++command_type_i) {
            int cmd_func_str_index = this._commandInputField.text.IndexOf(UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[command_type_i]);

            if (cmd_func_str_index >= 0) {
                cmd_type = (UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE)command_type_i;
                cmd_param_ary = this._commandInputField.text.Substring(cmd_func_str_index + UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[command_type_i].Length).Split(',');

                for (int cmd_param_i = 0; cmd_param_i < cmd_param_ary.Length; ++cmd_param_i) {
                    cmd_param_ary[cmd_param_i] = cmd_param_ary[cmd_param_i].Trim();
                }

                break;
            }
        }

		switch (cmd_type) {
		case UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.DATA_DELETE: {
			break;
		}
		}

        this.GetMenuNodeScript().RunStageOkButton();

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

        this.GetMenuNodeScript().RunStageCancelButton();

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
     * @brief RunCommandButton関数
     */
    public void RunCommandButton(UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE cmd_type)
    {
        var param = UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_PARAMETER_ARRAY[(int)cmd_type];

        if (param.Length > 0) {
            this._commandInputField.SetTextWithoutNotify(UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)cmd_type] + " " + param);
        } else {
            this._commandInputField.SetTextWithoutNotify(UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)cmd_type]);
        }

        return;
    }
}
}
}
