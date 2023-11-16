/**
 * @file
 * @brief ConfigFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace Lib.Data {
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
        if (!this.valueContainer.TryGetValue(key, out string val)) {
    	    return (null);
        }

	    return (val);
    }
}

/**
 * @brief ConfigFileReadDescDataクラス
 */
public class ConfigFileReadDescData : Lib.Data.TextFileReadDescData
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
public class ConfigFileWriteDescData : Lib.Data.TextFileWriteDescData
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
public class ConfigFile : Lib.Data.File
{
	public Lib.Data.ConfigFileData data = new Lib.Data.ConfigFileData();
	public Lib.Data.FileReadDesc<Lib.Data.ConfigFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.ConfigFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.ConfigFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.ConfigFileWriteDescData>();

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
     * @return result_val (result_value)<br>
     * 0未満=失敗,-2=ファイル存在無し
     */
    protected override int _OnRead()
    {
        const string equal_str = "=";
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
        int equal_str_index;
        int comment_str_index;
        string key = "";
        string val = "";

	    foreach (var txt_file_line_txt in txt_file.data.lineTextContainer) {
	        if (txt_file_line_txt.Length <= 0) {
		        continue;
	        }

	        line_txt = txt_file_line_txt;

	        {// コメントを削除
		        comment_str_index = line_txt.IndexOf(comment_str);

		        if (comment_str_index >= 0) {
			        line_txt = line_txt.Remove(comment_str_index);
		        }
	        }

	        if (line_txt.Length <= 0) {
		        continue;
	        }

	        {// ｢=｣を確認
		        equal_str_index = line_txt.IndexOf(equal_str);

		        if (equal_str_index < 0) {
			        continue;
		        }
	        }

	        key = line_txt.Substring(0, equal_str_index);
	        key = key.Trim();

	        if (key.Length <= 0) {
		        continue;
	        }

	        val = line_txt.Substring(equal_str_index + equal_str.Length);
	        val = val.Trim();

	        this.data.valueContainer.Add(key, val);
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
        const string equal_str = "=";

	    var desc_dat = this.writeDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    return (-1);
	    }

        var txt_file = new Lib.Data.TextFile();
        int txt_file_write_result_val;

        if (this.data.valueContainer.Count > 0) {
	        string line_txt;

	        foreach (var val in this.data.valueContainer) {
		        line_txt = val.Key;
		        line_txt += equal_str;
		        line_txt += val.Value;

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
