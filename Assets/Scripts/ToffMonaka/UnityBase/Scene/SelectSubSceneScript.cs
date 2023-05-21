/**
 * @file
 * @brief SelectSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief SelectSubSceneScriptCreateDescクラス
 */
public class SelectSubSceneScriptCreateDesc : ToffMonaka.Lib.Scene.SubSceneScriptCreateDesc
{
}

/**
 * @brief SelectSubSceneScriptクラス
 */
public class SelectSubSceneScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    [SerializeField] private Image _openCloseFadeImage = null;
    [SerializeField] private ToffMonaka.UnityBase.Scene.SelectSubSceneStageItemScript[] _stageItemScriptArray = null;

    public new ToffMonaka.UnityBase.Scene.SelectSubSceneScriptCreateDesc createDesc{get; private set;} = null;
    private Sequence _openCloseFadeSequence = null;
    private int _stageItemSelectIndex = 0;

    /**
     * @brief コンストラクタ
     */
    public SelectSubSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.SELECT_SUB_SCENE);

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

        this._stageItemScriptArray[0].Set(this, 0, "Test2D");
        this._stageItemScriptArray[1].Set(this, 1, "Test3D");

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.SelectSubSceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlayBgm((int)ToffMonaka.UnityBase.Constant.Util.SOUND.BGM_INDEX.SELECT);

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

            this._openCloseFadeSequence = DOTween.Sequence();
            this._openCloseFadeSequence.AppendInterval(0.05f);
            this._openCloseFadeSequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));

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
		switch (this.GetOpenType()) {
		case 1: {
            if (!this._openCloseFadeSequence.IsActive()) {
                this.CompleteOpen();

                this._openCloseFadeImage.gameObject.SetActive(false);
            }

			break;
		}
		default: {
            this.CompleteOpen();

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
		switch (this.GetCloseType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 0);

            this._openCloseFadeSequence = DOTween.Sequence();
            this._openCloseFadeSequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
            this._openCloseFadeSequence.AppendInterval(0.05f);

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
		switch (this.GetCloseType()) {
		case 1: {
            if (!this._openCloseFadeSequence.IsActive()) {
                this.CompleteClose();

                // Test2DStageSubScene Create
                if (this._stageItemSelectIndex == 0) {
                    var script = this.GetManager().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_2D_STAGE_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.Test2DStageSubSceneScript;
                    var script_create_desc = new ToffMonaka.UnityBase.Scene.Test2DStageSubSceneScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }

                // Test3DStageSubScene Create
                if (this._stageItemSelectIndex == 1) {
                    var script = this.GetManager().ChangeSubScene(ToffMonaka.UnityBase.Constant.Util.FILE_PATH.TEST_3D_STAGE_SUB_SCENE_PREFAB) as ToffMonaka.UnityBase.Scene.Test3DStageSubSceneScript;
                    var script_create_desc = new ToffMonaka.UnityBase.Scene.Test3DStageSubSceneScriptCreateDesc();

                    script.Create(script_create_desc);
                    script.Open(1);
                }
            }

			break;
		}
		default: {
            this.CompleteClose();

			break;
		}
		}

        return;
    }

    /**
     * @brief GetStageItemSelectIndex関数
     * @return stage_item_select_index (stage_item_select_index)
     */
    public int GetStageItemSelectIndex()
    {
        return (this._stageItemSelectIndex);
    }

    /**
     * @brief StageItemSelectIndex関数
     * @param stage_item_select_index (stage_item_select_index)
     */
    public void SetStageItemSelectIndex(int stage_item_select_index)
    {
        this._stageItemSelectIndex = stage_item_select_index;

        return;
    }
}
}
