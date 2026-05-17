/**
 * @file
 * @brief SubSceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Select {
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
    [SerializeField] private GameObject _stageBoardNode = null;
    [SerializeField] private GameObject _backButtonNode = null;

    public new UnityBase.Scene.Select.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Select.StageBoardNodeScript _stageBoardNodeScript = null;
    private UnityBase.Scene.Select.BoardNodeScript _openBoardNodeScript = null;
    private UnityBase.Scene.Ui.BackButtonNodeScript _backButtonNodeScript = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SELECT_SUB_SCENE_NODE);
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
            var script = this._stageBoardNode.GetComponent<UnityBase.Scene.Select.StageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Select.StageBoardNodeScriptCreateDesc();

            script_create_desc.onOpenStage = (owner, stage_type) =>
            {
                var tmp_stage_type = stage_type;

                this.Close(1, (owner) =>
                {
		            switch (tmp_stage_type) {
		            case UnityBase.Util.SCENE.STAGE_TYPE.TEST_2D: {
                        {// Test2DStageSubSceneNodeScript Create
                            var script = UnityBase.Global.GetSceneManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TEST_2D_STAGE_SUB_SCENE_PREFAB) as UnityBase.Scene.Stage.Test2D.SubSceneNodeScript;
                            var script_create_desc = new UnityBase.Scene.Stage.Test2D.SubSceneNodeScriptCreateDesc();

                            script.Create(script_create_desc);
                            script.Open(1);
                        }

			            break;
		            }
		            case UnityBase.Util.SCENE.STAGE_TYPE.TEST_3D: {
                        {// Test3DStageSubSceneNodeScript Create
                            var script = UnityBase.Global.GetSceneManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TEST_3D_STAGE_SUB_SCENE_PREFAB) as UnityBase.Scene.Stage.Test3D.SubSceneNodeScript;
                            var script_create_desc = new UnityBase.Scene.Stage.Test3D.SubSceneNodeScriptCreateDesc();

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
            var script = this._backButtonNode.GetComponent<UnityBase.Scene.Ui.BackButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.BackButtonNodeScriptCreateDesc();

            script_create_desc.onClick = (UnityBase.Scene.Ui.BackButtonNodeScript owner) =>
            {
		        switch (this._openBoardNodeScript.GetBoardType()) {
		        case UnityBase.Util.SCENE.SELECT_BOARD_TYPE.STAGE: {
                    this.Close(1, (owner) =>
                    {
                        {// TitleSubSceneNodeScript Create
                            var script = UnityBase.Global.GetSceneManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB) as UnityBase.Scene.TitleSubSceneNodeScript;
                            var script_create_desc = new UnityBase.Scene.TitleSubSceneNodeScriptCreateDesc();

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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Select.SubSceneNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Select.SubSceneNodeScriptCreateDesc;

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

        this.OpenBoard(UnityBase.Util.SCENE.SELECT_BOARD_TYPE.STAGE);

		switch (this.GetOpenType()) {
		case 1: {
            {// SimpleCover Add
                var script_create_desc = new UnityBase.Scene.Ui.Cover.SimpleCoverNodeScriptCreateDesc();

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

        UnityBase.Global.GetSceneManager().PlaySoundBgm((int)UnityBase.Util.SOUND.BGM_INDEX.SELECT);

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
                var script_create_desc = new UnityBase.Scene.Ui.Cover.SimpleCoverNodeScriptCreateDesc();

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
    public void OpenBoard(UnityBase.Util.SCENE.SELECT_BOARD_TYPE board_type)
    {
        this.CloseBoard();

        UnityBase.Scene.Select.BoardNodeScript[] board_node_script_ary = {
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
