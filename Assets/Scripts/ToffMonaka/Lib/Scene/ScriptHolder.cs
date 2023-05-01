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

    /**
     * @brief コンストラクタ
     * @param script_type_cnt (script_type_count)
     */
    public ScriptHolder(int script_type_cnt)
    {
        this._script_array = new List<ToffMonaka.Lib.Scene.Script>[script_type_cnt];

        for (int script_i = 0; script_i < this._script_array.Length; ++script_i) {
            this._script_array[script_i] = new List<ToffMonaka.Lib.Scene.Script>();
        }

        return;
    }

    /**
     * @brief Get関数
     * @param script_type (script_type)
     * @return script (script)<br>
     * null=失敗
     */
    public ToffMonaka.Lib.Scene.Script Get(int script_type)
    {
        if ((script_type <= 0)
        || (script_type >= this._script_array.Length)) {
            return (null);
        }

        if (this._script_array[script_type].Count <= 0) {
            return (null);
        }

        return (this._script_array[script_type][0]);
    }

    /**
     * @brief GetContainer関数
     * @param script_type (script_type)
     * @return script (script)<br>
     * null=失敗
     */
    public List<ToffMonaka.Lib.Scene.Script> GetContainer(int script_type)
    {
        if ((script_type <= 0)
        || (script_type >= this._script_array.Length)) {
            return (null);
        }

        return (this._script_array[script_type]);
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

        if ((script.GetScriptType() <= 0)
        || (script.GetScriptType() >= this._script_array.Length)) {
            return (-1);
        }

        if (script.GetHolder() != this) {
            return (-1);
        }

        this._script_array[script.GetScriptType()].Add(script);

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

        if ((script.GetScriptType() <= 0)
        || (script.GetScriptType() >= this._script_array.Length)) {
            return;
        }

        if (script.GetHolder() != this) {
            return;
        }

        this._script_array[script.GetScriptType()].Remove(script);

        return;
    }
}
}
