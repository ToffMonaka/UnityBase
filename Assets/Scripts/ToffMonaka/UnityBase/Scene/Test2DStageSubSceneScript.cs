/**
 * @file
 * @brief Test2DStageSubSceneScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief Test2DStageSubSceneScriptCreateDescクラス
 */
public class Test2DStageSubSceneScriptCreateDesc : ToffMonaka.UnityBase.Scene.StageSubSceneScriptCreateDesc
{
}

/**
 * @brief Test2DStageSubSceneScriptクラス
 */
public class Test2DStageSubSceneScript : ToffMonaka.UnityBase.Scene.StageSubSceneScript
{
    [SerializeField] private TextMeshProUGUI _nameText = null;
    [SerializeField] private GameObject _menuNode = null;
    [SerializeField] private Image _openCloseFadeImage = null;

    public new ToffMonaka.UnityBase.Scene.Test2DStageSubSceneScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;
    private Sequence _openCloseSequence = null;

    /**
     * @brief コンストラクタ
     */
    public Test2DStageSubSceneScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.TEST_2D_STAGE_SUB_SCENE);
        this._SetStageType(ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.TEST_2D);

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

        this._nameText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE_NAME_ARRAY[(int)this.GetStageType()]);

        {// MenuScript Create
            var script = this._menuNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuScriptCreateDesc();

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
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.Test2DStageSubSceneScriptCreateDesc;

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
		switch (this.GetOpenType()) {
		case 1: {
            this._openCloseFadeImage.gameObject.SetActive(true);
            this._openCloseFadeImage.color = new Color32(8, 8, 8, 255);

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.AppendInterval(0.05f);
            this._openCloseSequence.Append(this._openCloseFadeImage.DOFade(0.0f, 0.2f));

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
            if (!this._openCloseSequence.IsActive()) {
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

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(this._openCloseFadeImage.DOFade(1.0f, 0.2f));
            this._openCloseSequence.AppendInterval(0.05f);

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
            if (!this._openCloseSequence.IsActive()) {
                this.CompleteClose();
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
}
}
