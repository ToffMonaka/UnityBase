/**
 * @file
 * @brief StageSubSceneNodeScriptファイル
 */

namespace ToffMonaka {
namespace UnityBase.Scene.Stage {
/**
 * @brief StageSubSceneNodeScriptCreateDescクラス
 */
public class StageSubSceneNodeScriptCreateDesc : SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief StageSubSceneNodeScriptクラス
 */
public abstract class StageSubSceneNodeScript : SubSceneNodeScript
{
    public new StageSubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private SceneUtil.STAGE_TYPE _stageType = SceneUtil.STAGE_TYPE.NONE;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.STAGE_SUB_SCENE_NODE);
    }

    /**
     * @brief _OnGetStageType関数
     * @return stage_type (stage_type)
     */
    protected virtual SceneUtil.STAGE_TYPE _OnGetStageType()
    {
        return (SceneUtil.STAGE_TYPE.NONE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        this._stageType = this._OnGetStageType();

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
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new StageSubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as StageSubSceneNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

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
     * @brief GetStageType関数
     * @return stage_type (stage_type)
     */
    public SceneUtil.STAGE_TYPE GetStageType()
    {
        return (this._stageType);
    }
}
}
}
