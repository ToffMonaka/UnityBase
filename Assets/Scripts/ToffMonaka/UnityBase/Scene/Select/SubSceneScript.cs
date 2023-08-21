/**
 * @file
 * @brief SubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Select {
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
    [SerializeField] private GameObject _stageBoardNode = null;
    [SerializeField] private GameObject _backButtonNode = null;
    [SerializeField] private GameObject _menuNode = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new UnityBase.Scene.Select.SubSceneScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Select.StageBoardScript _stageBoardScript = null;
    private UnityBase.Scene.Select.BoardScript _openBoardScript = null;
    private UnityBase.Constant.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;
    private UnityBase.Scene.Select.BackButtonScript _backButtonScript = null;
    private UnityBase.Scene.MenuScript _menuScript = null;

    /**
     * @brief コンストラクタ
     */
    public SubSceneScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_SUB_SCENE);

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
        var canvas_node = this.transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.GetManager().GetMainSceneScript().GetMainCamera();

        {// StageBoardScript Create
            var script = this._stageBoardNode.GetComponent<UnityBase.Scene.Select.StageBoardScript>();
            var script_create_desc = new UnityBase.Scene.Select.StageBoardScriptCreateDesc();

            script_create_desc.subSceneScript = this;

            script.Create(script_create_desc);

            this._stageBoardScript = script;
        }

        {// BackButtonScript Create
            var script = this._backButtonNode.GetComponent<UnityBase.Scene.Select.BackButtonScript>();
            var script_create_desc = new UnityBase.Scene.Select.BackButtonScriptCreateDesc();

            script_create_desc.subSceneScript = this;

            script.Create(script_create_desc);
            script.Open(1);

            this._backButtonScript = script;
        }

        {// MenuScript Create
            var script = this._menuNode.GetComponent<UnityBase.Scene.MenuScript>();
            var script_create_desc = new UnityBase.Scene.MenuScriptCreateDesc();

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
	    this.createDesc = create_desc as UnityBase.Scene.Select.SubSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        Lib.Scene.Util.GetSoundManager().PlayBgm((int)UnityBase.Constant.Util.SOUND.BGM_INDEX.SELECT);

        this._stageType = UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;

        this._ChangeBoard(UnityBase.Constant.Util.SCENE.SELECT_BOARD_TYPE.STAGE, 0);

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
		        case UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_2D: {
                    {// Test2DStageSubSceneScript Create
                        var script = this.GetManager().ChangeSubScene(UnityBase.Constant.Util.FILE_PATH.TEST_2D_STAGE_SUB_SCENE_PREFAB) as UnityBase.Scene.Stage.Test2D.SubSceneScript;
                        var script_create_desc = new UnityBase.Scene.Stage.Test2D.SubSceneScriptCreateDesc();

                        script.Create(script_create_desc);
                        script.Open(1);
                    }

			        break;
		        }
		        case UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_3D: {
                    {// Test3DStageSubSceneScript Create
                        var script = this.GetManager().ChangeSubScene(UnityBase.Constant.Util.FILE_PATH.TEST_3D_STAGE_SUB_SCENE_PREFAB) as UnityBase.Scene.Stage.Test3D.SubSceneScript;
                        var script_create_desc = new UnityBase.Scene.Stage.Test3D.SubSceneScriptCreateDesc();

                        script.Create(script_create_desc);
                        script.Open(1);
                    }

			        break;
		        }
		        }

			    break;
		    }
            case 2: {
                {// TitleSubSceneScript Create
                    var script = this.GetManager().ChangeSubScene(UnityBase.Constant.Util.FILE_PATH.TITLE_SUB_SCENE_PREFAB) as UnityBase.Scene.TitleSubSceneScript;
                    var script_create_desc = new UnityBase.Scene.TitleSubSceneScriptCreateDesc();

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
    public UnityBase.Constant.Util.SCENE.STAGE_TYPE GetStageType()
    {
        return (this._stageType);
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(UnityBase.Constant.Util.SCENE.STAGE_TYPE stage_type)
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
		switch (this._openBoardScript.GetBoardType()) {
		case UnityBase.Constant.Util.SCENE.SELECT_BOARD_TYPE.STAGE: {
            this.Close(1, 2);

			break;
		}
		}

        return;
    }

    /**
     * @brief ChangeBoard関数
     * @param board_type (board_type)
     * @param open_type (open_type)
     */
    private void _ChangeBoard(UnityBase.Constant.Util.SCENE.SELECT_BOARD_TYPE board_type, int open_type)
    {
        if (this._openBoardScript != null) {
            this._openBoardScript.Close(0);

            this._openBoardScript = null;
        }

		switch (board_type) {
		case UnityBase.Constant.Util.SCENE.SELECT_BOARD_TYPE.STAGE: {
            this._openBoardScript = this._stageBoardScript;

			break;
		}
		}

        this._openBoardScript.Open(open_type);

        return;
    }
}
}
}
