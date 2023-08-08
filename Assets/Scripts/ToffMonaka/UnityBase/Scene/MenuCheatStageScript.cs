/**
 * @file
 * @brief MenuCheatStageScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief MenuCheatStageScriptCreateDescクラス
 */
public class MenuCheatStageScriptCreateDesc : UnityBase.Scene.MenuStageScriptCreateDesc
{
    public UnityBase.Scene.MenuScript menuScript = null;
}

/**
 * @brief MenuCheatStageScriptクラス
 */
public class MenuCheatStageScript : UnityBase.Scene.MenuStageScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_InputField _commandInputField = null;
    [SerializeField] private TMP_Text _commandInputFieldNameText = null;
    [SerializeField] private ScrollRect _commandScrollRect = null;
    [SerializeField] private GameObject _commandButtonNode = null;
    [SerializeField] private TMP_Text _okButtonNameText = null;
    [SerializeField] private Image _okButtonCoverImage = null;
    [SerializeField] private TMP_Text _cancelButtonNameText = null;
    [SerializeField] private Image _cancelButtonCoverImage = null;

    public new UnityBase.Scene.MenuCheatStageScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.MenuScript _menuScript = null;
    private List<UnityBase.Scene.MenuCheatStageCommandButtonScript> _commandButtonScriptContainer = new List<UnityBase.Scene.MenuCheatStageCommandButtonScript>();

    /**
     * @brief コンストラクタ
     */
    public MenuCheatStageScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_CHEAT_STAGE);
        this._SetStageType(UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.CHEAT);

        return;
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        this._menuScript = this.createDesc.menuScript;

        this._nameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.SCENE.MENU_STAGE_NAME_MST_STRING_ID_ARRAY[(int)this.GetStageType()]));

        this._commandInputFieldNameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.MST_STRING_ID.COMMAND));

        this._commandButtonNode.SetActive(false);

        {// CommandButtonScript Create
            var script = GameObject.Instantiate(this._commandButtonNode, this._commandButtonNode.transform.parent).GetComponent<UnityBase.Scene.MenuCheatStageCommandButtonScript>();
            var script_create_desc = new UnityBase.Scene.MenuCheatStageCommandButtonScriptCreateDesc();

            script_create_desc.menuCheatStageScript = this;
            script_create_desc.commandType = UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.DATA_DELETE;

            script.Create(script_create_desc);
            script.Open(0);

            this._commandButtonScriptContainer.Add(script);
        }

        this._okButtonNameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.MST_STRING_ID.OK));
        this._cancelButtonNameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.MST_STRING_ID.CANCEL));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.MenuCheatStageScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
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
        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetOpenType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 8.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(8.0f, rect_transform.anchoredPosition.y);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteOpen();
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetCloseType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(8.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(-rect_transform.sizeDelta.x - 8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 8.0f, rect_transform.anchoredPosition.y);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteClose();
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

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        var cmd_type = UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.NONE;
        var cmd_param_ary = System.Array.Empty<string>();

        for (int command_type_i = 1; command_type_i < UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE_COUNT; ++command_type_i) {
            int cmd_func_str_index = this._commandInputField.text.IndexOf(UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[command_type_i]);

            if (cmd_func_str_index >= 0) {
                cmd_type = (UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE)command_type_i;
                cmd_param_ary = this._commandInputField.text.Substring(cmd_func_str_index + UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[command_type_i].Length).Split(',');

                for (int cmd_param_i = 0; cmd_param_i < cmd_param_ary.Length; ++cmd_param_i) {
                    cmd_param_ary[cmd_param_i] = cmd_param_ary[cmd_param_i].Trim();
                }

                break;
            }
        }

		switch (cmd_type) {
		case UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.DATA_DELETE: {
			break;
		}
		}

        this._menuScript.RunStageOkButton();

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
        if (!this.IsControllable()) {
            return;
        }

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

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        this._menuScript.RunStageCancelButton();

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
        if (!this.IsControllable()) {
            return;
        }

        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief RunCommandButton関数
     */
    public void RunCommandButton(UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE cmd_type)
    {
        var param = UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_PARAMETER_ARRAY[(int)cmd_type];

        if (param.Length > 0) {
            this._commandInputField.SetTextWithoutNotify(UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)cmd_type] + " " + param);
        } else {
            this._commandInputField.SetTextWithoutNotify(UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)cmd_type]);
        }

        return;
    }
}
}
}
