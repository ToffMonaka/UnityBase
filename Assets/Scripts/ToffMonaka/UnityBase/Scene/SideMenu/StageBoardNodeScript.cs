/**
 * @file
 * @brief StageBoardNodeScriptファイル
 */

namespace ToffMonaka {
namespace UnityBase.Scene.SideMenu {
/**
 * @brief StageBoardNodeScriptCreateDescクラス
 */
public class StageBoardNodeScriptCreateDesc : BoardNodeScriptCreateDesc
{
    public System.Action<StageBoardNodeScript> onCloseStageBoard = null;
}

/**
 * @brief StageBoardNodeScriptクラス
 */
public abstract class StageBoardNodeScript : BoardNodeScript
{
    public new StageBoardNodeScriptCreateDesc createDesc{get; private set;} = null;

    protected System.Action<StageBoardNodeScript> _onCloseStageBoard = null;

    /**
     * @brief _OnGetScriptType関数
     * @return script_type (script_type)
     */
    protected override ToffMonaka.Tml.Scene.SceneUtil.SCRIPT_TYPE _OnGetScriptType()
    {
        return ((ToffMonaka.Tml.Scene.SceneUtil.SCRIPT_TYPE)SceneUtil.SCRIPT_TYPE.SIDE_MENU_STAGE_BOARD_NODE);
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
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new StageBoardNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as StageBoardNodeScriptCreateDesc;

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
