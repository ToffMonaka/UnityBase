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
    [SerializeField] private GameObject _startButtonNode = null;
    [SerializeField] private GameObject _stageSelectNode = null;
    [SerializeField] private GameObject _optionStageNode = null;
    [SerializeField] private GameObject _faqStageNode = null;
    [SerializeField] private GameObject _staffStageNode = null;
    [SerializeField] private GameObject _licenseStageNode = null;
    [SerializeField] private GameObject _endStageNode = null;
    [SerializeField] private GameObject _cheatStageNode = null;

    public new ToffMonaka.UnityBase.Scene.MenuScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuStartButtonScript _startButtonScript = null;
    private ToffMonaka.UnityBase.Scene.MenuStageSelectScript _stageSelectScript = null;
    private ToffMonaka.UnityBase.Scene.MenuStageScript _currentStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuOptionStageScript _optionStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuFaqStageScript _faqStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuStaffStageScript _staffStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuLicenseStageScript _licenseStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuEndStageScript _endStageScript = null;
    private ToffMonaka.UnityBase.Scene.MenuCheatStageScript _cheatStageScript = null;

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

        {// StartButtonScript Create
            var script = this._startButtonNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuStartButtonScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuStartButtonScriptCreateDesc();

            script_create_desc.menuScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._startButtonScript = script;
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
     * @brief RunStartButton関数
     */
    public void RunStartButton()
    {
        if (this._backgroundImage.gameObject.activeSelf) {
            this._backgroundImage.gameObject.SetActive(false);

            this._stageSelectScript.Close(1);
        } else {
            this._backgroundImage.gameObject.SetActive(true);

            this._stageSelectScript.Open(1);
        }

        if (this._currentStageScript != null) {
            this._currentStageScript.Close(1);
        }

        return;
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        this._currentStageScript = null;

		switch (stage_type) {
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.OPTION: {
            this._currentStageScript = this._optionStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.FAQ: {
            this._currentStageScript = this._faqStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.STAFF: {
            this._currentStageScript = this._staffStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.LICENSE: {
            this._currentStageScript = this._licenseStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.END: {
            this._currentStageScript = this._endStageScript;

			break;
		}
		case ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.CHEAT: {
            this._currentStageScript = this._cheatStageScript;

			break;
		}
		}

        if (this._currentStageScript != null) {
            this._stageSelectScript.Close(1);
            this._currentStageScript.Open(1);
        }

        return;
    }
}
}
