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
