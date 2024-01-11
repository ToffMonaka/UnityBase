/**
 * @file
 * @brief MenuScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuScriptCreateDescクラス
 */
public class MenuScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    public Lib.Scene.SubSceneNodeScript subSceneNodeScript = null;
}

/**
 * @brief MenuScriptクラス
 */
public class MenuScript : Lib.Scene.ObjectNodeScript
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

    public new UnityBase.Scene.Ui.MenuScriptCreateDesc createDesc{get; private set;} = null;

    private Lib.Scene.SubSceneNodeScript _subSceneNodeScript = null;
    private UnityBase.Scene.Ui.MenuOpenCloseButtonNodeScript _openCloseButtonNodeScript = null;
    private UnityBase.Scene.Ui.MenuSelectScript _selectScript = null;
    private UnityBase.Scene.Ui.MenuSelectScript _openSelectScript = null;
    private UnityBase.Scene.Ui.MenuOptionStageScript _optionStageScript = null;
    private UnityBase.Scene.Ui.MenuFaqStageScript _faqStageScript = null;
    private UnityBase.Scene.Ui.MenuStaffStageScript _staffStageScript = null;
    private UnityBase.Scene.Ui.MenuLicenseStageScript _licenseStageScript = null;
    private UnityBase.Scene.Ui.MenuPrivacyPolicyStageScript _privacyPolicyStageScript = null;
    private UnityBase.Scene.Ui.MenuEndStageScript _endStageScript = null;
    private UnityBase.Scene.Ui.MenuCheatStageScript _cheatStageScript = null;
    private UnityBase.Scene.Ui.MenuStageScript _openStageScript = null;

    /**
     * @brief コンストラクタ
     */
    public MenuScript() : base((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.MENU)
    {
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

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._openCloseButtonNodeScript = script;
        }

        {// SelectScript Create
            var script = this._selectNode.GetComponent<UnityBase.Scene.Ui.MenuSelectScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._selectScript = script;
        }

        {// OptionStageScript Create
            var script = this._optionStageNode.GetComponent<UnityBase.Scene.Ui.MenuOptionStageScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuOptionStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._optionStageScript = script;
        }

        {// FaqStageScript Create
            var script = this._faqStageNode.GetComponent<UnityBase.Scene.Ui.MenuFaqStageScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuFaqStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._faqStageScript = script;
        }

        {// StaffStageScript Create
            var script = this._staffStageNode.GetComponent<UnityBase.Scene.Ui.MenuStaffStageScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuStaffStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._staffStageScript = script;
        }

        {// LicenseStageScript Create
            var script = this._licenseStageNode.GetComponent<UnityBase.Scene.Ui.MenuLicenseStageScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuLicenseStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._licenseStageScript = script;
        }

        {// PrivacyPolicyStageScript Create
            var script = this._privacyPolicyStageNode.GetComponent<UnityBase.Scene.Ui.MenuPrivacyPolicyStageScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuPrivacyPolicyStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._privacyPolicyStageScript = script;
        }

        {// EndStageScript Create
            var script = this._endStageNode.GetComponent<UnityBase.Scene.Ui.MenuEndStageScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuEndStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._endStageScript = script;
        }

        {// CheatStageScript Create
            var script = this._cheatStageNode.GetComponent<UnityBase.Scene.Ui.MenuCheatStageScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuCheatStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._cheatStageScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuScriptCreateDesc;

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
     * @brief GetOpenSelectScript関数
     * @return open_select_script (open_select_script)
     */
    public UnityBase.Scene.Ui.MenuSelectScript GetOpenSelectScript()
    {
        return (this._openSelectScript);
    }

    /**
     * @brief GetOpenStageScript関数
     * @return open_stage_script (open_stage_script)
     */
    public UnityBase.Scene.Ui.MenuStageScript GetOpenStageScript()
    {
        return (this._openStageScript);
    }

    /**
     * @brief RunOpenCloseButton関数
     */
    public void RunOpenCloseButton()
    {
        if (!this._backgroundImage.gameObject.activeSelf) {
            this._backgroundImage.gameObject.SetActive(true);

            this._openSelectScript = this._selectScript;

            this._openSelectScript.Open(1);
        } else {
            this._backgroundImage.gameObject.SetActive(false);

            if (this._openSelectScript != null) {
                this._openSelectScript.Close(1);

                this._openSelectScript = null;
            }
        }

        if (this._openStageScript != null) {
            this._openStageScript.Close(1);

            this._openStageScript = null;
        }

        return;
    }

    /**
     * @brief RunSelectStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunSelectStageButton(UnityBase.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        UnityBase.Scene.Ui.MenuStageScript open_stage_script = null;

		switch (stage_type) {
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.OPTION: {
            open_stage_script = this._optionStageScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.FAQ: {
            open_stage_script = this._faqStageScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.STAFF: {
            open_stage_script = this._staffStageScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.LICENSE: {
            open_stage_script = this._licenseStageScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.PRIVACY_POLICY: {
            open_stage_script = this._privacyPolicyStageScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.END: {
            open_stage_script = this._endStageScript;

			break;
		}
		case UnityBase.Util.SCENE.MENU_STAGE_TYPE.CHEAT: {
            open_stage_script = this._cheatStageScript;

			break;
		}
		}

        if (open_stage_script != null) {
            if (this._openSelectScript != null) {
                this._openSelectScript.Close(1);

                this._openSelectScript = null;
            }

            this._openStageScript = open_stage_script;

            this._openStageScript.Open(1);
        }

        return;
    }

    /**
     * @brief RunStageOkButton関数
     */
    public void RunStageOkButton()
    {
        if (this._openStageScript != null) {
            this._openStageScript.Close(1);

            this._openStageScript = null;
        }

        this._openSelectScript = this._selectScript;

        this._openSelectScript.Open(1);

        return;
    }

    /**
     * @brief RunStageCancelButton関数
     */
    public void RunStageCancelButton()
    {
        if (this._openStageScript != null) {
            this._openStageScript.Close(1);

            this._openStageScript = null;
        }

        this._openSelectScript = this._selectScript;

        this._openSelectScript.Open(1);

        return;
    }
}
}
}
