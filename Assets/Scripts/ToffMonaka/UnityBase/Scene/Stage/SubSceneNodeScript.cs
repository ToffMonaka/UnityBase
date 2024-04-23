/**
 * @file
 * @brief SubSceneNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Stage {
/**
 * @brief SubSceneNodeScriptCreateDescクラス
 */
public class SubSceneNodeScriptCreateDesc : Lib.Scene.SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief SubSceneNodeScriptクラス
 */
public class SubSceneNodeScript : Lib.Scene.SubSceneNodeScript
{
    [SerializeField] private GameObject _backButtonNode = null;
    [SerializeField] private GameObject _menuNode = null;

    public new UnityBase.Scene.Stage.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Util.SCENE.STAGE_TYPE.NONE;
    private UnityBase.Scene.Stage.BackButtonNodeScript _backButtonNodeScript = null;
    private UnityBase.Scene.Ui.Menu.NodeScript _menuNodeScript = null;

    /**
     * @brief コンストラクタ
     * @param stage_type (stage_type)
     */
    public SubSceneNodeScript(UnityBase.Util.SCENE.STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.STAGE_SUB_SCENE_NODE);
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
        {// BackButtonNodeScript Create
            var script = this._backButtonNode.GetComponent<UnityBase.Scene.Stage.BackButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Stage.BackButtonNodeScriptCreateDesc();

            script_create_desc.onClick = (UnityBase.Scene.Stage.BackButtonNodeScript owner) => {
                this.Close(1, 1);

                return;
            };

            script.Create(script_create_desc);
            script.Open(1);

            this._backButtonNodeScript = script;
        }

        {// MenuNodeScript Create
            var script = this._menuNode.GetComponent<UnityBase.Scene.Ui.Menu.NodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Menu.NodeScriptCreateDesc();

            script_create_desc.subSceneNodeScript = this;

            script.Create(script_create_desc);
            script.Open(0);

            this._menuNodeScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Stage.SubSceneNodeScriptCreateDesc;

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
}
}
}
