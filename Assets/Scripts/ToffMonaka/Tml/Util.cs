/**
 * @file
 * @brief Utilファイル
 */

using UnityEngine;

namespace ToffMonaka {
namespace Tml {
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

    public static class PROJECT
    {
        public static readonly string NAME = "Toff Monaka Library";
        public static readonly string VERSION_NAME = "1.0.0";
        public static readonly string COMPANY_NAME = "Toff Monaka Project";
    }

    public static class FILE_PATH
    {
        public static readonly string NONE = "";
    }

    public static class INPUT
    {
    }

    public static class GRAPHIC
    {
    }

    public static class SOUND
    {
    }

    public static class SCENE
    {
        public enum SCRIPT_TYPE : int
        {
            NONE = 0,
            MAIN_SCENE_NODE,
            SUB_SCENE_NODE,
            OBJECT_NODE,
            PARTS,
		    COUNT
        }
        public static readonly int SCRIPT_TYPE_COUNT = (int)Util.SCENE.SCRIPT_TYPE.COUNT;

        public enum SCRIPT_INDEX : int
        {
            NONE = -1,
            NODE,
            MAIN_SCENE_NODE,
            SUB_SCENE_NODE,
            OBJECT_NODE,
            SOUND_BGM_NODE,
            SOUND_SE_NODE,
            PARTS,
            BUTTON_PARTS,
            SCROLL_VIEW_PARTS,
            SLIDER_PARTS,
		    COUNT
        }
        public static readonly int SCRIPT_INDEX_COUNT = (int)Util.SCENE.SCRIPT_INDEX.COUNT;
    }

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
        Debug.Log("Warning: ToffMonaka.Tml.Util.SetDebugFlag: " + debug_flg);

        Util._debugFlag = debug_flg;

        return;
    }
}
}
}
