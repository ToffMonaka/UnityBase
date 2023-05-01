/**
 * @file
 * @brief Utilファイル
 */


namespace ToffMonaka.UnityBase.Constant {
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
    public const string NAME = "C# ベースプロジェクト";
    public const string COMPANY_NAME = "Toff Monaka Project";
    public const string VERSION_NAME = "1.0.0";
    public enum SCRIPT_TYPE
    {
        NONE = 0,
        INIT_SCENE,
        PLAY_SCENE,
        TITLE_SUB_SCENE,
        SELECT_SUB_SCENE,
        TEST_2D_SUB_SCENE,
        TEST_3D_SUB_SCENE,
        MENU_SUB_LAYER,
		COUNT
    }
    public const int SCRIPT_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCRIPT_TYPE.COUNT;
}
}
