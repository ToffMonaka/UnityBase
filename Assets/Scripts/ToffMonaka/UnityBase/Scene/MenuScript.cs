/**
 * @file
 * @brief MenuScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuScriptCreateDescクラス
 */
public class MenuScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
}

/**
 * @brief MenuScriptクラス
 */
public class MenuScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private Image _backgroundImage = null;
    [SerializeField] private GameObject _openCloseButtonNode = null;
    [SerializeField] private GameObject _stageSelectNode = null;
    [SerializeField] private GameObject _optionStageNode = null;
    [SerializeField] private GameObject _faqStageNode = null;
    [SerializeField] private GameObject _staffStageNode = null;
    [SerializeField] private GameObject _licenseStageNode = null;
    [SerializeField] private GameObject _endStageNode = null;
    [SerializeField] private GameObject _cheatStageNode = null;

    public new ToffMonaka.UnityBase.Scene.MenuScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuOpenCloseButtonScript _openCloseButtonScript = null;
    private ToffMonaka.UnityBase.Scene.MenuStageSelectScript _stageSelectScript = null;
    private ToffMonaka.UnityBase.Scene.MenuOptionStageScript _optionStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuFaqStageScript _faqStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuStaffStageScript _staffStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuLicenseStageScript _licenseStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuEndStageScript _endStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuCheatStageScript _cheatStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuStageScript _openStageScript = null;

    /**
     * @brief コンストラクタ
     */
    public MenuScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU);

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
        this._backgroundImage.gameObject.SetActive(false);

        {// OpenCloseButtonScript Create
            var script = this._openCloseButtonNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuOpenCloseButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuOpenCloseButtonScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._openCloseButtonScript = script;
        }

        {// StageSelectScript Create
            var script = this._stageSelectNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuStageSelectScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuStageSelectScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._stageSelectScript = script;
        }

        {// OptionStageScript Create
            var script = this._optionStageNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuOptionStageScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuOptionStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._optionStageScript = script;
        }

        {// FaqStageScript Create
            var script = this._faqStageNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuFaqStageScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuFaqStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._faqStageScript = script;
        }

        {// StaffStageScript Create
            var script = this._staffStageNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuStaffStageScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuStaffStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._staffStageScript = script;
        }

        {// LicenseStageScript Create
            var script = this._licenseStageNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuLicenseStageScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuLicenseStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._licenseStageScript = script;
        }

        {// EndStageScript Create
            var script = this._endStageNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuEndStageScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuEndStageScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);

            this._endStageScript = script;
        }

        {// CheatStageScript Create
            var script = this._cheatStageNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuCheatStageScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuCheatStageScriptCreateDesc();

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
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuScriptCreateDesc;

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
        this.CompleteOpen();

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
        this.CompleteClose();

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
     * @brief RunOpenCloseButton関数
     */
    public void RunOpenCloseButton()
    {
        if (this._backgroundImage.gameObject.activeSelf) {
            this._backgroundImage.gameObject.SetActive(false);

            this._stageSelectScript.Close(1);
        } else {
            this._backgroundImage.gameObject.SetActive(true);

            this._stageSelectScript.Open(1);
        }

        if (this._openStageScript != null) {
            this._openStageScript.Close(1);

            this._openStageScript = null;
        }

        return;
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        this._openStageScript = null;

		switch (stage_type) {
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.OPTION: {
            this._openStageScript = this._optionStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.FAQ: {
            this._openStageScript = this._faqStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.STAFF: {
            this._openStageScript = this._staffStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.LICENSE: {
            this._openStageScript = this._licenseStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.END: {
            this._openStageScript = this._endStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.CHEAT: {
            this._openStageScript = this._cheatStageScript;

			break;
		}
		}

        if (this._openStageScript != null) {
            this._stageSelectScript.Close(1);

            this._openStageScript.Open(1);
        }

        return;
    }

    /**
     * @brief RunOkButton関数
     */
    public void RunOkButton()
    {
        if (this._openStageScript != null) {
            this._openStageScript.Close(1);

            this._openStageScript = null;
        }

        this._stageSelectScript.Open(1);

        return;
    }

    /**
     * @brief RunCancelButton関数
     */
    public void RunCancelButton()
    {
        if (this._openStageScript != null) {
            this._openStageScript.Close(1);

            this._openStageScript = null;
        }

        this._stageSelectScript.Open(1);

        return;
    }
}
}
