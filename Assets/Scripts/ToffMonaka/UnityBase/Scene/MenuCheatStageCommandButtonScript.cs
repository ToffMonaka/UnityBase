﻿/**
 * @file
 * @brief MenuCheatStageCommandButtonScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuCheatStageCommandButtonScriptCreateDescクラス
 */
public class MenuCheatStageCommandButtonScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuCheatStageScript menuCheatStageScript = null;
    public ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE commandType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.NONE;
}

/**
 * @brief MenuCheatStageCommandButtonScriptクラス
 */
public class MenuCheatStageCommandButtonScript : ToffMonaka.Lib.Scene.ObjectScript, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private TMP_Text _detailText = null;
    [SerializeField] private Image _coverImage = null;

    public new ToffMonaka.UnityBase.Scene.MenuCheatStageCommandButtonScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuCheatStageScript _menuCheatStageScript = null;
    private ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE _commandType = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public MenuCheatStageCommandButtonScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_CHEAT_STAGE_COMMAND_BUTTON);

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
        this._menuCheatStageScript = this.createDesc.menuCheatStageScript;
        this._commandType = this.createDesc.commandType;

        this._nameText.SetText(ToffMonaka.UnityBase.Global.GetString(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_NAME_MST_STRING_ID_ARRAY[(int)this._commandType]));

        var param = ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_PARAMETER_ARRAY[(int)this._commandType];

        if (param.Length > 0) {
            this._detailText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)this._commandType] + " " + param);
        } else {
            this._detailText.SetText(ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY[(int)this._commandType]);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuCheatStageCommandButtonScriptCreateDesc;

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
     * @brief OnPointerClick関数
     * @param event_dat (event_data)
     */
    public void OnPointerClick(PointerEventData event_dat)
    {
        if (!this.IsControllable()) {
            return;
        }

        ToffMonaka.Lib.Scene.Util.GetSoundManager().PlaySe((int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.OK2);

        this._menuCheatStageScript.RunCommandButton(this._commandType);

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
        if (!this.IsControllable()) {
            return;
        }

        this._coverImage.gameObject.SetActive(false);

        return;
    }
}
}
