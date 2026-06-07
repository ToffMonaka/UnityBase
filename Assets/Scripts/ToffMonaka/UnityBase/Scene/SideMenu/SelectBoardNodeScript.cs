/**
 * @file
 * @brief SelectBoardNodeScriptファイル
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ToffMonaka.UnityBase.Data;

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief SelectBoardNodeScriptCreateDescクラス
 */
public class SelectBoardNodeScriptCreateDesc : BoardNodeScriptCreateDesc
{
    public System.Action<SelectBoardNodeScript, SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE> onOpenSelect2Board = null;
    public System.Action<SelectBoardNodeScript, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE> onOpenStageBoard = null;
}

/**
 * @brief SelectBoardNodeScriptクラス
 */
public class SelectBoardNodeScript : BoardNodeScript
{
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private GameObject _itemNode = null;

    public new SelectBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    private List<SelectBoardItemNodeScript> _itemNodeScriptContainer = new();
    private System.Action<SelectBoardNodeScript, SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE> _onOpenSelect2Board = null;
    private System.Action<SelectBoardNodeScript, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE> _onOpenStageBoard = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SIDE_MENU_SELECT_BOARD_NODE);
    }

    /**
     * @brief _OnGetBoardType関数
     * @return board_type (board_type)
     */
    protected override SceneUtil.SIDE_MENU_BOARD_TYPE _OnGetBoardType()
    {
        return (SceneUtil.SIDE_MENU_BOARD_TYPE.SELECT);
    }

    /**
     * @brief _OnGetSelect2BoardType関数
     * @return select2_board_type (select2_board_type)
     */
    protected override SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE _OnGetSelect2BoardType()
    {
        return (SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnGetStageBoardType関数
     * @return stage_board_type (stage_board_type)
     */
    protected override SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE _OnGetStageBoardType()
    {
        return (SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.NONE);
    }

    /**
     * @brief _OnAwake関数
     */
    protected override void _OnAwake()
    {
        base._OnAwake();

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

        this._onOpenSelect2Board = this.createDesc.onOpenSelect2Board;
        this._onOpenStageBoard = this.createDesc.onOpenStageBoard;

        this._nameText.SetText(DataUtil.GetText(DataUtil.MST_TEXT_ID.MENU));

        this._itemNode.SetActive(false);

        {// Option ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectBoardItemNodeScript>();
            var script_create_desc = new SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.OPTION);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenSelect2Board(this, SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.OPTION);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// Info ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectBoardItemNodeScript>();
            var script_create_desc = new SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.INFO);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenSelect2Board(this, SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.INFO);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        {// Exit ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectBoardItemNodeScript>();
            var script_create_desc = new SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.EXIT);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.EXIT);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        // Cheat ItemNodeScript Create
        if (Util.GetDebugFlag()) {
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectBoardItemNodeScript>();
            var script_create_desc = new SelectBoardItemNodeScriptCreateDesc();

            script_create_desc.name = DataUtil.GetText(DataUtil.MST_TEXT_ID.CHEAT);
            script_create_desc.onClick = (owner) =>
            {
                this._onOpenStageBoard(this, SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.CHEAT);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
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
            this.SetCreateDesc(new SelectBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SelectBoardNodeScriptCreateDesc;

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

        this._scrollRect.verticalNormalizedPosition = 1.0f;

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        base._OnClose();

        return;
    }
}
}
}
