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
     * @brief コンストラクタ
     * @param node_script_index (node_script_index)
     */
    public ObjectNodeScript(int node_script_index) : base(Lib.Util.SCENE.NODE_SCRIPT_TYPE.OBJECT, node_script_index, true)
    {
        return;
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
     * @brief _OnSetNode関数
     */
    protected override void _OnSetNode()
    {
        return;
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
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
     * @brief _FirstUpdate関数
     */
    protected override void _FirstUpdate()
    {
        base._FirstUpdate();

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
