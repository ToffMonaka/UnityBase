/**
 * @file
 * @brief ArrayUtilファイル
 */

namespace ToffMonaka {
namespace Tml {
/**
 * @brief ArrayUtilクラス
 */
public static class ArrayUtil
{
    /**
     * @brief Resize関数
     * @param ary (array)
     * @param cnt (count)
     */
    public static void Resize<T>(ref T[] ary, int cnt)
    {
        System.Array.Resize(ref ary, cnt);

        return;
    }

    /**
     * @brief Resize関数
     * @param ary (array)
     * @param cnt (count)
     * @param val (value)
     */
    public static void Resize<T>(ref T[] ary, int cnt, T val)
    {
        int old_cnt = (ary != null) ? ary.Length : 0;

        System.Array.Resize(ref ary, cnt);

	    for (int i = old_cnt; i < ary.Length; ++i) {
            ary[i] = val;
	    }

        return;
    }
}
}
}
