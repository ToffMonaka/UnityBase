/**
 * @file
 * @brief NodeScriptファイル
 */


using System.Collections.Generic;
using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Dialog {
/**
 * @brief SystemNodeScriptCreateDescクラス
 */
public class SystemNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
}

/**
 * @brief SystemNodeScriptクラス
 */
public class SystemNodeScript : Lib.Scene.ObjectNodeScript
{
    public new UnityBase.Scene.Ui.Dialog.SystemNodeScriptCreateDesc createDesc{get; private set;} = null;

    private List<GameObject> _dialogNodeContainer = new List<GameObject>();

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.DIALOG_SYSTEM_NODE);
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
        this._RemoveDialogNode();

        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Dialog.SystemNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Dialog.SystemNodeScriptCreateDesc;

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
     * @brief AddDialog関数
     * @param dialog_node_script (dialog_node_script)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddDialog(UnityBase.Scene.Ui.Dialog.DialogNodeScript dialog_node_script)
    {
        if (dialog_node_script == null) {
            return (-1);
        }

        dialog_node_script.gameObject.transform.SetParent(this.gameObject.transform, false);

        dialog_node_script.Open(1);

        return (0);
    }

    /**
     * @brief _AddDialogNode関数
     * @param create_desc (create_desc)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    private int _AddDialogNode(UnityBase.Scene.Ui.Dialog.DialogNodeScriptCreateDesc create_desc)
    {
        if (create_desc == null) {
            return (-1);
        }

        return (0);
    }

    /**
     * @brief _RemoveDialogNode関数
     */
    private void _RemoveDialogNode()
    {
        foreach (var dialog_node in this._dialogNodeContainer) {
            var tmp_dialog_node = dialog_node;

            Lib.Scene.Util.ReleasePrefabNode(ref tmp_dialog_node);
        }

        this._dialogNodeContainer.Clear();

        return;
    }
}
}
}
