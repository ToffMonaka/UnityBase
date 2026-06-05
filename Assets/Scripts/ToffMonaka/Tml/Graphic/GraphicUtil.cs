/**
 * @file
 * @brief GraphicUtilファイル
 */

namespace ToffMonaka {
namespace Tml.Graphic {
/**
 * @brief GraphicUtilクラス
 */
public static class GraphicUtil
{
    private static GraphicManager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static GraphicManager GetManager()
    {
        return (GraphicUtil._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(GraphicManager manager)
    {
        GraphicUtil._manager?.Init();

        GraphicUtil._manager = manager;

        return;
    }
}
}
}
