/**
 * @file
 * @brief SubSceneScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Stage {
/**
 * @brief SubSceneScriptCreateDescクラス
 */
public class SubSceneScriptCreateDesc : Lib.Scene.SubSceneScriptCreateDesc
{
}

/**
 * @brief SubSceneScriptクラス
 */
public class SubSceneScript : Lib.Scene.SubSceneScript
{
    public new UnityBase.Scene.Stage.SubSceneScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Constant.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public SubSceneScript()
    {
        return;
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
     * @return result (result)<br>
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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Stage.SubSceneScriptCreateDesc;

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
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        this.CompleteOpen();

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
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief GetStageType関数
     * @return stage_type (stage_type)
     */
    public UnityBase.Constant.Util.SCENE.STAGE_TYPE GetStageType()
    {
        return (this._stageType);
    }

    /**
     * @brief _SetStageType関数
     * @param stage_type (stage_type)
     */
    protected void _SetStageType(UnityBase.Constant.Util.SCENE.STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        return;
    }
}
}
}
