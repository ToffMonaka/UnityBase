/**
 * @file
 * @brief Globalファイル
 */


namespace ToffMonaka.UnityBase {
/**
 * @brief Globalクラス
 */
public static class Global
{
    public static ToffMonaka.UnityBase.Data.SystemConfigFile systemConfigFile = new ToffMonaka.UnityBase.Data.SystemConfigFile();
    public static ToffMonaka.UnityBase.Data.MstStringTableFile mstStringTableFile = new ToffMonaka.UnityBase.Data.MstStringTableFile();

    /**
     * @brief GetString関数
     * @param mst_str_id (mst_string_id)
     * @return str (string)
     */
    public static string GetString(int mst_str_id)
    {
        var entity = ToffMonaka.UnityBase.Global.mstStringTableFile.data.GetEntity(mst_str_id);

        return ((entity != null) ? entity.string_ : System.String.Empty);
    }

    /**
     * @brief GetString関数
     * @param mst_str_id (mst_string_id)
     * @return str (string)
     */
    public static string GetString(ToffMonaka.UnityBase.Constant.Util.MST_STRING_ID mst_str_id)
    {
        return (ToffMonaka.UnityBase.Global.mstStringTableFile.data.GetEntityFast((int)mst_str_id).string_);
    }
}
}
