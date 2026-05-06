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
public abstract class SubSceneNodeScript : Lib.Scene.SubSceneNodeScript
{
    [SerializeField] private GameObject _mainMenuNode = null;
    [SerializeField] private GameObject _dialogSystemNode = null;
    [SerializeField] private GameObject _coverSystemNode = null;
    [SerializeField] protected Image _openCloseCoverImage = null;

    public new UnityBase.Scene.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Menu.Main.NodeScript _mainMenuNodeScript = null;
    private UnityBase.Scene.Ui.Dialog.SystemNodeScript _dialogSystemNodeScript = null;
    private UnityBase.Scene.Ui.Cover.SystemNodeScript _coverSystemNodeScript = null;

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
        // MainMenuNodeScript Create
        if (this._mainMenuNode != null) {
            var script = this._mainMenuNode.GetComponent<UnityBase.Scene.Ui.Menu.Main.NodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.Main.NodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._mainMenuNodeScript = script;
        }

        // DialogSystemNodeScript Create
        if (this._dialogSystemNode != null) {
            var script = this._dialogSystemNode.GetComponent<UnityBase.Scene.Ui.Dialog.SystemNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Dialog.SystemNodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._dialogSystemNodeScript = script;
        }

        // CoverSystemNodeScript Create
        if (this._coverSystemNode != null) {
            var script = this._coverSystemNode.GetComponent<UnityBase.Scene.Ui.Cover.SystemNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Cover.SystemNodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._coverSystemNodeScript = script;
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
        Lib.Scene.Util.GetManager().EnableInputEventSystem();

        if (this._openCloseCoverImage != null) {
            this._openCloseCoverImage.gameObject.SetActive(false);
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        Lib.Scene.Util.GetManager().DisableInputEventSystem();

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
     * @brief GetMainMenuNodeScript関数
     * @return main_menu_node_script (main_menu_node_script)
     */
    public UnityBase.Scene.Ui.Menu.Main.NodeScript GetMainMenuNodeScript()
    {
        return (this._mainMenuNodeScript);
    }

    /**
     * @brief GetDialogSystemNodeScript関数
     * @return dialog_sys_node_script (dialog_system_node_script)
     */
    public UnityBase.Scene.Ui.Dialog.SystemNodeScript GetDialogSystemNodeScript()
    {
        return (this._dialogSystemNodeScript);
    }

    /**
     * @brief GetCoverSystemNodeScript関数
     * @return cover_sys_node_script (cover_system_node_script)
     */
    public UnityBase.Scene.Ui.Cover.SystemNodeScript GetCoverSystemNodeScript()
    {
        return (this._coverSystemNodeScript);
    }
}
}
}
