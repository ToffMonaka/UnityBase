/**
 * @file
 * @brief SceneNodeScriptファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief SceneNodeScriptクラス
 */
public abstract class SceneNodeScript : ToffMonaka.Lib.Scene.NodeScript
{
    private GameObject _subSceneNode = null;

    public Camera mainCamera = null;
    public GameObject subSceneLayoutNode = null;

    /**
     * @brief _OnActivate2関数
     */
    protected override void _OnActivate2()
    {
        return;
    }

    /**
     * @brief _OnDeactivate2関数
     */
    protected override void _OnDeactivate2()
    {
        this._DeleteSubScene();

        return;
    }

    /**
     * @brief _OnUpdate2関数
     */
    protected override void _OnUpdate2()
    {
        return;
    }

    /**
     * @brief ChangeScene関数
     * @param name (name)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int ChangeScene(string name)
    {
        if (name.Length <= 0) {
            return (-1);
        }

        SceneManager.LoadScene("PlayScene");

        return (0);
    }

    /**
     * @brief ChangeSubScene関数
     * @param prefab_file_path (prefab_file_path)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int ChangeSubScene(string prefab_file_path)
    {
        this._DeleteSubScene();

        if (prefab_file_path.Length <= 0) {
            return (-1);
        }

        this._subSceneNode = Addressables.InstantiateAsync(prefab_file_path).WaitForCompletion();

        this._subSceneNode.transform.parent = this.subSceneLayoutNode.transform;

        var canvas_node = this._subSceneNode.transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.mainCamera;

        return (0);
    }

    /**
     * @brief _DeleteSubScene関数
     */
    private void _DeleteSubScene()
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
