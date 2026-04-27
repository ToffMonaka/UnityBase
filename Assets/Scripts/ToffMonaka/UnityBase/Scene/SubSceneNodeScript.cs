/**
 * @file
 * @brief SubSceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief SubSceneNodeScriptCreateDescクラス
 */
public class SubSceneNodeScriptCreateDesc : Lib.Scene.SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief SubSceneNodeScriptクラス
 */
public class SubSceneNodeScript : Lib.Scene.SubSceneNodeScript
{
    [SerializeField] private GameObject _menuSystemNode = null;
    [SerializeField] private GameObject _dialogSystemNode = null;
    [SerializeField] private GameObject _fadeSystemNode = null;

    [SerializeField] protected Image _openCloseFadeImage = null;

    public new UnityBase.Scene.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.MenuSystem.NodeScript _menuSystemNodeScript = null;
    private UnityBase.Scene.Ui.DialogSystem.NodeScript _dialogSystemNodeScript = null;
    private UnityBase.Scene.Ui.FadeSystem.NodeScript _fadeSystemNodeScript = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SUB_SCENE_NODE);
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
        // MenuSystemNodeScript Create
        if (this._menuSystemNode != null) {
            var script = this._menuSystemNode.GetComponent<UnityBase.Scene.Ui.MenuSystem.NodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSystem.NodeScriptCreateDesc();

            script_create_desc.subSceneNodeScript = this;

            script.Create(script_create_desc);
            script.Open(0);

            this._menuSystemNodeScript = script;
        }

        // DialogSystemNodeScript Create
        if (this._dialogSystemNode != null) {
            var script = this._dialogSystemNode.GetComponent<UnityBase.Scene.Ui.DialogSystem.NodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.DialogSystem.NodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._dialogSystemNodeScript = script;
        }

        // FadeSystemNodeScript Create
        if (this._fadeSystemNode != null) {
            var script = this._fadeSystemNode.GetComponent<UnityBase.Scene.Ui.FadeSystem.NodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.FadeSystem.NodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._fadeSystemNodeScript = script;
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
            this.SetCreateDesc(new UnityBase.Scene.SubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.SubSceneNodeScriptCreateDesc;

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
        Lib.Scene.Util.GetInputManager().EnableEventSystem();

        if (this._openCloseFadeImage != null) {
            this._openCloseFadeImage.gameObject.SetActive(false);
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        Lib.Scene.Util.GetInputManager().DisableEventSystem();

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
     * @brief GetMenuSystemNodeScript関数
     * @return menu_sys_node_script (menu_system_node_script)
     */
    public UnityBase.Scene.Ui.MenuSystem.NodeScript GetMenuSystemNodeScript()
    {
        return (this._menuSystemNodeScript);
    }

    /**
     * @brief GetDialogSystemNodeScript関数
     * @return dialog_sys_node_script (dialog_system_node_script)
     */
    public UnityBase.Scene.Ui.DialogSystem.NodeScript GetDialogSystemNodeScript()
    {
        return (this._dialogSystemNodeScript);
    }

    /**
     * @brief GetFadeSystemNodeScript関数
     * @return fade_sys_node_script (fade_system_node_script)
     */
    public UnityBase.Scene.Ui.FadeSystem.NodeScript GetFadeSystemNodeScript()
    {
        return (this._fadeSystemNodeScript);
    }
}
}
}
