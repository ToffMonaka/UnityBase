/**
 * @file
 * @brief Globalファイル
 */

namespace ToffMonaka {
namespace UnityBase {
/**
 * @brief Globalクラス
 */
public static class Global
{
    /**
     * @brief GetInputManager関数
     * @return input_manager (input_manager)
     */
    public static ToffMonaka.Tml.Input.InputManager GetInputManager()
    {
        return (ToffMonaka.Tml.Global.GetInputManager());
    }

    /**
     * @brief SetInputManager関数
     * @param input_manager (input_manager)
     */
    public static void SetInputManager(ToffMonaka.Tml.Input.InputManager input_manager)
    {
        ToffMonaka.Tml.Global.SetInputManager(input_manager);

        return;
    }

    /**
     * @brief GetGraphicManager関数
     * @return graphic_manager (graphic_manager)
     */
    public static ToffMonaka.Tml.Graphic.GraphicManager GetGraphicManager()
    {
        return (ToffMonaka.Tml.Global.GetGraphicManager());
    }

    /**
     * @brief SetGraphicManager関数
     * @param graphic_manager (graphic_manager)
     */
    public static void SetGraphicManager(ToffMonaka.Tml.Graphic.GraphicManager graphic_manager)
    {
        ToffMonaka.Tml.Global.SetGraphicManager(graphic_manager);

        return;
    }

    /**
     * @brief GetSoundManager関数
     * @return sound_manager (sound_manager)
     */
    public static ToffMonaka.Tml.Sound.SoundManager GetSoundManager()
    {
        return (ToffMonaka.Tml.Global.GetSoundManager());
    }

    /**
     * @brief SetSoundManager関数
     * @param sound_manager (sound_manager)
     */
    public static void SetSoundManager(ToffMonaka.Tml.Sound.SoundManager sound_manager)
    {
        ToffMonaka.Tml.Global.SetSoundManager(sound_manager);

        return;
    }

    /**
     * @brief GetSceneManager関数
     * @return scene_manager (scene_manager)
     */
    public static ToffMonaka.Tml.Scene.SceneManager GetSceneManager()
    {
        return (ToffMonaka.Tml.Global.GetSceneManager());
    }

    /**
     * @brief SetSceneManager関数
     * @param scene_manager (scene_manager)
     */
    public static void SetSceneManager(ToffMonaka.Tml.Scene.SceneManager scene_manager)
    {
        ToffMonaka.Tml.Global.SetSceneManager(scene_manager);

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
}
}
}
