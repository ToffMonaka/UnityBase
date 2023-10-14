/**
 * @file
 * @brief Globalファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase {
/**
 * @brief Globalクラス
 */
public static class Global
{
    public static UnityBase.Data.SystemConfigFile systemConfigFile = new UnityBase.Data.SystemConfigFile();
    public static UnityBase.Data.MstStringTableFile mstStringTableFile = new UnityBase.Data.MstStringTableFile();

    /**
     * @brief GetString関数
     * @param mst_str_id (mst_string_id)
     * @return str (string)
     */
    public static string GetString(int mst_str_id)
    {
        var entity = UnityBase.Global.mstStringTableFile.data.GetEntity(mst_str_id);

        return ((entity != null) ? entity.string_ : System.String.Empty);
    }

    /**
     * @brief GetString関数
     * @param mst_str_id (mst_string_id)
     * @return str (string)
     */
    public static string GetString(UnityBase.Util.MST_STRING_ID mst_str_id)
    {
        return (UnityBase.Global.mstStringTableFile.data.GetEntityFast((int)mst_str_id).string_);
    }
}
}
}
