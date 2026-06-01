/**
 * @file
 * @brief PartsScriptファイル
 */

namespace ToffMonaka {
namespace Tml.Scene {
/**
 * @brief PartsScriptCreateDescクラス
 */
public class PartsScriptCreateDesc : ScriptCreateDesc
{
}

/**
 * @brief PartsScriptクラス
 */
public abstract class PartsScript : Script
{
    public new PartsScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptType関数
     * @return script_type (script_type)
     */
    protected override sealed Util.SCENE.SCRIPT_TYPE _OnGetScriptType()
    {
        return (Util.SCENE.SCRIPT_TYPE.PARTS);
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Util.SCENE.SCRIPT_INDEX.PARTS);
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
    public override void SetCreateDesc(ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new PartsScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as PartsScriptCreateDesc;

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
