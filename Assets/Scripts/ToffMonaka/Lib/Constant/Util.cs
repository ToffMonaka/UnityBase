/**
 * @file
 * @brief Utilファイル
 */


namespace ToffMonaka.Lib.Constant {
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
    public const string NAME = "Toff Monaka ライブラリ";
    public const string COMPANY_NAME = "Toff Monaka Project";
    public const string VERSION_NAME = "1.0.0";

    public static class FILE_PATH
    {
        public const string NONE = "";
    }

    public static class SCENE
    {
        public enum SCRIPT_TYPE : int
        {
            NONE = 0,
            SCENE,
            SUB_SCENE,
            STATIC_SUB_LAYER,
            DYNAMIC_SUB_LAYER,
		    COUNT
        }
        public const int SCRIPT_TYPE_COUNT = (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.COUNT;
    }
}
}
