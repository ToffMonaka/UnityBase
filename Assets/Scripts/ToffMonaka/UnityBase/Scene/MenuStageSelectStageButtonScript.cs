﻿/**
 * @file
 * @brief MenuStageSelectStageButtonScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuStageSelectStageButtonScriptCreateDescクラス
 */
public class MenuStageSelectStageButtonScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuStageSelectScript menuStageSelectScript = null;
    public ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.NONE;
}

/**
 * @brief MenuStageSelectStageButtonScriptクラス
 */
public class MenuStageSelectStageButtonScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private Image _coverImage = null;

    public new ToffMonaka.UnityBase.Scene.MenuStageSelectStageButtonScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuStageSelectScript _menuStageSelectScript = null;
    private ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE _stageType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public MenuStageSelectStageButtonScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_STAGE_SELECT_STAGE_BUTTON);

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
        this._menuStageSelectScript = this.createDesc.menuStageSelectScript;
        this._stageType = this.createDesc.stageType;

        this._nameText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_NAME_ARRAY[(int)this._stageType]);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuStageSelectStageButtonScriptCreateDesc;

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
     * @brief OnPointerClickEvent関数
     */
    public void OnPointerClickEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._menuStageSelectScript.RunStageButton(this._stageType);

        return;
    }

    /**
     * @brief OnPointerEnterEvent関数
     */
    public void OnPointerEnterEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(true);

        return;
    }

    /**
     * @brief OnPointerExitEvent関数
     */
    public void OnPointerExitEvent()
    {
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(false);

        return;
    }
}
}
