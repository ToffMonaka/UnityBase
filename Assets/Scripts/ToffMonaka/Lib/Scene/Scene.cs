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
    private bool _openedFlag = false;
    private GameObject _subSceneNode = null;

    public Camera mainCamera = null;
    public GameObject mainLayoutNode = null;

    /**
     * @brief OnEnable関数
     */
    public void OnEnable()
    {
        if (this._openedFlag) {
            return;
        }

        this._OnOpen();

        this._openedFlag = true;

        return;
    }

    /**
     * @brief _OnOpen関数
     */
    protected virtual void _OnOpen()
    {
        return;
    }

    /**
     * @brief OnDisable関数
     */
    public void OnDisable()
    {
        if (!this._openedFlag) {
            return;
        }

        this._OnClose();

        this._openedFlag = false;

        return;
    }

    /**
     * @brief _OnClose関数
     */
    protected virtual void _OnClose()
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
     * @brief GetOpenedFlag関数
     * @return opened_flg (opened_flag)
     */
    public bool GetOpenedFlag()
    {
        return (this._openedFlag);
    }

    /**
     * @brief _CreateSubScene関数
     * @param prefab_file_path (prefab_file_path)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int _CreateSubScene(string prefab_file_path)
    {
        this._DeleteSubScene();

        if (prefab_file_path.Length <= 0) {
            return (-1);
        }

        this._subSceneNode = Addressables.InstantiateAsync(prefab_file_path).WaitForCompletion();

        this._subSceneNode.transform.parent = this.mainLayoutNode.transform;

        var canvas_node = this._subSceneNode.transform.Find("Canvas").gameObject;

        canvas_node.GetComponent<Canvas>().worldCamera = this.mainCamera;

        return (0);
    }

    /**
     * @brief _DeleteSubScene関数
     */
    public void _DeleteSubScene()
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
