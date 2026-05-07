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
    public static UnityBase.Data.UserDataFile userDataFile = new UnityBase.Data.UserDataFile();
    public static UnityBase.Data.MstTextTableFile mstTextTableFile = new UnityBase.Data.MstTextTableFile();

    // Change Property Name
    // [UnityEngine.Serialization.FormerlySerializedAs("_propertyName")]

    /**
     * @brief GetInputManager関数
     * @return input_manager (input_manager)
     */
    public static Lib.Input.Manager GetInputManager()
    {
        return (Lib.Global.GetInputManager());
    }

    /**
     * @brief SetInputManager関数
     * @param input_manager (input_manager)
     */
    public static void SetInputManager(Lib.Input.Manager input_manager)
    {
        Lib.Global.SetInputManager(input_manager);

        return;
    }

    /**
     * @brief GetGraphicManager関数
     * @return graphic_manager (graphic_manager)
     */
    public static Lib.Graphic.Manager GetGraphicManager()
    {
        return (Lib.Global.GetGraphicManager());
    }

    /**
     * @brief SetGraphicManager関数
     * @param graphic_manager (graphic_manager)
     */
    public static void SetGraphicManager(Lib.Graphic.Manager graphic_manager)
    {
        Lib.Global.SetGraphicManager(graphic_manager);

        return;
    }

    /**
     * @brief GetSoundManager関数
     * @return sound_manager (sound_manager)
     */
    public static Lib.Sound.Manager GetSoundManager()
    {
        return (Lib.Global.GetSoundManager());
    }

    /**
     * @brief SetSoundManager関数
     * @param sound_manager (sound_manager)
     */
    public static void SetSoundManager(Lib.Sound.Manager sound_manager)
    {
        Lib.Global.SetSoundManager(sound_manager);

        return;
    }

    /**
     * @brief GetSceneManager関数
     * @return scene_manager (scene_manager)
     */
    public static Lib.Scene.Manager GetSceneManager()
    {
        return (Lib.Global.GetSceneManager());
    }

    /**
     * @brief SetSceneManager関数
     * @param scene_manager (scene_manager)
     */
    public static void SetSceneManager(Lib.Scene.Manager scene_manager)
    {
        Lib.Global.SetSceneManager(scene_manager);

        return;
    }

    /**
     * @brief GetMainSceneNodeScript関数
     * @return main_scene_node_script (main_scene_node_script)
     */
    public static UnityBase.Scene.MainSceneNodeScript GetMainSceneNodeScript()
    {
        return (UnityBase.Global.GetSceneManager().GetMainSceneNodeScript() as UnityBase.Scene.MainSceneNodeScript);
    }

    /**
     * @brief GetSubSceneNodeScript関数
     * @return sub_scene_node_script (sub_scene_node_script)
     */
    public static UnityBase.Scene.SubSceneNodeScript GetSubSceneNodeScript()
    {
        return (UnityBase.Global.GetSceneManager().GetSubSceneNodeScript() as UnityBase.Scene.SubSceneNodeScript);
    }

    /**
     * @brief SaveDataFile関数
     */
    public static void SaveDataFile()
    {
        UnityBase.Global.systemConfigFile.Write(true);
        UnityBase.Global.userDataFile.Write(true);

        return;
    }

    /**
     * @brief DeleteDataFile関数
     */
    public static void DeleteDataFile()
    {
        UnityBase.Global.systemConfigFile.Delete(true);
        UnityBase.Global.userDataFile.Delete(true);

        UnityBase.Global.GetSceneManager().StartMainScene();

        return;
    }

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
