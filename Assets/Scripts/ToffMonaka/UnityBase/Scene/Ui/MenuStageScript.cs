﻿/**
 * @file
 * @brief MenuStageScriptファイル
 */


using UnityEngine;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief MenuStageScriptCreateDescクラス
 */
public class MenuStageScriptCreateDesc : Lib.Scene.ObjectScriptCreateDesc
{
    public UnityBase.Scene.Ui.MenuScript menuScript = null;
}

/**
 * @brief MenuStageScriptクラス
 */
public class MenuStageScript : Lib.Scene.ObjectScript
{
    [SerializeField] private TMP_Text _nameText = null;

    public new UnityBase.Scene.Ui.MenuStageScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.MenuScript _menuScript = null;
    private UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE _stageType = UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public MenuStageScript()
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
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        this._menuScript = this.createDesc.menuScript;

        this._nameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.SCENE.MENU_STAGE_NAME_MST_STRING_ID_ARRAY[(int)this._stageType]));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.MenuStageScriptCreateDesc;

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
     * @brief GetMenuScript関数
     * @return menu_script (menu_script)
     */
    public UnityBase.Scene.Ui.MenuScript GetMenuScript()
    {
        return (this._menuScript);
    }

    /**
     * @brief GetStageType関数
     * @return stage_type (stage_type)
     */
    public UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE GetStageType()
    {
        return (this._stageType);
    }

    /**
     * @brief _SetStageType関数
     * @param stage_type (stage_type)
     */
    protected void _SetStageType(UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE stage_type)
    {
        this._stageType = stage_type;

        return;
    }
}
}
}