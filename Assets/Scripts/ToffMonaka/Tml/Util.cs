/**
 * @file
 * @brief Utilファイル
 */

using UnityEngine;

namespace ToffMonaka {
namespace Tml {
/**
 * @brief Utilクラス
 */
public static class Util
{
#if DEBUG
    private static bool _debugFlag = true;
#else
    private static bool _debugFlag = false;
#endif

    // Change Property Name
    // [UnityEngine.Serialization.FormerlySerializedAs("_propertyName")]

    public static class PROJECT
    {
        public static readonly string NAME = "Toff Monaka Library";
        public static readonly string VERSION_NAME = "1.0.0";
        public static readonly string COMPANY_NAME = "Toff Monaka Project";
    }

    /**
     * @brief GetDebugFlag関数
     * @return debug_flg (debug_flag)
     */
    public static bool GetDebugFlag()
    {
        return (Util._debugFlag);
    }
    
    /**
     * @brief SetDebugFlag関数
     * @param debug_flg (debug_flag)
     */
    public static void SetDebugFlag(bool debug_flg)
    {
        Debug.Log("Warning: ToffMonaka.Tml.Util.SetDebugFlag: " + debug_flg);

        Util._debugFlag = debug_flg;

        return;
    }
}
}
}
