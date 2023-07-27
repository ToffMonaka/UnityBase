﻿/**
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
        public const string SYSTEM_CONFIG = "dat/sys_conf.ini";
        public const string MST_STRING_ENGLISH_TABLE = "Assets/Resources2/dat/mst_str_en_tbl.csv";
        public const string MST_STRING_JAPANESE_TABLE = "Assets/Resources2/dat/mst_str_jp_tbl.csv";
        public const string INIT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/InitSubScene.prefab";
        public const string TITLE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/TitleSubScene.prefab";
        public const string STAGE_SELECT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/StageSelectSubScene.prefab";
        public const string TEST_2D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test2DStageSubScene.prefab";
        public const string TEST_3D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test3DStageSubScene.prefab";
        public const string MENU_OPTION_STAGE_LANGUAGE_SELECT_DIALOG_PREFAB = "Assets/Resources2/prefab/MenuOptionStageLanguageSelectDialog.prefab";
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
            MENU_OPTION_STAGE_LANGUAGE_SELECT_DIALOG,
            MENU_OPTION_STAGE_LANGUAGE_SELECT_LANGUAGE_BUTTON,
            MENU_FAQ_STAGE,
            MENU_STAFF_STAGE,
            MENU_LICENSE_STAGE,
            MENU_PRIVACY_POLICY_STAGE,
            MENU_END_STAGE,
            MENU_CHEAT_STAGE,
            MENU_CHEAT_STAGE_COMMAND_BUTTON,
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
        public static readonly ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID[] SELECT_NAME_MST_STRING_ID_ARRAY = {
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.NONE,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.STAGE
        };

        public enum STAGE_TYPE : int
        {
            NONE = 0,
            TEST_2D,
            TEST_3D,
		    COUNT
        }
        public const int STAGE_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.STAGE_TYPE.COUNT;
        public static readonly ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID[] STAGE_NAME_MST_STRING_ID_ARRAY = {
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.NONE,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.TEST_2D,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.TEST_3D
        };

        public enum MENU_SELECT_TYPE : int
        {
            NONE = 0,
            STAGE,
		    COUNT
        }
        public const int MENU_SELECT_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_SELECT_TYPE.COUNT;
        public static readonly ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID[] MENU_SELECT_NAME_MST_STRING_ID_ARRAY = {
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.NONE,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.MENU
        };

        public enum MENU_STAGE_TYPE : int
        {
            NONE = 0,
            OPTION,
            FAQ,
            STAFF,
            LICENSE,
            PRIVACY_POLICY,
            END,
            CHEAT,
		    COUNT
        }
        public const int MENU_STAGE_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_STAGE_TYPE.COUNT;
        public static readonly ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID[] MENU_STAGE_NAME_MST_STRING_ID_ARRAY = {
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.NONE,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.OPTION,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.FAQ,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.STAFF,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.LICENSE,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.PRIVACY_POLICY,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.EXIT,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.CHEAT
        };

        public enum MENU_CHEAT_STAGE_COMMAND_TYPE : int
        {
            NONE = 0,
            DATA_DELETE,
		    COUNT
        }
        public const int MENU_CHEAT_STAGE_COMMAND_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.COUNT;
        public static readonly ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID[] MENU_CHEAT_STAGE_COMMAND_NAME_MST_STRING_ID_ARRAY = {
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.NONE,
            ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.DELETE_DATA
        };
        public static readonly string[] MENU_CHEAT_STAGE_COMMAND_FUNCTION_ARRAY = {
            "",
            "/DeleteData"
        };
        public static readonly string[] MENU_CHEAT_STAGE_COMMAND_PARAMETER_ARRAY = {
            "",
            ""
        };
    }

    public enum MST_STRING_ID : int
    {
        NONE = 0,
        OK,
        OK_RESTART,
		CANCEL,
        MENU,
        OPTION,
        FAQ,
        STAFF,
        LICENSE,
        PRIVACY_POLICY,
        EXIT,
        CHEAT,
        LANGUAGE,
        ENGLISH,
        JAPANESE,
        SOUND,
        BGM_VOLUME,
        BGM_MUTE,
        SE_VOLUME,
        SE_MUTE,
        RESTART,
        COMMAND,
        DELETE_DATA,
        STAGE,
        TEST_2D,
        TEST_3D,
        IN_PREPARATION
    }

    public enum LANGUAGE_TYPE : int
    {
        NONE = 0,
        ENGLISH,
        JAPANESE,
		COUNT
    }
    public const int LANGUAGE_TYPE_COUNT = (int)ToffMonaka.UnityBase.Constant.Util.LANGUAGE_TYPE.COUNT;
    public static readonly ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID[] LANGUAGE_NAME_MST_STRING_ID_ARRAY = {
        ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.NONE,
        ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.ENGLISH,
        ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID.JAPANESE
    };
}
}
