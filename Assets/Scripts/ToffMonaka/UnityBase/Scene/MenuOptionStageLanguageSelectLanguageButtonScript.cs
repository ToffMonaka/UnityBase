/**
 * @file
 * @brief MenuOptionStageLanguageSelectLanguageButtonScriptファイル
 */


using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace ToffMonaka.UnityBase.Scene {
/**
 * @brief MenuOptionStageLanguageSelectLanguageButtonScriptCreateDescクラス
 */
public class MenuOptionStageLanguageSelectLanguageButtonScriptCreateDesc : ToffMonaka.Lib.Scene.ObjectScriptCreateDesc
{
    public ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectDialogScript menuOptionStageLanguageSelectScript = null;
    public ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.NONE;
}

/**
 * @brief MenuOptionStageLanguageSelectLanguageButtonScriptクラス
 */
public class MenuOptionStageLanguageSelectLanguageButtonScript : ToffMonaka.Lib.Scene.ObjectScript
{
    [SerializeField] private TMP_Text _nameText = null;
    [SerializeField] private Image _coverImage = null;

    public new ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScriptCreateDesc createDesc{get; private set;} = null;

    private ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectDialogScript _menuOptionStageLanguageSelectScript = null;
    private ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE _languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.NONE;

    /**
     * @brief コンストラクタ
     */
    public MenuOptionStageLanguageSelectLanguageButtonScript()
    {
        this._SetScriptIndex((int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.MENU_OPTION_STAGE_LANGUAGE_SELECT_LANGUAGE_BUTTON);

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
        this._menuOptionStageLanguageSelectScript = this.createDesc.menuOptionStageLanguageSelectScript;
        this._languageType = this.createDesc.languageType;

        this._nameText.SetText(ToffMonaka.Lib.Constant.Util.LANGUAGE_NAME_ARRAY[(int)this._languageType]);

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.UnityBase.Scene.MenuOptionStageLanguageSelectLanguageButtonScriptCreateDesc;

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

        this._menuOptionStageLanguageSelectScript.RunLanguageButton(this._languageType);

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
