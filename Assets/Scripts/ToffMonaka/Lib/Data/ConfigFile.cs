/**
 * @file
 * @brief ConfigFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace Lib.Data {
/**
 * @brief ConfigFileUtilクラス
 */
public static class ConfigFileUtil
{
    public static readonly string EQUAL_CODE = "=";
    public static readonly string COMMENT_CODE = "#";
}

/**
 * @brief ConfigFileDataクラス
 */
public class ConfigFileData
{
	public Dictionary<string, string> valueContainer = new();

    /**
     * @brief コンストラクタ
     */
    public ConfigFileData()
    {
        this.Init();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
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
    public ConfigFileReadDescData() : base()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
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
    public ConfigFileWriteDescData() : base()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
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
	public Lib.Data.ConfigFileData data = new();
	public Lib.Data.FileReadDesc<Lib.Data.ConfigFileReadDescData> readDesc = new();
	public Lib.Data.FileWriteDesc<Lib.Data.ConfigFileWriteDescData> writeDesc = new();

    /**
     * @brief コンストラクタ
     */
    public ConfigFile() : base()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        base.Init();

	    this.data.Init();
	    this.readDesc.Init();
	    this.writeDesc.Init();

        return;
    }

    /**
     * @brief _OnRead関数
     * @return result_val (result_value)<br>
     * 0未満=失敗,-2=ファイル存在無し
     */
    protected override int _OnRead()
    {
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
        string key;
        string val;

	    foreach (var txt_file_line_txt in txt_file.data.lineTextContainer) {
	        if (txt_file_line_txt.Length <= 0) {
		        continue;
	        }

	        line_txt = txt_file_line_txt;

	        {// コメントを削除
		        comment_str_index = line_txt.IndexOf(Lib.Data.ConfigFileUtil.COMMENT_CODE);

		        if (comment_str_index >= 0) {
			        line_txt = line_txt.Remove(comment_str_index);
		        }
	        }

	        if (line_txt.Length <= 0) {
		        continue;
	        }

	        {// ｢=｣を確認
		        equal_str_index = line_txt.IndexOf(Lib.Data.ConfigFileUtil.EQUAL_CODE);

		        if (equal_str_index < 0) {
			        continue;
		        }
	        }

	        key = line_txt.Substring(0, equal_str_index);
	        key = key.Trim();

	        if (key.Length <= 0) {
		        continue;
	        }

	        val = line_txt.Substring(equal_str_index + Lib.Data.ConfigFileUtil.EQUAL_CODE.Length);
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
		        line_txt += Lib.Data.ConfigFileUtil.EQUAL_CODE;
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
