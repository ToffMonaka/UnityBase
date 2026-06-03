/**
 * @file
 * @brief StringUtilファイル
 */

namespace ToffMonaka {
namespace Tml {
/**
 * @brief StringUtilクラス
 */
public static class StringUtil
{
    public enum NEWLINE_TYPE : int
    {
        NONE = 0,
		CRLF,
		LF,
		COUNT
    }
    public static readonly int NEWLINE_TYPE_COUNT = (int)StringUtil.NEWLINE_TYPE.COUNT;

    public static readonly string[] NEWLINE_NAME_ARRAY = {
        "",
        "CRLF",
        "LF"
    };

    public static readonly string[] NEWLINE_CODE_ARRAY = {
        "",
        "\r\n",
        "\n"
    };

    /**
     * @brief GetNewlineCode関数
     * @param newline_type (newline_type)
     * @return newline_code (newline_code)<br>
     * null=失敗
     */
    public static string GetNewlineCode(StringUtil.NEWLINE_TYPE newline_type)
    {
        return (StringUtil.NEWLINE_CODE_ARRAY[(int)newline_type]);
    }

    /**
     * @brief GetNewlineCode関数
     * @param newline_name (newline_name)
     * @return newline_code (newline_code)<br>
     * null=失敗
     */
    public static string GetNewlineCode(string newline_name)
    {
        if (newline_name == StringUtil.NEWLINE_NAME_ARRAY[(int)StringUtil.NEWLINE_TYPE.CRLF]) {
            return (StringUtil.NEWLINE_CODE_ARRAY[(int)StringUtil.NEWLINE_TYPE.CRLF]);
        } else if (newline_name == StringUtil.NEWLINE_NAME_ARRAY[(int)StringUtil.NEWLINE_TYPE.LF]) {
            return (StringUtil.NEWLINE_CODE_ARRAY[(int)StringUtil.NEWLINE_TYPE.LF]);
        }

        return (null);
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
