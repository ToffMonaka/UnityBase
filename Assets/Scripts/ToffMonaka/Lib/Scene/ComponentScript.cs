/**
 * @file
 * @brief ComponentScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief ComponentScriptCreateDescクラス
 */
public class ComponentScriptCreateDesc : Lib.Scene.ScriptCreateDesc
{
}

/**
 * @brief ComponentScriptクラス
 */
public abstract class ComponentScript : Lib.Scene.Script
{
    public new Lib.Scene.ComponentScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public ComponentScript() : base(Lib.Util.SCENE.SCRIPT_TYPE.COMPONENT)
    {
        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.COMPONENT);
    }

    /**
     * @brief _Awake関数
     */
    protected override void _Awake()
    {
        this._OnAwake();

        return;
    }

    /**
     * @brief _Destroy関数
     */
    protected override void _Destroy()
    {
        this._OnDestroy();

        if (this.GetManager() != null) {
            this.GetManager().RemoveScript(this);
        }

        return;
    }

    /**
     * @brief _OnSetNode関数
     */
    protected virtual void _OnSetNode()
    {
        return;
    }
    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public override int Create(Lib.Scene.ScriptCreateDesc desc = null)
    {
        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            if (Lib.Scene.Util.GetManager() != null) {
                if (Lib.Scene.Util.GetManager().AddScript(this) < 0) {
                    return (-1);
                }
            } else {
                return (-1);
            }

            this._OnSetNode();
        }

        int create_result_val = this._OnCreate();

        if (create_result_val < 0) {
            return (create_result_val);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.ComponentScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _Active関数
     */
    protected override void _Active()
    {
        this._OnActive();

        return;
    }

    /**
     * @brief _Deactive関数
     */
    protected override void _Deactive()
    {
        this._OnDeactive();

        return;
    }

    /**
     * @brief _FirstUpdate関数
     */
    protected override void _FirstUpdate()
    {
        this._OnFirstUpdate();

        return;
    }

    /**
     * @brief _Update関数
     */
    protected override void _Update()
    {
        this._OnUpdate();

        return;
    }

    /**
     * @brief _FixedUpdate関数
     */
    protected override void _FixedUpdate()
    {
        this._OnFixedUpdate();

        return;
    }

    /**
     * @brief _LateUpdate関数
     */
    protected override void _LateUpdate()
    {
        this._OnLateUpdate();

        return;
    }
}
}
}
