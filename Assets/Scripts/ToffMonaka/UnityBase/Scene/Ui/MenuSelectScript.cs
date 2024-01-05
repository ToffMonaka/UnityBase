/**
 * @file
 * @brief MenuSelectScriptファイル
 */


using UnityEngine;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuSelectScriptCreateDescクラス
 */
public class MenuSelectScriptCreateDesc : Lib.Scene.ObjectScriptCreateDesc
{
    public UnityBase.Scene.Ui.MenuScript menuScript = null;
}

/**
 * @brief MenuSelectScriptクラス
 */
public class MenuSelectScript : Lib.Scene.ObjectScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private GameObject _stageButtonNode = null;

    public new UnityBase.Scene.Ui.MenuSelectScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.MenuScript _menuScript = null;
    private List<UnityBase.Scene.Ui.MenuSelectStageButtonScript> _stageButtonScriptContainer = new List<UnityBase.Scene.Ui.MenuSelectStageButtonScript>();

    /**
     * @brief コンストラクタ
     */
    public MenuSelectScript()
    {
        this._SetScriptIndex((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_SELECT);

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
        this._menuScript = this.createDesc.menuScript;

        this._nameText.SetText(UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.MENU));

        this._stageButtonNode.SetActive(false);

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.MenuSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.selectScript = this;
            script_create_desc.stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.OPTION;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.MenuSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.selectScript = this;
            script_create_desc.stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.FAQ;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.MenuSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.selectScript = this;
            script_create_desc.stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.STAFF;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.MenuSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.selectScript = this;
            script_create_desc.stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.LICENSE;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.MenuSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.selectScript = this;
            script_create_desc.stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.PRIVACY_POLICY;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        {// StageButtonScript Create
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.MenuSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.selectScript = this;
            script_create_desc.stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.END;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
        }

        // StageButtonScript Create
        if (UnityBase.Util.DEBUG_FLAG) {
#pragma warning disable CS0162
            var script = GameObject.Instantiate(this._stageButtonNode, this._stageButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.MenuSelectStageButtonScript>();
            var script_create_desc = new UnityBase.Scene.Ui.MenuSelectStageButtonScriptCreateDesc();

            script_create_desc.selectScript = this;
            script_create_desc.stageType = UnityBase.Util.SCENE.MENU_STAGE_TYPE.CHEAT;

            script.Create(script_create_desc);
            script.Open(0);

            this._stageButtonScriptContainer.Add(script);
#pragma warning restore CS0162
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.NodeScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuSelectScriptCreateDesc;

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
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 8.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(8.0f, rect_transform.anchoredPosition.y);

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
            rect_transform.anchoredPosition = new Vector2(8.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(-rect_transform.sizeDelta.x - 8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 8.0f, rect_transform.anchoredPosition.y);

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
        }

        return;
    }

    /**
     * @brief RunStageButton関数
     * @param stage_type (stage_type)
     */
    public void RunStageButton(UnityBase.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        this._menuScript.RunSelectStageButton(stage_type);

        return;
    }
}
}
}
