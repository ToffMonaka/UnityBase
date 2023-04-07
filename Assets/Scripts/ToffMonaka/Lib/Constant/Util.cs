/**
 * @file
 * @brief Utilファイル
 */

namespace ToffMonaka.Lib.Constant
{
    /**
     * @brief Utilクラス
     */
    public static class Util
    {
#if DEBUG
    	public const bool DEBUG_FLAG = true;
#else
        public const bool DEBUG_FLAG = false;
#endif
        public const string NAME = "Toff Monaka Library";
        public const string COMPANY_NAME = "Toff Monaka Project";
        public const string VERSION_NAME = "1.0.0";
    }
}
