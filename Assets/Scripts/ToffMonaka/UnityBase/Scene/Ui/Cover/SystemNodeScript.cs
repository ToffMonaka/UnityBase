/**
 * @file
 * @brief SystemNodeScriptファイル
 */


using System.Collections.Generic;
using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Cover {
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
    public new UnityBase.Scene.Ui.Cover.SystemNodeScriptCreateDesc createDesc{get; private set;} = null;

    private List<UnityBase.Scene.Ui.Cover.CoverNodeScript> _coverNodeScriptContainer = new List<UnityBase.Scene.Ui.Cover.CoverNodeScript>();

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.COVER_SYSTEM_NODE);
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
        this._RemoveCover();

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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Cover.SystemNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Cover.SystemNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        this._UpdateCover();

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
     * @brief AddCover関数
     * @param cover_node_script_create_desc (cover_node_script_create_desc)
     * @return cover_node_script<br>
     * null=失敗
     */
    public UnityBase.Scene.Ui.Cover.CoverNodeScript AddCover(UnityBase.Scene.Ui.Cover.CoverNodeScriptCreateDesc cover_node_script_create_desc)
    {
        if (cover_node_script_create_desc == null) {
            return (null);
        }

        var cover_node_script = cover_node_script_create_desc.GetNewScript(cover_node_script_create_desc.GetPrefabFilePath());

        if (cover_node_script == null) {
            return (null);
        }

        cover_node_script.gameObject.transform.SetParent(this.gameObject.transform, false);

        cover_node_script.Create(cover_node_script_create_desc);
        cover_node_script.Open(1);

        this._coverNodeScriptContainer.Add(cover_node_script);

        return (cover_node_script);
    }

    /**
     * @brief _RemoveCover関数
     */
    private void _RemoveCover()
    {
        foreach (var cover_node_script in this._coverNodeScriptContainer) {
            var node = cover_node_script.gameObject;

            Lib.Scene.Util.ReleasePrefabNode(ref node);
        }

        this._coverNodeScriptContainer.Clear();

        return;
    }

    /**
     * @brief _UpdateCover関数
     */
    private void _UpdateCover()
    {
        for (int cover_node_script_i = this._coverNodeScriptContainer.Count - 1; cover_node_script_i >= 0; --cover_node_script_i) {
            var cover_node_script = this._coverNodeScriptContainer[cover_node_script_i];

            if (!cover_node_script.GetClosedFlag()) {
                continue;
            }

            var cover_node = cover_node_script.gameObject;

            Lib.Scene.Util.ReleasePrefabNode(ref cover_node);

            this._coverNodeScriptContainer.RemoveAt(cover_node_script_i);

            break;
        }

        return;
    }

    /**
     * @brief CloseCover関数
     */
    public void CloseCover()
    {
        foreach (var cover_node_script in this._coverNodeScriptContainer) {
            cover_node_script.Close(0);
        }

        return;
    }

    /**
     * @brief IsPlay関数
     * @return play_flg (play_flag)<br>
     * false=非プレイ,true=プレイ
     */
    public bool IsPlay()
    {
        bool play_flg = false;

        foreach (var cover_node_script in this._coverNodeScriptContainer) {
            if (cover_node_script.GetClosedFlag()) {
                continue;
            }

            if (!cover_node_script.IsPlay()) {
                continue;
            }

            play_flg = true;

            break;
        }

        return (play_flg);
    }
}
}
}
