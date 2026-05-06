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
    private static Lib.Scene.Manager _manager = null;

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

        if (parent_node != null) {
            node.transform.SetParent(parent_node.transform, pos_keep_flg);
        }

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
}
}
}
