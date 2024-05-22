/**
 * @file
 * @brief CheatCommandParserファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace UnityBase.Scene.Ui.Menu {
/**
 * @brief CheatCommandParserUtilクラス
 */
public static class CheatCommandParserUtil
{
    public enum NODE_TYPE : int
    {
        NONE = 0,
        EMPTY,
        NUMBER,
        UNARY_EXPRESSION,
        FUNCTION,
		COUNT
    }
    public static readonly int NODE_TYPE_COUNT = (int)UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.COUNT;

    public static readonly UnityBase.Scene.Ui.Menu.CheatCommandParserOperator[] UNARY_OPERATOR_ARRAY = {
        new UnityBase.Scene.Ui.Menu.CheatCommandParserOperator("+", 0),
        new UnityBase.Scene.Ui.Menu.CheatCommandParserOperator("-", 0),
        new UnityBase.Scene.Ui.Menu.CheatCommandParserOperator("~", 0)
    };

    public static readonly int UNARY_OPERATOR_MAX_LENGTH = 1;
}

/**
 * @brief CheatCommandParserOperatorクラス
 */
public class CheatCommandParserOperator
{
    private string _name_;
    private int _priority;

    /**
     * @brief コンストラクタ
     */
    public CheatCommandParserOperator()
    {
        this._name_ = "";
        this._priority = 0;

        return;
    }

    /**
     * @brief コンストラクタ
     * @param name (name)
     * @param priority (priority)
     */
    public CheatCommandParserOperator(string name, int priority)
    {
        this._name_ = name;
        this._priority = priority;

        return;
    }

    /**
     * @brief GetName関数
     * @return name (name)
     */
    public string GetName()
    {
        return (this._name_);
    }

    /**
     * @brief GetPriority関数
     * @return priority (priority)
     */
    public int GetPriority()
    {
        return (this._priority);
    }
}

/**
 * @brief CheatCommandParserNodeクラス
 */
public class CheatCommandParserNode
{
    private UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE _nodeType;
    private string _text;
    private List<UnityBase.Scene.Ui.Menu.CheatCommandParserNode> _argumentNodeContainer;
    private UnityBase.Scene.Ui.Menu.CheatCommandParserOperator _operator_;
    private UnityBase.Scene.Ui.Menu.CheatCommandParserNode _leftNode;
    private UnityBase.Scene.Ui.Menu.CheatCommandParserNode _rightNode;

    /**
     * @brief コンストラクタ
     */
    public CheatCommandParserNode()
    {
        this._nodeType = UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.NONE;
        this._text = "";
        this._argumentNodeContainer = null;
        this._operator_ = null;
        this._leftNode = null;
        this._rightNode = null;

        return;
    }

    /**
     * @brief コンストラクタ
     * @param node_type (node_type)
     */
    public CheatCommandParserNode(UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE node_type)
    {
        this._nodeType = node_type;
        this._text = "";
        this._argumentNodeContainer = null;
        this._operator_ = null;
        this._leftNode = null;
        this._rightNode = null;

        return;
    }

    /**
     * @brief コンストラクタ
     * @param node_type (node_type)
     * @param txt (text)
     */
    public CheatCommandParserNode(UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE node_type, string txt)
    {
        this._nodeType = node_type;
        this._text = txt;
        this._argumentNodeContainer = null;
        this._operator_ = null;
        this._leftNode = null;
        this._rightNode = null;

        return;
    }

    /**
     * @brief コンストラクタ
     * @param node_type (node_type)
     * @param txt (text)
     * @param arg_node_cont (argument_node_container)
     */
    public CheatCommandParserNode(UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE node_type, string txt, List<UnityBase.Scene.Ui.Menu.CheatCommandParserNode> arg_node_cont)
    {
        this._nodeType = node_type;
        this._text = txt;
        this._argumentNodeContainer = arg_node_cont;
        this._operator_ = null;
        this._leftNode = null;
        this._rightNode = null;

        return;
    }

    /**
     * @brief コンストラクタ
     * @param node_type (node_type)
     * @param txt (text)
     * @param op (operator)
     * @param left_node (left_node)
     * @param right_node (right_node)
     */
    public CheatCommandParserNode(UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE node_type, string txt, UnityBase.Scene.Ui.Menu.CheatCommandParserOperator op, UnityBase.Scene.Ui.Menu.CheatCommandParserNode left_node, UnityBase.Scene.Ui.Menu.CheatCommandParserNode right_node)
    {
        this._nodeType = node_type;
        this._text = txt;
        this._argumentNodeContainer = null;
        this._operator_ = op;
        this._leftNode = left_node;
        this._rightNode = right_node;

        return;
    }

    /**
     * @brief GetNodeType関数
     * @return node_type (node_type)
     */
    public UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE GetNodeType()
    {
        return (this._nodeType);
    }

    /**
     * @brief GetText関数
     * @return txt (text)
     */
    public string GetText()
    {
        return (this._text);
    }

    /**
     * @brief GetArgumentNodeContainer関数
     * @return arg_node_cont (argument_node_container)
     */
    public List<UnityBase.Scene.Ui.Menu.CheatCommandParserNode> GetArgumentNodeContainer()
    {
        return (this._argumentNodeContainer);
    }

    /**
     * @brief GetOperator関数
     * @return op (operator)
     */
    public UnityBase.Scene.Ui.Menu.CheatCommandParserOperator GetOperator()
    {
        return (this._operator_);
    }

    /**
     * @brief GetLeftNode関数
     * @return left_node (left_node)
     */
    public UnityBase.Scene.Ui.Menu.CheatCommandParserNode GetLeftNode()
    {
        return (this._leftNode);
    }

    /**
     * @brief GetRightNode関数
     * @return right_node (right_node)
     */
    public UnityBase.Scene.Ui.Menu.CheatCommandParserNode GetRightNode()
    {
        return (this._rightNode);
    }
}

/**
 * @brief CheatCommandParserクラス
 */
public class CheatCommandParser
{
    private string _code;
    private int _codeIndex;
    private List<UnityBase.Scene.Ui.Menu.CheatCommandParserNode> _nodeContainer;

    /**
     * @brief コンストラクタ
     */
    public CheatCommandParser()
    {
        this._code = "";
        this._codeIndex = 0;
        this._nodeContainer = new List<UnityBase.Scene.Ui.Menu.CheatCommandParserNode>();

        this._Parse();

        return;
    }

    /**
     * @brief コンストラクタ
     * @param code (code)
     */
    public CheatCommandParser(string code)
    {
        this._code = code;
        this._codeIndex = 0;
        this._nodeContainer = new List<UnityBase.Scene.Ui.Menu.CheatCommandParserNode>();

        this._Parse();

        return;
    }

    /**
     * @brief GetNodeContainer関数
     * @return node_cont (node_container)
     */
    public List<UnityBase.Scene.Ui.Menu.CheatCommandParserNode> GetNodeContainer()
    {
        return (this._nodeContainer);
    }

    /**
     * @brief _Parse関数
     */
    private void _Parse()
    {
        do {
            var parse_result = this._ParseNode();

            if (parse_result.Item1 < 0) {
                this._nodeContainer.Clear();

                break;
            }

            if (parse_result.Item2 != null) {
                this._nodeContainer.Add(parse_result.Item2);
            } else {
                this._nodeContainer.Add(new UnityBase.Scene.Ui.Menu.CheatCommandParserNode(UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.EMPTY));
            }

            this._ParseTrim();

            var c = this._GetCharacter(this._codeIndex);

            if (c == ';') {
                ++this._codeIndex;
            } else if (c == '\0') {
                break;
            } else {
                this._nodeContainer.Clear();

                break;
            }
        } while (this._codeIndex < this._code.Length);

        return;
    }

    /**
     * @brief _ParseNode関数
     * @return result (result)
     */
    private System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode> _ParseNode()
    {
        var parse_result = this._ParseUnaryNode();

        if (parse_result.Item1 < 0) {
            return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
        }

        return (parse_result);
    }

    /**
     * @brief _ParseUnaryNode関数
     * @return result (result)
     */
    private System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode> _ParseUnaryNode()
    {
        this._ParseTrim();

        var c = this._GetCharacter(this._codeIndex);

        if (this._IsNumber(c) || (c == '.')) {
            string node_txt = "";

            while (this._IsNumber(this._GetCharacter(this._codeIndex))) {
                node_txt += this._GetCharacter(this._codeIndex++);
            }

            c = this._GetCharacter(this._codeIndex);

            if (c == '.') {
                if (node_txt.Length <= 0) {
                    node_txt += "0";
                }

                node_txt += this._GetCharacter(this._codeIndex++);

                int old_node_txt_len = node_txt.Length;

                while (this._IsNumber(this._GetCharacter(this._codeIndex))) {
                    node_txt += this._GetCharacter(this._codeIndex++);
                }

                if (node_txt.Length == old_node_txt_len) {
                    node_txt += "0";
                }
            }

            c = this._GetCharacter(this._codeIndex);

            if ((c == 'E') || (c == 'e')) {
                node_txt += this._GetCharacter(this._codeIndex++);

                int old_node_txt_len = node_txt.Length;

                c = this._GetCharacter(this._codeIndex);

                if ((c == '+') || (c == '-')) {
                    node_txt += this._GetCharacter(this._codeIndex++);
                }

                while (this._IsNumber(this._GetCharacter(this._codeIndex))) {
                    node_txt += this._GetCharacter(this._codeIndex++);
                }

                if (node_txt.Length == old_node_txt_len) {
                    return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
                }
            }

            c = this._GetCharacter(this._codeIndex);

            if (this._IsIdentifierStart(c) || (c == '.')) {
                return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
            }

            var node = new UnityBase.Scene.Ui.Menu.CheatCommandParserNode(UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.NUMBER, node_txt);

            return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(0, node));
        } else {
            var op_parse_result = this._ParseUnaryOperator();

            if (op_parse_result.Item1 < 0) {
                return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
            }

            if (op_parse_result.Item2 != null) {
                var right_parse_result = this._ParseUnaryNode();

                if ((right_parse_result.Item1 < 0)
                || (right_parse_result.Item2 == null)) {
                    return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
                }

                var node = new UnityBase.Scene.Ui.Menu.CheatCommandParserNode(UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.UNARY_EXPRESSION, System.String.Empty, op_parse_result.Item2, null, right_parse_result.Item2);

                return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(0, node));
            }

            if (this._IsIdentifierStart(c)) {
                int start_code_index = this._codeIndex;

                ++this._codeIndex;

                while (this._codeIndex < this._code.Length) {
                    c = this._GetCharacter(this._codeIndex);

                    if (this._IsIdentifierPart(c)) {
                        ++this._codeIndex;
                    } else {
                        break;
                    }
                }

                string identifier = this._code.Substring(start_code_index, this._codeIndex - start_code_index);

                this._ParseTrim();

                c = this._GetCharacter(this._codeIndex);

                if (c == '(') {
                    var arg_node_cont = new List<UnityBase.Scene.Ui.Menu.CheatCommandParserNode>();
                    bool arg_close_flg = false;

                    ++this._codeIndex;

                    while (this._codeIndex < this._code.Length) {
                        this._ParseTrim();

                        c = this._GetCharacter(this._codeIndex);

                        if (c == ')') {
                            arg_close_flg = true;

                            ++this._codeIndex;

                            break;
                        } else if (c == ',') {
                            ++this._codeIndex;
                        } else {
                            var parse_result = this._ParseNode();

                            if ((parse_result.Item1 < 0)
                            || (parse_result.Item2 == null)) {
                                return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
                            }

                            arg_node_cont.Add(parse_result.Item2);
                        }
                    }

                    if (!arg_close_flg) {
                        return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
                    }

                    var node = new UnityBase.Scene.Ui.Menu.CheatCommandParserNode(UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.NODE_TYPE.FUNCTION, identifier, arg_node_cont);

                    return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(0, node));
                } else {
                    return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
                }
            } else if (c == '(') {
                ++this._codeIndex;

                var parse_result = this._ParseNode();

                if (parse_result.Item1 < 0) {
                    return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
                }

                this._ParseTrim();

                c = this._GetCharacter(this._codeIndex);

                if (c == ')') {
                    ++this._codeIndex;

                    return (parse_result);
                } else {
                    return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(-1, null));
                }
            }
        }

        return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserNode>(0, null));
    }

    /**
     * @brief _ParseUnaryOperator関数
     * @return result (result)
     */
    private System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserOperator> _ParseUnaryOperator()
    {
        this._ParseTrim();

        var op_name = this._GetString(this._codeIndex, UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.UNARY_OPERATOR_MAX_LENGTH);

        while (op_name.Length > 0) {
            foreach (var tmp_op in UnityBase.Scene.Ui.Menu.CheatCommandParserUtil.UNARY_OPERATOR_ARRAY) {
                if (tmp_op.GetName() == op_name) {
                    this._codeIndex += op_name.Length;

                    return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserOperator>(0, tmp_op));
                }
            }

            op_name = op_name.Substring(0, op_name.Length - 1);
        }

        return (new System.Tuple<int, UnityBase.Scene.Ui.Menu.CheatCommandParserOperator>(0, null));
    }

    /**
     * @brief _ParseTrim関数
     */
    private void _ParseTrim()
    {
        var c = this._GetCharacter(this._codeIndex);

        while ((c == ' ') || (c == '　') || (c == '\r') || (c == '\n') || (c == '\t')) {
            c = this._GetCharacter(++this._codeIndex);
        }

        return;
    }

    /**
     * @brief _GetCharacter関数
     * @param str (string)
     * @param index (index)
     * @return c (character)
     */
    private char _GetCharacter(string str, int index)
    {
        if ((index < 0) || (index >= str.Length)) {
            return ('\0');
        }

        return (str[index]);
    }

    /**
     * @brief _GetCharacter関数
     * @param index (index)
     * @return c (character)
     */
    private char _GetCharacter(int index)
    {
        return (this._GetCharacter(this._code, index));
    }

    /**
     * @brief _GetString関数
     * @param str (string)
     * @param index (index)
     * @param len (length)
     * @return str (string)
     */
    private string _GetString(string str, int index, int len)
    {
        int tmp_index = System.Math.Clamp(index, 0, str.Length);
        int tmp_len = System.Math.Clamp(len, 0, str.Length - tmp_index);

        return (str.Substring(tmp_index, tmp_len));
    }

    /**
     * @brief _GetString関数
     * @param index (index)
     * @param len (length)
     * @return str (string)
     */
    private string _GetString(int index, int len)
    {
        return (this._GetString(this._code, index, len));
    }

    /**
     * @brief _IsIdentifierStart関数
     * @param c (character)
     * @return result_flg (result_flag)<br>
     * false=非識別子開始,true=識別子開始
     */
    private bool _IsIdentifierStart(char c)
    {
        if ((c == '_')
        || ((c >= 'A') && (c <= 'Z'))
        || ((c >= 'a') && (c <= 'z'))) {
            return (true);
        }

        return (false);
    }

    /**
     * @brief _IsIdentifierPart関数
     * @param c (character)
     * @return result_flg (result_flag)<br>
     * false=非識別子部分,true=識別子部分
     */
    private bool _IsIdentifierPart(char c)
    {
        if ((c == '_')
        || ((c >= 'A') && (c <= 'Z'))
        || ((c >= 'a') && (c <= 'z'))
        || ((c >= '0') && (c <= '9'))) {
            return (true);
        }

        return (false);
    }

    /**
     * @brief _IsNumber関数
     * @param c (character)
     * @return result_flg (result_flag)<br>
     * false=非数字,true=数字
     */
    private bool _IsNumber(char c)
    {
        if ((c >= '0') && (c <= '9')) {
            return (true);
        }

        return (false);
    }
}
}
}
