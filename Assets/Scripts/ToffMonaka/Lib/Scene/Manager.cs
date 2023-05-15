﻿/**
 * @file
 * @brief Managerファイル
 */


using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief ManagerCreateDescクラス
 */
public class ManagerCreateDesc
{
    public int scriptCount = 0;
}

/**
 * @brief Managerクラス
 */
public class Manager
{
    public ToffMonaka.Lib.Scene.ManagerCreateDesc createDesc{get; private set;} = null;
    private List<ToffMonaka.Lib.Scene.Script>[] _scriptArray = null;
    private ToffMonaka.Lib.Scene.SceneScript _sceneScript = null;
    private ToffMonaka.Lib.Scene.SubSceneScript _subSceneScript = null;
    private ToffMonaka.Lib.Scene.StaticSubLayerScript[] _staticSubLayerScriptArray = null;
    private List<ToffMonaka.Lib.Scene.DynamicSubLayerScript>[]  _dynamicSubLayerScriptArray = null;
    private GameObject _subSceneNode = null;

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

        this._sceneScript = null;
        this._subSceneScript = null;
        this._staticSubLayerScriptArray = null;
        this._dynamicSubLayerScriptArray = null;

        ToffMonaka.Lib.Scene.Util.ReleasePrefabNode(ref this._subSceneNode);

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._Release();

        return;
    }

    /**
     * @brief Create関数
     * @param desc (desc)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Create(ToffMonaka.Lib.Scene.ManagerCreateDesc desc = null)
    {
        this.Init();

        if (desc != null) {
            this.SetCreateDesc(desc);
        }

        {// This Create
            this._scriptArray = new List<ToffMonaka.Lib.Scene.Script>[this.createDesc.scriptCount];

            for (int script_i = 0; script_i < this._scriptArray.Length; ++script_i) {
                this._scriptArray[script_i] = new List<ToffMonaka.Lib.Scene.Script>();
            }

            this._staticSubLayerScriptArray = new ToffMonaka.Lib.Scene.StaticSubLayerScript[this.createDesc.scriptCount];
            this._dynamicSubLayerScriptArray = new List<ToffMonaka.Lib.Scene.DynamicSubLayerScript>[this.createDesc.scriptCount];

            for (int script_i = 0; script_i < this._dynamicSubLayerScriptArray.Length; ++script_i) {
                this._dynamicSubLayerScriptArray[script_i] = new List<ToffMonaka.Lib.Scene.DynamicSubLayerScript>();
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
     * @brief GetSceneScript関数
     * @return scene_script (scene_script)
     */
    public ToffMonaka.Lib.Scene.SceneScript GetSceneScript()
    {
        return (this._sceneScript);
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
     * @brief GetStaticSubLayerScript関数
     * @param script_inex (script_inex)
     * @return static_sub_layer_script (static_sub_layer_script)
     */
    public ToffMonaka.Lib.Scene.StaticSubLayerScript GetStaticSubLayerScript(int script_inex)
    {
        return (this._staticSubLayerScriptArray[script_inex]);
    }

    /**
     * @brief GetDynamicSubLayerScriptContainer関数
     * @param script_inex (script_inex)
     * @return dynamic_sub_layer_script_cont (dynamic_sub_layer_script_container)
     */
    public List<ToffMonaka.Lib.Scene.DynamicSubLayerScript> GetDynamicSubLayerScriptContainer(int script_inex)
    {
        return (this._dynamicSubLayerScriptArray[script_inex]);
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
        || (script.GetScriptIndex() < 0)
        || (script.GetScriptIndex() >= this._scriptArray.Length)) {
            return (-1);
        }

        this._scriptArray[script.GetScriptIndex()].Add(script);

		switch (script.GetScriptType()) {
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SCENE: {
            this._sceneScript = (ToffMonaka.Lib.Scene.SceneScript)script;

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SUB_SCENE: {
            this._subSceneScript = (ToffMonaka.Lib.Scene.SubSceneScript)script;

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.STATIC_SUB_LAYER: {
            this._staticSubLayerScriptArray[script.GetScriptIndex()] = (ToffMonaka.Lib.Scene.StaticSubLayerScript)script;

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.DYNAMIC_SUB_LAYER: {
            this._dynamicSubLayerScriptArray[script.GetScriptIndex()].Add((ToffMonaka.Lib.Scene.DynamicSubLayerScript)script);

			break;
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
        || (script.GetScriptIndex() < 0)
        || (script.GetScriptIndex() >= this._scriptArray.Length)) {
            return;
        }

        this._scriptArray[script.GetScriptIndex()].Remove(script);

		switch (script.GetScriptType()) {
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SCENE: {
            if (this._sceneScript == (ToffMonaka.Lib.Scene.SceneScript)script) {
                this._sceneScript = null;
            }

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SUB_SCENE: {
            if (this._subSceneScript == (ToffMonaka.Lib.Scene.SubSceneScript)script) {
                this._subSceneScript = null;
            }

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.STATIC_SUB_LAYER: {
            if (this._staticSubLayerScriptArray[script.GetScriptIndex()] == (ToffMonaka.Lib.Scene.StaticSubLayerScript)script) {
                this._staticSubLayerScriptArray[script.GetScriptIndex()] = null;
            }

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.DYNAMIC_SUB_LAYER: {
            this._dynamicSubLayerScriptArray[script.GetScriptIndex()].Remove((ToffMonaka.Lib.Scene.DynamicSubLayerScript)script);

			break;
		}
		}

        script.SetManager(null);

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
        if ((this.GetSceneScript() == null)
        || (name.Length <= 0)) {
            return (null);
        }

        SceneManager.LoadScene(name);

        return (this.GetSceneScript());
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

        if ((this.GetSceneScript() == null)
        || (prefab_file_path.Length <= 0)) {
            return (null);
        }

        this._subSceneNode = ToffMonaka.Lib.Scene.Util.GetPrefabNode(prefab_file_path, this.GetSceneScript().gameObject);

        return (this._subSceneNode.GetComponent<ToffMonaka.Lib.Scene.SubSceneScript>());
    }
}
}
