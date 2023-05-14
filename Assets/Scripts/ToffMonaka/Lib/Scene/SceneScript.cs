/**
 * @file
 * @brief SceneScriptファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief SceneScriptCreateDescクラス
 */
public class SceneScriptCreateDesc : ToffMonaka.Lib.Scene.ScriptCreateDesc
{
}

/**
 * @brief SceneScriptクラス
 */
public abstract class SceneScript : ToffMonaka.Lib.Scene.Script
{
    [SerializeField] private Camera _mainCamera = null;

    public new ToffMonaka.Lib.Scene.SceneScriptCreateDesc createDesc{get; private set;} = null;
    private GameObject _subSceneNode = null;

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
        return;
    }

    /**
     * @brief _OnRelease2関数
     */
    protected override void _OnRelease2()
    {
        ToffMonaka.Lib.Scene.Util.ReleasePrefabNode(ref this._subSceneNode);

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
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Lib.Scene.ScriptCreateDesc create_desc)
    {
	    this.createDesc = create_desc as ToffMonaka.Lib.Scene.SceneScriptCreateDesc;

        base.SetCreateDesc(this.createDesc);

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
     * @brief _OnFixedUpdate2関数
     */
    protected override void _OnFixedUpdate2()
    {
        return;
    }

    /**
     * @brief _OnLateUpdate2関数
     */
    protected override void _OnLateUpdate2()
    {
        return;
    }

    /**
     * @brief ChangeScene関数
     * @param name (name)
     * @return scene_script (scene_script)<br>
     * null=失敗
     */
    public ToffMonaka.Lib.Scene.SceneScript ChangeScene(string name)
    {
        if (name.Length <= 0) {
            return (null);
        }

        SceneManager.LoadScene(name);

        return (this);
    }

    /**
     * @brief ChangeSubScene関数
     * @param prefab_file_path (prefab_file_path)
     * @return sub_scene_script (sub_scene_script)<br>
     * null=失敗
     */
    public ToffMonaka.Lib.Scene.SubSceneScript ChangeSubScene(string prefab_file_path)
    {
        ToffMonaka.Lib.Scene.Util.ReleasePrefabNode(ref this._subSceneNode);

        if (prefab_file_path.Length <= 0) {
            return (null);
        }

        this._subSceneNode = ToffMonaka.Lib.Scene.Util.GetPrefabNode(prefab_file_path, this.gameObject);

        return (this._subSceneNode.GetComponent<ToffMonaka.Lib.Scene.SubSceneScript>());
    }

    /**
     * @brief GetMainCamera関数
     * @return main_camera (main_camera)
     */
    public Camera GetMainCamera()
    {
        return (this._mainCamera);
    }

    /**
     * @brief GetSubSceneNode関数
     * @return sub_scene_node (sub_scene_node)
     */
    public GameObject GetSubSceneNode()
    {
        return (this._subSceneNode);
    }
}
}
