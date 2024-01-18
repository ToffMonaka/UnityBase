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
    public static readonly bool DEBUG_FLAG = true;
#else
    public static readonly bool DEBUG_FLAG = false;
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
            MAIN_SCENE_NODE,
            SUB_SCENE_NODE,
            OBJECT_NODE,
            COMPONENT,
		    COUNT
        }
        public static readonly int SCRIPT_TYPE_COUNT = (int)Lib.Util.SCENE.SCRIPT_TYPE.COUNT;

        public enum SCRIPT_INDEX : int
        {
            NONE = -1,
            NODE,
            MAIN_SCENE_NODE,
            SUB_SCENE_NODE,
            OBJECT_NODE,
            SOUND_BGM_NODE,
            SOUND_SE_NODE,
            COMPONENT,
            BUTTON_COMPONENT,
            SCROLL_VIEW_COMPONENT,
            SCROLL_BAR_COMPONENT,
            SLIDER_COMPONENT,
		    COUNT
        }
        public static readonly int SCRIPT_INDEX_COUNT = (int)Lib.Util.SCENE.SCRIPT_INDEX.COUNT;
    }
}
}
}
