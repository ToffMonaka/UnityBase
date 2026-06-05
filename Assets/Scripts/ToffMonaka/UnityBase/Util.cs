/**
 * @file
 * @brief Utilファイル
 */

using UnityEngine;
using ToffMonaka.UnityBase.Data;

namespace ToffMonaka {
namespace UnityBase {
/**
 * @brief Utilクラス
 */
public static class Util
{
#if DEBUG
    private static bool _debugFlag = true;
#else
    private static bool _debugFlag = false;
#endif

    // Change Property Name
    // [UnityEngine.Serialization.FormerlySerializedAs("_propertyName")]

    public static class PROJECT
    {
        public static readonly string NAME = "Unity Base";
        public static readonly string VERSION_NAME = "1.0.0";
        public static readonly string COMPANY_NAME = "Toff Monaka Project";
    }

    public static class FILE_PATH
    {
        public static readonly string NONE = "";
        public static readonly string SYSTEM_CONFIG = "dat/sys_conf.ini";
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
        public static readonly string SIMPLE_COVER_PREFAB = "Assets/Resources2/prefab/SimpleCover.prefab";
    }

    public enum LANGUAGE_TYPE : int
    {
        NONE = 0,
        ENGLISH,
        JAPANESE,
		COUNT
    }
    public static readonly int LANGUAGE_TYPE_COUNT = (int)Util.LANGUAGE_TYPE.COUNT;

    public static readonly DataUtil.MST_TEXT_ID[] LANGUAGE_NAME_MST_TEXT_ID_ARRAY = {
        DataUtil.MST_TEXT_ID.NONE,
        DataUtil.MST_TEXT_ID.ENGLISH,
        DataUtil.MST_TEXT_ID.JAPANESE
    };

    /**
     * @brief GetDebugFlag関数
     * @return debug_flg (debug_flag)
     */
    public static bool GetDebugFlag()
    {
        return (Util._debugFlag);
    }
    
    /**
     * @brief SetDebugFlag関数
     * @param debug_flg (debug_flag)
     */
    public static void SetDebugFlag(bool debug_flg)
    {
        Debug.Log("Warning: ToffMonaka.UnityBase.Util.SetDebugFlag: " + debug_flg);

        Util._debugFlag = debug_flg;

        return;
    }
}
}
}
