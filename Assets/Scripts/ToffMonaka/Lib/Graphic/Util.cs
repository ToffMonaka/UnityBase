/**
 * @file
 * @brief Utilファイル
 */


namespace ToffMonaka.Lib.Graphic {
/**
 * @brief Utilクラス
 */
public static class Util
{
    private static ToffMonaka.Lib.Graphic.Manager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static ToffMonaka.Lib.Graphic.Manager GetManager()
    {
        return (ToffMonaka.Lib.Graphic.Util._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(ToffMonaka.Lib.Graphic.Manager manager)
    {
        ToffMonaka.Lib.Graphic.Util._manager = manager;

        return;
    }
}
}
