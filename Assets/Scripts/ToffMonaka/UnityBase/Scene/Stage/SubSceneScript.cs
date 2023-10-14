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
    [SerializeField] private GameObject _backButtonNode = null;
    [SerializeField] private GameObject _menuNode = null;

    public new UnityBase.Scene.Stage.SubSceneScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Util.SCENE.STAGE_TYPE.NONE;
    private UnityBase.Scene.Stage.BackButtonScript _backButtonScript = null;
    private UnityBase.Scene.Ui.MenuScript _menuScript = null;

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
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        {// BackButtonScript Create
            var script = this._backButtonNode.GetComponent<UnityBase.Scene.Stage.BackButtonScript>();
            var script_create_desc = new UnityBase.Scene.Stage.BackButtonScriptCreateDesc();

            script_create_desc.subSceneScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._backButtonScript = script;
        }

        {// MenuScript Create
            var script = this._menuNode.GetComponent<UnityBase.Scene.Ui.MenuScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuScriptCreateDesc();

            script_create_desc.subSceneScript = this;

            script.Create(script_create_desc);
            script.Open(0);

            this._menuScript = script;
        }

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
        return;
    }

    /**
     * @brief GetStageType関数
     * @return stage_type (stage_type)
     */
    public UnityBase.Util.SCENE.STAGE_TYPE GetStageType()
    {
        return (this._stageType);
    }

    /**
     * @brief _SetStageType関数
     * @param stage_type (stage_type)
     */
    protected void _SetStageType(UnityBase.Util.SCENE.STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        return;
    }

    /**
     * @brief RunBackButton関数
     */
    public virtual void RunBackButton()
    {
        return;
    }
}
}
}
