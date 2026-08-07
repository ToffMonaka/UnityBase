/**
 * @file
 * @brief Test3DStageSubSceneNodeScriptファイル
 */

using UnityEngine;
using ToffMonaka.UnityBase.Scene.Stage;
using ToffMonaka.UnityBase.Scene.CoverSystem;

namespace ToffMonaka {
namespace UnityBase.Scene.Test3DStageSubScene {
/**
 * @brief Test3DStageSubSceneNodeScriptCreateDescクラス
 */
public class Test3DStageSubSceneNodeScriptCreateDesc : StageSubSceneNodeScriptCreateDesc
{
}

/**
 * @brief Test3DStageSubSceneNodeScriptクラス
 */
public class Test3DStageSubSceneNodeScript : StageSubSceneNodeScript
{
#pragma warning disable 0414
    [SerializeField] private GameObject _fieldLayoutNode = null;
    [SerializeField] private FieldNodeScript _fieldNodeScript = null;
    [SerializeField] private GameObject _playerLayoutNode = null;
    [SerializeField] private PlayerNodeScript _playerNodeScript = null;
    [SerializeField] private GameObject _enemyLayoutNode = null;
    [SerializeField] private GameObject _objectLayoutNode = null;

    public new Test3DStageSubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;
#pragma warning restore 0414

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.TEST_3D_STAGE_SUB_SCENE_NODE);
    }

    /**
     * @brief _OnGetStageType関数
     * @return stage_type (stage_type)
     */
    protected override SceneUtil.STAGE_TYPE _OnGetStageType()
    {
        return (SceneUtil.STAGE_TYPE.TEST_3D);
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

        {// FieldNodeScript Create
            var script = this._fieldNodeScript;
            var script_create_desc = new FieldNodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);
        }

        {// PlayerNodeScript Create
            var script = this._playerNodeScript;
            var script_create_desc = new PlayerNodeScriptCreateDesc();

            script.Create(script_create_desc);
            script.Open(0);
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
            this.SetCreateDesc(new Test3DStageSubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as Test3DStageSubSceneNodeScriptCreateDesc;

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

		switch (this.GetOpenType()) {
		case 1: {
            {// SimpleCover Add
                var script_create_desc = new SimpleCoverNodeScriptCreateDesc();

                script_create_desc.color = new Color32(8, 8, 8, 255);
                script_create_desc.playTime = 0.2f;
                script_create_desc.waitTime = 0.05f;
                script_create_desc.reverseFlag = false;

                this.GetCoverSystemNodeScript().AddCover(script_create_desc);
            }

            this.AddOpenCloseChecker((owner) =>
            {
                return (this.GetCoverSystemNodeScript().IsPlay());
            });

			break;
		}
		default: {
			break;
		}
		}

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

		switch (this.GetCloseType()) {
		case 1: {
            {// SimpleCover Add
                var script_create_desc = new SimpleCoverNodeScriptCreateDesc();

                script_create_desc.color = new Color32(8, 8, 8, 255);
                script_create_desc.playTime = 0.2f;
                script_create_desc.waitTime = 0.05f;
                script_create_desc.reverseFlag = true;

                this.GetCoverSystemNodeScript().AddCover(script_create_desc);
            }

            this.AddOpenCloseChecker((owner) =>
            {
                return (this.GetCoverSystemNodeScript().IsPlay());
            });

			break;
		}
		default: {
			break;
		}
		}

        return;
    }
}
}
}
