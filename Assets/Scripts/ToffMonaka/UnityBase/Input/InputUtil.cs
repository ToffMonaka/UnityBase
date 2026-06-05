/**
 * @file
 * @brief InputUtilファイル
 */

namespace ToffMonaka {
namespace UnityBase.Input {
/**
 * @brief InputUtilクラス
 */
public static class InputUtil
{
    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static ToffMonaka.Tml.Input.InputManager GetManager()
    {
        return (ToffMonaka.Tml.Input.InputUtil.GetManager());
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(ToffMonaka.Tml.Input.InputManager manager)
    {
        ToffMonaka.Tml.Input.InputUtil.SetManager(manager);

        return;
    }
}
}
}
