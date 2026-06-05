/**
 * @file
 * @brief SoundUtilファイル
 */

namespace ToffMonaka {
namespace Tml.Sound {
/**
 * @brief SoundUtilクラス
 */
public static class SoundUtil
{
    private static SoundManager _manager = null;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static SoundManager GetManager()
    {
        return (SoundUtil._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(SoundManager manager)
    {
        SoundUtil._manager?.Init();

        SoundUtil._manager = manager;

        return;
    }
}
}
}
