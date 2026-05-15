/**
 * @file
 * @brief StageBoardNodeScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu.Side {
/**
 * @brief StageBoardNodeScriptCreateDescクラス
 */
public class StageBoardNodeScriptCreateDesc : UnityBase.Scene.Ui.Menu.Side.BoardNodeScriptCreateDesc
{
    public System.Action<UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScript> onCloseStageBoard = null;
}

/**
 * @brief StageBoardNodeScriptクラス
 */
public abstract class StageBoardNodeScript : UnityBase.Scene.Ui.Menu.Side.BoardNodeScript
{
    public new UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    protected System.Action<UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScript> _onCloseStageBoard = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SIDE_MENU_STAGE_BOARD_NODE);
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

        this._onCloseStageBoard = this.createDesc.onCloseStageBoard;

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.Side.StageBoardNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        return;
    }

    /**
     * @brief _OnDeactive関数
     */
    protected override void _OnDeactive()
    {
        base._OnDeactive();

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
