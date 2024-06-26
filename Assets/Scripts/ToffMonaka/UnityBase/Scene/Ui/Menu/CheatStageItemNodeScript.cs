﻿/**
 * @file
 * @brief CheatStageItemNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief CheatStageItemNodeScriptCreateDescクラス
 */
public class CheatStageItemNodeScriptCreateDesc : Lib.Scene.ObjectNodeScriptCreateDesc
{
    public UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE addCodeType = UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE.NONE;
    public System.Action<UnityBase.Scene.Ui.Menu.CheatStageItemNodeScript> onClick = null;
}

/**
 * @brief CheatStageItemNodeScriptクラス
 */
public class CheatStageItemNodeScript : Lib.Scene.ObjectNodeScript, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_Text _detailText = null;
    [SerializeField] private Image _coverImage = null;

    public new UnityBase.Scene.Ui.Menu.CheatStageItemNodeScriptCreateDesc createDesc{get; private set;} = null;

    private UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE _addCodeType = UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE.NONE;
    private System.Action<UnityBase.Scene.Ui.Menu.CheatStageItemNodeScript> _onClick = null;

    /**
     * @brief コンストラクタ
     */
    public CheatStageItemNodeScript()
    {
        return;
    }
    
    /**
     * @brief _OnGetScriptIndex関数
     * @return script_index (script_index)
     */
    protected override int _OnGetScriptIndex()
    {
        return ((int)UnityBase.Util.SCENE.SCRIPT_INDEX.MENU_CHEAT_STAGE_ITEM_NODE);
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
        this._addCodeType = this.createDesc.addCodeType;
        this._onClick = this.createDesc.onClick;

        this._nameText.SetText(UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_NAME_ARRAY[(int)this._addCodeType]);
        this._detailText.SetText(UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TEXT_ARRAY[(int)this._addCodeType]);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as UnityBase.Scene.Ui.Menu.CheatStageItemNodeScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }

    /**
     * @brief _OnActive関数
     */
    protected override void _OnActive()
    {
        this._coverImage.gameObject.SetActive(false);

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
        return;
    }

    /**
     * @brief _OnOpened関数
     */
    protected override void _OnOpened()
    {
        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected override void _OnClose()
    {
        return;
    }

    /**
     * @brief _OnClosed関数
     */
    protected override void _OnClosed()
    {
        return;
    }

    /**
     * @brief OnPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        Lib.Scene.Util.GetSoundManager().PlaySe((int)UnityBase.Util.SOUND.SE_INDEX.OK2);

        this._onClick?.Invoke(this);

        return;
    }

    /**
     * @brief OnPointerEnter関数
     * @param event_dat (event_data)
     */
    public void OnPointerEnter(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnPointerExit関数
     * @param event_dat (event_data)
     */
    public void OnPointerExit(PointerEventData event_dat)
    {
        this._coverImage.gameObject.SetActive(false);

        return;
    }

    /**
     * @brief GetAddCodeType関数
     * @return add_code_type (add_code_type)
     */
    public UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE GetAddCodeType()
    {
        return (this._addCodeType);
    }
}
}
}
