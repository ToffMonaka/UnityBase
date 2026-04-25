/**
 * @file
 * @brief PartsScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief PartsScriptCreateDescクラス
 */
public class PartsScriptCreateDesc : Lib.Scene.ScriptCreateDesc
{
}

/**
 * @brief PartsScriptクラス
 */
public abstract class PartsScript : Lib.Scene.Script
{
    public new Lib.Scene.PartsScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptType関数
     * @return script_type (script_type)
     */
    protected override sealed Lib.Util.SCENE.SCRIPT_TYPE _OnGetScriptType()
    {
        return (Lib.Util.SCENE.SCRIPT_TYPE.PARTS);
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.PARTS);
    }

    /**
     * @brief _OnGetActiveAutoFlag関数
     * @return active_auto_flg (active_auto_flag)
     */
    protected override sealed bool _OnGetActiveAutoFlag()
    {
        return (false);
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
        if (!this.GetCreatedFlag()) {
            this.Create();
        }

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
            this.SetCreateDesc(new Lib.Scene.PartsScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as Lib.Scene.PartsScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _Active関数
     */
    protected override void _Active()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnActive();

        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected override void _Deactive()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnDeactive();

        return;
    }

    /**
     * @brief _Update関数
     */
    protected override void _Update()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnUpdate();

        return;
    }

    /**
     * @brief _FixedUpdate関数
     */
    protected override void _FixedUpdate()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnFixedUpdate();

        return;
    }

    /**
     * @brief _LateUpdate関数
     */
    protected override void _LateUpdate()
    {
        if (!this.GetCreatedFlag()) {
            return;
        }

        this._OnLateUpdate();

        return;
    }

    /**
     * @brief IsControllable関数
     * @return controllable_flg (controllable_flag)<br>
     * false=コントロール不可,true=コントロール可
     */
    public override bool IsControllable()
    {
        if (!base.IsControllable()) {
            return (false);
        }

        return (true);
    }
}
}
}
