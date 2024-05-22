/**
 * @file
 * @brief CheatCommandファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief CheatCommandCalculateOptionクラス
 */
public class CheatCommandCalculateOption
{
    public delegate double Function(UnityBase.Scene.Ui.Menu.CheatCommand owner, double[] arg_val_ary, out int dst_result_val);

	private Function[] _functionArray;
	private Dictionary<string, int> _functionIndexContainer;

    /**
     * @brief コンストラクタ
     */
    public CheatCommandCalculateOption()
    {
	    this.Init();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
	    this.SetFunction();

        return;
    }

    /**
     * @brief SetFunction関数
     */
    public void SetFunction()
    {
	    this._functionArray = new Function[]{
            new Function(UnityBase.Scene.Ui.Menu.CheatCommandUtil.FunctionDeleteData)
        };

	    this._functionIndexContainer = new Dictionary<string, int>();

        for (int add_code_type_i = 0; add_code_type_i < UnityBase.Scene.Ui.Menu.CheatCommandUtil.FUNCTION_ADD_CODE_TYPE_ARRAY.Length; ++add_code_type_i) {
        	this._functionIndexContainer[UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_NAME_ARRAY[(int)UnityBase.Scene.Ui.Menu.CheatCommandUtil.FUNCTION_ADD_CODE_TYPE_ARRAY[add_code_type_i]]] = add_code_type_i;
        }

        return;
    }

    /**
     * @brief GetFunction関数
     * @param index (index)
     * @return func (function)
     */
    public Function GetFunction(int index)
    {
        return (this._functionArray[index]);
    }

    /**
     * @brief GetFunction関数
     * @param name (name)
     * @return func (function)
     */
    public Function GetFunction(string name)
    {
        if (!this._functionIndexContainer.TryGetValue(name, out int index)) {
    	    return (null);
        }

        return (this._functionArray[index]);
    }

    /**
     * @brief GetFunction関数
     * @param name (name)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return func (function)
     */
    public Function GetFunction(string name, out int dst_result_val)
    {
        dst_result_val = 0;

        if (!this._functionIndexContainer.TryGetValue(name, out int index)) {
            dst_result_val = -1;

    	    return (null);
        }

        return (this._functionArray[index]);
    }

    /**
     * @brief SetFunction関数
     * @param index (index)
     * @param func (function)
     */
    public void SetFunction(int index, Function func)
    {
    	this._functionArray[index] = func;

        return;
    }

    /**
     * @brief SetFunction関数
     * @param name (name)
     * @param func (function)
     */
    public void SetFunction(string name, Function func)
    {
        if (name.Length <= 0) {
            return;
        }

    	this._functionArray[this._functionIndexContainer[name]] = func;

        return;
    }

    /**
     * @brief GetFunctionArray関数
     * @return func_ary (function_array)
     */
    public Function[] GetFunctionArray()
    {
        return (this._functionArray);
    }

    /**
     * @brief SetFunctionArray関数
     * @param func_ary (function_array)
     */
    public void SetFunctionArray(Function[] func_ary)
    {
        if (func_ary == null) {
            return;
        }

	    this._functionArray = func_ary;

        return;
    }
}
}
}
