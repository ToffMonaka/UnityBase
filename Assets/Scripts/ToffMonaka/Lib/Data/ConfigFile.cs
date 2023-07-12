/**
 * @file
 * @brief ConfigFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka.Lib.Data {
/**
 * @brief ConfigFileDataクラス
 */
public class ConfigFileData
{
	public Dictionary<string, string> valueContainer = new Dictionary<string, string>();

    /**
     * @brief コンストラクタ
     */
    public ConfigFileData()
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

        this.valueContainer.Clear();

        return;
    }

    /**
     * @brief GetValue関数
     * @param key (key)
     * @return val (value)<br>
     * null=失敗
     */
    public string GetValue(string key)
    {
        string val;

        if (!this.valueContainer.TryGetValue(key, out val)) {
    	    return (null);
        }

	    return (val);
    }
}

/**
 * @brief ConfigFileReadDescDataクラス
 */
public class ConfigFileReadDescData : ToffMonaka.Lib.Data.TextFileReadDescData
{
    /**
     * @brief コンストラクタ
     */
    public ConfigFileReadDescData()
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
 * @brief ConfigFileWriteDescDataクラス
 */
public class ConfigFileWriteDescData : ToffMonaka.Lib.Data.TextFileWriteDescData
{
    /**
     * @brief コンストラクタ
     */
    public ConfigFileWriteDescData()
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
 * @brief ConfigFileクラス
 */
public class ConfigFile : ToffMonaka.Lib.Data.File
{
	public ToffMonaka.Lib.Data.ConfigFileData data = new ToffMonaka.Lib.Data.ConfigFileData();
	public ToffMonaka.Lib.Data.FileReadDesc<ToffMonaka.Lib.Data.ConfigFileReadDescData> readDesc = new ToffMonaka.Lib.Data.FileReadDesc<ToffMonaka.Lib.Data.ConfigFileReadDescData>();
	public ToffMonaka.Lib.Data.FileWriteDesc<ToffMonaka.Lib.Data.ConfigFileWriteDescData> writeDesc = new ToffMonaka.Lib.Data.FileWriteDesc<ToffMonaka.Lib.Data.ConfigFileWriteDescData>();

    /**
     * @brief コンストラクタ
     */
    public ConfigFile()
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
     * @return result (result)<br>
     * 0未満=失敗,-2=ファイル存在無し
     */
    protected override int _OnRead()
    {
        const string equal_str = "=";
        const string comment_str = "#";

	    var desc_dat = this.readDesc.GetDataByParent();

        var txt_file = new ToffMonaka.Lib.Data.TextFile();
        int txt_file_read_res;

        txt_file.readDesc.parentData = desc_dat;

        if ((txt_file_read_res = txt_file.Read()) < 0) {
	        return (txt_file_read_res);
        }

        this.data.Init();

        if (txt_file.data.lineStringContainer.Count <= 0) {
	        return (0);
        }

        string line_str;
        int equal_str_index;
        int comment_str_index;
        string key = "";
        string val = "";

	    foreach (var txt_file_line_str in txt_file.data.lineStringContainer) {
	        if (txt_file_line_str.Length <= 0) {
		        continue;
	        }

	        line_str = txt_file_line_str;

	        {// コメントを削除
		        comment_str_index = line_str.IndexOf(comment_str);

		        if (comment_str_index >= 0) {
			        line_str = line_str.Remove(comment_str_index);
		        }
	        }

	        if (line_str.Length <= 0) {
		        continue;
	        }

	        {// ｢=｣を確認
		        equal_str_index = line_str.IndexOf(equal_str);

		        if (equal_str_index < 0) {
			        continue;
		        }
	        }

	        key = line_str.Substring(0, equal_str_index);
	        key = key.Trim();

	        if (key.Length <= 0) {
		        continue;
	        }

	        val = line_str.Substring(equal_str_index + equal_str.Length);
	        val = val.Trim();

	        this.data.valueContainer.Add(key, val);
        }

        return (0);
    }

    /**
     * @brief _OnWrite関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnWrite()
    {
        const string equal_str = "=";

	    var desc_dat = this.writeDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    return (-1);
	    }

        var txt_file = new ToffMonaka.Lib.Data.TextFile();
        int txt_file_write_res;

        if (this.data.valueContainer.Count > 0) {
	        string line_str;

	        foreach (var val in this.data.valueContainer) {
		        line_str = val.Key;
		        line_str += equal_str;
		        line_str += val.Value;

		        txt_file.data.lineStringContainer.Add(line_str);
	        }

	        txt_file.data.lineStringContainer.Add(System.String.Empty);
        }

        txt_file.writeDesc.parentData = desc_dat;

        if ((txt_file_write_res = txt_file.Write()) < 0) {
	        return (txt_file_write_res);
        }

        return (0);
    }
}
}
