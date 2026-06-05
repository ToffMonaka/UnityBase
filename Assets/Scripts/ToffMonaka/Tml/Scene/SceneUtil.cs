/**
 * @file
 * @brief SceneUtilファイル
 */

using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ToffMonaka {
namespace Tml.Scene {
/**
 * @brief SceneUtilクラス
 */
public static class SceneUtil
{
    private static SceneManager _manager = null;

    public enum SCRIPT_TYPE : int
    {
        NONE = 0,
        MAIN_SCENE_NODE,
        SUB_SCENE_NODE,
        OBJECT_NODE,
        PARTS,
		COUNT
    }
    public static readonly int SCRIPT_TYPE_COUNT = (int)SceneUtil.SCRIPT_TYPE.COUNT;

    public enum SCRIPT_INDEX : int
    {
        NONE = -1,
        NODE,
        MAIN_SCENE_NODE,
        SUB_SCENE_NODE,
        OBJECT_NODE,
        SOUND_BGM_NODE,
        SOUND_SE_NODE,
        PARTS,
        BUTTON_PARTS,
        SCROLL_VIEW_PARTS,
        SLIDER_PARTS,
		COUNT
    }
    public static readonly int SCRIPT_INDEX_COUNT = (int)SceneUtil.SCRIPT_INDEX.COUNT;

    /**
     * @brief GetManager関数
     * @return manager (manager)
     */
    public static SceneManager GetManager()
    {
        return (SceneUtil._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(SceneManager manager)
    {
        SceneUtil._manager?.Init();

        SceneUtil._manager = manager;

        return;
    }

    /**
     * @brief GetPrefabNode関数
     * @param prefab_file_path (prefab_file_path)
     * @return prefab_node (node)<br>
     * null=失敗
     */
    public static GameObject GetPrefabNode(string prefab_file_path)
    {
        return (SceneUtil.GetPrefabNode(prefab_file_path, null, false));
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
        return (SceneUtil.GetPrefabNode(prefab_file_path, parent_node, false));
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

        var prefab_node = Addressables.InstantiateAsync(prefab_file_path).WaitForCompletion();

        if (prefab_node == null) {
            return (null);
        }

        if (parent_node != null) {
            prefab_node.transform.SetParent(parent_node.transform, pos_keep_flg);
        }

        return (prefab_node);
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
}
}
}
