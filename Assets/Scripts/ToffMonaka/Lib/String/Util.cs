/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.String {
/**
 * @brief Utilクラス
 */
public static class Util
{
    public enum NEWLINE_TYPE : int
    {
        NONE = 0,
		CRLF,
		CR,
		LF,
		COUNT
    }
    public static readonly int NEWLINE_TYPE_COUNT = (int)Lib.String.Util.NEWLINE_TYPE.COUNT;

    public static readonly string[] NEWLINE_CODE_ARRAY = {
        "",
        "\r\n",
        "\r",
        "\n"
    };

    /**
     * @brief GetNewlineCode関数
     * @param newline_type (newline_type)
     * @return newline_code (newline_code)
     */
    public static string GetNewlineCode(Lib.String.Util.NEWLINE_TYPE newline_type)
    {
        return (Lib.String.Util.NEWLINE_CODE_ARRAY[(int)newline_type]);
    }

    /**
     * @brief Replace関数
     * @param str (string)
     * @param old_str (old_string)
     * @param new_str (new_string)
     */
    public static void Replace(ref string str, string old_str, string new_str)
    {
        if ((str == null)
        || (old_str == null)
        || (old_str.Length <= 0)
        || (new_str == null)
        || (new_str.Length <= 0)) {
            return;
        }

        str = str.Replace(old_str, new_str);

        return;
    }

    /**
     * @brief Replace関数
     * @param str (string)
     * @param old_str_index (old_string_index)
     * @param old_str_cnt (old_string_count)
     * @param new_str (new_string)
     */
    public static void Replace(ref string str, int old_str_index, int old_str_cnt, string new_str)
    {
        if ((str == null)
        || (old_str_index < 0)
        || (old_str_cnt <= 0)
        || (new_str == null)
        || (new_str.Length <= 0)) {
            return;
        }

		str = str.Substring(0, old_str_index) + new_str + str.Remove(0, old_str_index + old_str_cnt);

        return;
    }
}
}
}
