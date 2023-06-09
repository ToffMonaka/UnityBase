﻿/**
 * @file
 * @brief Managerファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


namespace ToffMonaka.Lib.Scene {
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
    public ToffMonaka.Lib.Scene.ManagerCreateDesc createDesc{get; private set;} = null;

    private GameObject _mainSceneNode = null;
    private GameObject _subSceneNode = null;
    private List<ToffMonaka.Lib.Scene.Script>[] _scriptArray = null;
    private ToffMonaka.Lib.Scene.MainSceneScript _mainSceneScript = null;
    private ToffMonaka.Lib.Scene.SubSceneScript _subSceneScript = null;
    private List<ToffMonaka.Lib.Scene.ObjectScript>[]  _objectScriptArray = null;

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
        ToffMonaka.Lib.Scene.Util.ReleasePrefabNode(ref this._subSceneNode);

        if (this._scriptArray != null) {
            foreach (var script_cont in this._scriptArray) {
                var tmp_script_cont = new List<ToffMonaka.Lib.Scene.Script>(script_cont);

                foreach (var tmp_script in tmp_script_cont) {
                    tmp_script.DestroyByManager();
                }

                script_cont.Clear();
            }

            this._scriptArray = null;
        }

        this._mainSceneScript = null;
        this._subSceneScript = null;
        this._objectScriptArray = null;

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
     * @return result (result)<br>
     * 0未満=失敗
     */
    public virtual int Create(ToffMonaka.Lib.Scene.ManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }

            this._mainSceneNode = desc.mainSceneNode;

            this._scriptArray = new List<ToffMonaka.Lib.Scene.Script>[this.createDesc.scriptCount];

            for (int script_i = 0; script_i < this._scriptArray.Length; ++script_i) {
                this._scriptArray[script_i] = new List<ToffMonaka.Lib.Scene.Script>();
            }

            this._objectScriptArray = new List<ToffMonaka.Lib.Scene.ObjectScript>[this.createDesc.scriptCount];

            for (int script_i = 0; script_i < this._objectScriptArray.Length; ++script_i) {
                this._objectScriptArray[script_i] = new List<ToffMonaka.Lib.Scene.ObjectScript>();
            }
        }

        int create_res = this._OnCreate();

        if (create_res < 0) {
            this.Init();

            return (create_res);
        }

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
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
    public virtual void SetCreateDesc(ToffMonaka.Lib.Scene.ManagerCreateDesc create_desc)
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
    public ToffMonaka.Lib.Scene.Script GetScript(int script_inex)
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
    public List<ToffMonaka.Lib.Scene.Script> GetScriptContainer(int script_inex)
    {
        if ((script_inex < 0)
        || (script_inex >= this._scriptArray.Length)) {
            return (null);
        }

        return (this._scriptArray[script_inex]);
    }

    /**
     * @brief GetMainSceneScript関数
     * @return main_scene_script (main_scene_script)
     */
    public ToffMonaka.Lib.Scene.MainSceneScript GetMainSceneScript()
    {
        return (this._mainSceneScript);
    }

    /**
     * @brief GetSubSceneScript関数
     * @return sub_scene_script (sub_scene_script)
     */
    public ToffMonaka.Lib.Scene.SubSceneScript GetSubSceneScript()
    {
        return (this._subSceneScript);
    }

    /**
     * @brief GetObjectScriptContainer関数
     * @param script_inex (script_inex)
     * @return obj_script_cont (object_script_container)
     */
    public List<ToffMonaka.Lib.Scene.ObjectScript> GetObjectScriptContainer(int script_inex)
    {
        return (this._objectScriptArray[script_inex]);
    }

    /**
     * @brief AddScript関数
     * @param script (script)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int AddScript(ToffMonaka.Lib.Scene.Script script)
    {
        if ((script == null)
        || (script.GetManager() != null)
        || (script.GetScriptIndex() >= this._scriptArray.Length)) {
            return (-1);
        }

        if (script.GetScriptIndex() >= 0) {
            this._scriptArray[script.GetScriptIndex()].Add(script);

		    switch (script.GetScriptType()) {
		    case ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.MAIN_SCENE: {
                this._mainSceneScript = (ToffMonaka.Lib.Scene.MainSceneScript)script;

			    break;
		    }
		    case ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SUB_SCENE: {
                this._subSceneScript = (ToffMonaka.Lib.Scene.SubSceneScript)script;

			    break;
		    }
		    case ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.OBJECT: {
                this._objectScriptArray[script.GetScriptIndex()].Add((ToffMonaka.Lib.Scene.ObjectScript)script);

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
    public void RemoveScript(ToffMonaka.Lib.Scene.Script script)
    {
        if ((script == null)
        || (script.GetManager() == null)
        || (script.GetScriptIndex() >= this._scriptArray.Length)) {
            return;
        }

        if (script.GetScriptIndex() >= 0) {
            this._scriptArray[script.GetScriptIndex()].Remove(script);

		    switch (script.GetScriptType()) {
		    case ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.MAIN_SCENE: {
                if (this._mainSceneScript == (ToffMonaka.Lib.Scene.MainSceneScript)script) {
                    this._mainSceneScript = null;
                }

			    break;
		    }
		    case ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SUB_SCENE: {
                if (this._subSceneScript == (ToffMonaka.Lib.Scene.SubSceneScript)script) {
                    this._subSceneScript = null;
                }

			    break;
		    }
		    case ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.OBJECT: {
                this._objectScriptArray[script.GetScriptIndex()].Remove((ToffMonaka.Lib.Scene.ObjectScript)script);

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
     * @return main_scene_script (main_scene_script)<br>
     * null=失敗
     */
    public ToffMonaka.Lib.Scene.MainSceneScript ChangeMainScene(string name)
    {
        if ((this._mainSceneNode == null)
        || (name.Length <= 0)) {
            return (null);
        }

        SceneManager.LoadScene(name);

        return (this._mainSceneNode.GetComponent<ToffMonaka.Lib.Scene.MainSceneScript>());
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

        if ((this._mainSceneNode == null)
        || (prefab_file_path.Length <= 0)) {
            return (null);
        }

        this._subSceneNode = ToffMonaka.Lib.Scene.Util.GetPrefabNode(prefab_file_path, this._mainSceneNode);

        return (this._subSceneNode.GetComponent<ToffMonaka.Lib.Scene.SubSceneScript>());
    }
}
}
