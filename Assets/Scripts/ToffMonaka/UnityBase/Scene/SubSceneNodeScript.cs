/**
 * @file
 * @brief SubSceneNodeScriptファイル
 */

using UnityEngine;
using ToffMonaka.UnityBase.Scene.SideMenu;
using ToffMonaka.UnityBase.Scene.CoverSystem;
using ToffMonaka.UnityBase.Scene.DialogSystem;

namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief SubSceneNodeScriptCreateDescクラス
 */
public class SubSceneNodeScriptCreateDesc : ToffMonaka.Tml.Scene.SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief SubSceneNodeScriptクラス
 */
public abstract class SubSceneNodeScript : ToffMonaka.Tml.Scene.SubSceneNodeScript
{
    [SerializeField] private GameObject _sideMenuNode = null;
    [SerializeField] private GameObject _dialogSystemNode = null;
    [SerializeField] private GameObject _coverSystemNode = null;

    public new SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private SideMenuNodeScript _sideMenuNodeScript = null;
    private DialogSystemNodeScript _dialogSystemNodeScript = null;
    private CoverSystemNodeScript _coverSystemNodeScript = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SUB_SCENE_NODE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        base._OnDestroy();

        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        // SideMenuNodeScript Create
        if (this._sideMenuNode != null) {
            var script = this._sideMenuNode.GetComponent<SideMenuNodeScript>();
            var script_create_desc = new SideMenuNodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._sideMenuNodeScript = script;
        }

        // DialogSystemNodeScript Create
        if (this._dialogSystemNode != null) {
            var script = this._dialogSystemNode.GetComponent<DialogSystemNodeScript>();
            var script_create_desc = new DialogSystemNodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);

            this._dialogSystemNodeScript = script;
        }

        // CoverSystemNodeScript Create
        if (this._coverSystemNode != null) {
            var script = this._coverSystemNode.GetComponent<CoverSystemNodeScript>();
            var script_create_desc = new CoverSystemNodeScriptCreateDesc();

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
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SubSceneNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        if (this._coverSystemNodeScript != null) {
            this._coverSystemNodeScript.CloseCover();
        }

        return;
    }

    /**
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
        base._OnOpened();

        SceneUtil.GetManager().EnableInputEventSystem();

        if (this._coverSystemNodeScript != null) {
            this._coverSystemNodeScript.CloseCover();
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

        SceneUtil.GetManager().DisableInputEventSystem();

        if (this._coverSystemNodeScript != null) {
            this._coverSystemNodeScript.CloseCover();
        }

        return;
    }

    /**
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        base._OnClosed();

        if (this._coverSystemNodeScript != null) {
            this._coverSystemNodeScript.CloseCover();
        }

        return;
    }

    /**
     * @brief GetSideMenuNodeScript関数
     * @return side_menu_node_script (side_menu_node_script)
     */
    public SideMenuNodeScript GetSideMenuNodeScript()
    {
        return (this._sideMenuNodeScript);
    }

    /**
     * @brief GetDialogSystemNodeScript関数
     * @return dialog_sys_node_script (dialog_system_node_script)
     */
    public DialogSystemNodeScript GetDialogSystemNodeScript()
    {
        return (this._dialogSystemNodeScript);
    }

    /**
     * @brief GetCoverSystemNodeScript関数
     * @return cover_sys_node_script (cover_system_node_script)
     */
    public CoverSystemNodeScript GetCoverSystemNodeScript()
    {
        return (this._coverSystemNodeScript);
    }
}
}
}
