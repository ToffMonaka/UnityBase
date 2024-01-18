/**
 * @file
 * @brief ScrollViewComponentScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief ScrollViewComponentScriptCreateDescクラス
 */
public class ScrollViewComponentScriptCreateDesc : Lib.Scene.ComponentScriptCreateDesc
{
    public System.Func<GameObject, Lib.Scene.ObjectNodeScript> onGetItemNodeScript = null;
    public System.Action<Lib.Scene.ObjectNodeScript, int> onSetItemNodeScript = null;
}

/**
 * @brief ScrollViewComponentScriptクラス
 */
public class ScrollViewComponentScript : Lib.Scene.ComponentScript
{
    [SerializeField] private GameObject _scrollBarNode = null;
    [SerializeField] private GameObject _itemNode = null;

    public new Lib.Scene.ScrollViewComponentScriptCreateDesc createDesc{get; private set;} = null;

    private ScrollRect _scrollRect = null;
    private Lib.Scene.ScrollBarComponentScript _scrollBarComponentScript = null;
    private int _itemCount = 0;
    private List<Lib.Scene.ObjectNodeScript> _itemNodeScriptContainer = new List<Lib.Scene.ObjectNodeScript>();
    private System.Func<GameObject, Lib.Scene.ObjectNodeScript> _onGetItemNodeScript = null;
    private System.Action<Lib.Scene.ObjectNodeScript, int> _onSetItemNodeScript = null;

    /**
     * @brief コンストラクタ
     */
    public ScrollViewComponentScript()
    {
        return;
    }

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)Lib.Util.SCENE.SCRIPT_INDEX.SCROLL_VIEW_COMPONENT);
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
        this._scrollRect = this.gameObject.GetComponent<ScrollRect>();
        this._scrollBarComponentScript = this._scrollBarNode.GetComponent<Lib.Scene.ScrollBarComponentScript>();
        this._onGetItemNodeScript = this.createDesc.onGetItemNodeScript;
        this._onSetItemNodeScript = this.createDesc.onSetItemNodeScript;

        this._itemNode.SetActive(false);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as Lib.Scene.ScrollViewComponentScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._scrollRect.horizontalNormalizedPosition = 1.0f;
        this._scrollRect.verticalNormalizedPosition = 1.0f;

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
    public void OnValueChanged(Vector2 event_pos)
    {
        return;
    }

    /**
     * @brief GetItemCount関数
     * @return item_cnt (item_count)
     */
    public int GetItemCount()
    {
        return (this._itemCount);
    }

    /**
     * @brief SetItemCount関数
     * @param item_cnt (item_count)
     */
    public void SetItemCount(int item_cnt)
    {
        this._itemCount = item_cnt;

        int item_node_cnt = 5;

        if (item_node_cnt > this._itemCount) {
            item_node_cnt = this._itemCount;
        }

        if (this._itemNodeScriptContainer.Count != item_node_cnt) {
            foreach (var item_node_script in this._itemNodeScriptContainer) {
                item_node_script.Close(0);

                GameObject.Destroy(item_node_script.gameObject);
            }

            this._itemNodeScriptContainer.Clear();

            for (int item_node_i = 0; item_node_i < item_node_cnt; ++item_node_i) {
                var script = this._onGetItemNodeScript(this._itemNode);

                this._itemNodeScriptContainer.Add(script);
            }
        }

        for (int item_node_script_i = 0; item_node_script_i < this._itemNodeScriptContainer.Count; ++item_node_script_i) {
            this._onSetItemNodeScript(this._itemNodeScriptContainer[item_node_script_i], item_node_script_i);
        }

        this._scrollRect.horizontalNormalizedPosition = 1.0f;
        this._scrollRect.verticalNormalizedPosition = 1.0f;

        return;
    }
}
}
}
