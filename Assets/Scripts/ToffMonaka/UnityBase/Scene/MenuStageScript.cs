/**
 * @file
 * @brief MenuStageScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief MenuStageScriptCreateDescクラス
 */
public class MenuStageScriptCreateDesc : Lib.Scene.ObjectScriptCreateDesc
{
}

/**
 * @brief MenuStageScriptクラス
 */
public class MenuStageScript : Lib.Scene.ObjectScript
{
    public new UnityBase.Scene.MenuStageScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE _stageType = UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public MenuStageScript()
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
	    this.createDesc = create_desc as UnityBase.Scene.MenuStageScriptCreateDesc;

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
        this.CompleteOpen();

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
        this.CompleteClose();

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
    public UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE GetStageType()
    {
        return (this._stageType);
    }

    /**
     * @brief _SetStageType関数
     * @param stage_type (stage_type)
     */
    protected void _SetStageType(UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        return;
    }
}
}
}
