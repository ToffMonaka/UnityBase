/**
 * @file
 * @brief SelectDialogNodeScriptファイル
 */


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Dialog {
/**
 * @brief SelectDialogNodeScriptCreateDescクラス
 */
public class SelectDialogNodeScriptCreateDesc : UnityBase.Scene.Ui.Dialog.DialogNodeScriptCreateDesc
{
    public UnityBase.Scene.Ui.Dialog.SelectDialogEngine engine = null;
    public System.Action<UnityBase.Scene.Ui.Dialog.SelectDialogNodeScript, UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScript> onClickItem = null;

    /**
     * @brief GetPrefabFilePath関数
     * @return prefab_file_path (prefab_file_path)
     */
    public override string GetPrefabFilePath()
    {
        return (UnityBase.Util.FILE_PATH.SELECT_DIALOG_PREFAB);
    }

    /**
     * @brief GetNewScript関数
     * @param prefab_file_path (prefab_file_path)
     * @return script (script)
     */
    public override UnityBase.Scene.Ui.Dialog.DialogNodeScript GetNewScript(string prefab_file_path)
    {
        var node = Lib.Scene.Util.GetPrefabNode(prefab_file_path);

        return (node.GetComponent<UnityBase.Scene.Ui.Dialog.SelectDialogNodeScript>());
    }
}

/**
 * @brief SelectDialogNodeScriptクラス
 */
public class SelectDialogNodeScript : UnityBase.Scene.Ui.Dialog.DialogNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private GameObject _itemNode = null;

    public new UnityBase.Scene.Ui.Dialog.SelectDialogNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Dialog.SelectDialogEngine _engine = null;
    private List<UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScript> _itemNodeScriptContainer = new List<UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScript>();
    private System.Action<UnityBase.Scene.Ui.Dialog.SelectDialogNodeScript, UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScript> _onClickItem = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SELECT_DIALOG_NODE);
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
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new UnityBase.Scene.Ui.Dialog.SelectDialogNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as UnityBase.Scene.Ui.Dialog.SelectDialogNodeScriptCreateDesc;

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

    /**
     * @brief OnCloseButtonPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnCloseButtonPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        UnityBase.Global.GetSceneManager().PlaySoundSe((int)UnityBase.Util.SOUND.SE_INDEX.CANCEL);

        this.Close(1);

        return;
    }

    /**
     * @brief GetEngine関数
     * @return engine (engine)
     */
    public UnityBase.Scene.Ui.Dialog.SelectDialogEngine GetEngine()
    {
        return (this._engine);
    }

    /**
     * @brief AddItem関数
     * @param item_engine (item_engine)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddItem(UnityBase.Scene.Ui.Dialog.SelectDialogItemEngine item_engine)
    {
        if (item_engine == null) {
            return (-1);
        }

        {// ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScript>();
            var script_create_desc = new UnityBase.Scene.Ui.Dialog.SelectDialogItemNodeScriptCreateDesc();

            script_create_desc.engine = item_engine;
            script_create_desc.onClick = (owner) =>
            {
                this._onClickItem?.Invoke(this, owner);

                this.Close(1);

                return;
            };

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
