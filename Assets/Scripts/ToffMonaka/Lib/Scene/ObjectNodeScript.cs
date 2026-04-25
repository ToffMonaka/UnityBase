/**
 * @file
 * @brief ObjectNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief ObjectNodeScriptCreateDescクラス
 */
public class ObjectNodeScriptCreateDesc : Lib.Scene.NodeScriptCreateDesc
{
}

/**
 * @brief ObjectNodeScriptクラス
 */
public abstract class ObjectNodeScript : Lib.Scene.NodeScript
{
    public new Lib.Scene.ObjectNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptType関数
     * @return script_type (script_type)
     */
    protected override sealed Lib.Util.SCENE.SCRIPT_TYPE _OnGetScriptType()
    {
        return (Lib.Util.SCENE.SCRIPT_TYPE.OBJECT_NODE);
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.OBJECT_NODE);
    }

    /**
     * @brief _OnGetActiveAutoFlag関数
     * @return active_auto_flg (active_auto_flag)
     */
    protected override sealed bool _OnGetActiveAutoFlag()
    {
        return (true);
    }

    /**
     * @brief _Awake関数
     */
    protected override void _Awake()
    {
        base._Awake();

        return;
    }

    /**
     * @brief _Destroy関数
     */
    protected override void _Destroy()
    {
        base._Destroy();

        return;
    }

    /**
     * @brief _Start関数
     */
    protected override void _Start()
    {
        base._Start();

        return;
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new Lib.Scene.ObjectNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as Lib.Scene.ObjectNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _Active関数
     */
    protected override void _Active()
    {
        base._Active();

        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected override void _Deactive()
    {
        base._Deactive();

        return;
    }

    /**
     * @brief _Update関数
     */
    protected override void _Update()
    {
        base._Update();

        return;
    }

    /**
     * @brief _FixedUpdate関数
     */
    protected override void _FixedUpdate()
    {
        base._FixedUpdate();

        return;
    }

    /**
     * @brief _LateUpdate関数
     */
    protected override void _LateUpdate()
    {
        base._LateUpdate();

        return;
    }
}
}
}
