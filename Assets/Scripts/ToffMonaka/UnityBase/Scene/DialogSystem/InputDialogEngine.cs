/**
 * @file
 * @brief InputDialogEngineファイル
 */

namespace ToffMonaka {
namespace UnityBase.Scene.DialogSystem {
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
