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
        return;
    }

    /**
     * @brief _OnDestroy関数
     */
    protected override void _OnDestroy()
    {
        this._RemoveDialog();

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
        this._UpdateDialog();

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
     * @param script_create_desc (script_create_desc)
     * @return script<br>
     * null=失敗
     */
    public UnityBase.Scene.Ui.Dialog.DialogNodeScript AddDialog(UnityBase.Scene.Ui.Dialog.DialogNodeScriptCreateDesc script_create_desc)
    {
        if (script_create_desc == null) {
            return (null);
        }

        var script = script_create_desc.GetNewScript(script_create_desc.GetPrefabFilePath());

        if (script == null) {
            return (null);
        }

        script.gameObject.transform.SetParent(this.gameObject.transform, false);

        script.Create(script_create_desc);
        script.Open(1);

        this._dialogNodeScriptContainer.Add(script);

        return (script);
    }

    /**
     * @brief _RemoveDialog関数
     */
    private void _RemoveDialog()
    {
        foreach (var script in this._dialogNodeScriptContainer) {
            var node = script.gameObject;

            Lib.Scene.Util.ReleasePrefabNode(ref node);
        }

        this._dialogNodeScriptContainer.Clear();

        return;
    }

    /**
     * @brief _UpdateDialog関数
     */
    private void _UpdateDialog()
    {
        for (int script_i = this._dialogNodeScriptContainer.Count - 1; script_i >= 0; --script_i) {
            var script = this._dialogNodeScriptContainer[script_i];

            if (!script.GetClosedFlag()) {
                continue;
            }

            var node = script.gameObject;

            Lib.Scene.Util.ReleasePrefabNode(ref node);

            this._dialogNodeScriptContainer.RemoveAt(script_i);

            break;
        }

        return;
    }
}
}
}
