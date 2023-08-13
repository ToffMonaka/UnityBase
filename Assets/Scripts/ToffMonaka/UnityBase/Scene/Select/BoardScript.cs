/**
 * @file
 * @brief BoardScriptファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Select {
/**
 * @brief BoardScriptCreateDescクラス
 */
public class BoardScriptCreateDesc : Lib.Scene.ObjectScriptCreateDesc
{
}

/**
 * @brief BoardScriptクラス
 */
public class BoardScript : Lib.Scene.ObjectScript
{
    public new UnityBase.Scene.Select.BoardScriptCreateDesc createDesc{get; private set;} = null;

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
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        this.CompleteOpen();

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        this.CompleteClose();

        return;
    }

    /**
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        this.CompleteClose();

        return;
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
