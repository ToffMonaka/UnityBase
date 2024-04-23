/**
 * @file
 * @brief NodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief NodeScriptCreateDescクラス
 */
public class NodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    public Lib.Scene.SubSceneNodeScript subSceneNodeScript = null;
}

/**
 * @brief NodeScriptクラス
 */
public class NodeScript : Lib.Scene.ObjectNodeScript
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

    public new UnityBase.Scene.Ui.Menu.NodeScriptCreateDesc createDesc{get; private set;} = null;

    private Lib.Scene.SubSceneNodeScript _subSceneNodeScript = null;
    private UnityBase.Scene.Ui.Menu.OpenCloseButtonNodeScript _openCloseButtonNodeScript = null;
    private UnityBase.Scene.Ui.Menu.SelectNodeScript _selectNodeScript = null;
    private UnityBase.Scene.Ui.Menu.SelectNodeScript _openSelectNodeScript = null;
    private UnityBase.Scene.Ui.Menu.OptionStageNodeScript _optionStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.FaqStageNodeScript _faqStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.StaffStageNodeScript _staffStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.LicenseStageNodeScript _licenseStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.PrivacyPolicyStageNodeScript _privacyPolicyStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.EndStageNodeScript _endStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.CheatStageNodeScript _cheatStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.StageNodeScript _openStageNodeScript = null;

    /**
     * @brief コンストラクタ
     */
    public NodeScript()
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
            var script = this._openCloseButtonNode.GetComponent<UnityBase.Scene.Ui.Menu.OpenCloseButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.OpenCloseButtonNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._openCloseButtonNodeScript = script;
        }

        {// SelectNodeScript Create
            var script = this._selectNode.GetComponent<UnityBase.Scene.Ui.Menu.SelectNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.SelectNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._selectNodeScript = script;
        }

        {// OptionStageNodeScript Create
            var script = this._optionStageNode.GetComponent<UnityBase.Scene.Ui.Menu.OptionStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.OptionStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._optionStageNodeScript = script;
        }

        {// FaqStageNodeScript Create
            var script = this._faqStageNode.GetComponent<UnityBase.Scene.Ui.Menu.FaqStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.FaqStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._faqStageNodeScript = script;
        }

        {// StaffStageNodeScript Create
            var script = this._staffStageNode.GetComponent<UnityBase.Scene.Ui.Menu.StaffStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.StaffStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._staffStageNodeScript = script;
        }

        {// LicenseStageNodeScript Create
            var script = this._licenseStageNode.GetComponent<UnityBase.Scene.Ui.Menu.LicenseStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.LicenseStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._licenseStageNodeScript = script;
        }

        {// PrivacyPolicyStageNodeScript Create
            var script = this._privacyPolicyStageNode.GetComponent<UnityBase.Scene.Ui.Menu.PrivacyPolicyStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.PrivacyPolicyStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._privacyPolicyStageNodeScript = script;
        }

        {// EndStageNodeScript Create
            var script = this._endStageNode.GetComponent<UnityBase.Scene.Ui.Menu.EndStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.EndStageNodeScriptCreateDesc();

            script_create_desc.menuNodeScript = this;

            script.Create(script_create_desc);

            this._endStageNodeScript = script;
        }

        {// CheatStageNodeScript Create
            var script = this._cheatStageNode.GetComponent<UnityBase.Scene.Ui.Menu.CheatStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.CheatStageNodeScriptCreateDesc();

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
	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.NodeScriptCreateDesc;

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
    public UnityBase.Scene.Ui.Menu.SelectNodeScript GetOpenSelectNodeScript()
    {
        return (this._openSelectNodeScript);
    }

    /**
     * @brief GetOpenStageNodeScript関数
     * @return open_stage_node_script (open_stage_node_script)
     */
    public UnityBase.Scene.Ui.Menu.StageNodeScript GetOpenStageNodeScript()
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
        UnityBase.Scene.Ui.Menu.StageNodeScript open_stage_node_script = null;

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
