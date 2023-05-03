﻿/**
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
     * @brief コンストラクタ
     */
    public SceneScript()
    {
        this._SetScriptType((int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SCENE);

        return;
    }

    /**
     * @brief _OnAwake2関数
     */
    protected override void _OnAwake2()
    {
        this.SetActiveFlag(true);

        return;
    }

    /**
     * @brief _OnActive2関数
     */
    protected override void _OnActive2()
    {
        return;
    }

    /**
     * @brief _OnDeactive2関数
     */
    protected override void _OnDeactive2()
    {
        return;
    }

    /**
     * @brief _OnFirstUpdate2関数
     */
    protected override void _OnFirstUpdate2()
    {
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
     * @brief _OnCreate2関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate2()
    {
        return (0);
    }

    /**
     * @brief _OnDelete2関数
     */
    protected override void _OnDelete2()
    {
        if (this._subSceneNode != null) {
            Addressables.ReleaseInstance(this._subSceneNode);

            this._subSceneNode = null;
        }

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

        SceneManager.LoadScene(name);

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

        this._subSceneNode.transform.parent = this.subSceneLayoutNode.transform;

        this._subSceneNode.GetComponent<ToffMonaka.Lib.Scene.SubSceneScript>().Create(this.GetHolder());

        return (0);
    }
}
}
