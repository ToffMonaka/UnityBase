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
    public static UnityBase.Data.MstTextTableFile mstTextTableFile = new UnityBase.Data.MstTextTableFile();

    /**
     * @brief GetText関数
     * @param mst_txt_id (mst_text_id)
     * @return txt (text)
     */
    public static string GetText(int mst_txt_id)
    {
        var entity = UnityBase.Global.mstTextTableFile.data.GetEntity(mst_txt_id);

        return ((entity != null) ? entity.text : System.String.Empty);
    }

    /**
     * @brief GetText関数
     * @param mst_txt_id (mst_text_id)
     * @return txt (text)
     */
    public static string GetText(UnityBase.Util.MST_TEXT_ID mst_txt_id)
    {
        return (UnityBase.Global.mstTextTableFile.data.GetEntityFast((int)mst_txt_id).text);
    }
}
}
}
