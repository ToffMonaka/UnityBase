/**
 * @file
 * @brief StageSelectSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief StageSelectSubSceneScriptCreateDescクラス
 */
public class StageSelectSubSceneScriptCreateDesc : UnityBase.Scene.SelectSubSceneScriptCreateDesc
{
}

/**
 * @brief StageSelectSubSceneScriptクラス
 */
public class StageSelectSubSceneScript : UnityBase.Scene.SelectSubSceneScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private GameObject _stageButtonNode = null;
    [SerializeField] private GameObject _menuNode = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new UnityBase.Scene.StageSelectSubSceneScriptCreateDesc createDesc{get; private set;} = null;

    private List<UnityBase.Scene.StageSelectStageButtonScript> _stageButtonScriptContainer = new List<UnityBase.Scene.StageSelectStageButtonScript>();
    private UnityBase.Constant.Util.SCENE.STAGE_TYPE _stageType = UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE;
    private UnityBase.Scene.MenuScript _menuScript = null;

    /**
     * @brief コンストラクタ
     */
    public StageSelectSubSceneScript()
    {
        this._SetScriptIndex((int)UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.STAGE_SELECT_SUB_SCENE);
        this._SetSelectType(UnityBase.Constant.Util.SCENE.SELECT_TYPE.STAGE);

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

        this._nameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.SCENE.SELECT_NAME_MST_STRING_ID_ARRAY[(int)this.GetSelectType()]));

        this._stageButtonNode.SetActive(false);

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.StageSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.StageSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_2D;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.StageSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.StageSelectStageButtonScriptCreateDesc();

            script_create_desc.stageSelectScript = this;
            script_create_desc.stageType = UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_3D;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
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
	    this.createDesc = create_desc as UnityBase.Scene.StageSelectSubSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        Lib.Scene.Util.GetSoundManager().PlayBgm((int)UnityBase.Constant.Util.SOUND.BGM_INDEX.SELECT);

        this.SetStageType(UnityBase.Constant.Util.SCENE.STAGE_TYPE.NONE);

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

		    switch (this._stageType) {
		    case UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_2D: {
                {// Test2DStageSubSceneScript Create
                    var script = this.GetManager().ChangeSubScene(UnityBase.Constant.Util.FILE_PATH.TEST_2D_STAGE_SUB_SCENE_PREFAB) as UnityBase.Scene.Test2DStageSubSceneScript;
                    var script_create_desc = new UnityBase.Scene.Test2DStageSubSceneScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }

			    break;
		    }
		    case UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_3D: {
                {// Test3DStageSubSceneScript Create
                    var script = this.GetManager().ChangeSubScene(UnityBase.Constant.Util.FILE_PATH.TEST_3D_STAGE_SUB_SCENE_PREFAB) as UnityBase.Scene.Test3DStageSubSceneScript;
                    var script_create_desc = new UnityBase.Scene.Test3DStageSubSceneScriptCreateDesc();

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
     * @brief SetStageType関数
     * @param stage_type (stage_type)
     */
    public void SetStageType(UnityBase.Constant.Util.SCENE.STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        return;
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(UnityBase.Constant.Util.SCENE.STAGE_TYPE stage_type)
    {
        this.SetStageType(stage_type);

        this.Close(1);

        return;
    }
}
}
}
