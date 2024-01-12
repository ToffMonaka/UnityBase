/**
 * @file
 * @brief SubSceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Select {
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
    [SerializeField] private GameObject _stageBoardNode = null;
    [SerializeField] private GameObject _backButtonNode = null;
    [SerializeField] private GameObject _menuNode = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new UnityBase.Scene.Select.SubSceneNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Select.StageBoardNodeScript _stageBoardNodeScript = null;
    private UnityBase.Scene.Select.BoardNodeScript _openBoardNodeScript = null;
    private UnityBase.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Util.SCENE.STAGE_TYPE.NONE;
    private UnityBase.Scene.Select.BackButtonNodeScript _backButtonNodeScript = null;
    private UnityBase.Scene.Ui.MenuNodeScript _menuNodeScript = null;

    /**
     * @brief コンストラクタ
     */
    public SubSceneNodeScript() : base((int)UnityBase.Util.SCENE.NODE_SCRIPT_INDEX.SELECT_SUB_SCENE)
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
        {// StageBoardNodeScript Create
            var script = this._stageBoardNode.GetComponent<UnityBase.Scene.Select.StageBoardNodeScript>();
            var script_create_desc = new UnityBase.Scene.Select.StageBoardNodeScriptCreateDesc();

            script_create_desc.subSceneNodeScript = this;

            script.Create(script_create_desc);

            this._stageBoardNodeScript = script;
        }

        {// BackButtonNodeScript Create
            var script = this._backButtonNode.GetComponent<UnityBase.Scene.Select.BackButtonNodeScript>();
            var script_create_desc = new UnityBase.Scene.Select.BackButtonNodeScriptCreateDesc();

            script_create_desc.subSceneNodeScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._backButtonNodeScript = script;
        }

        {// MenuNodeScript Create
            var script = this._menuNode.GetComponent<UnityBase.Scene.Ui.MenuNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuNodeScriptCreateDesc();

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
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Select.SubSceneNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        Lib.Scene.Util.GetSoundManager().PlayBgm((int)UnityBase.Util.SOUND.BGM_INDEX.SELECT);

        this._stageType = UnityBase.Util.SCENE.STAGE_TYPE.NONE;

        this.ChangeBoard(UnityBase.Util.SCENE.SELECT_BOARD_TYPE.STAGE, 0);

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
		switch (this.GetOpenType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 255);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.AppendInterval(0.05f);
            open_close_sequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            this._openCloseFadeImage.gameObject.SetActive(false);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteOpen();

            this._openCloseFadeImage.gameObject.SetActive(false);
        }

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
		switch (this.GetCloseType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 0);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
            open_close_sequence.AppendInterval(0.05f);
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            this._openCloseFadeImage.gameObject.SetActive(false);

			break;
		}
		}

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        if (!this.IsActiveOpenCloseSequence()) {
            this.CompleteClose();

		    switch (this.GetClosedType()) {
            case 1: {
		        switch (this._stageType) {
		        case UnityBase.Util.SCENE.STAGE_TYPE.TEST_2D: {
                    {// Test2DStageSubSceneNodeScript Create
                        var script = this.GetManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TEST_2D_STAGE_SUB_SCENE_PREFAB) as UnityBase.Scene.Stage.Test2D.SubSceneNodeScript;
                        var script_create_desc = new UnityBase.Scene.Stage.Test2D.SubSceneNodeScriptCreateDesc();

                        script.Create(script_create_desc);
                        script.Open(1);
                    }

			        break;
		        }
		        case UnityBase.Util.SCENE.STAGE_TYPE.TEST_3D: {
                    {// Test3DStageSubSceneNodeScript Create
                        var script = this.GetManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TEST_3D_STAGE_SUB_SCENE_PREFAB) as UnityBase.Scene.Stage.Test3D.SubSceneNodeScript;
                        var script_create_desc = new UnityBase.Scene.Stage.Test3D.SubSceneNodeScriptCreateDesc();

                        script.Create(script_create_desc);
                        script.Open(1);
                    }

			        break;
		        }
		        }

			    break;
		    }
            case 2: {
                {// TitleSubSceneNodeScript Create
                    var script = this.GetManager().ChangeSubScene(UnityBase.Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB) as UnityBase.Scene.TitleSubSceneNodeScript;
                    var script_create_desc = new UnityBase.Scene.TitleSubSceneNodeScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }

			    break;
		    }
		    }
        }

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
     * @brief ChangeBoard関数
     * @param board_type (board_type)
     * @param open_type (open_type)
     */
    public void ChangeBoard(UnityBase.Util.SCENE.SELECT_BOARD_TYPE board_type, int open_type)
    {
        if (this._openBoardNodeScript != null) {
            this._openBoardNodeScript.Close(0);

            this._openBoardNodeScript = null;
        }

		switch (board_type) {
		case UnityBase.Util.SCENE.SELECT_BOARD_TYPE.STAGE: {
            this._openBoardNodeScript = this._stageBoardNodeScript;

			break;
		}
		}

        this._openBoardNodeScript.Open(open_type);

        return;
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(UnityBase.Util.SCENE.STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        this.Close(1, 1);

        return;
    }

    /**
     * @brief RunBackButton関数
     */
    public void RunBackButton()
    {
		switch (this._openBoardNodeScript.GetBoardType()) {
		case UnityBase.Util.SCENE.SELECT_BOARD_TYPE.STAGE: {
            this.Close(1, 2);

			break;
		}
		}

        return;
    }
}
}
}
