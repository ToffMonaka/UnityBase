/**
 * @file
 * @brief MenuCheatStageScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuCheatStageScriptCreateDescクラス
 */
public class MenuCheatStageScriptCreateDesc : ToffMonaka.UnityBase.Scene.MenuStageScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuScript menuScript = null;
}

/**
 * @brief MenuCheatStageScriptクラス
 */
public class MenuCheatStageScript : ToffMonaka.UnityBase.Scene.MenuStageScript
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

    public new ToffMonaka.UnityBase.Scene.MenuCheatStageScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;
    private List<ToffMonaka.UnityBase.Scene.MenuCheatStageCommandButtonScript> _commandButtonScriptContainer = new List<ToffMonaka.UnityBase.Scene.MenuCheatStageCommandButtonScript>();
    private Sequence _openCloseSequence = null;

    /**
     * @brief コンストラクタ
     */
    public MenuCheatStageScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_CHEAT_STAGE);
        this._SetStageType(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.CHEAT);

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

        this._nameText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_NAME_ARRAY[(int)this.GetStageType()]);

        this._commandInputFieldNameText.SetText("コマンド");

        this._commandButtonNode.SetActive(false);

        {// CommandButtonScript Create
            var script = GameObject.Instantiate(this._commandButtonNode, this._commandButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuCheatStageCommandButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuCheatStageCommandButtonScriptCreateDesc();

            script_create_desc.cheatStageScript = this;
            script_create_desc.commandType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.STORAGE_DELETE;

            script.Create(script_create_desc);
            script.Open(0);

            this._commandButtonScriptContainer.Add(script);
        }

        {// CommandButtonScript Create
            var script = GameObject.Instantiate(this._commandButtonNode, this._commandButtonNode.transform.parent).GetComponent<ToffMonaka.UnityBase.Scene.MenuCheatStageCommandButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuCheatStageCommandButtonScriptCreateDesc();

            script_create_desc.cheatStageScript = this;
            script_create_desc.commandType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.LOG;

            script.Create(script_create_desc);
            script.Open(0);

            this._commandButtonScriptContainer.Add(script);
        }

        this._okButtonNameText.SetText("OK");
        this._cancelButtonNameText.SetText("キャンセル");

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuCheatStageScriptCreateDesc;

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

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(rect_transform.DOAnchorPosX(8.0f, 0.1f));
            this._openCloseSequence.SetLink(this.gameObject);

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
		switch (this.GetOpenType()) {
		case 1: {
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteOpen();
            }

			break;
		}
		default: {
            this.CompleteOpen();

			break;
		}
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

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(rect_transform.DOAnchorPosX(-rect_transform.sizeDelta.x - 8.0f, 0.1f));
            this._openCloseSequence.SetLink(this.gameObject);

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
		switch (this.GetCloseType()) {
		case 1: {
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteClose();
            }

			break;
		}
		default: {
            this.CompleteClose();

			break;
		}
		}

        return;
    }

    /**
     * @brief RunCommandButton関数
     */
    public void RunCommandButton(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE cmd_type)
    {
        var param = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_PARAMETER_ARRAY[(int)cmd_type];

        if (param.Length > 0) {
            this._commandInputField.SetTextWithoutNotify(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)cmd_type] + " " + param);
        } else {
            this._commandInputField.SetTextWithoutNotify(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)cmd_type]);
        }

        return;
    }

    /**
     * @brief OnCommandInputFieldEndEditEvent関数
     */
    public void OnCommandInputFieldEndEditEvent()
    {
        return;
    }

    /**
     * @brief OnOkButtonPointerClickEvent関数
     */
    public void OnOkButtonPointerClickEvent()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        var cmd_type = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.NONE;
        var cmd_param_ary = System.Array.Empty<string>();

        for (int command_type_i = 1; command_type_i < ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE_COUNT; ++command_type_i) {
            int cmd_func_str_index = this._commandInputField.text.IndexOf(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[command_type_i]);

            if (cmd_func_str_index >= 0) {
                cmd_type = (ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE)command_type_i;
                cmd_param_ary = this._commandInputField.text.Substring(cmd_func_str_index + ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[command_type_i].Length).Split(',');

                for (int cmd_param_i = 0; cmd_param_i < cmd_param_ary.Length; ++cmd_param_i) {
                    cmd_param_ary[cmd_param_i] = cmd_param_ary[cmd_param_i].Trim();
                }

                break;
            }
        }

		switch (cmd_type) {
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.STORAGE_DELETE: {
			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.LOG: {
            if (cmd_param_ary.Length < 1) {
    			break;
            }

            Debug.Log(cmd_param_ary[0]);

			break;
		}
		}

        this._menuScript.RunOkButton();

        return;
    }

    /**
     * @brief OnOkButtonPointerEnterEvent関数
     */
    public void OnOkButtonPointerEnterEvent()
    {
        this._okButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnOkButtonPointerExitEvent関数
     */
    public void OnOkButtonPointerExitEvent()
    {
        this._okButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief OnCancelButtonPointerClickEvent関数
     */
    public void OnCancelButtonPointerClickEvent()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.CANCEL);

        this._menuScript.RunCancelButton();

        return;
    }

    /**
     * @brief OnCancelButtonPointerEnterEvent関数
     */
    public void OnCancelButtonPointerEnterEvent()
    {
        this._cancelButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCancelButtonPointerExitEvent関数
     */
    public void OnCancelButtonPointerExitEvent()
    {
        this._cancelButtonCoverImage.gameObject.SetActive(false);

        return;
    }
}
}
