/**
 * @file
 * @brief Sceneファイル
 */


using UnityEngine;
using UnityEngine.AddressableAssets;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief Sceneクラス
 */
public abstract class Scene : MonoBehaviour
{
    private GameObject _subSceneNode = null;

    public Camera mainCamera = null;
    public GameObject mainLayoutNode = null;

    /**
     * @brief Start関数
     */
    public void Start()
    {
        this._OnStart();

        return;
    }

    /**
     * @brief _OnStart関数
     */
    protected virtual void _OnStart()
    {
        return;
    }

    /**
     * @brief Update関数
     */
    public void Update()
    {
        this._OnUpdate();

        return;
    }

    /**
     * @brief _OnUpdate関数
     */
    protected virtual void _OnUpdate()
    {
        return;
    }

    /**
     * @brief _LoadSubScene関数
     * @param prefab_file_path (prefab_file_path)
     */
    protected async void _LoadSubScene(string prefab_file_path)
    {
        this._ReleaseSubScene();

        if (prefab_file_path.Length <= 0) {
            return;
        }

        this._subSceneNode = await Addressables.InstantiateAsync(prefab_file_path).Task;

        this._subSceneNode.transform.parent = this.mainLayoutNode.transform;

        var canvas_node = this._subSceneNode.transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.mainCamera;

        return;
    }

    /**
     * @brief _ReleaseSubScene関数
     */
    protected void _ReleaseSubScene()
    {
        if (this._subSceneNode == null) {
            return;
        }

        Addressables.ReleaseInstance(this._subSceneNode);

        this._subSceneNode = null;

        return;
    }
}
}
