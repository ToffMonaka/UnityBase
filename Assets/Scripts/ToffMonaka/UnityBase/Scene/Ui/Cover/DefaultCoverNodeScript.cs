/**
 * @file
 * @brief DefaultCoverNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Cover {
/**
 * @brief DefaultCoverNodeScriptCreateDescクラス
 */
public class DefaultCoverNodeScriptCreateDesc : UnityBase.Scene.Ui.Cover.CoverNodeScriptCreateDesc
{
}

/**
 * @brief DefaultCoverNodeScriptクラス
 */
public class DefaultCoverNodeScript : UnityBase.Scene.Ui.Cover.CoverNodeScript
{
    [SerializeField] private Image _coverImage = null;

    public new UnityBase.Scene.Ui.Cover.DefaultCoverNodeScriptCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.DEFAULT_COVER_NODE);
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

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Cover.DefaultCoverNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Cover.DefaultCoverNodeScriptCreateDesc;

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
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
        base._OnOpened();

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

    /**
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        base._OnClosed();

        return;
    }
}
}
}
