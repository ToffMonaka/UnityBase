/**
 * @file
 * @brief SliderPartsScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief SliderPartsScriptCreateDescクラス
 */
public class SliderPartsScriptCreateDesc : Lib.Scene.PartsScriptCreateDesc
{
}

/**
 * @brief SliderPartsScriptクラス
 */
public class SliderPartsScript : Lib.Scene.PartsScript
{
    public new Lib.Scene.SliderPartsScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.SLIDER_PARTS);
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
            this.SetCreateDesc(new Lib.Scene.SliderPartsScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as Lib.Scene.SliderPartsScriptCreateDesc;

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
}
}
}
