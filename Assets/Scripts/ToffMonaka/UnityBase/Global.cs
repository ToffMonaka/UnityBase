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
    public static UnityBase.Data.UserFile userFile = new UnityBase.Data.UserFile();
    public static UnityBase.Data.MstTextTableFile mstTextTableFile = new UnityBase.Data.MstTextTableFile();

    // Change Property Name
    // [UnityEngine.Serialization.FormerlySerializedAs("_propertyName")]

    /**
     * @brief GetText関数
     * @param mst_txt_id (mst_text_id)
     * @return txt (text)
     */
    public static string GetText(int mst_txt_id)
    {
        if (mst_txt_id >= UnityBase.Global.mstTextTableFile.data.entityArrayByMstTextId.Length) {
            return (System.String.Empty);
        }

        return (UnityBase.Global.mstTextTableFile.data.entityArrayByMstTextId[mst_txt_id].text);
    }

    /**
     * @brief GetText関数
     * @param mst_txt_id (mst_text_id)
     * @return txt (text)
     */
    public static string GetText(UnityBase.Util.MST_TEXT_ID mst_txt_id)
    {
        return (UnityBase.Global.mstTextTableFile.data.entityArrayByMstTextId[(int)mst_txt_id].text);
    }
}
}
}
