/**
 * @file
 * @brief SelectDialogEngineファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief SelectDialogEngineクラス
 */
public abstract class SelectDialogEngine
{
    /**
     * @brief コンストラクタ
     */
    public SelectDialogEngine()
    {
        return;
    }

    /**
     * @brief OnGetName関数
     * @return name (name)
     */
    public virtual string OnGetName()
    {
        return (System.String.Empty);
    }

    /**
     * @brief OnClickItemButton関数
     * @param dialog_node_script (dialog_node_script)
     * @param item_btn_node_script (item_button_node_script)
     */
    public virtual void OnClickItemButton(UnityBase.Scene.Ui.SelectDialogNodeScript dialog_node_script, UnityBase.Scene.Ui.SelectDialogItemButtonNodeScript item_btn_node_script)
    {
        return;
    }
}

/**
 * @brief SelectDialogItemButtonEngineクラス
 */
public abstract class SelectDialogItemButtonEngine
{
    /**
     * @brief コンストラクタ
     */
    public SelectDialogItemButtonEngine()
    {
        return;
    }

    /**
     * @brief OnGetName関数
     * @return name (name)
     */
    public virtual string OnGetName()
    {
        return (System.String.Empty);
    }
}
}
}
