/**
 * @file
 * @brief MenuSelectScriptファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuSelectScriptCreateDescクラス
 */
public class MenuSelectScriptCreateDesc : ToffMonaka.Lib.Scene.SubSceneScriptCreateDesc
{
}

/**
 * @brief MenuSelectScriptクラス
 */
public class MenuSelectScript : ToffMonaka.Lib.Scene.SubSceneScript
{
    public new ToffMonaka.UnityBase.Scene.MenuSelectScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_SELECT_TYPE _selectType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_SELECT_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public MenuSelectScript()
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
     * @brief GetSelectType関数
     * @return select_type (select_type)
     */
    public ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_SELECT_TYPE GetSelectType()
    {
        return (this._selectType);
    }

    /**
     * @brief _SetSelectType関数
     * @param select_type (select_type)
     */
    protected void _SetSelectType(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_SELECT_TYPE select_type)
    {
        this._selectType = select_type;

        return;
    }
}
}
