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

    public static class FILE_PATH
    {
        public const string NONE = "";
        public const string TITLE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/TitleSubScene.prefab";
        public const string SELECT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/SelectSubScene.prefab";
        public const string TEST_2D_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test2DSubScene.prefab";
        public const string TEST_3D_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test3DSubScene.prefab";
    }

    public static class SCENE
    {
        public enum SCRIPT_INDEX
        {
            INIT_SCENE = 0,
            PLAY_SCENE,
            TITLE_SUB_SCENE,
            SELECT_SUB_SCENE,
            TEST_2D_SUB_SCENE,
            TEST_3D_SUB_SCENE,
            MENU_SUB_LAYER,
		    COUNT
        }
        public const int SCRIPT_INDEX_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.COUNT;
    }

    public static class SCENE_NAME
    {
        public const string NONE = "";
        public const string INIT_SCENE = "InitScene";
        public const string PLAY_SCENE = "PlayScene";
    }
}
}
