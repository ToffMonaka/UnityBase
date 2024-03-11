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
    [SerializeField] private float _scrollBarMinSize = 64.0f;
    [SerializeField] private GameObject _mainContentNode = null;
    [SerializeField] private GameObject _subContentNode = null;
    [SerializeField] private GameObject _itemNode = null;

    public new Lib.Scene.ScrollViewComponentScriptCreateDesc createDesc{get; private set;} = null;

    private ScrollRect _scrollRect = null;
    private float _scrollValue = 1.0f;
    private Vector2 _scrollBarMinSize2 = Vector2.zero;
    private RectTransform _mainContentRectTransform = null;
    private Vector2 _mainContentSize = Vector2.zero;
    private RectTransform _subContentRectTransform = null;
    private Vector2 _subContentSize = Vector2.zero;
    private HorizontalLayoutGroup _subContentHorizontalLayoutGroup = null;
    private VerticalLayoutGroup _subContentVerticalLayoutGroup = null;
    private RectTransform _itemRectTransform = null;
    private int _itemCount = 0;
    private int _itemIndex = 0;
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
        this._scrollBarMinSize2 = new Vector2(1.0f / this._scrollRect.viewport.rect.width * this._scrollBarMinSize, 1.0f / this._scrollRect.viewport.rect.height * this._scrollBarMinSize);
        this._mainContentRectTransform = this._mainContentNode.GetComponent<RectTransform>();
        this._subContentRectTransform = this._subContentNode.GetComponent<RectTransform>();
        this._subContentHorizontalLayoutGroup = this._subContentNode.GetComponent<HorizontalLayoutGroup>();
        this._subContentVerticalLayoutGroup = this._subContentNode.GetComponent<VerticalLayoutGroup>();
        this._itemRectTransform = this._itemNode.GetComponent<RectTransform>();
        this._onGetItemNodeScript = this.createDesc.onGetItemNodeScript;
        this._onSetItemNodeScript = this.createDesc.onSetItemNodeScript;

        this._itemNode.SetActive(false);

        this._itemCount = -1;
        this.SetItemCount(0);

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
        this._UpdateScrollBarSize();

        return;
    }

    /**
     * @brief OnValueChanged関数
     * @param event_pos (event_position)
     */
    public void OnValueChanged(Vector2 event_pos)
    {
        if (this._scrollRect.horizontal) {
            this.SetScrollValue(this._scrollRect.horizontalNormalizedPosition, false);
        } else if (this._scrollRect.vertical) {
            this.SetScrollValue(this._scrollRect.verticalNormalizedPosition, false);
        }

        this._UpdateScrollBarSize();

        return;
    }

    /**
     * @brief GetScrollValue関数
     * @return scroll_val (scroll_value)
     */
    public float GetScrollValue()
    {
        return (this._scrollValue);
    }

    /**
     * @brief SetScrollValue関数
     * @param scroll_val (scroll_value)
     * @param norm_pos_set_flg (normalized_position_set_flag)
     */
    public void SetScrollValue(float scroll_val, bool norm_pos_set_flg = true)
    {
        if (scroll_val == this._scrollValue) {
            return;
        }

        this._scrollValue = scroll_val;

        int item_index = 0;
        var item_pos = Vector2.zero;

        if (this._scrollRect.horizontal) {
            if (norm_pos_set_flg) {
                this._scrollRect.horizontalNormalizedPosition = this._scrollValue;
            }

            if (this._mainContentSize.x > this._scrollRect.viewport.rect.width) {
                if (this._scrollRect.horizontalNormalizedPosition >= (1.0f - (this._subContentHorizontalLayoutGroup.padding.left / (this._mainContentSize.x - this._scrollRect.viewport.rect.width)))) {
                    item_index = 0;
                    item_pos.x = 0.0f;
                } else if (this._scrollRect.horizontalNormalizedPosition <= 0.0f) {
                    item_index = this._itemCount - this._itemNodeScriptContainer.Count;
                    item_pos.x = -this._mainContentSize.x + this._subContentSize.x;
                } else {
                    item_index = (int)System.Math.Truncate((((this._mainContentSize.x - this._scrollRect.viewport.rect.width) * (1.0f - this._scrollRect.horizontalNormalizedPosition)) - this._subContentHorizontalLayoutGroup.padding.left) / (this._itemRectTransform.sizeDelta.x + this._subContentHorizontalLayoutGroup.spacing));
                    item_pos.x = -((this._itemRectTransform.sizeDelta.x + this._subContentHorizontalLayoutGroup.spacing) * item_index);
                }
            }
        } else if (this._scrollRect.vertical) {
            if (norm_pos_set_flg) {
                this._scrollRect.verticalNormalizedPosition = this._scrollValue;
            }

            if (this._mainContentSize.y > this._scrollRect.viewport.rect.height) {
                if (this._scrollRect.verticalNormalizedPosition >= (1.0f - (this._subContentVerticalLayoutGroup.padding.top / (this._mainContentSize.y - this._scrollRect.viewport.rect.height)))) {
                    item_index = 0;
                    item_pos.y = 0.0f;
                } else if (this._scrollRect.verticalNormalizedPosition <= 0.0f) {
                    item_index = this._itemCount - this._itemNodeScriptContainer.Count;
                    item_pos.y = -this._mainContentSize.y + this._subContentSize.y;
                } else {
                    item_index = (int)System.Math.Truncate((((this._mainContentSize.y - this._scrollRect.viewport.rect.height) * (1.0f - this._scrollRect.verticalNormalizedPosition)) - this._subContentVerticalLayoutGroup.padding.top) / (this._itemRectTransform.sizeDelta.y + this._subContentVerticalLayoutGroup.spacing));
                    item_pos.y = -((this._itemRectTransform.sizeDelta.y + this._subContentVerticalLayoutGroup.spacing) * item_index);
                }
            }
        }

        this._subContentRectTransform.anchoredPosition = item_pos;

        if (item_index != this._itemIndex) {
            this._itemIndex = item_index;

            this.UpdateItem();
        }

        return;
    }

    /**
     * @brief _UpdateScrollBarSize関数
     */
    private void _UpdateScrollBarSize()
    {
        if (this._scrollRect.horizontal) {
            if (this._scrollRect.horizontalScrollbar != null) {
                if (this._scrollRect.horizontalScrollbar.size < this._scrollBarMinSize2.x) {
                    this._scrollRect.horizontalScrollbar.size = this._scrollBarMinSize2.x;
                }
            }
        } else if (this._scrollRect.vertical) {
            if (this._scrollRect.verticalScrollbar != null) {
                if (this._scrollRect.verticalScrollbar.size < this._scrollBarMinSize2.y) {
                    this._scrollRect.verticalScrollbar.size = this._scrollBarMinSize2.y;
                }
            }
        }

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
        if (item_cnt == this._itemCount) {
            return;
        }

        this._itemCount = item_cnt;

        int item_node_cnt = 0;

        if (this._scrollRect.horizontal) {
            item_node_cnt = System.Math.Min((int)System.Math.Ceiling(this._scrollRect.viewport.rect.width / (this._itemRectTransform.sizeDelta.x + this._subContentHorizontalLayoutGroup.spacing)) + 2, this._itemCount);

            this._mainContentSize.y = this._mainContentRectTransform.sizeDelta.y;
            this._mainContentSize.x = this._subContentHorizontalLayoutGroup.padding.left + this._subContentHorizontalLayoutGroup.padding.right;

            if (this._itemCount > 0) {
                this._mainContentSize.x += (this._itemRectTransform.sizeDelta.x * this._itemCount) + (this._subContentHorizontalLayoutGroup.spacing * (this._itemCount - 1));
            }

            if (this._mainContentSize.x < this._scrollRect.viewport.rect.width) {
                this._mainContentSize.x = this._scrollRect.viewport.rect.width;
            }

            this._mainContentRectTransform.sizeDelta = this._mainContentSize;

            this._subContentSize.y = this._subContentRectTransform.sizeDelta.y;
            this._subContentSize.x = this._subContentHorizontalLayoutGroup.padding.left + this._subContentHorizontalLayoutGroup.padding.right;

            if (item_node_cnt > 0) {
                this._subContentSize.x += (this._itemRectTransform.sizeDelta.x * item_node_cnt) + (this._subContentHorizontalLayoutGroup.spacing * (item_node_cnt - 1));
            }
        } else if (this._scrollRect.vertical) {
            item_node_cnt = System.Math.Min((int)System.Math.Ceiling(this._scrollRect.viewport.rect.height / (this._itemRectTransform.sizeDelta.y + this._subContentVerticalLayoutGroup.spacing)) + 2, this._itemCount);

            this._mainContentSize.x = this._mainContentRectTransform.sizeDelta.x;
            this._mainContentSize.y = this._subContentVerticalLayoutGroup.padding.top + this._subContentVerticalLayoutGroup.padding.bottom;

            if (this._itemCount > 0) {
                this._mainContentSize.y += (this._itemRectTransform.sizeDelta.y * this._itemCount) + (this._subContentVerticalLayoutGroup.spacing * (this._itemCount - 1));
            }

            if (this._mainContentSize.y < this._scrollRect.viewport.rect.height) {
                this._mainContentSize.y = this._scrollRect.viewport.rect.height;
            }

            this._mainContentRectTransform.sizeDelta = this._mainContentSize;

            this._subContentSize.x = this._subContentRectTransform.sizeDelta.x;
            this._subContentSize.y = this._subContentVerticalLayoutGroup.padding.top + this._subContentVerticalLayoutGroup.padding.bottom;

            if (item_node_cnt > 0) {
                this._subContentSize.y += (this._itemRectTransform.sizeDelta.y * item_node_cnt) + (this._subContentVerticalLayoutGroup.spacing * (item_node_cnt - 1));
            }
        }

        if (item_node_cnt != this._itemNodeScriptContainer.Count) {
            foreach (var item_node_script in this._itemNodeScriptContainer) {
                item_node_script.Close(0);

                GameObject.Destroy(item_node_script.gameObject);
            }

            this._itemNodeScriptContainer.Clear();

            for (int item_node_i = 0; item_node_i < item_node_cnt; ++item_node_i) {
                this._itemNodeScriptContainer.Add(this._onGetItemNodeScript(this._itemNode));
            }
        }

        this._scrollValue = -1.0f;
        this._itemIndex = -1;
        this.SetScrollValue(1.0f);

        return;
    }

    /**
     * @brief UpdateItem関数
     */
    public void UpdateItem()
    {
        for (int item_node_script_i = 0; item_node_script_i < this._itemNodeScriptContainer.Count; ++item_node_script_i) {
            this._onSetItemNodeScript(this._itemNodeScriptContainer[item_node_script_i], System.Math.Min(this._itemIndex + item_node_script_i, this._itemCount - 1));
        }

        return;
    }
}
}
}
