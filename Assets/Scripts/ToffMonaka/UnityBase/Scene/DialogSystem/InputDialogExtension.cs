/**
 * @file
 * @brief InputDialogExtensionファイル
 */

namespace ToffMonaka {
namespace UnityBase.Scene.DialogSystem {
/**
 * @brief InputDialogExtensionクラス
 */
public abstract class InputDialogExtension
{
    /**
     * @brief コンストラクタ
     */
    public InputDialogExtension()
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
