/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Input {
/**
 * @brief Utilクラス
 */
public static class Util
{
    private static ToffMonaka.Lib.Input.Manager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static ToffMonaka.Lib.Input.Manager GetManager()
    {
        return (ToffMonaka.Lib.Input.Util._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(ToffMonaka.Lib.Input.Manager manager)
    {
        if (ToffMonaka.Lib.Input.Util._manager != null) {
            ToffMonaka.Lib.Input.Util._manager.Init();
        }

        ToffMonaka.Lib.Input.Util._manager = manager;

        return;
    }
}
}
