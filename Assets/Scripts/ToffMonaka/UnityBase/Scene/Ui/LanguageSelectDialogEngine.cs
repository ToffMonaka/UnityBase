/**
 * @file
 * @brief LanguageSelectDialogEngineファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief LanguageSelectDialogEngineクラス
 */
public class LanguageSelectDialogEngine : UnityBase.Scene.Ui.SelectDialogEngine
{
    private System.Action<UnityBase.Scene.Ui.SelectDialogScript, UnityBase.Scene.Ui.SelectDialogItemButtonScript> _onClickItemButton;

    /**
     * @brief コンストラクタ
     * @param on_click_item_btn (on_click_item_button)
     */
    public LanguageSelectDialogEngine(System.Action<UnityBase.Scene.Ui.SelectDialogScript, UnityBase.Scene.Ui.SelectDialogItemButtonScript> on_click_item_btn)
    {
        this._onClickItemButton = on_click_item_btn;

        return;
    }

    /**
     * @brief OnGetName関数
     * @return name (name)
     */
    public override string OnGetName()
    {
        return (UnityBase.Global.GetText(UnityBase.Util.MST_TEXT_ID.LANGUAGE));
    }

    /**
     * @brief OnClickItemButton関数
     * @param dialog_script (dialog_script)
     * @param item_btn_script (item_button_script)
     */
    public override void OnClickItemButton(UnityBase.Scene.Ui.SelectDialogScript dialog_script, UnityBase.Scene.Ui.SelectDialogItemButtonScript item_btn_script)
    {
        this._onClickItemButton?.Invoke(dialog_script, item_btn_script);

        return;
    }
}

/**
 * @brief LanguageSelectDialogItemButtonEngineクラス
 */
public class LanguageSelectDialogItemButtonEngine : UnityBase.Scene.Ui.SelectDialogItemButtonEngine
{
    private UnityBase.Util.LANGUAGE_TYPE _languageType;

    /**
     * @brief コンストラクタ
     * @param language_type (language_type)
     */
    public LanguageSelectDialogItemButtonEngine(UnityBase.Util.LANGUAGE_TYPE language_type)
    {
        this._languageType = language_type;

        return;
    }

    /**
     * @brief OnGetName関数
     * @return name (name)
     */
    public override string OnGetName()
    {
        return (UnityBase.Global.GetText(UnityBase.Util.LANGUAGE_NAME_MST_TEXT_ID_ARRAY[(int)this._languageType]));
    }

    /**
     * @brief GetLanguageType関数
     * @return language_type (language_type)
     */
    public UnityBase.Util.LANGUAGE_TYPE GetLanguageType()
    {
        return (this._languageType);
    }
}
}
}
