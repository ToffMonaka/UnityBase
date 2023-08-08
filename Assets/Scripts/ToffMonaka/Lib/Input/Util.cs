/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Input {
/**
 * @brief Utilクラス
 */
public static class Util
{
    private static Lib.Input.Manager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static Lib.Input.Manager GetManager()
    {
        return (Lib.Input.Util._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(Lib.Input.Manager manager)
    {
        if (Lib.Input.Util._manager != null) {
            Lib.Input.Util._manager.Init();
        }

        Lib.Input.Util._manager = manager;

        return;
    }
}
}
}
