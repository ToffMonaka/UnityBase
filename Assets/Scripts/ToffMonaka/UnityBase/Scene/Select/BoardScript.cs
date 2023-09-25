﻿/**
 * @file
 * @brief BoardScriptファイル
 */


using UnityEngine;
using TMPro;
using DG.Tweening;


namespace ToffMonaka {
namespace UnityBase.Scene.Select {
/**
 * @brief BoardScriptCreateDescクラス
 */
public class BoardScriptCreateDesc : Lib.Scene.ObjectScriptCreateDesc
{
    public UnityBase.Scene.Select.SubSceneScript subSceneScript = null;
}

/**
 * @brief BoardScriptクラス
 */
public class BoardScript : Lib.Scene.ObjectScript
{
    [SerializeField] private TMP_Text _nameText = null;

    public new UnityBase.Scene.Select.BoardScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Select.SubSceneScript _subSceneScript = null;
    private UnityBase.Constant.Util.SCENE.SELECT_BOARD_TYPE _boardType = UnityBase.Constant.Util.SCENE.SELECT_BOARD_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public BoardScript()
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
        this._subSceneScript = this.createDesc.subSceneScript;

        this._nameText.SetText(UnityBase.Global.GetString(UnityBase.Constant.Util.SCENE.SELECT_BOARD_NAME_MST_STRING_ID_ARRAY[(int)this._boardType]));

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Select.BoardScriptCreateDesc;

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
            rect_transform.anchoredPosition = new Vector2(rect_transform.sizeDelta.x + 8.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(-8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(-8.0f, rect_transform.anchoredPosition.y);

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
            rect_transform.anchoredPosition = new Vector2(-8.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(rect_transform.sizeDelta.x + 8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(rect_transform.sizeDelta.x + 8.0f, rect_transform.anchoredPosition.y);

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
     * @brief GetSubSceneScript関数
     * @return sub_scene_script (sub_scene_script)
     */
    public UnityBase.Scene.Select.SubSceneScript GetSubSceneScript()
    {
        return (this._subSceneScript);
    }

    /**
     * @brief GetBoardType関数
     * @return board_type (board_type)
     */
    public UnityBase.Constant.Util.SCENE.SELECT_BOARD_TYPE GetBoardType()
    {
        return (this._boardType);
    }

    /**
     * @brief _SetBoardType関数
     * @param board_type (board_type)
     */
    protected void _SetBoardType(UnityBase.Constant.Util.SCENE.SELECT_BOARD_TYPE board_type)
    {
        this._boardType = board_type;

        return;
    }
}
}
}