/**
 * @file
 * @brief SubSceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Stage {
/**
 * @brief SubSceneNodeScriptCreateDescクラス
 */
public class SubSceneNodeScriptCreateDesc : UnityBase.Scene.SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief SubSceneNodeScriptクラス
 */
public class SubSceneNodeScript : UnityBase.Scene.SubSceneNodeScript
{
    [SerializeField] protected GameObject _backButtonNode = null;

    public new UnityBase.Scene.Stage.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Util.SCENE.STAGE_TYPE.NONE;
    protected UnityBase.Scene.Stage.BackButtonNodeScript _backButtonNodeScript = null;

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
     * @brief _OnGetNodeScriptIndex関数
     * @return node_script_index (node_script_index)
     */
    protected override int _OnGetNodeScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.STAGE_SUB_SCENE);
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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
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
     * @brief _OnOpen関数
     */
    protected override void _OnOpen()
    {
        base._OnOpen();

        return;
    }

    /**
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
        base._OnOpened();

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
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        base._OnClosed();

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
