/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


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
        public const string STAGE_SELECT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/StageSelectSubScene.prefab";
        public const string TEST_2D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test2DStageSubScene.prefab";
        public const string TEST_3D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test3DStageSubScene.prefab";
    }

    public static class INPUT
    {
    }

    public static class GRAPHIC
    {
    }

    public static class SOUND
    {
        public enum BGM_INDEX : int
        {
            NONE = -1,
            TITLE,
            SELECT,
		    COUNT
        }
        public const int BGM_INDEX_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SOUND.BGM_INDEX.COUNT;

        public enum SE_INDEX : int
        {
            NONE = -1,
            OK,
            OK2,
            CANCEL,
		    COUNT
        }
        public const int SE_INDEX_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SOUND.SE_INDEX.COUNT;
    }

    public static class SCENE
    {
        public enum SCRIPT_INDEX : int
        {
            MAIN_SCENE = ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_INDEX.COUNT,
            INIT_SUB_SCENE,
            TITLE_SUB_SCENE,
            STAGE_SELECT_SUB_SCENE,
            STAGE_SELECT_STAGE_BUTTON,
            TEST_2D_STAGE_SUB_SCENE,
            TEST_3D_STAGE_SUB_SCENE,
            MENU,
            MENU_OPEN_CLOSE_BUTTON,
            MENU_STAGE_SELECT,
            MENU_STAGE_SELECT_STAGE_BUTTON,
            MENU_OPTION_STAGE,
            MENU_FAQ_STAGE,
            MENU_STAFF_STAGE,
            MENU_LICENSE_STAGE,
            MENU_END_STAGE,
            MENU_CHEAT_STAGE,
            MENU_CHEAT_STAGE_COMMAND_BUTTON,
            MENU_LANGUAGE_SELECT_DIALOG,
            MENU_LANGUAGE_SELECT_LANGUAGE_BUTTON,
		    COUNT
        }
        public const int SCRIPT_INDEX_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.SCRIPT_INDEX.COUNT;

        public static class NAME
        {
            public const string NONE = "";
            public const string MAIN = "MainScene";
        }

        public enum SELECT_TYPE : int
        {
            NONE = 0,
            STAGE,
		    COUNT
        }
        public const int SELECT_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.SELECT_TYPE.COUNT;
        public static readonly string[] SELECT_NAME_ARRAY = {
            "",
            "ステージ"
        };

        public enum STAGE_TYPE : int
        {
            NONE = 0,
            TEST_2D,
            TEST_3D,
		    COUNT
        }
        public const int STAGE_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.COUNT;
        public static readonly string[] STAGE_NAME_ARRAY = {
            "",
            "テスト2D",
            "テスト3D"
        };

        public enum MENU_SELECT_TYPE : int
        {
            NONE = 0,
            STAGE,
		    COUNT
        }
        public const int MENU_SELECT_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_SELECT_TYPE.COUNT;
        public static readonly string[] MENU_SELECT_NAME_ARRAY = {
            "",
            "メニュー"
        };

        public enum MENU_STAGE_TYPE : int
        {
            NONE = 0,
            OPTION,
            FAQ,
            STAFF,
            LICENSE,
            END,
            CHEAT,
		    COUNT
        }
        public const int MENU_STAGE_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.COUNT;
        public static readonly string[] MENU_STAGE_NAME_ARRAY = {
            "",
            "オプション",
            "FAQ",
            "スタッフ",
            "ライセンス",
            "終了",
            "チート"
        };

        public enum MENU_CHEAT_STAGE_COMMAND_TYPE : int
        {
            NONE = 0,
            STORAGE_DELETE,
            LOG,
		    COUNT
        }
        public const int MENU_CHEAT_STAGE_COMMAND_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.COUNT;
        public static readonly string[] MENU_CHEAT_STAGE_COMMAND_NAME_ARRAY = {
            "",
            "ストレージ削除",
            "ログ"
        };
        public static readonly string[] MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY = {
            "",
            "/DeleteStorage",
            "/Log"
        };
        public static readonly string[] MENU_CHEAT_STAGE_COMMAND_PARAMETER_ARRAY = {
            "",
            "",
            "Text"
        };
    }
}
}
