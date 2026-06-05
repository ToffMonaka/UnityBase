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
    public enum BGM_SOUND_INDEX : int
    {
        NONE = -1,
        TITLE,
        SELECT,
		COUNT
    }
    public static readonly int BGM_SOUND_INDEX_COUNT = (int)SoundUtil.BGM_SOUND_INDEX.COUNT;

    public enum SE_SOUND_INDEX : int
    {
        NONE = -1,
        OK,
        OK2,
        CANCEL,
		COUNT
    }
    public static readonly int SE_SOUND_INDEX_COUNT = (int)SoundUtil.SE_SOUND_INDEX.COUNT;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static ToffMonaka.Tml.Sound.SoundManager GetManager()
    {
        return (ToffMonaka.Tml.Sound.SoundUtil.GetManager());
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(ToffMonaka.Tml.Sound.SoundManager manager)
    {
        ToffMonaka.Tml.Sound.SoundUtil.SetManager(manager);

        return;
    }
}
}
}
