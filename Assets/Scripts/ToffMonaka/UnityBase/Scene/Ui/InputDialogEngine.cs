/**
 * @file
 * @brief InputDialogEngineファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui {
/**
 * @brief InputDialogEngineクラス
 */
public abstract class InputDialogEngine
{
    /**
     * @brief コンストラクタ
     */
    public InputDialogEngine()
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
