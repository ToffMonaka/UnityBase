/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;
using UnityEngine.AddressableAssets;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief Utilクラス
 */
public static class Util
{
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
