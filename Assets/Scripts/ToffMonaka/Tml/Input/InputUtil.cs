/**
 * @file
 * @brief InputUtilファイル
 */

namespace ToffMonaka {
namespace Tml.Input {
/**
 * @brief InputUtilクラス
 */
public static class InputUtil
{
    private static InputManager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static InputManager GetManager()
    {
        return (InputUtil._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(InputManager manager)
    {
        InputUtil._manager?.Init();

        InputUtil._manager = manager;

        return;
    }
}
}
}
