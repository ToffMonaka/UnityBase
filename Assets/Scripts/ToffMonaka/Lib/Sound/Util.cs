/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Sound {
/**
 * @brief Utilクラス
 */
public static class Util
{
    private static ToffMonaka.Lib.Sound.Manager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static ToffMonaka.Lib.Sound.Manager GetManager()
    {
        return (ToffMonaka.Lib.Sound.Util._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(ToffMonaka.Lib.Sound.Manager manager)
    {
        if (ToffMonaka.Lib.Sound.Util._manager != null) {
            ToffMonaka.Lib.Sound.Util._manager.Init();
        }

        ToffMonaka.Lib.Sound.Util._manager = manager;

        return;
    }
}
}
