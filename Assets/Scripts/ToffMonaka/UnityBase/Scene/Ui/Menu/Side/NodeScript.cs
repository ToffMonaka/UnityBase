/**
 * @file
 * @brief NodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief NodeScriptCreateDescクラス
 */
public class NodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
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

    public new UnityBase.Scene.Ui.Menu.Side.NodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Menu.Side.OpenCloseButtonNodeScript _openCloseButtonNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.SelectNodeScript _selectNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.SelectNodeScript _openSelectNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.OptionStageNodeScript _optionStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.FaqStageNodeScript _faqStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.StaffStageNodeScript _staffStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.LicenseStageNodeScript _licenseStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.PrivacyPolicyStageNodeScript _privacyPolicyStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.EndStageNodeScript _endStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.CheatStageNodeScript _cheatStageNodeScript = null;
    private UnityBase.Scene.Ui.Menu.Side.StageNodeScript _openStageNodeScript = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIDE_MENU_NODE);
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
        this._backgroundImage.gameObject.SetActive(false);

        {// OpenCloseButtonNodeScript Create
            var script = this._openCloseButtonNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.OpenCloseButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.OpenCloseButtonNodeScriptCreateDesc();

            void on_click(UnityBase.Scene.Ui.Menu.Side.OpenCloseButtonNodeScript owner)
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

                if (this._openSelectNodeScript != null) {
                    UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);
                } else {
                    UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);
                }

                if (this._openStageNodeScript != null) {
                    this._openStageNodeScript.Close(1);

                    this._openStageNodeScript = null;
                }

                return;
            }

            script_create_desc.onClick = on_click;

            script.Create(script_create_desc);
            script.Open(1);

            this._openCloseButtonNodeScript = script;
        }

        {// SelectNodeScript Create
            var script = this._selectNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.SelectNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.SelectNodeScriptCreateDesc();

            void on_open_stage(UnityBase.Scene.Ui.Menu.Side.SelectNodeScript owner, UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE stage_type)
            {
                this.ChangeStage(stage_type);

                return;
            }

            script_create_desc.onOpenStage = on_open_stage;

            script.Create(script_create_desc);

            this._selectNodeScript = script;
        }

        {// OptionStageNodeScript Create
            var script = this._optionStageNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.OptionStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.OptionStageNodeScriptCreateDesc();

            void on_close_stage(UnityBase.Scene.Ui.Menu.Side.StageNodeScript owner)
            {
                this.ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.NONE);

                return;
            }

            script_create_desc.onCloseStage = on_close_stage;

            script.Create(script_create_desc);

            this._optionStageNodeScript = script;
        }

        {// FaqStageNodeScript Create
            var script = this._faqStageNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.FaqStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.FaqStageNodeScriptCreateDesc();

            void on_close_stage(UnityBase.Scene.Ui.Menu.Side.StageNodeScript owner)
            {
                this.ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.NONE);

                return;
            }

            script_create_desc.onCloseStage = on_close_stage;

            script.Create(script_create_desc);

            this._faqStageNodeScript = script;
        }

        {// StaffStageNodeScript Create
            var script = this._staffStageNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.StaffStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.StaffStageNodeScriptCreateDesc();

            void on_close_stage(UnityBase.Scene.Ui.Menu.Side.StageNodeScript owner)
            {
                this.ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.NONE);

                return;
            }

            script_create_desc.onCloseStage = on_close_stage;

            script.Create(script_create_desc);

            this._staffStageNodeScript = script;
        }

        {// LicenseStageNodeScript Create
            var script = this._licenseStageNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.LicenseStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.LicenseStageNodeScriptCreateDesc();

            void on_close_stage(UnityBase.Scene.Ui.Menu.Side.StageNodeScript owner)
            {
                this.ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.NONE);

                return;
            }

            script_create_desc.onCloseStage = on_close_stage;

            script.Create(script_create_desc);

            this._licenseStageNodeScript = script;
        }

        {// PrivacyPolicyStageNodeScript Create
            var script = this._privacyPolicyStageNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.PrivacyPolicyStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.PrivacyPolicyStageNodeScriptCreateDesc();

            void on_close_stage(UnityBase.Scene.Ui.Menu.Side.StageNodeScript owner)
            {
                this.ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.NONE);

                return;
            }

            script_create_desc.onCloseStage = on_close_stage;

            script.Create(script_create_desc);

            this._privacyPolicyStageNodeScript = script;
        }

        {// EndStageNodeScript Create
            var script = this._endStageNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.EndStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.EndStageNodeScriptCreateDesc();

            void on_close_stage(UnityBase.Scene.Ui.Menu.Side.StageNodeScript owner)
            {
                this.ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.NONE);

                return;
            }

            script_create_desc.onCloseStage = on_close_stage;

            script.Create(script_create_desc);

            this._endStageNodeScript = script;
        }

        {// CheatStageNodeScript Create
            var script = this._cheatStageNode.GetComponent<UnityBase.Scene.Ui.Menu.Side.CheatStageNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Side.CheatStageNodeScriptCreateDesc();

            void on_close_stage(UnityBase.Scene.Ui.Menu.Side.StageNodeScript owner)
            {
                this.ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.NONE);

                return;
            }

            script_create_desc.onCloseStage = on_close_stage;

            script.Create(script_create_desc);

            this._cheatStageNodeScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.NodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.NodeScriptCreateDesc;

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
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
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
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        return;
    }

    /**
     * @brief ChangeStage関数
     * @param stage_type (stage_type)
     */
    public void ChangeStage(UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE stage_type)
    {
        if (this._openStageNodeScript != null) {
            this._openStageNodeScript.Close(0);

            this._openStageNodeScript = null;
        }

		switch (stage_type) {
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.OPTION: {
            this._optionStageNodeScript.SetLanguageType(UnityBase.Global.systemConfigFile.data.systemLanguageType);
            this._optionStageNodeScript.SetSoundBgmVolume(UnityBase.Global.systemConfigFile.data.soundBgmVolume);
            this._optionStageNodeScript.SetSoundBgmMuteFlag(UnityBase.Global.systemConfigFile.data.soundBgmMuteFlag);
            this._optionStageNodeScript.SetSoundSeVolume(UnityBase.Global.systemConfigFile.data.soundSeVolume);
            this._optionStageNodeScript.SetSoundSeMuteFlag(UnityBase.Global.systemConfigFile.data.soundSeMuteFlag);

            this._openStageNodeScript = this._optionStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.FAQ: {
            this._openStageNodeScript = this._faqStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.STAFF: {
            this._openStageNodeScript = this._staffStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.LICENSE: {
            this._openStageNodeScript = this._licenseStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.PRIVACY_POLICY: {
            this._openStageNodeScript = this._privacyPolicyStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.END: {
            this._openStageNodeScript = this._endStageNodeScript;

			break;
		}
		case UnityBase.Util.SCENE.SIDE_MENU_STAGE_TYPE.CHEAT: {
            this._openStageNodeScript = this._cheatStageNodeScript;

			break;
		}
		}

        if (this._openStageNodeScript == null) {
            this._openSelectNodeScript = this._selectNodeScript;

            this._openSelectNodeScript.Open(1);

            return;
        }

        if (this._openSelectNodeScript != null) {
            this._openSelectNodeScript.Close(1);

            this._openSelectNodeScript = null;
        }

        this._openStageNodeScript.Open(1);

        return;
    }
}
}
}
