/**
 * @file
 * @brief CsvFileファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Data {
/**
 * @brief CsvFileDataクラス
 */
public class CsvFileData
{
	public string[][] valueArray = System.Array.Empty<string[]>();

    /**
     * @brief コンストラクタ
     */
    public CsvFileData()
    {
        return;
    }

    /**
     * @brief _Release関数
     */
    private void _Release()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._Release();

        this.valueArray = System.Array.Empty<string[]>();

        return;
    }

    /**
     * @brief GetRowCount関数
     * @return row_cnt (row_count)
     */
    public int GetRowCount()
    {
	    return (this.valueArray.Length);
    }

    /**
     * @brief GetColumnCount関数
     * @return column_cnt (column_count)
     */
    public int GetColumnCount()
    {
	    return ((this.valueArray.Length > 0) ? this.valueArray[0].Length : 0);
    }

    /**
     * @brief GetValue関数
     * @param row_index (row_index)
     * @param column_index (column_index)
     * @return val (value)<br>
     * null=失敗
     */
    public string GetValue(int row_index, int column_index)
    {
	    if ((row_index >= this.valueArray.Length)
	    || (column_index >= this.valueArray[row_index].Length)) {
		    return (null);
	    }

	    return (this.valueArray[row_index][column_index]);
    }

    /**
     * @brief GetValueFast関数
     * @param row_index (row_index)
     * @param column_index (column_index)
     * @return val (value)<br>
     * null=失敗
     */
    public string GetValueFast(int row_index, int column_index)
    {
	    return (this.valueArray[row_index][column_index]);
    }
}

/**
 * @brief CsvFileReadDescDataクラス
 */
public class CsvFileReadDescData : Lib.Data.TextFileReadDescData
{
    /**
     * @brief コンストラクタ
     */
    public CsvFileReadDescData()
    {
        return;
    }

    /**
     * @brief _Release関数
     */
    private void _Release()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        this._Release();

        base.Init();

        return;
    }

    /**
     * @brief IsEmpty関数
     * @return result_flg (result_flag)<br>
     * false=非空,true=空
     */
    public override bool IsEmpty()
    {
        return (base.IsEmpty());
    }
}

/**
 * @brief CsvFileWriteDescDataクラス
 */
public class CsvFileWriteDescData : Lib.Data.TextFileWriteDescData
{
    /**
     * @brief コンストラクタ
     */
    public CsvFileWriteDescData()
    {
        return;
    }

    /**
     * @brief _Release関数
     */
    private void _Release()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        this._Release();

        base.Init();

        return;
    }

    /**
     * @brief IsEmpty関数
     * @return result_flg (result_flag)<br>
     * false=非空,true=空
     */
    public override bool IsEmpty()
    {
        return (base.IsEmpty());
    }
}

/**
 * @brief CsvFileクラス
 */
public class CsvFile : Lib.Data.File
{
	public Lib.Data.CsvFileData data = new Lib.Data.CsvFileData();
	public Lib.Data.FileReadDesc<Lib.Data.CsvFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.CsvFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.CsvFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.CsvFileWriteDescData>();

    /**
     * @brief コンストラクタ
     */
    public CsvFile()
    {
        return;
    }

    /**
     * @brief _Release関数
     */
    private void _Release()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        this._Release();

	    this.data.Init();
	    this.readDesc.Init();
	    this.writeDesc.Init();

        base.Init();

        return;
    }

    /**
     * @brief _OnRead関数
     * @return result_val (result_value)<br>
     * 0未満=失敗,-2=ファイル存在無し
     */
    protected override int _OnRead()
    {
	    const string comma_str = ",";
	    const string dq_str = "\"";
	    const string ddq_str = "\"\"";
	    const string comment_str = "#";

	    var desc_dat = this.readDesc.GetDataByParent();

        var txt_file = new Lib.Data.TextFile();
        int txt_file_read_result_val;

        txt_file.readDesc.parentData = desc_dat;

        if ((txt_file_read_result_val = txt_file.Read()) < 0) {
	        return (txt_file_read_result_val);
        }

        this.data.Init();

        if (txt_file.data.lineTextContainer.Count <= 0) {
	        return (0);
        }

        string line_txt;
        int comma_str_index;
        int dq_str_index;
        int dq_str_sub_index;
        int dq_str_cnt;
        int ddq_str_index;
        int comment_str_index;
    	string newline_code = Lib.String.Util.GetNewlineCode(desc_dat.newlineType);
	    int val_cnt = 0;
        string val = "";

	    foreach (var txt_file_line_txt in txt_file.data.lineTextContainer) {
	        if (txt_file_line_txt.Length <= 0) {
		        continue;
	        }

	        line_txt = txt_file_line_txt;

            {// コメントを削除
	            dq_str_index = 0;
	            dq_str_sub_index = 0;
	            dq_str_cnt = 0;

	            comment_str_index = line_txt.IndexOf(comment_str);

	            while (comment_str_index >= 0) {
		            dq_str_index = line_txt.IndexOf(dq_str, dq_str_sub_index);

		            while (dq_str_index >= 0) {
			            if (dq_str_index >= comment_str_index) {
				            break;
			            }

			            ++dq_str_cnt;

			            dq_str_sub_index = dq_str_index + dq_str.Length;

			            dq_str_index = line_txt.IndexOf(dq_str, dq_str_index + dq_str.Length);
		            }

		            if ((dq_str_cnt & 1) == 0) {
			            line_txt = line_txt.Remove(comment_str_index);

			            break;
		            } else {
			            dq_str_sub_index = comment_str_index + comment_str.Length;

			            comment_str_index = line_txt.IndexOf(comment_str, comment_str_index + comment_str.Length);
		            }
	            }
            }

            if (line_txt.Length <= 0) {
	            continue;
            }

            {// ｢,｣を改行文字列に変換
	            dq_str_index = 0;
	            dq_str_sub_index = 0;
	            dq_str_cnt = 0;

	            comma_str_index = line_txt.IndexOf(comma_str);

	            while (comma_str_index >= 0) {
		            dq_str_index = line_txt.IndexOf(dq_str, dq_str_sub_index);

		            while (dq_str_index >= 0) {
			            if (dq_str_index >= comma_str_index) {
				            break;
			            }

			            ++dq_str_cnt;

			            dq_str_index = line_txt.IndexOf(dq_str, dq_str_index + dq_str.Length);
		            }

		            if ((dq_str_cnt & 1U) == 0U) {
                        Lib.String.Util.Replace(ref line_txt, comma_str_index, comma_str.Length, newline_code);

			            dq_str_sub_index = comma_str_index + newline_code.Length;

			            comma_str_index = line_txt.IndexOf(comma_str, comma_str_index + newline_code.Length);
		            } else {
			            dq_str_sub_index = comma_str_index + comma_str.Length;

			            comma_str_index = line_txt.IndexOf(comma_str, comma_str_index + comma_str.Length);
		            }
	            }
            }

            string[] val_ary = line_txt.Split(newline_code);

            for (int val_i = 0; val_i < val_ary.Length; ++val_i) {
                val = val_ary[val_i];

	            {// ｢""｣を｢"｣に変換
		            ddq_str_index = val.IndexOf(ddq_str);

		            while (ddq_str_index >= 0) {
                        Lib.String.Util.Replace(ref val, ddq_str_index, ddq_str.Length, dq_str);

			            ddq_str_index = val.IndexOf(ddq_str, ddq_str_index + dq_str.Length);
		            }
	            }

	            {// 先頭の｢"｣を削除
		            dq_str_index = val.IndexOf(dq_str);

		            if (dq_str_index >= 0) {
			            val = val.Remove(0, dq_str_index + dq_str.Length);
		            }
	            }

	            {// 末尾の｢"｣を削除
		            dq_str_index = val.LastIndexOf(dq_str);

		            if (dq_str_index >= 0) {
			            val = val.Remove(dq_str_index);
		            }
	            }

                val_ary[val_i] = val.Trim();
            }

            if (val_ary.Length < val_cnt) {
                int old_val_cnt = val_ary.Length;

                System.Array.Resize(ref val_ary, val_cnt);

	            for (int empty_val_i = old_val_cnt; empty_val_i < val_ary.Length; ++empty_val_i) {
                    val_ary[empty_val_i] = System.String.Empty;
	            }
            } else if (val_ary.Length > val_cnt) {
	            val_cnt = val_ary.Length;

	            for (int val_i = 0; val_i < this.data.valueArray.Length; ++val_i) {
                    Lib.Array.Util.Resize(ref this.data.valueArray[val_i], val_cnt, System.String.Empty);
	            }
            }

            Lib.Array.Util.Resize(ref this.data.valueArray, this.data.valueArray.Length + 1, val_ary);
        }

        return (0);
    }

    /**
     * @brief _OnWrite関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnWrite()
    {
	    const string comma_str = ",";

	    var desc_dat = this.writeDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    return (-1);
	    }

        var txt_file = new Lib.Data.TextFile();
        int txt_file_write_result_val;

        if (this.data.valueArray.Length > 0) {
	        string line_txt;

	        foreach (var val_ary in this.data.valueArray) {
                line_txt = System.String.Join(comma_str, val_ary);

		        txt_file.data.lineTextContainer.Add(line_txt);
	        }

	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        txt_file.writeDesc.parentData = desc_dat;

        if ((txt_file_write_result_val = txt_file.Write()) < 0) {
	        return (txt_file_write_result_val);
        }

        return (0);
    }
}
}
}
