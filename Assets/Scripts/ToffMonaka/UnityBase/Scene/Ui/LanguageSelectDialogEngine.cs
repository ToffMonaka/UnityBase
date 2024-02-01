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
    private System.Action<UnityBase.Scene.Ui.SelectDialogNodeScript, UnityBase.Scene.Ui.SelectDialogItemNodeScript> _onClickItem;

    /**
     * @brief コンストラクタ
     * @param on_click_item (on_click_item)
     */
    public LanguageSelectDialogEngine(System.Action<UnityBase.Scene.Ui.SelectDialogNodeScript, UnityBase.Scene.Ui.SelectDialogItemNodeScript> on_click_item)
    {
        this._onClickItem = on_click_item;

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
     * @brief OnClickItem関数
     * @param dialog_node_script (dialog_node_script)
     * @param item_node_script (item_node_script)
     */
    public override void OnClickItem(UnityBase.Scene.Ui.SelectDialogNodeScript dialog_node_script, UnityBase.Scene.Ui.SelectDialogItemNodeScript item_node_script)
    {
        this._onClickItem?.Invoke(dialog_node_script, item_node_script);

        return;
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
