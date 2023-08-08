/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Graphic {
/**
 * @brief Utilクラス
 */
public static class Util
{
    private static Lib.Graphic.Manager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static Lib.Graphic.Manager GetManager()
    {
        return (Lib.Graphic.Util._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(Lib.Graphic.Manager manager)
    {
        if (Lib.Graphic.Util._manager != null) {
            Lib.Graphic.Util._manager.Init();
        }

        Lib.Graphic.Util._manager = manager;

        return;
    }
}
}
}
