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
     * @brief OnClickItem関数
     * @param dialog_node_script (dialog_node_script)
     * @param item_node_script (item_node_script)
     */
    public virtual void OnClickItem(UnityBase.Scene.Ui.SelectDialogNodeScript dialog_node_script, UnityBase.Scene.Ui.SelectDialogItemNodeScript item_node_script)
    {
        return;
    }
}

/**
 * @brief SelectDialogItemEngineクラス
 */
public abstract class SelectDialogItemEngine
{
    /**
     * @brief コンストラクタ
     */
    public SelectDialogItemEngine()
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
