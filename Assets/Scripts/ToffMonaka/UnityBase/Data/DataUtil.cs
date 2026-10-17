/**
 * @file
 * @brief DataUtilファイル
 */

using ToffMonaka.UnityBase.Scene;

namespace ToffMonaka {
namespace UnityBase.Data {
/**
 * @brief DataUtilクラス
 */
public static class DataUtil
{
    public static SystemConfigFile systemConfigFile = new();
    public static UserDataFile userDataFile = new();
    public static MstTextTableFile mstTextTableFile = new();

    public enum MST_TEXT_ID : int
    {
        NONE = 0,
        JOIN_SPACE,
        OK,
		CANCEL,
        FORWARD,
        BACK,
        MENU,
        OPTION,
        INFO,
        FAQ,
        STAFF,
        LICENSE,
        PRIVACY_POLICY,
        BACK_TO_TITLE,
        RESTART,
        EXIT,
        LANGUAGE,
        ENGLISH,
        JAPANESE,
        SYSTEM,
        INPUT,
        GRAPHIC,
        SOUND,
        BGM,
        SE,
        VOLUME,
        MUTE,
        CHEAT,
        COMMAND,
        DELETE_DATA,
        STAGE,
        TEST_2D,
        TEST_3D,
        IN_PREPARATION,
        UI_MARGIN,
        TOP,
        BOTTOM,
        LEFT,
        RIGHT,
        CAMERA,
        SPEED,
        VERTICAL,
        HORIZONTAL,
        INVERT
    }

    /**
     * @brief WriteDataFile関数
     */
    public static void WriteDataFile()
    {
        DataUtil.systemConfigFile.Write(true);
        DataUtil.userDataFile.Write(true);

        return;
    }

    /**
     * @brief DeleteDataFile関数
     */
    public static void DeleteDataFile()
    {
        DataUtil.systemConfigFile.Delete(true);
        DataUtil.userDataFile.Delete(true);

        SceneUtil.GetManager().StartMainScene();

        return;
    }

    /**
     * @brief GetText関数
     * @param mst_txt_id (mst_text_id)
     * @return txt (text)
     */
    public static string GetText(int mst_txt_id)
    {
        if (mst_txt_id >= DataUtil.mstTextTableFile.data.entityArrayByMstTextId.Length) {
            return (System.String.Empty);
        }

        return (DataUtil.mstTextTableFile.data.entityArrayByMstTextId[mst_txt_id].text);
    }

    /**
     * @brief GetText関数
     * @param mst_txt_id (mst_text_id)
     * @return txt (text)
     */
    public static string GetText(DataUtil.MST_TEXT_ID mst_txt_id)
    {
        return (DataUtil.mstTextTableFile.data.entityArrayByMstTextId[(int)mst_txt_id].text);
    }

    /**
     * @brief GetJoinSpaceText関数
     * @return join_space_txt (join_space_text)
     */
    public static string GetJoinSpaceText()
    {
        return (DataUtil.mstTextTableFile.data.entityArrayByMstTextId[(int)DataUtil.MST_TEXT_ID.JOIN_SPACE].text);
    }
}
}
}
