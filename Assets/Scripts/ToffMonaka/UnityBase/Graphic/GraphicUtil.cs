/**
 * @file
 * @brief GraphicUtilファイル
 */

namespace ToffMonaka {
namespace UnityBase.Graphic {
/**
 * @brief GraphicUtilクラス
 */
public static class GraphicUtil
{
    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static GraphicManager GetManager()
    {
        return (ToffMonaka.Tml.Graphic.GraphicUtil.GetManager() as GraphicManager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(GraphicManager manager)
    {
        ToffMonaka.Tml.Graphic.GraphicUtil.SetManager(manager);

        return;
    }
}
}
}
