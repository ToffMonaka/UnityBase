/**
 * @file
 * @brief ScrollBarComponentScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief ScrollBarComponentScriptCreateDescクラス
 */
public class ScrollBarComponentScriptCreateDesc : Lib.Scene.ComponentScriptCreateDesc
{
}

/**
 * @brief ScrollBarComponentScriptクラス
 */
public class ScrollBarComponentScript : Lib.Scene.ComponentScript
{
    [SerializeField] private GameObject _scrollViewNode = null;

    public new Lib.Scene.ScrollBarComponentScriptCreateDesc createDesc{get; private set;} = null;

    private Scrollbar _scrollBar = null;
    private Lib.Scene.ScrollViewComponentScript _scrollViewComponentScript = null;

    /**
     * @brief コンストラクタ
     */
    public ScrollBarComponentScript()
    {
        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.SCROLL_BAR_COMPONENT);
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
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        this._scrollBar = this.gameObject.GetComponent<Scrollbar>();
        this._scrollViewComponentScript = this._scrollViewNode.GetComponent<Lib.Scene.ScrollViewComponentScript>();

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.ScrollBarComponentScriptCreateDesc;

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
     * @brief OnValueChanged関数
     * @param event_pos (event_position)
     */
    public void OnValueChanged(float event_pos)
    {
        return;
    }
}
}
}
