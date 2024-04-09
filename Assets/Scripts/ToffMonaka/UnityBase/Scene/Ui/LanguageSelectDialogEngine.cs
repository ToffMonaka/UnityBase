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
    /**
     * @brief コンストラクタ
     * @param on_click_item (on_click_item)
     */
    public LanguageSelectDialogEngine()
    {
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
}

/**
 * @brief LanguageSelectDialogItemEngineクラス
 */
public class LanguageSelectDialogItemEngine : UnityBase.Scene.Ui.SelectDialogItemEngine
{
    private UnityBase.Util.LANGUAGE_TYPE _languageType;

    /**
     * @brief コンストラクタ
     * @param language_type (language_type)
     */
    public LanguageSelectDialogItemEngine(UnityBase.Util.LANGUAGE_TYPE language_type)
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
