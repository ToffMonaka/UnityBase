/**
 * @file
 * @brief Managerファイル
 */


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ToffMonaka {
namespace Lib.Scene {
/**
 * @brief ManagerCreateDescクラス
 */
public class ManagerCreateDesc
{
    public GameObject mainSceneNode = null;
    public int scriptCount = 0;
}

/**
 * @brief Managerクラス
 */
public class Manager
{
    public Lib.Scene.ManagerCreateDesc createDesc{get; private set;} = null;

    private GameObject _mainSceneNode = null;
    private GameObject _subSceneNode = null;
    private List<Lib.Scene.NodeScript>[] _nodeScriptArray = null;
    private Lib.Scene.MainSceneNodeScript _mainSceneNodeScript = null;
    private Lib.Scene.SubSceneNodeScript _subSceneNodeScript = null;
    private List<Lib.Scene.ObjectNodeScript>[]  _objectNodeScriptArray = null;
    private bool _applicationStartedFlag = false;
    private bool _applicationEndedFlag = false;

    /**
     * @brief コンストラクタ
     */
    public Manager()
    {
        return;
    }

    /**
     * @brief _Release関数
     */
    private void _Release()
    {
        Lib.Scene.Util.ReleasePrefabNode(ref this._subSceneNode);

        if (this._nodeScriptArray != null) {
            foreach (var node_script_cont in this._nodeScriptArray) {
                var tmp_node_script_cont = new List<Lib.Scene.NodeScript>(node_script_cont);

                foreach (var tmp_node_script in tmp_node_script_cont) {
                    tmp_node_script.DestroyByManager();
                }

                node_script_cont.Clear();
            }

            this._nodeScriptArray = null;
        }

        this._mainSceneNodeScript = null;
        this._subSceneNodeScript = null;
        this._objectNodeScriptArray = null;

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._Release();

        this._mainSceneNode = null;
        this._subSceneNode = null;
        this._applicationStartedFlag = false;
        this._applicationEndedFlag = false;

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public virtual int Create(Lib.Scene.ManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            this._mainSceneNode = desc.mainSceneNode;

            this._nodeScriptArray = new List<Lib.Scene.NodeScript>[this.createDesc.scriptCount];

            for (int node_script_i = 0; node_script_i < this._nodeScriptArray.Length; ++node_script_i) {
                this._nodeScriptArray[node_script_i] = new List<Lib.Scene.NodeScript>();
            }

            this._objectNodeScriptArray = new List<Lib.Scene.ObjectNodeScript>[this.createDesc.scriptCount];

            for (int obj_node_script_i = 0; obj_node_script_i < this._objectNodeScriptArray.Length; ++obj_node_script_i) {
                this._objectNodeScriptArray[obj_node_script_i] = new List<Lib.Scene.ObjectNodeScript>();
            }
        }

        int create_result_val = this._OnCreate();

        if (create_result_val < 0) {
            this.Init();

            return (create_result_val);
        }

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected virtual int _OnCreate()
    {
        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public virtual void SetCreateDesc(Lib.Scene.ManagerCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
    }

    /**
     * @brief GetMainSceneNode関数
     * @return main_scene_node (main_scene_node)
     */
    public GameObject GetMainSceneNode()
    {
        return (this._mainSceneNode);
    }

    /**
     * @brief GetSubSceneNode関数
     * @return sub_scene_node (sub_scene_node)
     */
    public GameObject GetSubSceneNode()
    {
        return (this._subSceneNode);
    }

    /**
     * @brief GetNodeScript関数
     * @param node_script_inex (node_script_inex)
     * @return node_script (node_script)<br>
     * null=失敗
     */
    public Lib.Scene.NodeScript GetNodeScript(int node_script_inex)
    {
        if ((node_script_inex < 0)
        || (node_script_inex >= this._nodeScriptArray.Length)) {
            return (null);
        }

        if (this._nodeScriptArray[node_script_inex].Count <= 0) {
            return (null);
        }

        return (this._nodeScriptArray[node_script_inex][0]);
    }

    /**
     * @brief GetNodeScriptContainer関数
     * @param node_script_inex (node_script_inex)
     * @return node_script_cont (node_script_container)<br>
     * null=失敗
     */
    public List<Lib.Scene.NodeScript> GetNodeScriptContainer(int node_script_inex)
    {
        if ((node_script_inex < 0)
        || (node_script_inex >= this._nodeScriptArray.Length)) {
            return (null);
        }

        return (this._nodeScriptArray[node_script_inex]);
    }

    /**
     * @brief GetMainSceneNodeScript関数
     * @return main_scene_node_script (main_scene_node_script)
     */
    public Lib.Scene.MainSceneNodeScript GetMainSceneNodeScript()
    {
        return (this._mainSceneNodeScript);
    }

    /**
     * @brief GetSubSceneNodeScript関数
     * @return sub_scene_node_script (sub_scene_node_script)
     */
    public Lib.Scene.SubSceneNodeScript GetSubSceneNodeScript()
    {
        return (this._subSceneNodeScript);
    }

    /**
     * @brief GetObjectNodeScriptContainer関数
     * @param script_inex (script_inex)
     * @return obj_node_script_cont (object_node_script_container)
     */
    public List<Lib.Scene.ObjectNodeScript> GetObjectNodeScriptContainer(int script_inex)
    {
        return (this._objectNodeScriptArray[script_inex]);
    }

    /**
     * @brief AddScript関数
     * @param script (script)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddScript(Lib.Scene.NodeScript script)
    {
        if ((script == null)
        || (script.GetManager() != null)
        || (script.GetNodeScriptIndex() >= this._nodeScriptArray.Length)) {
            return (-1);
        }

        if (script.GetNodeScriptIndex() >= 0) {
            this._nodeScriptArray[script.GetNodeScriptIndex()].Add(script);

		    switch (script.GetNodeScriptType()) {
		    case Lib.Util.SCENE.NODE_SCRIPT_TYPE.MAIN_SCENE: {
                this._mainSceneNodeScript = (Lib.Scene.MainSceneNodeScript)script;

			    break;
		    }
		    case Lib.Util.SCENE.NODE_SCRIPT_TYPE.SUB_SCENE: {
                this._subSceneNodeScript = (Lib.Scene.SubSceneNodeScript)script;

			    break;
		    }
		    case Lib.Util.SCENE.NODE_SCRIPT_TYPE.OBJECT: {
                this._objectNodeScriptArray[script.GetNodeScriptIndex()].Add((Lib.Scene.ObjectNodeScript)script);

			    break;
		    }
		    }
        }

        script.SetManager(this);

        return (0);
    }

    /**
     * @brief RemoveScript関数
     * @param script (script)
     */
    public void RemoveScript(Lib.Scene.NodeScript script)
    {
        if ((script == null)
        || (script.GetManager() == null)
        || (script.GetNodeScriptIndex() >= this._nodeScriptArray.Length)) {
            return;
        }

        if (script.GetNodeScriptIndex() >= 0) {
            this._nodeScriptArray[script.GetNodeScriptIndex()].Remove(script);

		    switch (script.GetNodeScriptType()) {
		    case Lib.Util.SCENE.NODE_SCRIPT_TYPE.MAIN_SCENE: {
                if (this._mainSceneNodeScript == (Lib.Scene.MainSceneNodeScript)script) {
                    this._mainSceneNodeScript = null;
                }

			    break;
		    }
		    case Lib.Util.SCENE.NODE_SCRIPT_TYPE.SUB_SCENE: {
                if (this._subSceneNodeScript == (Lib.Scene.SubSceneNodeScript)script) {
                    this._subSceneNodeScript = null;
                }

			    break;
		    }
		    case Lib.Util.SCENE.NODE_SCRIPT_TYPE.OBJECT: {
                this._objectNodeScriptArray[script.GetNodeScriptIndex()].Remove((Lib.Scene.ObjectNodeScript)script);

			    break;
		    }
		    }
        }

        script.SetManager(null);

        return;
    }

    /**
     * @brief ChangeMainScene関数
     * @param name (name)
     * @return main_scene_node_script (main_scene_node_script)<br>
     * null=失敗
     */
    public Lib.Scene.MainSceneNodeScript ChangeMainScene(string name)
    {
        if ((this._mainSceneNode == null)
        || (name.Length <= 0)) {
            return (null);
        }

        SceneManager.LoadScene(name);

        return (this._mainSceneNode.GetComponent<Lib.Scene.MainSceneNodeScript>());
    }

    /**
     * @brief ChangeSubScene関数
     * @param prefab_file_path (prefab_file_path)
     * @return sub_scene_node_script (sub_scene_node_script)<br>
     * null=失敗
     */
    public Lib.Scene.SubSceneNodeScript ChangeSubScene(string prefab_file_path)
    {
        Lib.Scene.Util.ReleasePrefabNode(ref this._subSceneNode);

        if ((this._mainSceneNode == null)
        || (prefab_file_path.Length <= 0)) {
            return (null);
        }

        this._subSceneNode = Lib.Scene.Util.GetPrefabNode(prefab_file_path, this._mainSceneNode);

        return (this._subSceneNode.GetComponent<Lib.Scene.SubSceneNodeScript>());
    }

    /**
     * @brief StartApplication関数
     * @param scene_name (scene_name)
     */
    public void StartApplication(string scene_name = null)
    {
        if ((this._applicationStartedFlag)
        || (this._applicationEndedFlag)) {
            return;
        }

        this._applicationStartedFlag = true;

        this.ChangeMainScene(scene_name ?? SceneManager.GetActiveScene().name);

        return;
    }

    /**
     * @brief EndApplication関数
     */
    public void EndApplication()
    {
        if ((this._applicationStartedFlag)
        || (this._applicationEndedFlag)) {
            return;
        }

        this._applicationEndedFlag = true;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

        return;
    }
}
}
}
