﻿/**
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
    public const bool DEBUG_FLAG = true;
#else
    public const bool DEBUG_FLAG = false;
#endif

    public static class PROJECT
    {
        public const string NAME = "Toff Monaka Library";
        public const string COMPANY_NAME = "Toff Monaka Project";
        public const string VERSION_NAME = "1.0.0";
    }

    public static class FILE_PATH
    {
        public const string NONE = "";
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
            MAIN_SCENE,
            SUB_SCENE,
            OBJECT,
		    COUNT
        }
        public const int SCRIPT_TYPE_COUNT = (int)Lib.Util.SCENE.SCRIPT_TYPE.COUNT;

        public enum SCRIPT_INDEX : int
        {
            NONE = -1,
            SOUND_BGM,
            SOUND_SE,
		    COUNT
        }
        public const int SCRIPT_INDEX_COUNT = (int)Lib.Util.SCENE.SCRIPT_INDEX.COUNT;
    }
}
}
}