/**
 * @file
 * @brief Select2BoardNodeScriptファイル
 */


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief Select2BoardNodeScriptCreateDescクラス
 */
public class Select2BoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.BoardNodeScriptCreateDesc
{
    public System.Action<UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScript, UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE> onOpenStageBoard = null;
    public System.Action<UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScript> onCloseSelect2Board = null;
}

/**
 * @brief Select2BoardNodeScriptクラス
 */
public abstract class Select2BoardNodeScript : UnityBase.Scene.Ui.Menu.Side.BoardNodeScript
{
    [SerializeField] protected ScrollRect _scrollRect = null;
    [SerializeField] protected GameObject _itemNode = null;

    public new UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    protected List<UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScript> _itemNodeScriptContainer = new List<UnityBase.Scene.Ui.Menu.Side.SelectBoardItemNodeScript>();
    protected System.Action<UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScript, UnityBase.Util.SCENE.SIDE_MENU_STAGE_BOARD_TYPE> _onOpenStageBoard = null;
    protected System.Action<UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScript> _onCloseSelect2Board = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIDE_MENU_SELECT2_BOARD_NODE);
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

        this._onOpenStageBoard = this.createDesc.onOpenStageBoard;
        this._onCloseSelect2Board = this.createDesc.onCloseSelect2Board;

        this._itemNode.SetActive(false);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.Select2BoardNodeScriptCreateDesc;

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
