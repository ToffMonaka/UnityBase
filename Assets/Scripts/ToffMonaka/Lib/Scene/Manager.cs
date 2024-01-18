/**
 * @file
 * @brief Managerファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


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
    private List<Lib.Scene.Script>[] _scriptArray = null;
    private Lib.Scene.MainSceneNodeScript _mainSceneNodeScript = null;
    private Lib.Scene.SubSceneNodeScript _subSceneNodeScript = null;
    private List<Lib.Scene.ObjectNodeScript>[]  _objectNodeScriptArray = null;
    private List<Lib.Scene.ComponentScript>[]  _componentScriptArray = null;

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

        if (this._scriptArray != null) {
            foreach (var script_cont in this._scriptArray) {
                var tmp_script_cont = new List<Lib.Scene.Script>(script_cont);

                foreach (var tmp_script in tmp_script_cont) {
                    tmp_script.DestroyByManager();
                }

                script_cont.Clear();
            }

            this._scriptArray = null;
        }

        this._mainSceneNodeScript = null;
        this._subSceneNodeScript = null;
        this._objectNodeScriptArray = null;
        this._componentScriptArray = null;

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._Release();

        this._mainSceneNode = null;

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

            this._scriptArray = new List<Lib.Scene.Script>[this.createDesc.scriptCount];

            for (int script_i = 0; script_i < this._scriptArray.Length; ++script_i) {
                this._scriptArray[script_i] = new List<Lib.Scene.Script>();
            }

            this._objectNodeScriptArray = new List<Lib.Scene.ObjectNodeScript>[this.createDesc.scriptCount];

            for (int obj_node_script_i = 0; obj_node_script_i < this._objectNodeScriptArray.Length; ++obj_node_script_i) {
                this._objectNodeScriptArray[obj_node_script_i] = new List<Lib.Scene.ObjectNodeScript>();
            }

            this._componentScriptArray = new List<Lib.Scene.ComponentScript>[this.createDesc.scriptCount];

            for (int component_script_i = 0; component_script_i < this._componentScriptArray.Length; ++component_script_i) {
                this._componentScriptArray[component_script_i] = new List<Lib.Scene.ComponentScript>();
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
     * @brief GetScript関数
     * @param script_inex (script_inex)
     * @return script (script)<br>
     * null=失敗
     */
    public Lib.Scene.Script GetScript(int script_inex)
    {
        if ((script_inex < 0)
        || (script_inex >= this._scriptArray.Length)) {
            return (null);
        }

        if (this._scriptArray[script_inex].Count <= 0) {
            return (null);
        }

        return (this._scriptArray[script_inex][0]);
    }

    /**
     * @brief GetScriptContainer関数
     * @param script_inex (script_inex)
     * @return script_cont (script_container)<br>
     * null=失敗
     */
    public List<Lib.Scene.Script> GetScriptContainer(int script_inex)
    {
        if ((script_inex < 0)
        || (script_inex >= this._scriptArray.Length)) {
            return (null);
        }

        return (this._scriptArray[script_inex]);
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
     * @brief GetComponentScriptContainer関数
     * @param script_inex (script_inex)
     * @return component_script_cont (component_script_container)
     */
    public List<Lib.Scene.ComponentScript> GetComponentScriptContainer(int script_inex)
    {
        return (this._componentScriptArray[script_inex]);
    }

    /**
     * @brief AddScript関数
     * @param script (script)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int AddScript(Lib.Scene.Script script)
    {
        if ((script == null)
        || (script.GetManager() != null)
        || (script.GetScriptIndex() >= this._scriptArray.Length)) {
            return (-1);
        }

        if (script.GetScriptIndex() >= 0) {
            this._scriptArray[script.GetScriptIndex()].Add(script);

		    switch (script.GetScriptType()) {
		    case Lib.Util.SCENE.SCRIPT_TYPE.MAIN_SCENE_NODE: {
                this._mainSceneNodeScript = (Lib.Scene.MainSceneNodeScript)script;

			    break;
		    }
		    case Lib.Util.SCENE.SCRIPT_TYPE.SUB_SCENE_NODE: {
                this._subSceneNodeScript = (Lib.Scene.SubSceneNodeScript)script;

			    break;
		    }
		    case Lib.Util.SCENE.SCRIPT_TYPE.OBJECT_NODE: {
                this._objectNodeScriptArray[script.GetScriptIndex()].Add((Lib.Scene.ObjectNodeScript)script);

			    break;
		    }
		    case Lib.Util.SCENE.SCRIPT_TYPE.COMPONENT: {
                this._componentScriptArray[script.GetScriptIndex()].Add((Lib.Scene.ComponentScript)script);

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
    public void RemoveScript(Lib.Scene.Script script)
    {
        if ((script == null)
        || (script.GetManager() == null)
        || (script.GetScriptIndex() >= this._scriptArray.Length)) {
            return;
        }

        if (script.GetScriptIndex() >= 0) {
            this._scriptArray[script.GetScriptIndex()].Remove(script);

		    switch (script.GetScriptType()) {
		    case Lib.Util.SCENE.SCRIPT_TYPE.MAIN_SCENE_NODE: {
                if (this._mainSceneNodeScript == (Lib.Scene.MainSceneNodeScript)script) {
                    this._mainSceneNodeScript = null;
                }

			    break;
		    }
		    case Lib.Util.SCENE.SCRIPT_TYPE.SUB_SCENE_NODE: {
                if (this._subSceneNodeScript == (Lib.Scene.SubSceneNodeScript)script) {
                    this._subSceneNodeScript = null;
                }

			    break;
		    }
		    case Lib.Util.SCENE.SCRIPT_TYPE.OBJECT_NODE: {
                this._objectNodeScriptArray[script.GetScriptIndex()].Remove((Lib.Scene.ObjectNodeScript)script);

			    break;
		    }
		    case Lib.Util.SCENE.SCRIPT_TYPE.COMPONENT: {
                this._componentScriptArray[script.GetScriptIndex()].Remove((Lib.Scene.ComponentScript)script);

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
}
}
}
