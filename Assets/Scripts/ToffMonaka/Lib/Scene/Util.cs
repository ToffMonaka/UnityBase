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
     * @brief GetNode関数
     * @param prefab_file_path (prefab_file_path)
     * @param parent_node (parent_node)
     * @return node (node)<br>
     * null=失敗
     */
    public static GameObject GetNode(string prefab_file_path, GameObject parent_node)
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
     * @brief GetScript関数
     * @param prefab_file_path (prefab_file_path)
     * @param parent_node (parent_node)
     * @return script (script)<br>
     * null=失敗
     */
    public static T GetScript<T>(string prefab_file_path, GameObject parent_node)
    {
        if (prefab_file_path.Length <= 0) {
            return (default(T));
        }

        var node = Addressables.InstantiateAsync(prefab_file_path).WaitForCompletion();

        if (node == null) {
            return (default(T));
        }

        node.transform.parent = parent_node.transform;

        return (node.GetComponent<T>());
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
        ToffMonaka.Lib.Scene.Util._manager = manager;

        return;
    }
}
}
