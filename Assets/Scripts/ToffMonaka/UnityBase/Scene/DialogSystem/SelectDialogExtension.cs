/**
 * @file
 * @brief SelectDialogExtensionファイル
 */

namespace ToffMonaka {
namespace UnityBase.Scene.DialogSystem {
/**
 * @brief SelectDialogExtensionクラス
 */
public abstract class SelectDialogExtension
{
    /**
     * @brief コンストラクタ
     */
    public SelectDialogExtension()
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
 * @brief SelectDialogItemExtensionクラス
 */
public abstract class SelectDialogItemExtension
{
    /**
     * @brief コンストラクタ
     */
    public SelectDialogItemExtension()
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
