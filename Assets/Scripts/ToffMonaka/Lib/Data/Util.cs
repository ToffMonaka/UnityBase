/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Data {
/**
 * @brief Utilクラス
 */
public static class Util
{
    /**
     * @brief IsExistFile関数
     * @param file_path (file_path)
     * @return result_flg (result_flag)<br>
     * false=存在無し,true=存在有り
     */
    public static bool IsExistFile(string file_path)
    {
        if (file_path.Length <= 0) {
            return (false);
        }

        return (System.IO.File.Exists(file_path));
    }

    /**
     * @brief IsExistDirectory関数
     * @param dir_path (directory_path)
     * @return result_flg (result_flag)<br>
     * false=存在無し,true=存在有り
     */
    public static bool IsExistDirectory(string dir_path)
    {
        if (dir_path.Length <= 0) {
            return (false);
        }

        return (System.IO.Directory.Exists(dir_path));
    }
}
}
}
