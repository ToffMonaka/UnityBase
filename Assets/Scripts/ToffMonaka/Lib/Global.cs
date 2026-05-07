/**
 * @file
 * @brief Globalファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib {
/**
 * @brief Globalクラス
 */
public static class Global
{
    private static Lib.Input.Manager _inputManager = null;
    private static Lib.Graphic.Manager _graphicManager = null;
    private static Lib.Sound.Manager _soundManager = null;
    private static Lib.Scene.Manager _sceneManager = null;

    // Change Property Name
    // [UnityEngine.Serialization.FormerlySerializedAs("_propertyName")]

    /**
     * @brief GetInputManager関数
     * @return input_manager (input_manager)
     */
    public static Lib.Input.Manager GetInputManager()
    {
        return (Lib.Global._inputManager);
    }

    /**
     * @brief SetInputManager関数
     * @param input_manager (input_manager)
     */
    public static void SetInputManager(Lib.Input.Manager input_manager)
    {
        Lib.Global._inputManager?.Init();

        Lib.Global._inputManager = input_manager;

        return;
    }

    /**
     * @brief GetGraphicManager関数
     * @return graphic_manager (graphic_manager)
     */
    public static Lib.Graphic.Manager GetGraphicManager()
    {
        return (Lib.Global._graphicManager);
    }

    /**
     * @brief SetGraphicManager関数
     * @param graphic_manager (graphic_manager)
     */
    public static void SetGraphicManager(Lib.Graphic.Manager graphic_manager)
    {
        Lib.Global._graphicManager?.Init();

        Lib.Global._graphicManager = graphic_manager;

        return;
    }

    /**
     * @brief GetSoundManager関数
     * @return sound_manager (sound_manager)
     */
    public static Lib.Sound.Manager GetSoundManager()
    {
        return (Lib.Global._soundManager);
    }

    /**
     * @brief SetSoundManager関数
     * @param sound_manager (sound_manager)
     */
    public static void SetSoundManager(Lib.Sound.Manager sound_manager)
    {
        Lib.Global._soundManager?.Init();

        Lib.Global._soundManager = sound_manager;

        return;
    }

    /**
     * @brief GetSceneManager関数
     * @return scene_manager (scene_manager)
     */
    public static Lib.Scene.Manager GetSceneManager()
    {
        return (Lib.Global._sceneManager);
    }

    /**
     * @brief SetSceneManager関数
     * @param scene_manager (scene_manager)
     */
    public static void SetSceneManager(Lib.Scene.Manager scene_manager)
    {
        Lib.Global._sceneManager?.Init();

        Lib.Global._sceneManager = scene_manager;

        return;
    }
}
}
}
