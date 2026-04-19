/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib {
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
        public static readonly string COMPANY_NAME = "Toff Monaka Project";
        public static readonly string VERSION_NAME = "1.0.0";
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
            NODE,
            PARTS,
		    COUNT
        }
        public static readonly int SCRIPT_TYPE_COUNT = (int)Lib.Util.SCENE.SCRIPT_TYPE.COUNT;

        public enum NODE_SCRIPT_TYPE : int
        {
            NONE = 0,
            MAIN_SCENE,
            SUB_SCENE,
            OBJECT,
		    COUNT
        }
        public static readonly int NODE_SCRIPT_TYPE_COUNT = (int)Lib.Util.SCENE.NODE_SCRIPT_TYPE.COUNT;

        public enum NODE_SCRIPT_INDEX : int
        {
            NONE = -1,
            NODE,
            MAIN_SCENE,
            SUB_SCENE,
            OBJECT,
            SOUND_BGM,
            SOUND_SE,
		    COUNT
        }
        public static readonly int NODE_SCRIPT_INDEX_COUNT = (int)Lib.Util.SCENE.NODE_SCRIPT_INDEX.COUNT;
    }

    /**
     * @brief GetDebugFlag関数
     * @return debug_flg (debug_flag)
     */
    public static bool GetDebugFlag()
    {
        return (Lib.Util._debugFlag);
    }
    
    /**
     * @brief SetDebugFlag関数
     * @param debug_flg (debug_flag)
     */
    public static void SetDebugFlag(bool debug_flg)
    {
        Debug.Log("Warning: ToffMonaka.Lib.Util.SetDebugFlag: " + debug_flg);

        Lib.Util._debugFlag = debug_flg;

        return;
    }
}
}
}
