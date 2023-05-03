/**
 * @file
 * @brief ScriptHolderファイル
 */


using System;
using System.Collections.Generic;


namespace ToffMonaka.Lib.Scene {
/**
 * @brief ScriptHolderクラス
 */
public class ScriptHolder
{
    private List<ToffMonaka.Lib.Scene.Script>[] _script_array = null;
    private ToffMonaka.Lib.Scene.SceneScript _scene_script = null;
    private ToffMonaka.Lib.Scene.SubSceneScript _sub_scene_script = null;
    private ToffMonaka.Lib.Scene.StaticSubLayerScript[] _static_sub_layer_script_array = null;
    private List<ToffMonaka.Lib.Scene.DynamicSubLayerScript>[]  _dynamic_sub_layer_script_array = null;

    /**
     * @brief コンストラクタ
     * @param script_cnt (script_count)
     */
    public ScriptHolder(int script_cnt)
    {
        this._script_array = new List<ToffMonaka.Lib.Scene.Script>[script_cnt];

        for (int script_i = 0; script_i < this._script_array.Length; ++script_i) {
            this._script_array[script_i] = new List<ToffMonaka.Lib.Scene.Script>();
        }

        this._static_sub_layer_script_array = new ToffMonaka.Lib.Scene.StaticSubLayerScript[script_cnt];
        this._dynamic_sub_layer_script_array = new List<ToffMonaka.Lib.Scene.DynamicSubLayerScript>[script_cnt];

        for (int script_i = 0; script_i < this._dynamic_sub_layer_script_array.Length; ++script_i) {
            this._dynamic_sub_layer_script_array[script_i] = new List<ToffMonaka.Lib.Scene.DynamicSubLayerScript>();
        }

        return;
    }

    /**
     * @brief Get関数
     * @param script_inex (script_inex)
     * @return script (script)<br>
     * null=失敗
     */
    public ToffMonaka.Lib.Scene.Script Get(int script_inex)
    {
        if ((script_inex < 0)
        || (script_inex >= this._script_array.Length)) {
            return (null);
        }

        if (this._script_array[script_inex].Count <= 0) {
            return (null);
        }

        return (this._script_array[script_inex][0]);
    }

    /**
     * @brief GetContainer関数
     * @param script_inex (script_inex)
     * @return script (script)<br>
     * null=失敗
     */
    public List<ToffMonaka.Lib.Scene.Script> GetContainer(int script_inex)
    {
        if ((script_inex < 0)
        || (script_inex >= this._script_array.Length)) {
            return (null);
        }

        return (this._script_array[script_inex]);
    }

    /**
     * @brief GetSceneScript関数
     * @return scene_script (scene_script)
     */
    public ToffMonaka.Lib.Scene.SceneScript GetSceneScript()
    {
        return (this._scene_script);
    }

    /**
     * @brief GetSubSceneScript関数
     * @return sub_scene_script (sub_scene_script)
     */
    public ToffMonaka.Lib.Scene.SubSceneScript GetSubSceneScript()
    {
        return (this._sub_scene_script);
    }

    /**
     * @brief GetStaticSubLayerScript関数
     * @param script_inex (script_inex)
     * @return static_sub_layer_script (static_sub_layer_script)
     */
    public ToffMonaka.Lib.Scene.StaticSubLayerScript GetSubLayerScript(int script_inex)
    {
        return (this._static_sub_layer_script_array[script_inex]);
    }

    /**
     * @brief GetDynamicLayerScriptContainer関数
     * @param script_inex (script_inex)
     * @return dynamic_sub_layer_script (dynamic_sub_layer_script)
     */
    public List<ToffMonaka.Lib.Scene.DynamicSubLayerScript> GetDynamicLayerScriptContainer(int script_inex)
    {
        return (this._dynamic_sub_layer_script_array[script_inex]);
    }

    /**
     * @brief Add関数
     * @param script (script)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Add(ToffMonaka.Lib.Scene.Script script)
    {
        if (script == null) {
            return (-1);
        }

        if ((script.GetScriptIndex() < 0)
        || (script.GetScriptIndex() >= this._script_array.Length)) {
            return (-1);
        }

        if (script.GetHolder() != this) {
            return (-1);
        }

        this._script_array[script.GetScriptIndex()].Add(script);

		switch (script.GetScriptType()) {
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SCENE: {
            this._scene_script = (ToffMonaka.Lib.Scene.SceneScript)script;

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SUB_SCENE: {
            this._sub_scene_script = (ToffMonaka.Lib.Scene.SubSceneScript)script;

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.STATIC_SUB_LAYER: {
            this._static_sub_layer_script_array[script.GetScriptIndex()] = (ToffMonaka.Lib.Scene.StaticSubLayerScript)script;

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.DYNAMIC_SUB_LAYER: {
            this._dynamic_sub_layer_script_array[script.GetScriptIndex()].Add((ToffMonaka.Lib.Scene.DynamicSubLayerScript)script);

			break;
		}
		}

        return (0);
    }

    /**
     * @brief Remove関数
     * @param script (script)
     */
    public void Remove(ToffMonaka.Lib.Scene.Script script)
    {
        if (script == null) {
            return;
        }

        if ((script.GetScriptIndex() < 0)
        || (script.GetScriptIndex() >= this._script_array.Length)) {
            return;
        }

        if (script.GetHolder() != this) {
            return;
        }

        this._script_array[script.GetScriptIndex()].Remove(script);

		switch (script.GetScriptType()) {
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SCENE: {
            if (this._scene_script == (ToffMonaka.Lib.Scene.SceneScript)script) {
                this._scene_script = null;
            }

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.SUB_SCENE: {
            if (this._sub_scene_script == (ToffMonaka.Lib.Scene.SubSceneScript)script) {
                this._sub_scene_script = null;
            }

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.STATIC_SUB_LAYER: {
            if (this._static_sub_layer_script_array[script.GetScriptIndex()] == (ToffMonaka.Lib.Scene.StaticSubLayerScript)script) {
                this._static_sub_layer_script_array[script.GetScriptIndex()] = null;
            }

			break;
		}
		case (int)ToffMonaka.Lib.Constant.Util.SCENE.SCRIPT_TYPE.DYNAMIC_SUB_LAYER: {
            this._dynamic_sub_layer_script_array[script.GetScriptIndex()].Remove((ToffMonaka.Lib.Scene.DynamicSubLayerScript)script);

			break;
		}
		}

        return;
    }
}
}
