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
public abstract class SubSceneNodeScript : UnityBase.Scene.SubSceneNodeScript
{
    [SerializeField] protected GameObject _backButtonNode = null;

    public new UnityBase.Scene.Stage.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Util.SCENE.STAGE_TYPE.NONE;
    protected UnityBase.Scene.Ui.BackButtonNodeScript _backButtonNodeScript = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.STAGE_SUB_SCENE_NODE);
    }

    /**
     * @brief _OnGetStageType関数
     * @return stage_type (stage_type)
     */
    protected virtual UnityBase.Util.SCENE.STAGE_TYPE _OnGetStageType()
    {
        return (UnityBase.Util.SCENE.STAGE_TYPE.NONE);
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

        {// BackButtonNodeScript Create
            var script = this._backButtonNode.GetComponent<UnityBase.Scene.Ui.BackButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.BackButtonNodeScriptCreateDesc();

            script_create_desc.onClick = (UnityBase.Scene.Ui.BackButtonNodeScript owner) =>
            {
                this.Close(1, (owner) =>
                {
                    {// SelectSubSceneNodeScript Create
                        var script = UnityBase.Global.GetSceneManager().ChangeSubScene(UnityBase.Util.FILE_PATH.SELECT_SUB_SCENE_PREFAB) as UnityBase.Scene.Select.SubSceneNodeScript;
                        var script_create_desc = new UnityBase.Scene.Select.SubSceneNodeScriptCreateDesc();

                        script.Create(script_create_desc);
                        script.Open(1);
                    }

                    return;
                });

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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Stage.SubSceneNodeScriptCreateDesc());

            return;
        }

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
    public UnityBase.Util.SCENE.STAGE_TYPE GetStageType()
    {
        return (this._stageType);
    }
}
}
}
