﻿/**
 * @file
 * @brief MenuNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuNodeScriptCreateDescクラス
 */
public class MenuNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    public Lib.Scene.SubSceneNodeScript subSceneNodeScript = null;
}

/**
 * @brief MenuNodeScriptクラス
 */
public class MenuNodeScript : Lib.Scene.ObjectNodeScript
{
    [SerializeField] private Image _backgroundImage = null;
    [SerializeField] private GameObject _openCloseButtonNode = null;
    [SerializeField] private GameObject _selectNode = null;
    [SerializeField] private GameObject _optionStageNode = null;
    [SerializeField] private GameObject _faqStageNode = null;
    [SerializeField] private GameObject _staffStageNode = null;
    [SerializeField] private GameObject _licenseStageNode = null;
    [SerializeField] private GameObject _privacyPolicyStageNode = null;
    [SerializeField] private GameObject _endStageNode = null;
    [SerializeField] private GameObject _cheatStageNode = null;

    public new UnityBase.Scene.Ui.MenuNodeScriptCreateDesc createDesc{get; private set;} = null;

    private Lib.Scene.SubSceneNodeScript _subSceneNodeScript = null;
    private UnityBase.Scene.Ui.MenuOpenCloseButtonNodeScript _openCloseButtonNodeScript = null;
    private UnityBase.Scene.Ui.MenuSelectNodeScript _selectNodeScript = null;
    private UnityBase.Scene.Ui.MenuSelectNodeScript _openSelectNodeScript = null;
    private UnityBase.Scene.Ui.MenuOptionStageNodeScript _optionStageNodeScript = null;
    private UnityBase.Scene.Ui.MenuFaqStageNodeScript _faqStageNodeScript = null;
    private UnityBase.Scene.Ui.MenuStaffStageNodeScript _staffStageNodeScript = null;
    private UnityBase.Scene.Ui.MenuLicenseStageNodeScript _licenseStageNodeScript = null;
    private UnityBase.Scene.Ui.MenuPrivacyPolicyStageNodeScript _privacyPolicyStageNodeScript = null;
    private UnityBase.Scene.Ui.MenuEndStageNodeScript _endStageNodeScript = null;
    private UnityBase.Scene.Ui.MenuCheatStageNodeScript _cheatStageNodeScript = null;
    private UnityBase.Scene.Ui.MenuStageNodeScript _openStageNodeScript = null;

    /**
     * @brief コンストラクタ
     */
    public MenuNodeScript()
    {
        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_NODE);
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
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        this._subSceneNodeScript = this.createDesc.subSceneNodeScript;

        this._backgroundImage.gameObject.SetActive(false);

        {// OpenCloseButtonNodeScript Create
            var script = this._openCloseButtonNode.GetComponent<UnityBase.Scene.Ui.MenuOpenCloseButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuOpenCloseButtonNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._openCloseButtonNodeScript = script;
        }

        {// SelectNodeScript Create
            var script = this._selectNode.GetComponent<UnityBase.Scene.Ui.MenuSelectNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._selectNodeScript = script;
        }

        {// OptionStageNodeScript Create
            var script = this._optionStageNode.GetComponent<UnityBase.Scene.Ui.MenuOptionStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuOptionStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._optionStageNodeScript = script;
        }

        {// FaqStageNodeScript Create
            var script = this._faqStageNode.GetComponent<UnityBase.Scene.Ui.MenuFaqStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuFaqStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._faqStageNodeScript = script;
        }

        {// StaffStageNodeScript Create
            var script = this._staffStageNode.GetComponent<UnityBase.Scene.Ui.MenuStaffStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuStaffStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._staffStageNodeScript = script;
        }

        {// LicenseStageNodeScript Create
            var script = this._licenseStageNode.GetComponent<UnityBase.Scene.Ui.MenuLicenseStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuLicenseStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._licenseStageNodeScript = script;
        }

        {// PrivacyPolicyStageNodeScript Create
            var script = this._privacyPolicyStageNode.GetComponent<UnityBase.Scene.Ui.MenuPrivacyPolicyStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuPrivacyPolicyStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._privacyPolicyStageNodeScript = script;
        }

        {// EndStageNodeScript Create
            var script = this._endStageNode.GetComponent<UnityBase.Scene.Ui.MenuEndStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuEndStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._endStageNodeScript = script;
        }

        {// CheatStageNodeScript Create
            var script = this._cheatStageNode.GetComponent<UnityBase.Scene.Ui.MenuCheatStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuCheatStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._cheatStageNodeScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
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
        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief GetSubSceneNodeScript関数
     * @return sub_scene_node_script (sub_scene_node_script)
     */
    public Lib.Scene.SubSceneNodeScript GetSubSceneNodeScript()
    {
        return (this._subSceneNodeScript);
    }

    /**
     * @brief GetOpenSelectNodeScript関数
     * @return open_select_node_script (open_select_node_script)
     */
    public UnityBase.Scene.Ui.MenuSelectNodeScript GetOpenSelectNodeScript()
    {
        return (this._openSelectNodeScript);
    }

    /**
     * @brief GetOpenStageNodeScript関数
     * @return open_stage_node_script (open_stage_node_script)
     */
    public UnityBase.Scene.Ui.MenuStageNodeScript GetOpenStageNodeScript()
    {
        return (this._openStageNodeScript);
    }

    /**
     * @brief RunOpenCloseButton関数
     */
    public void RunOpenCloseButton()
    {
        if (!this._backgroundImage.gameObject.activeSelf) {
            this._backgroundImage.gameObject.SetActive(true);

            this._openSelectNodeScript = this._selectNodeScript;

            this._openSelectNodeScript.Open(1);
        } else {
            this._backgroundImage.gameObject.SetActive(false);

            if (this._openSelectNodeScript != null) {
                this._openSelectNodeScript.Close(1);

                this._openSelectNodeScript = null;
            }
        }

        if (this._openStageNodeScript != null) {
            this._openStageNodeScript.Close(1);

            this._openStageNodeScript = null;
        }

        return;
    }

    /**
     * @brief RunSelectStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunSelectStageButton(UnityBase.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        UnityBase.Scene.Ui.MenuStageNodeScript open_stage_node_script = null;

		switch (stage_type) {
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.OPTION: {
            open_stage_node_script = this._optionStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.FAQ: {
            open_stage_node_script = this._faqStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.STAFF: {
            open_stage_node_script = this._staffStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.LICENSE: {
            open_stage_node_script = this._licenseStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.PRIVACY_POLICY: {
            open_stage_node_script = this._privacyPolicyStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.END: {
            open_stage_node_script = this._endStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.CHEAT: {
            open_stage_node_script = this._cheatStageNodeScript;

			break;
		}
		}

        if (open_stage_node_script != null) {
            if (this._openSelectNodeScript != null) {
                this._openSelectNodeScript.Close(1);

                this._openSelectNodeScript = null;
            }

            this._openStageNodeScript = open_stage_node_script;

            this._openStageNodeScript.Open(1);
        }

        return;
    }

    /**
     * @brief RunStageOkButton関数
     */
    public void RunStageOkButton()
    {
        if (this._openStageNodeScript != null) {
            this._openStageNodeScript.Close(1);

            this._openStageNodeScript = null;
        }

        this._openSelectNodeScript = this._selectNodeScript;

        this._openSelectNodeScript.Open(1);

        return;
    }

    /**
     * @brief RunStageCancelButton関数
     */
    public void RunStageCancelButton()
    {
        if (this._openStageNodeScript != null) {
            this._openStageNodeScript.Close(1);

            this._openStageNodeScript = null;
        }

        this._openSelectNodeScript = this._selectNodeScript;

        this._openSelectNodeScript.Open(1);

        return;
    }
}
}
}
