/**
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
        public static readonly string SYSTEM_DATA = "dat/sys.dat";
        public static readonly string USER_DATA = "dat/user.dat";
        public static readonly string ENGLISH_MST_TEXT_TABLE = "Assets/Resources2/dat/en_mst_txt_tbl.csv";
        public static readonly string JAPANESE_MST_TEXT_TABLE = "Assets/Resources2/dat/jp_mst_txt_tbl.csv";
        public static readonly string SOUND_BGM_PREFAB = "Assets/Resources2/prefab/SoundBgm.prefab";
        public static readonly string SOUND_SE_PREFAB = "Assets/Resources2/prefab/SoundSe.prefab";
        public static readonly string INIT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/InitSubScene.prefab";
        public static readonly string TITLE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/TitleSubScene.prefab";
        public static readonly string SELECT_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/SelectSubScene.prefab";
        public static readonly string TEST_2D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test2DStageSubScene.prefab";
        public static readonly string TEST_3D_STAGE_SUB_SCENE_PREFAB = "Assets/Resources2/prefab/Test3DStageSubScene.prefab";
        public static readonly string SELECT_DIALOG_PREFAB = "Assets/Resources2/prefab/SelectDialog.prefab";
        public static readonly string INPUT_DIALOG_PREFAB = "Assets/Resources2/prefab/InputDialog.prefab";
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
            MAIN_SCENE_NODE = Lib.Util.SCENE.SCRIPT_INDEX.COUNT,
            INIT_SUB_SCENE_NODE,
            TITLE_SUB_SCENE_NODE,
            SELECT_SUB_SCENE_NODE,
            SELECT_BACK_BUTTON_NODE,
            SELECT_BOARD_NODE,
            SELECT_STAGE_BOARD_NODE,
            SELECT_STAGE_BUTTON_NODE,
            STAGE_SUB_SCENE_NODE,
            STAGE_BACK_BUTTON_NODE,
            TEST_2D_STAGE_SUB_SCENE_NODE,
            TEST_3D_STAGE_SUB_SCENE_NODE,
            MENU_NODE,
            MENU_OPEN_CLOSE_BUTTON_NODE,
            MENU_SELECT_NODE,
            MENU_SELECT_STAGE_BUTTON_NODE,
            MENU_STAGE_NODE,
            MENU_OPTION_STAGE_NODE,
            MENU_FAQ_STAGE_NODE,
            MENU_STAFF_STAGE_NODE,
            MENU_LICENSE_STAGE_NODE,
            MENU_PRIVACY_POLICY_STAGE_NODE,
            MENU_END_STAGE_NODE,
            MENU_CHEAT_STAGE_NODE,
            MENU_CHEAT_STAGE_COMMAND_BUTTON_NODE,
            DIALOG_NODE,
            SELECT_DIALOG_NODE,
            SELECT_DIALOG_ITEM_NODE,
            INPUT_DIALOG_NODE,
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

        public static readonly UnityBase.Util.MST_TEXT_ID[] SELECT_BOARD_NAME_MST_TEXT_ID_ARRAY = {
            UnityBase.Util.MST_TEXT_ID.NONE,
            UnityBase.Util.MST_TEXT_ID.STAGE
        };

        public enum STAGE_TYPE : int
        {
            NONE = 0,
            TEST_2D,
            TEST_3D,
		    COUNT
        }
        public static readonly int STAGE_TYPE_COUNT = (int)UnityBase.Util.SCENE.STAGE_TYPE.COUNT;

        public static readonly UnityBase.Util.MST_TEXT_ID[] STAGE_NAME_MST_TEXT_ID_ARRAY = {
            UnityBase.Util.MST_TEXT_ID.NONE,
            UnityBase.Util.MST_TEXT_ID.TEST_2D,
            UnityBase.Util.MST_TEXT_ID.TEST_3D
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

        public static readonly UnityBase.Util.MST_TEXT_ID[] MENU_STAGE_NAME_MST_TEXT_ID_ARRAY = {
            UnityBase.Util.MST_TEXT_ID.NONE,
            UnityBase.Util.MST_TEXT_ID.OPTION,
            UnityBase.Util.MST_TEXT_ID.FAQ,
            UnityBase.Util.MST_TEXT_ID.STAFF,
            UnityBase.Util.MST_TEXT_ID.LICENSE,
            UnityBase.Util.MST_TEXT_ID.PRIVACY_POLICY,
            UnityBase.Util.MST_TEXT_ID.EXIT,
            UnityBase.Util.MST_TEXT_ID.CHEAT
        };

        public enum MENU_CHEAT_STAGE_COMMAND_TYPE : int
        {
            NONE = 0,
            DATA_DELETE,
		    COUNT
        }
        public static readonly int MENU_CHEAT_STAGE_COMMAND_TYPE_COUNT = (int)UnityBase.Util.SCENE.MENU_CHEAT_STAGE_COMMAND_TYPE.COUNT;

        public static readonly UnityBase.Util.MST_TEXT_ID[] MENU_CHEAT_STAGE_COMMAND_NAME_MST_TEXT_ID_ARRAY = {
            UnityBase.Util.MST_TEXT_ID.NONE,
            UnityBase.Util.MST_TEXT_ID.DELETE_DATA
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

    public enum MST_TEXT_ID : int
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

    public static readonly UnityBase.Util.MST_TEXT_ID[] LANGUAGE_NAME_MST_TEXT_ID_ARRAY = {
        UnityBase.Util.MST_TEXT_ID.NONE,
        UnityBase.Util.MST_TEXT_ID.ENGLISH,
        UnityBase.Util.MST_TEXT_ID.JAPANESE
    };
}
}
}
