/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Sound {
/**
 * @brief Utilクラス
 */
public static class Util
{
    private static Lib.Sound.Manager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static Lib.Sound.Manager GetManager()
    {
        return (Lib.Sound.Util._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(Lib.Sound.Manager manager)
    {
        if (Lib.Sound.Util._manager != null) {
            Lib.Sound.Util._manager.Init();
        }

        Lib.Sound.Util._manager = manager;

        return;
    }
}
}
}
