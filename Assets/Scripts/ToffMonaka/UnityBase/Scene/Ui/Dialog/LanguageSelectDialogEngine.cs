/**
 * @file
 * @brief LanguageSelectDialogEngineファイル
 */


using ToffMonaka.UnityBase.Data;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Dialog {
/**
 * @brief LanguageSelectDialogEngineクラス
 */
public class LanguageSelectDialogEngine : UnityBase.Scene.Ui.Dialog.SelectDialogEngine
{
    /**
     * @brief コンストラクタ
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
        return (DataUtil.GetText(UnityBase.Util.MST_TEXT_ID.LANGUAGE));
    }
}

/**
 * @brief LanguageSelectDialogItemEngineクラス
 */
public class LanguageSelectDialogItemEngine : UnityBase.Scene.Ui.Dialog.SelectDialogItemEngine
{
    private UnityBase.Util.LANGUAGE_TYPE _languageType = UnityBase.Util.LANGUAGE_TYPE.NONE;

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
        return (DataUtil.GetText(UnityBase.Util.LANGUAGE_NAME_MST_TEXT_ID_ARRAY[(int)this._languageType]));
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
