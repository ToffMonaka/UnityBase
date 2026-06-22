/**
 * @file
 * @brief BoardNodeScriptファイル
 */

using UnityEngine;
using TMPro;
using DG.Tweening;

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief BoardNodeScriptCreateDescクラス
 */
public class BoardNodeScriptCreateDesc : ToffMonaka.Tml.Scene.NodeScriptCreateDesc
{
}

/**
 * @brief BoardNodeScriptクラス
 */
public abstract class BoardNodeScript : ToffMonaka.Tml.Scene.NodeScript
{
    [SerializeField] protected TMP_Text _nameText = null;

    public new BoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private SceneUtil.SIDE_MENU_BOARD_TYPE _boardType = SceneUtil.SIDE_MENU_BOARD_TYPE.NONE;
    private SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE _select2BoardType = SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.NONE;
    private SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE _stageBoardType = SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.NONE;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SIDE_MENU_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected virtual SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnGetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    protected virtual SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE _OnGetSelect2BoardType()
    {
        return (SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnGetStageBoardType関数
     * @return stage_board_type (stage_board_type)
     */
    protected virtual SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE _OnGetStageBoardType()
    {
        return (SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

        this._boardType = this._OnGetBoardType();
        this._select2BoardType = this._OnGetSelect2BoardType();
        this._stageBoardType = this._OnGetStageBoardType();

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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new BoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as BoardNodeScriptCreateDesc;

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

        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetOpenType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 8.0f - 8.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(0.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(0.0f, rect_transform.anchoredPosition.y);

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
        base._OnClose();

        var rect_transform = this.gameObject.GetComponent<RectTransform>();

		switch (this.GetCloseType()) {
		case 1: {
            rect_transform.anchoredPosition = new Vector2(0.0f, rect_transform.anchoredPosition.y);

            var open_close_sequence = DOTween.Sequence();

            open_close_sequence.Append(rect_transform.DOAnchorPosX(-rect_transform.sizeDelta.x - 8.0f - 8.0f, 0.1f));
            open_close_sequence.SetLink(this.gameObject);

            this.AddOpenCloseSequence(open_close_sequence);

			break;
		}
		default: {
            rect_transform.anchoredPosition = new Vector2(-rect_transform.sizeDelta.x - 8.0f - 8.0f, rect_transform.anchoredPosition.y);

			break;
		}
		}

        return;
    }

    /**
     * @brief GetBoardType関数
     * @return board_type (board_type)
     */
    public SceneUtil.SIDE_MENU_BOARD_TYPE GetBoardType()
    {
        return (this._boardType);
    }

    /**
     * @brief GetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    public SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE GetSelect2BoardType()
    {
        return (this._select2BoardType);
    }

    /**
     * @brief GetStageBoardType関数
     * @return stage_board_type (stage_board_type)
     */
    public SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE GetStageBoardType()
    {
        return (this._stageBoardType);
    }
}
}
}
