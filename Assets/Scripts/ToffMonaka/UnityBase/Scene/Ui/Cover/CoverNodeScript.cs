/**
 * @file
 * @brief CoverNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Cover {
/**
 * @brief CoverNodeScriptCreateDescクラス
 */
public class CoverNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    /**
     * @brief GetPrefabFilePath関数
     * @return prefab_file_path (prefab_file_path)
     */
    public virtual string GetPrefabFilePath()
    {
        return (System.String.Empty);
    }

    /**
     * @brief GetNewScript関数
     * @param prefab_file_path (prefab_file_path)
     * @return script (script)
     */
    public virtual UnityBase.Scene.Ui.Cover.CoverNodeScript GetNewScript(string prefab_file_path)
    {
        return (null);
    }
}

/**
 * @brief CoverNodeScriptクラス
 */
public abstract class CoverNodeScript : Lib.Scene.ObjectNodeScript
{
    public new UnityBase.Scene.Ui.Cover.CoverNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.COVER_NODE);
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
        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Cover.CoverNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Cover.CoverNodeScriptCreateDesc;

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
     * @brief IsPlay関数
     * @return play_flg (play_flag)<br>
     * false=非プレイ,true=プレイ
     */
    public virtual bool IsPlay()
    {
        return (false);
    }
}
}
}
