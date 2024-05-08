/**
 * @file
 * @brief SelectDialogNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief SelectDialogNodeScriptCreateDescクラス
 */
public class SelectDialogNodeScriptCreateDesc : UnityBase.Scene.Ui.DialogNodeScriptCreateDesc
{
    public UnityBase.Scene.Ui.SelectDialogEngine engine = null;
    public System.Action<UnityBase.Scene.Ui.SelectDialogNodeScript, UnityBase.Scene.Ui.SelectDialogItemNodeScript> onClickItem = null;
}

/**
 * @brief SelectDialogNodeScriptクラス
 */
public class SelectDialogNodeScript : UnityBase.Scene.Ui.DialogNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private Image _closeButtonCoverImage = null;
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private GameObject _itemNode = null;

    public new UnityBase.Scene.Ui.SelectDialogNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.SelectDialogEngine _engine = null;
    private List<UnityBase.Scene.Ui.SelectDialogItemNodeScript> _itemNodeScriptContainer = new List<UnityBase.Scene.Ui.SelectDialogItemNodeScript>();
    private System.Action<UnityBase.Scene.Ui.SelectDialogNodeScript, UnityBase.Scene.Ui.SelectDialogItemNodeScript> _onClickItem = null;

    /**
     * @brief コンストラクタ
     */
    public SelectDialogNodeScript()
    {
        return;
    }
    
    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SELECT_DIALOG_NODE);
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

        if (this.createDesc.engine == null) {
            return (-1);
        }

        this._engine = this.createDesc.engine;
        this._onClickItem = this.createDesc.onClickItem;

        this._nameText.SetText(this._engine.OnGetName());
        this._itemNode.SetActive(false);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.SelectDialogNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._closeButtonCoverImage.gameObject.SetActive(false);
        this._scrollRect.verticalNormalizedPosition = 1.0f;

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

    /**
     * @brief OnCloseButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCloseButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this.Close(1);

        return;
    }

    /**
     * @brief OnCloseButtonPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnCloseButtonPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._closeButtonCoverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnCloseButtonPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnCloseButtonPointerExit(PointerEventData event_dat)
    {
        this._closeButtonCoverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief GetEngine関数
     * @return engine (engine)
     */
    public UnityBase.Scene.Ui.SelectDialogEngine GetEngine()
    {
        return (this._engine);
    }

    /**
     * @brief AddItem関数
     * @param item_engine (item_engine)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddItem(UnityBase.Scene.Ui.SelectDialogItemEngine item_engine)
    {
        if (item_engine == null) {
            return (-1);
        }

        {// ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Ui.SelectDialogItemNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.SelectDialogItemNodeScriptCreateDesc();

            void on_click(UnityBase.Scene.Ui.SelectDialogItemNodeScript owner)
            {
                this._onClickItem?.Invoke(this, owner);

                this.Close(1);

                return;
            }

            script_create_desc.engine = item_engine;
            script_create_desc.onClick = on_click;

            script.Create(script_create_desc);
            script.Open(0);

            this._itemNodeScriptContainer.Add(script);
        }

        return (0);
    }

    /**
     * @brief RemoveItem関数
     */
    public void RemoveItem()
    {
        foreach (var item_node_script in this._itemNodeScriptContainer) {
            item_node_script.Close(0);

            GameObject.Destroy(item_node_script.gameObject);
        }

        this._itemNodeScriptContainer.Clear();

        return;
    }
}
}
}
