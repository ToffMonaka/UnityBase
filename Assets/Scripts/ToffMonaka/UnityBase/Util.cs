﻿/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase {
/**
 * @brief Utilクラス
 */
public static class Util
{
#if DEBUG
    public static readonly bool DEBUG_FLAG = true;
#else
    public static readonly bool DEBUG_FLAG = false;
#endif

    public static class PROJECT
    {
        public static readonly string NAME = "Unity Base";
        public static readonly string COMPANY_NAME = "Toff Monaka Project";
        public static readonly string VERSION_NAME = "1.0.0";
    }

    public static class FILE_PATH
    {
        public static readonly string NONE = "";
        public static readonly string SYSTEM_CONFIG = "dat/sys_conf.ini";
        public static readonly string MST_STRING_ENGLISH_TABLE = "Assets/Resources2/dat/mst_str_en_tbl.csv";
        public static readonly string MST_STRING_JAPANESE_TABLE = "Assets/Resources2/dat/mst_str_jp_tbl.csv";
        public static readonly string INIT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/InitSubScene.prefab";
        public static readonly string TITLE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/TitleSubScene.prefab";
        public static readonly string SELECT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/SelectSubScene.prefab";
        public static readonly string TEST_2D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test2DStageSubScene.prefab";
        public static readonly string TEST_3D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test3DStageSubScene.prefab";
        public static readonly string LANGUAGE_SELECT_DIALOG_PREFAB = "Assets/Resources2/prefab/LanguageSelectDialog.prefab";
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
        public static readonly int BGM_INDEX_COUNT = (int)UnityBase.Util.SOUND.BGM_INDEX.COUNT;

        public enum SE_INDEX : int
        {
            NONE = -1,
            OK,
            OK2,
            CANCEL,
		    COUNT
        }
        public static readonly int SE_INDEX_COUNT = (int)UnityBase.Util.SOUND.SE_INDEX.COUNT;
    }

    public static class SCENE
    {
        public enum SCRIPT_INDEX : int
        {
            MAIN_SCENE = Lib.Util.SCENE.SCRIPT_INDEX.COUNT,
            INIT_SUB_SCENE,
            TITLE_SUB_SCENE,
            SELECT_SUB_SCENE,
            SELECT_BACK_BUTTON,
            SELECT_STAGE_BOARD,
            SELECT_STAGE_BUTTON,
            STAGE_BACK_BUTTON,
            TEST_2D_STAGE_SUB_SCENE,
            TEST_3D_STAGE_SUB_SCENE,
            MENU,
            MENU_OPEN_CLOSE_BUTTON,
            MENU_SELECT,
            MENU_SELECT_STAGE_BUTTON,
            MENU_OPTION_STAGE,
            MENU_FAQ_STAGE,
            MENU_STAFF_STAGE,
            MENU_LICENSE_STAGE,
            MENU_PRIVACY_POLICY_STAGE,
            MENU_END_STAGE,
            MENU_CHEAT_STAGE,
            MENU_CHEAT_STAGE_COMMAND_BUTTON,
            LANGUAGE_SELECT_DIALOG,
            LANGUAGE_SELECT_DIALOG_BUTTON,
		    COUNT
        }
        public static readonly int SCRIPT_INDEX_COUNT = (int)UnityBase.Util.SCENE.SCRIPT_INDEX.COUNT;

        public static class NAME
        {
            public static readonly string NONE = "";
            public static readonly string MAIN = "MainScene";
        }

        public enum SELECT_BOARD_TYPE : int
        {
            NONE = 0,
            STAGE,
		    COUNT
        }
        public static readonly int SELECT_BOARD_TYPE_COUNT = (int)UnityBase.Util.SCENE.SELECT_BOARD_TYPE.COUNT;

        public static readonly UnityBase.Util.MST_STRING_ID[] SELECT_BOARD_NAME_MST_STRING_ID_ARRAY = {
            UnityBase.Util.MST_STRING_ID.NONE,
            UnityBase.Util.MST_STRING_ID.STAGE
        };

        public enum STAGE_TYPE : int
        {
            NONE = 0,
            TEST_2D,
            TEST_3D,
		    COUNT
        }
        public static readonly int STAGE_TYPE_COUNT = (int)UnityBase.Util.SCENE.STAGE_TYPE.COUNT;

        public static readonly UnityBase.Util.MST_STRING_ID[] STAGE_NAME_MST_STRING_ID_ARRAY = {
            UnityBase.Util.MST_STRING_ID.NONE,
            UnityBase.Util.MST_STRING_ID.TEST_2D,
            UnityBase.Util.MST_STRING_ID.TEST_3D
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
        public static readonly int MENU_STAGE_TYPE_COUNT = (int)UnityBase.Util.SCENE.MENU_STAGE_TYPE.COUNT;

        public static readonly UnityBase.Util.MST_STRING_ID[] MENU_STAGE_NAME_MST_STRING_ID_ARRAY = {
            UnityBase.Util.MST_STRING_ID.NONE,
            UnityBase.Util.MST_STRING_ID.OPTION,
            UnityBase.Util.MST_STRING_ID.FAQ,
            UnityBase.Util.MST_STRING_ID.STAFF,
            UnityBase.Util.MST_STRING_ID.LICENSE,
            UnityBase.Util.MST_STRING_ID.PRIVACY_POLICY,
            UnityBase.Util.MST_STRING_ID.EXIT,
            UnityBase.Util.MST_STRING_ID.CHEAT
        };

        public enum MENU_CHEAT_STAGE_COMMAND_TYPE : int
        {
            NONE = 0,
            DATA_DELETE,
		    COUNT
        }
        public static readonly int MENU_CHEAT_STAGE_COMMAND_TYPE_COUNT = (int)UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.COUNT;

        public static readonly UnityBase.Util.MST_STRING_ID[] MENU_CHEAT_STAGE_COMMAND_NAME_MST_STRING_ID_ARRAY = {
            UnityBase.Util.MST_STRING_ID.NONE,
            UnityBase.Util.MST_STRING_ID.DELETE_DATA
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
    public static readonly int LANGUAGE_TYPE_COUNT = (int)UnityBase.Util.LANGUAGE_TYPE.COUNT;

    public static readonly UnityBase.Util.MST_STRING_ID[] LANGUAGE_NAME_MST_STRING_ID_ARRAY = {
        UnityBase.Util.MST_STRING_ID.NONE,
        UnityBase.Util.MST_STRING_ID.ENGLISH,
        UnityBase.Util.MST_STRING_ID.JAPANESE
    };
}
}
}
