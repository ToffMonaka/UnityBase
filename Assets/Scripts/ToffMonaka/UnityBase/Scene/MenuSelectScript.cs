/**
 * @file
 * @brief MenuSelectScriptファイル
 */


using UnityEngine;
using DG.Tweening;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuSelectScriptCreateDescクラス
 */
public class MenuSelectScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuScript menuScript = null;
}

/**
 * @brief MenuSelectScriptクラス
 */
public class MenuSelectScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private GameObject _stageSelectNode = null;

    public new ToffMonaka.UnityBase.Scene.MenuSelectScriptCreateDesc createDesc{get; private set;} = null;
    private Sequence _openCloseSequence = null;

    private ToffMonaka.UnityBase.Scene.MenuScript _menuScript = null;
    private ToffMonaka.UnityBase.Scene.MenuSelectStageSelectScript _stageSelectScript = null;
    private ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE _stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public MenuSelectScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_SELECT);

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
        this._menuScript = this.createDesc.menuScript;

        {// StageSelectScript Create
            var script = this._stageSelectNode.GetComponent<ToffMonaka.UnityBase.Scene.MenuSelectStageSelectScript>();
            var script_create_desc = new ToffMonaka.UnityBase.Scene.MenuSelectStageSelectScriptCreateDesc();

            script_create_desc.selectScript = this;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageSelectScript = script;
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuSelectScriptCreateDesc;

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
        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetOpenType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 4.0f, rect_transform.anchoredPosition.y);

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(rect_transform.DOAnchorPosX(4.0f, 0.1f));

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(4.0f, rect_transform.anchoredPosition.y);

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
        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetCloseType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(4.0f, rect_transform.anchoredPosition.y);

            this._openCloseSequence = DOTween.Sequence();
            this._openCloseSequence.Append(rect_transform.DOAnchorPosX(-rect_transform.sizeDelta.x - 4.0f, 0.1f));

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 4.0f, rect_transform.anchoredPosition.y);

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

    /**
     * @brief GetStageType関数
     * @return stage_type (stage_type)
     */
    public ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE GetStageIndex()
    {
        return (this._stageType);
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        return;
    }
}
}
