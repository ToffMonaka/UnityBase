/**
 * @file
 * @brief SelectSubSceneNodeScriptファイル
 */

using UnityEngine;
using ToffMonaka.UnityBase.Sound;
using ToffMonaka.UnityBase.Scene;
using ToffMonaka.UnityBase.Scene.TitleSubScene;
using ToffMonaka.UnityBase.Scene.Test2DStageSubScene;
using ToffMonaka.UnityBase.Scene.Test3DStageSubScene;
using ToffMonaka.UnityBase.Scene.CoverSystem;

namespace ToffMonaka {
namespace UnityBase.SelectSubScene {
/**
 * @brief SelectSubSceneNodeScriptCreateDescクラス
 */
public class SelectSubSceneNodeScriptCreateDesc : SubSceneNodeScriptCreateDesc
{
}

/**
 * @brief SelectSubSceneNodeScriptクラス
 */
public class SelectSubSceneNodeScript : SubSceneNodeScript
{
    [SerializeField] private GameObject _stageBoardNode = null;
    [SerializeField] private GameObject _backButtonNode = null;

    public new SelectSubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private StageBoardNodeScript _stageBoardNodeScript = null;
    private BoardNodeScript _openBoardNodeScript = null;
    private BackButtonNodeScript _backButtonNodeScript = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SELECT_SUB_SCENE_NODE);
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

        {// StageBoardNodeScript Create
            var script = this._stageBoardNode.GetComponent<StageBoardNodeScript>();
            var script_create_desc = new StageBoardNodeScriptCreateDesc();

            script_create_desc.onOpenStage = (owner, stage_type) =>
            {
                var tmp_stage_type = stage_type;

                this.Close(1, (owner) =>
                {
		            switch (tmp_stage_type) {
		            case SceneUtil.STAGE_TYPE.TEST_2D: {
                        {// Test2DStageSubSceneNodeScript Create
                            var script = SceneUtil.GetManager().ChangeSubScene(Util.FILE_PATH.TEST_2D_STAGE_SUB_SCENE_PREFAB) as Test2DStageSubSceneNodeScript;
                            var script_create_desc = new Test2DStageSubSceneNodeScriptCreateDesc();

                            script.Create(script_create_desc);
                            script.Open(1);
                        }

			            break;
		            }
		            case SceneUtil.STAGE_TYPE.TEST_3D: {
                        {// Test3DStageSubSceneNodeScript Create
                            var script = SceneUtil.GetManager().ChangeSubScene(Util.FILE_PATH.TEST_3D_STAGE_SUB_SCENE_PREFAB) as Test3DStageSubSceneNodeScript;
                            var script_create_desc = new Test3DStageSubSceneNodeScriptCreateDesc();

                            script.Create(script_create_desc);
                            script.Open(1);
                        }

			            break;
		            }
		            }

			        return;
                });
            };

            script.Create(script_create_desc);

            this._stageBoardNodeScript = script;
        }

        {// BackButtonNodeScript Create
            var script = this._backButtonNode.GetComponent<BackButtonNodeScript>();
            var script_create_desc = new BackButtonNodeScriptCreateDesc();

            script_create_desc.onClick = (owner) =>
            {
		        switch (this._openBoardNodeScript.GetBoardType()) {
		        case SceneUtil.SELECT_BOARD_TYPE.STAGE: {
                    this.Close(1, (owner) =>
                    {
                        {// TitleSubSceneNodeScript Create
                            var script = SceneUtil.GetManager().ChangeSubScene(Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB) as TitleSubSceneNodeScript;
                            var script_create_desc = new TitleSubSceneNodeScriptCreateDesc();

                            script.Create(script_create_desc);
                            script.Open(1);
                        }

                        return;
                    });

			        break;
		        }
		        }

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
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SelectSubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SelectSubSceneNodeScriptCreateDesc;

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

        this.OpenBoard(SceneUtil.SELECT_BOARD_TYPE.STAGE);

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

        SceneUtil.GetManager().PlaySoundBgm((int)SoundUtil.BGM_SOUND_INDEX.SELECT);

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

    /**
     * @brief OpenBoard関数
     * @param board_type (board_type)
     */
    public void OpenBoard(SceneUtil.SELECT_BOARD_TYPE board_type)
    {
        this.CloseBoard();

        BoardNodeScript[] board_node_script_ary = {
            null,
            this._stageBoardNodeScript
        };

        this._openBoardNodeScript = board_node_script_ary[(int)board_type];

        if (this._openBoardNodeScript != null) {
            this._openBoardNodeScript.Open(1);
        }

        return;
    }

    /**
     * @brief CloseBoard関数
     */
    public void CloseBoard()
    {
        if (this._openBoardNodeScript == null) {
            return;
        }

        this._openBoardNodeScript.Close(1);

        this._openBoardNodeScript = null;

        return;
    }
}
}
}
