/**
 * @file
 * @brief SceneUtilファイル
 */

namespace ToffMonaka {
namespace UnityBase.Scene {
/**
 * @brief SceneUtilクラス
 */
public static class SceneUtil
{
    public enum SCRIPT_INDEX : int
    {
        MAIN_SCENE_NODE = ToffMonaka.Tml.Scene.SceneUtil.SCRIPT_INDEX.COUNT,
        SUB_SCENE_NODE,
        INIT_SUB_SCENE_NODE,
        TITLE_SUB_SCENE_NODE,
        SELECT_SUB_SCENE_NODE,
        SELECT_BACK_BUTTON_NODE,
        SELECT_BOARD_NODE,
        SELECT_STAGE_BOARD_NODE,
        SELECT_STAGE_BOARD_ITEM_NODE,
        STAGE_SUB_SCENE_NODE,
        TEST_2D_STAGE_SUB_SCENE_NODE,
        TEST_2D_STAGE_FIELD_NODE,
        TEST_2D_STAGE_FIELD_FALL_ZONE_PARTS,
        TEST_2D_STAGE_PLAYER_NODE,
        TEST_3D_STAGE_SUB_SCENE_NODE,
        SIDE_MENU_NODE,
        SIDE_MENU_OPEN_CLOSE_BUTTON_NODE,
        SIDE_MENU_BOARD_NODE,
        SIDE_MENU_SELECT_BOARD_NODE,
        SIDE_MENU_SELECT_BOARD_ITEM_NODE,
        SIDE_MENU_SELECT2_BOARD_NODE,
        SIDE_MENU_OPTION_SELECT2_BOARD_NODE,
        SIDE_MENU_INFO_SELECT2_BOARD_NODE,
        SIDE_MENU_STAGE_BOARD_NODE,
        SIDE_MENU_OPTION_SYSTEM_STAGE_BOARD_NODE,
        SIDE_MENU_OPTION_INPUT_STAGE_BOARD_NODE,
        SIDE_MENU_OPTION_GRAPHIC_STAGE_BOARD_NODE,
        SIDE_MENU_OPTION_SOUND_STAGE_BOARD_NODE,
        SIDE_MENU_INFO_FAQ_STAGE_BOARD_NODE,
        SIDE_MENU_INFO_STAFF_STAGE_BOARD_NODE,
        SIDE_MENU_INFO_LICENSE_STAGE_BOARD_NODE,
        SIDE_MENU_INFO_PRIVACY_POLICY_STAGE_BOARD_NODE,
        SIDE_MENU_EXIT_STAGE_BOARD_NODE,
        SIDE_MENU_CHEAT_STAGE_BOARD_NODE,
        SIDE_MENU_CHEAT_STAGE_BOARD_ITEM_NODE,
        DIALOG_SYSTEM_NODE,
        DIALOG_NODE,
        SELECT_DIALOG_NODE,
        SELECT_DIALOG_ITEM_NODE,
        INPUT_DIALOG_NODE,
        COVER_SYSTEM_NODE,
        COVER_NODE,
        SIMPLE_COVER_NODE,
		COUNT
    }
    public static readonly int SCRIPT_INDEX_COUNT = (int)SceneUtil.SCRIPT_INDEX.COUNT;

    public enum SELECT_BOARD_TYPE : int
    {
        NONE = 0,
        STAGE,
		COUNT
    }
    public static readonly int SELECT_BOARD_TYPE_COUNT = (int)SceneUtil.SELECT_BOARD_TYPE.COUNT;

    public enum STAGE_TYPE : int
    {
        NONE = 0,
        TEST_2D,
        TEST_3D,
		COUNT
    }
    public static readonly int STAGE_TYPE_COUNT = (int)SceneUtil.STAGE_TYPE.COUNT;

    public enum SIDE_MENU_BOARD_TYPE : int
    {
        NONE = 0,
        SELECT,
        OPTION_SELECT2,
        INFO_SELECT2,
        OPTION_SYSTEM_STAGE,
        OPTION_INPUT_STAGE,
        OPTION_GRAPHIC_STAGE,
        OPTION_SOUND_STAGE,
        INFO_FAQ_STAGE,
        INFO_STAFF_STAGE,
        INFO_LICENSE_STAGE,
        INFO_PRIVACY_POLICY_STAGE,
        EXIT_STAGE,
        CHEAT_STAGE,
		COUNT
    }
    public static readonly int SIDE_MENU_BOARD_TYPE_COUNT = (int)SceneUtil.SIDE_MENU_BOARD_TYPE.COUNT;

    public enum SIDE_MENU_SELECT2_BOARD_TYPE : int
    {
        NONE = 0,
        OPTION,
        INFO,
		COUNT
    }
    public static readonly int SIDE_MENU_SELECT2_BOARD_TYPE_COUNT = (int)SceneUtil.SIDE_MENU_SELECT2_BOARD_TYPE.COUNT;

    public enum SIDE_MENU_STAGE_BOARD_TYPE : int
    {
        NONE = 0,
        OPTION_SYSTEM,
        OPTION_INPUT,
        OPTION_GRAPHIC,
        OPTION_SOUND,
        INFO_FAQ,
        INFO_STAFF,
        INFO_LICENSE,
        INFO_PRIVACY_POLICY,
        EXIT,
        CHEAT,
		COUNT
    }
    public static readonly int SIDE_MENU_STAGE_BOARD_TYPE_COUNT = (int)SceneUtil.SIDE_MENU_STAGE_BOARD_TYPE.COUNT;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static ToffMonaka.Tml.Scene.SceneManager GetManager()
    {
        return (ToffMonaka.Tml.Scene.SceneUtil.GetManager());
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(ToffMonaka.Tml.Scene.SceneManager manager)
    {
        ToffMonaka.Tml.Scene.SceneUtil.SetManager(manager);

        return;
    }

    /**
     * @brief GetMainSceneNodeScript関数
     * @return main_scene_node_script (main_scene_node_script)
     */
    public static MainSceneNodeScript GetMainSceneNodeScript()
    {
        return (SceneUtil.GetManager().GetMainSceneNodeScript() as MainSceneNodeScript);
    }

    /**
     * @brief GetSubSceneNodeScript関数
     * @return sub_scene_node_script (sub_scene_node_script)
     */
    public static SubSceneNodeScript GetSubSceneNodeScript()
    {
        return (SceneUtil.GetManager().GetSubSceneNodeScript() as SubSceneNodeScript);
    }
}
}
}
