﻿/**
 * @file
 * @brief SelectDialogScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief SelectDialogScriptCreateDescクラス
 */
public class SelectDialogScriptCreateDesc : UnityBase.Scene.Ui.DialogScriptCreateDesc
{
    public UnityBase.Scene.Ui.SelectDialogEngine engine = null;
}

/**
 * @brief SelectDialogScriptクラス
 */
public class SelectDialogScript : UnityBase.Scene.Ui.DialogScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private ScrollRect _itemScrollRect = null;
    [SerializeField] private GameObject _itemButtonNode = null;
    [SerializeField] private Image _closeButtonCoverImage = null;

    public new UnityBase.Scene.Ui.SelectDialogScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.SelectDialogEngine _engine = null;
    private List<UnityBase.Scene.Ui.SelectDialogItemButtonScript> _itemButtonScriptContainer = new List<UnityBase.Scene.Ui.SelectDialogItemButtonScript>();

    /**
     * @brief コンストラクタ
     */
    public SelectDialogScript()
    {
        this._SetScriptIndex((int)UnityBase.Util.SCENE.SCRIPT_INDEX.SELECT_DIALOG);

        return;
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

        this._nameText.SetText(this._engine.OnGetName());

        this._itemButtonNode.SetActive(false);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.SelectDialogScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        base._OnActive();

        this._itemScrollRect.verticalNormalizedPosition = 1.0f;
        this._closeButtonCoverImage.gameObject.SetActive(false);

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
     * @brief _OnUpdateOpen関数
     */
    protected override void _OnUpdateOpen()
    {
        base._OnUpdateOpen();

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
     * @brief _OnUpdateClose関数
     */
    protected override void _OnUpdateClose()
    {
        base._OnUpdateClose();

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
     * @brief AddItemButton関数
     * @param item_btn_engine (item_button_engine)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddItemButton(UnityBase.Scene.Ui.SelectDialogItemButtonEngine item_btn_engine)
    {
        if (item_btn_engine == null) {
            return (-1);
        }

        {// ItemButtonScript Create
            var script = GameObject.Instantiate(this._itemButtonNode, this._itemButtonNode.transform.parent).GetComponent<UnityBase.Scene.Ui.SelectDialogItemButtonScript>();
            var script_create_desc = new UnityBase.Scene.Ui.SelectDialogItemButtonScriptCreateDesc();

            script_create_desc.engine = item_btn_engine;
            script_create_desc.onClick = (UnityBase.Scene.Ui.SelectDialogItemButtonScript item_btn_script) => {
                this._engine.OnClickItemButton(this, item_btn_script);

                this.Close(1);

                return;
            };

            script.Create(script_create_desc);
            script.Open(0);

            this._itemButtonScriptContainer.Add(script);
        }

        return (0);
    }

    /**
     * @brief RemoveItemButton関数
     */
    public void RemoveItemButton()
    {
        foreach (var item_btn_script in this._itemButtonScriptContainer) {
            item_btn_script.Close(0);

            GameObject.Destroy(item_btn_script.gameObject);
        }

        this._itemButtonScriptContainer.Clear();

        return;
    }
}
}
}