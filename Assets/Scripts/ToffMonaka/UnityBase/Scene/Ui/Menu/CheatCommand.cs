/**
 * @file
 * @brief CheatCommandファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief CheatCommandUtilクラス
 */
public static class CheatCommandUtil
{
    public enum ADD_CODE_TYPE : int
    {
        NONE = 0,
        FUNCTION_DELETE_DATA,
		COUNT
    }
    public static readonly int ADD_CODE_TYPE_COUNT = (int)UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE.COUNT;

    public static readonly string[] ADD_CODE_NAME_ARRAY = {
        "",
        "DeleteData"
    };

    public static readonly string[] ADD_CODE_TEXT_ARRAY = {
        "",
        "DeleteData()"
    };

    public static readonly UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE[] FUNCTION_ADD_CODE_TYPE_ARRAY = {
        UnityBase.Scene.Ui.Menu.CheatCommandUtil.ADD_CODE_TYPE.FUNCTION_DELETE_DATA
    };

    /**
     * @brief FunctionDeleteData関数
     * @param owner (owner)
     * @param arg_val_ary (argument_value_array)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static double FunctionDeleteData(UnityBase.Scene.Ui.Menu.CheatCommand owner, double[] arg_val_ary, out int dst_result_val)
    {
        if (arg_val_ary.Length < 0) {
            dst_result_val = -1;

            return (0.0);
        }

        dst_result_val = 0;

        if (owner.GetCalculateTestFlag()) {
            return (0.0);
        }

        Debug.Log("FunctionDeleteData");

        return (0.0);
    }
}

/**
 * @brief CheatCommandクラス
 */
public class CheatCommand
{
    private string _code;
    private int _codeIndex;
	private UnityBase.Scene.Ui.Menu.CheatCommandCalculateOption _calculateOption;
	private bool _calculateTestFlag;
	private UnityBase.Scene.Ui.Menu.CheatCommandParser _parser;

    /**
     * @brief コンストラクタ
     */
    public CheatCommand()
    {
        this.Init();

        return;
    }

    /**
     * @brief コンストラクタ
     * @param code (code)
     */
    public CheatCommand(string code)
    {
        this.Init(code);

        return;
    }

    /**
     * @brief コンストラクタ
     * @param other (other)
     */
    public CheatCommand(CheatCommand other)
    {
        this.Init(other);

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._code = "";
        this._codeIndex = 0;
        this._calculateOption = null;
        this._calculateTestFlag = false;
        this._parser = null;

        return;
    }

    /**
     * @brief Init関数
     * @param code (code)
     */
    public virtual void Init(string code)
    {
        this._code = code;
        this._codeIndex = this._code.Length;
        this._calculateOption = null;
        this._calculateTestFlag = false;
        this._parser = null;

        return;
    }

    /**
     * @brief Init関数
     * @param other (other)
     */
    public virtual void Init(CheatCommand other)
    {
        if (other == this) {
            return;
        }

        this._code = other._code;
        this._codeIndex = other._codeIndex;
        this._calculateOption = null;
        this._calculateTestFlag = false;
        this._parser = null;

        return;
    }

    /**
     * @brief Clone関数
     * @return new_this (new_this)
     */
    public CheatCommand Clone()
    {
        return (new UnityBase.Scene.Ui.Menu.CheatCommand(this));
    }

    /**
     * @brief GetCode関数
     * @return code (code)
     */
    public string GetCode()
    {
        return (this._code);
    }

    /**
     * @brief SetCode関数
     * @param code (code)
     */
    public void SetCode(string code)
    {
        this._code = code;
        this._codeIndex = this._code.Length;

        return;
    }

    /**
     * @brief GetCodeIndex関数
     * @return code_index (code_index)
     */
    public int GetCodeIndex()
    {
        return (this._codeIndex);
    }

    /**
     * @brief SetCodeIndex関数
     * @param code_index (code_index)
     */
    public void SetCodeIndex(int code_index)
    {
        this._codeIndex = System.Math.Clamp(code_index, 0, this._code.Length);

        return;
    }

    /**
     * @brief GetCalculateOption関数
     * @param calc_option (calculate_option)
     */
    public UnityBase.Scene.Ui.Menu.CheatCommandCalculateOption GetCalculateOption()
    {
        return (this._calculateOption);
    }

    /**
     * @brief GetCalculateTestFlag関数
     * @param calc_test_flg (calculate_test_flag)
     */
    public bool GetCalculateTestFlag()
    {
        return (this._calculateTestFlag);
    }

    /**
     * @brief GetParser関数
     * @return parser (parser)
     */
    public UnityBase.Scene.Ui.Menu.CheatCommandParser GetParser()
    {
        return (this._parser);
    }

    /**
     * @brief Calculate関数
     * @param dst_calc_val (dst_calculate_value)
     * @param calc_option (calculate_option)
     * @param calc_test_flg (calculate_test_flag)
     * @param parser (parser)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int Calculate(out double dst_calc_val, UnityBase.Scene.Ui.Menu.CheatCommandCalculateOption calc_option, bool calc_test_flg = false, UnityBase.Scene.Ui.Menu.CheatCommandParser parser = null)
    {
        dst_calc_val = 0.0;

        this._calculateOption = calc_option;
        this._calculateTestFlag = calc_test_flg;
        this._parser = parser;
        
        if (this._parser == null) {
            this._parser = new UnityBase.Scene.Ui.Menu.CheatCommandParser(this._code);
        }

        if (this._parser.GetNodeContainer().Count <= 0) {
            return (-1);
        }

        foreach (var node in this._parser.GetNodeContainer()) {
            if (node.GetNodeType() == UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.EMPTY) {
                return (-1);
            }

            var calc_result = this._CalculateNode(node);

            if (calc_result.Item1 < 0) {
                return (-1);
            }

            dst_calc_val = calc_result.Item2;
        }

        return (0);
    }

    /**
     * @brief _CalculateNode関数
     * @param node (node)
     * @return result (result)
     */
    public System.Tuple<int, double> _CalculateNode(UnityBase.Scene.Ui.Menu.CheatCommandParserNode node)
    {
        double calc_val = 0.0;

		switch (node.GetNodeType()) {
		case UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.NUMBER: {
            if (!double.TryParse(node.GetText(), out calc_val)) {
                return (new System.Tuple<int, double>(-1, 0.0));
            }

            break;
		}
		case UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.UNARY_EXPRESSION: {
            var right_calc_result = this._CalculateNode(node.GetRightNode());

            if (right_calc_result.Item1 < 0) {
                return (new System.Tuple<int, double>(-1, 0.0));
            }

		    switch (node.GetOperator().GetName()) {
		    case "+": {
                calc_val = right_calc_result.Item2;

                break;
		    }
		    case "-": {
                calc_val = -right_calc_result.Item2;

                break;
		    }
		    case "~": {
                calc_val = (double)(~(int)right_calc_result.Item2);

                break;
		    }
		    default: {
                return (new System.Tuple<int, double>(-1, 0.0));
		    }
		    }

            break;
		}
		case UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.FUNCTION: {
            var func = this._calculateOption.GetFunction(node.GetText(), out int get_result_val);

            if (get_result_val < 0) {
                return (new System.Tuple<int, double>(-1, 0.0));
            }

            var arg_val_ary = System.Array.Empty<double>();
            int arg_val_index = 0;

            if (node.GetArgumentNodeContainer().Count > 0) {
                arg_val_ary = new double[node.GetArgumentNodeContainer().Count];

                foreach (var arg_node in node.GetArgumentNodeContainer()) {
                    var calc_result = this._CalculateNode(arg_node);

                    if (calc_result.Item1 < 0) {
                        return (new System.Tuple<int, double>(-1, 0.0));
                    }

                    arg_val_ary[arg_val_index++] = calc_result.Item2;
                }
            }

            calc_val = func(this, arg_val_ary, out int func_result_val);

            if (func_result_val < 0) {
                return (new System.Tuple<int, double>(-1, 0.0));
            }

            break;
		}
		}

        return (new System.Tuple<int, double>(0, calc_val));
    }
}
}
}
