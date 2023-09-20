/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief Utilクラス
 */
public static class Util
{
    private static Lib.Scene.Manager _manager = null;
    private static Lib.Scene.InputManager _inputManager = null;
    private static Lib.Scene.GraphicManager _graphicManager = null;
    private static Lib.Scene.SoundManager _soundManager = null;

    /**
     * @brief GetPrefabNode関数
     * @param prefab_file_path (prefab_file_path)
     * @return prefab_node (node)<br>
     * null=失敗
     */
    public static GameObject GetPrefabNode(string prefab_file_path)
    {
        return (Lib.Scene.Util.GetPrefabNode(prefab_file_path, null, false));
    }

    /**
     * @brief GetPrefabNode関数
     * @param prefab_file_path (prefab_file_path)
     * @param parent_node (parent_node)
     * @return prefab_node (node)<br>
     * null=失敗
     */
    public static GameObject GetPrefabNode(string prefab_file_path, GameObject parent_node)
    {
        return (Lib.Scene.Util.GetPrefabNode(prefab_file_path, parent_node, false));
    }

    /**
     * @brief GetPrefabNode関数
     * @param prefab_file_path (prefab_file_path)
     * @param parent_node (parent_node)
     * @param pos_keep_flg (position_keep_flag)
     * @return prefab_node (node)<br>
     * null=失敗
     */
    public static GameObject GetPrefabNode(string prefab_file_path, GameObject parent_node, bool pos_keep_flg)
    {
        if (prefab_file_path.Length <= 0) {
            return (null);
        }

        var node = Addressables.InstantiateAsync(prefab_file_path).WaitForCompletion();

        if (node == null) {
            return (null);
        }

        node.transform.SetParent(parent_node.transform, pos_keep_flg);

        return (node);
    }

    /**
     * @brief ReleasePrefabNode関数
     * @param prefab_node (prefab_node)
     */
    public static void ReleasePrefabNode(ref GameObject prefab_node)
    {
        if (prefab_node == null) {
            return;
        }

        Addressables.ReleaseInstance(prefab_node);

        prefab_node = null;

        return;
    }

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static Lib.Scene.Manager GetManager()
    {
        return (Lib.Scene.Util._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(Lib.Scene.Manager manager)
    {
        if (Lib.Scene.Util._manager != null) {
            Lib.Scene.Util._manager.Init();
        }

        Lib.Scene.Util._manager = manager;

        return;
    }

    /**
     * @brief GetInputManager関数
     * @return input_manager (input_manager)
     */
    public static Lib.Scene.InputManager GetInputManager()
    {
        return (Lib.Scene.Util._inputManager);
    }

    /**
     * @brief SetInputManager関数
     * @param input_manager (input_manager)
     */
    public static void SetInputManager(Lib.Scene.InputManager input_manager)
    {
        if (Lib.Scene.Util._inputManager != null) {
            Lib.Scene.Util._inputManager.Init();
        }

        Lib.Scene.Util._inputManager = input_manager;

        return;
    }

    /**
     * @brief GetGraphicManager関数
     * @return graphic_manager (graphic_manager)
     */
    public static Lib.Scene.GraphicManager GetGraphicManager()
    {
        return (Lib.Scene.Util._graphicManager);
    }

    /**
     * @brief SetGraphicManager関数
     * @param graphic_manager (graphic_manager)
     */
    public static void SetGraphicManager(Lib.Scene.GraphicManager graphic_manager)
    {
        if (Lib.Scene.Util._graphicManager != null) {
            Lib.Scene.Util._graphicManager.Init();
        }

        Lib.Scene.Util._graphicManager = graphic_manager;

        return;
    }

    /**
     * @brief GetSoundManager関数
     * @return sound_manager (sound_manager)
     */
    public static Lib.Scene.SoundManager GetSoundManager()
    {
        return (Lib.Scene.Util._soundManager);
    }

    /**
     * @brief SetSoundManager関数
     * @param sound_manager (sound_manager)
     */
    public static void SetSoundManager(Lib.Scene.SoundManager sound_manager)
    {
        if (Lib.Scene.Util._soundManager != null) {
            Lib.Scene.Util._soundManager.Init();
        }

        Lib.Scene.Util._soundManager = sound_manager;

        return;
    }

    /**
     * @brief IsFocusNode関数
     * @param node (node)
     * @return focus_flg (focus_flg)
     */
    public static bool IsFocusNode(GameObject node)
    {
        if (EventSystem.current == null) {
            return (false);
        }

        return (EventSystem.current.currentSelectedGameObject == node);
    }
}
}
}
