/**
 * @file
 * @brief SystemNodeScriptファイル
 */


using System.Collections.Generic;
using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Dialog {
/**
 * @brief SystemNodeScriptCreateDescクラス
 */
public class SystemNodeScriptCreateDesc : ToffMonaka.Tml.Scene.ObjectNodeScriptCreateDesc
{
}

/**
 * @brief SystemNodeScriptクラス
 */
public class SystemNodeScript : ToffMonaka.Tml.Scene.ObjectNodeScript
{
    public new UnityBase.Scene.Ui.Dialog.SystemNodeScriptCreateDesc createDesc{get; private set;} = null;

    private List<UnityBase.Scene.Ui.Dialog.DialogNodeScript> _dialogNodeScriptContainer = new List<UnityBase.Scene.Ui.Dialog.DialogNodeScript>();

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
        base._OnAwake();

        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        this._RemoveDialog();

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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
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
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        this._UpdateDialog();

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

        return;
    }

    /**
     * @brief AddDialog関数
     * @param dialog_node_script_create_desc (dialog_node_script_create_desc)
     * @return dialog_node_script<br>
     * null=失敗
     */
    public UnityBase.Scene.Ui.Dialog.DialogNodeScript AddDialog(UnityBase.Scene.Ui.Dialog.DialogNodeScriptCreateDesc dialog_node_script_create_desc)
    {
        if (dialog_node_script_create_desc == null) {
            return (null);
        }

        var dialog_node_script = dialog_node_script_create_desc.GetNewScript(dialog_node_script_create_desc.GetPrefabFilePath());

        if (dialog_node_script == null) {
            return (null);
        }

        dialog_node_script.gameObject.transform.SetParent(this.gameObject.transform, false);

        dialog_node_script.Create(dialog_node_script_create_desc);
        dialog_node_script.Open(1);

        this._dialogNodeScriptContainer.Add(dialog_node_script);

        return (dialog_node_script);
    }

    /**
     * @brief _RemoveDialog関数
     */
    private void _RemoveDialog()
    {
        foreach (var dialog_node_script in this._dialogNodeScriptContainer) {
            var node = dialog_node_script.gameObject;

            ToffMonaka.Tml.Scene.SceneUtil.ReleasePrefabNode(ref node);
        }

        this._dialogNodeScriptContainer.Clear();

        return;
    }

    /**
     * @brief _UpdateDialog関数
     */
    private void _UpdateDialog()
    {
        for (int dialog_node_script_i = this._dialogNodeScriptContainer.Count - 1; dialog_node_script_i >= 0; --dialog_node_script_i) {
            var dialog_node_script = this._dialogNodeScriptContainer[dialog_node_script_i];

            if (!dialog_node_script.GetClosedFlag()) {
                continue;
            }

            var dialog_node = dialog_node_script.gameObject;

            ToffMonaka.Tml.Scene.SceneUtil.ReleasePrefabNode(ref dialog_node);

            this._dialogNodeScriptContainer.RemoveAt(dialog_node_script_i);

            break;
        }

        return;
    }

    /**
     * @brief CloseDialog関数
     */
    public void CloseDialog()
    {
        foreach (var dialog_node_script in this._dialogNodeScriptContainer) {
            dialog_node_script.Close(0);
        }

        return;
    }
}
}
}
