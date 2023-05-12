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
        public const string INIT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/InitSubScene.prefab";
        public const string TITLE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/TitleSubScene.prefab";
        public const string SELECT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/SelectSubScene.prefab";
        public const string TEST_2D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test2DStageSubScene.prefab";
        public const string TEST_3D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test3DStageSubScene.prefab";
    }

    public static class SCENE
    {
        public enum SCRIPT_INDEX : int
        {
            NONE = -1,
            MAIN_SCENE,
            INIT_SUB_SCENE,
            TITLE_SUB_SCENE,
            SELECT_SUB_SCENE,
            TEST_2D_STAGE_SUB_SCENE,
            TEST_3D_STAGE_SUB_SCENE,
            MENU_BUTTON_SUB_LAYER,
		    COUNT
        }
        public const int SCRIPT_INDEX_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.COUNT;
    }

    public static class SCENE_NAME
    {
        public const string NONE = "";
        public const string MAIN_SCENE = "MainScene";
    }
}
}
