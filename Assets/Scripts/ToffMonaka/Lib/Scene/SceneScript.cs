/**
 * @file
 * @brief SceneScriptファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief SceneScriptクラス
 */
public abstract class SceneScript : ToffMonaka.Lib.Scene.Script
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
        if (this._subSceneNode != null) {
            Addressables.ReleaseInstance(this._subSceneNode);

            this._subSceneNode = null;
        }

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
     * @brief Create関数
     * @param holder (holder)
     * @param sub_scene_prefab_file_path (sub_scene_prefab_file_path)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Create(ToffMonaka.Lib.Scene.ScriptHolder holder, string sub_scene_prefab_file_path)
    {
        if (holder == null) {
            return (-1);
        }

        this.SetHolder(holder);

        this.ChangeSubScene(sub_scene_prefab_file_path);

        return (0);
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
        if (this._subSceneNode != null) {
            Addressables.ReleaseInstance(this._subSceneNode);

            this._subSceneNode = null;
        }

        if (prefab_file_path.Length <= 0) {
            return (-1);
        }

        this._subSceneNode = Addressables.InstantiateAsync(prefab_file_path).WaitForCompletion();

        this._subSceneNode.GetComponent<ToffMonaka.Lib.Scene.SubSceneScript>().Create(this);

        return (0);
    }
}
}
