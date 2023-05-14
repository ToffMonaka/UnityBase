/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;
using UnityEngine.AddressableAssets;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief Utilクラス
 */
public static class Util
{
    private static ToffMonaka.Lib.Scene.Manager _manager = null;

    /**
     * @brief GetPrefabNode関数
     * @param prefab_file_path (prefab_file_path)
     * @param parent_node (parent_node)
     * @return prefab_node (node)<br>
     * null=失敗
     */
    public static GameObject GetPrefabNode(string prefab_file_path, GameObject parent_node)
    {
        if (prefab_file_path.Length <= 0) {
            return (null);
        }

        var node = Addressables.InstantiateAsync(prefab_file_path).WaitForCompletion();

        if (node == null) {
            return (null);
        }

        node.transform.parent = parent_node.transform;

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
    public static ToffMonaka.Lib.Scene.Manager GetManager()
    {
        return (ToffMonaka.Lib.Scene.Util._manager);
    }

    /**
     * @brief SetManager関数
     * @param manager (manager)
     */
    public static void SetManager(ToffMonaka.Lib.Scene.Manager manager)
    {
        if (ToffMonaka.Lib.Scene.Util._manager != null) {
            ToffMonaka.Lib.Scene.Util._manager.Init();
        }

        ToffMonaka.Lib.Scene.Util._manager = manager;

        return;
    }
}
}
