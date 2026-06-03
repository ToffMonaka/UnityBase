/**
 * @file
 * @brief Globalファイル
 */

using ToffMonaka.Tml.Input;
using ToffMonaka.Tml.Graphic;
using ToffMonaka.Tml.Sound;
using ToffMonaka.Tml.Scene;

namespace ToffMonaka {
namespace Tml {
/**
 * @brief Globalクラス
 */
public static class Global
{
    private static InputManager _inputManager = null;
    private static GraphicManager _graphicManager = null;
    private static SoundManager _soundManager = null;
    private static SceneManager _sceneManager = null;

    /**
     * @brief GetInputManager関数
     * @return input_manager (input_manager)
     */
    public static InputManager GetInputManager()
    {
        return (Global._inputManager);
    }

    /**
     * @brief SetInputManager関数
     * @param input_manager (input_manager)
     */
    public static void SetInputManager(InputManager input_manager)
    {
        Global._inputManager?.Init();

        Global._inputManager = input_manager;

        return;
    }

    /**
     * @brief GetGraphicManager関数
     * @return graphic_manager (graphic_manager)
     */
    public static GraphicManager GetGraphicManager()
    {
        return (Global._graphicManager);
    }

    /**
     * @brief SetGraphicManager関数
     * @param graphic_manager (graphic_manager)
     */
    public static void SetGraphicManager(GraphicManager graphic_manager)
    {
        Global._graphicManager?.Init();

        Global._graphicManager = graphic_manager;

        return;
    }

    /**
     * @brief GetSoundManager関数
     * @return sound_manager (sound_manager)
     */
    public static SoundManager GetSoundManager()
    {
        return (Global._soundManager);
    }

    /**
     * @brief SetSoundManager関数
     * @param sound_manager (sound_manager)
     */
    public static void SetSoundManager(SoundManager sound_manager)
    {
        Global._soundManager?.Init();

        Global._soundManager = sound_manager;

        return;
    }

    /**
     * @brief GetSceneManager関数
     * @return scene_manager (scene_manager)
     */
    public static SceneManager GetSceneManager()
    {
        return (Global._sceneManager);
    }

    /**
     * @brief SetSceneManager関数
     * @param scene_manager (scene_manager)
     */
    public static void SetSceneManager(SceneManager scene_manager)
    {
        Global._sceneManager?.Init();

        Global._sceneManager = scene_manager;

        return;
    }
}
}
}
