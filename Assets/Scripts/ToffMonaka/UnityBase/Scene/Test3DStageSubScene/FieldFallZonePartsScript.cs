/**
 * @file
 * @brief FieldFallZonePartsScriptファイル
 */

using UnityEngine;
using ToffMonaka.Tml.Scene;

namespace ToffMonaka {
namespace UnityBase.Scene.Test3DStageSubScene {
/**
 * @brief FieldFallZonePartsScriptCreateDescクラス
 */
public class FieldFallZonePartsScriptCreateDesc : PartsScriptCreateDesc
{
}

/**
 * @brief FieldFallZonePartsScriptクラス
 */
public class FieldFallZonePartsScript : PartsScript
{
    public new FieldFallZonePartsScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.TEST_3D_STAGE_FIELD_FALL_ZONE_PARTS);
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
    public override void SetCreateDesc(ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new FieldFallZonePartsScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as FieldFallZonePartsScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        base._OnDeactive();

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected override void _OnUpdate()
    {
        base._OnUpdate();

        return;
    }

    /**
     * @brief OnTriggerEnter2D関数
     * @param collider (collider)
     */
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<PlayerNodeScript>(out var script)) {
            script.EnterFallZone();
        }

        return;
    }
}
}
}
