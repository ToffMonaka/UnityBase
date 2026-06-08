/**
 * @file
 * @brief SelectDialogNodeScriptファイル
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ToffMonaka.UnityBase.Sound;

namespace ToffMonaka {
namespace UnityBase.Scene.DialogSystem {
/**
 * @brief SelectDialogNodeScriptCreateDescクラス
 */
public class SelectDialogNodeScriptCreateDesc : DialogNodeScriptCreateDesc
{
    public SelectDialogExtension extension = null;
    public System.Action<SelectDialogNodeScript, SelectDialogItemNodeScript> onClickItem = null;

    /**
     * @brief GetPrefabFilePath関数
     * @return prefab_file_path (prefab_file_path)
     */
    public override string GetPrefabFilePath()
    {
        return (Util.FILE_PATH.SELECT_DIALOG_PREFAB);
    }

    /**
     * @brief GetNewScript関数
     * @param prefab_file_path (prefab_file_path)
     * @return script (script)
     */
    public override DialogNodeScript GetNewScript(string prefab_file_path)
    {
        var node = ToffMonaka.Tml.Scene.SceneUtil.GetPrefabNode(prefab_file_path);

        return (node.GetComponent<SelectDialogNodeScript>());
    }
}

/**
 * @brief SelectDialogNodeScriptクラス
 */
public class SelectDialogNodeScript : DialogNodeScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private ScrollRect _scrollRect = null;
    [SerializeField] private GameObject _itemNode = null;

    public new SelectDialogNodeScriptCreateDesc createDesc{get; private set;} = null;

    private SelectDialogExtension _extension = null;
    private List<SelectDialogItemNodeScript> _itemNodeScriptContainer = new();
    private System.Action<SelectDialogNodeScript, SelectDialogItemNodeScript> _onClickItem = null;

    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)SceneUtil.SCRIPT_INDEX.SELECT_DIALOG_NODE);
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

        if (this.createDesc.extension == null) {
            return (-1);
        }

        this._extension = this.createDesc.extension;
        this._onClickItem = this.createDesc.onClickItem;

        this._nameText.SetText(this._extension.OnGetName());
        this._itemNode.SetActive(false);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Scene.ScriptCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SelectDialogNodeScriptCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SelectDialogNodeScriptCreateDesc;

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

        SceneUtil.GetManager().PlaySoundSe((int)SoundUtil.SE_SOUND_INDEX.CANCEL);

        this.Close(1);

        return;
    }

    /**
     * @brief GetExtension関数
     * @return ext (extension)
     */
    public SelectDialogExtension GetExtension()
    {
        return (this._extension);
    }

    /**
     * @brief AddItem関数
     * @param item_ext (item_extension)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddItem(SelectDialogItemExtension item_ext)
    {
        if (item_ext == null) {
            return (-1);
        }

        {// ItemNodeScript Create
            var script = GameObject.Instantiate(this._itemNode, this._itemNode.transform.parent).GetComponent<SelectDialogItemNodeScript>();
            var script_create_desc = new SelectDialogItemNodeScriptCreateDesc();

            script_create_desc.extension = item_ext;
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
