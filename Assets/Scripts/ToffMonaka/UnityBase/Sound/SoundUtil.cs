/**
 * @file
 * @brief SoundUtilファイル
 */

namespace ToffMonaka {
namespace UnityBase.Sound {
/**
 * @brief SoundUtilクラス
 */
public static class SoundUtil
{
    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static SoundManager GetManager()
    {
        return (ToffMonaka.Tml.Sound.SoundUtil.GetManager() as SoundManager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(SoundManager manager)
    {
        ToffMonaka.Tml.Sound.SoundUtil.SetManager(manager);

        return;
    }
}
}
}
