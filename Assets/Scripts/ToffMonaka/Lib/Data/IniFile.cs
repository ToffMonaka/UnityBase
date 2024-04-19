/**
 * @file
 * @brief IniFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace Lib.Data {
/**
 * @brief IniFileUtilクラス
 */
public static class IniFileUtil
{
    public static readonly string SECTION_START_CODE = "[";
    public static readonly string SECTION_END_CODE = "]";
    public static readonly string EQUAL_CODE = "=";
    public static readonly string COMMENT_CODE = ";";
}

/**
 * @brief IniFileDataクラス
 */
public class IniFileData
{
	public Dictionary<string, Dictionary<string, string>> valueContainer = new();

    /**
     * @brief コンストラクタ
     */
    public IniFileData()
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
     * @brief GetKeyContainer関数
     * @param section_name (section_name)
     * @return key_cont (key_container)<br>
     * null=失敗
     */
    public Dictionary<string, string> GetKeyContainer(string section_name)
    {
        if (!this.valueContainer.TryGetValue(section_name, out Dictionary<string, string> key_cont)) {
    	    return (null);
        }

	    return (key_cont);
    }

    /**
     * @brief GetValue関数
     * @param key_cont (key_container)
     * @param key (key)
     * @return val (value)<br>
     * null=失敗
     */
    public string GetValue(Dictionary<string, string> key_cont, string key)
    {
        if (!key_cont.TryGetValue(key, out string val)) {
    	    return (null);
        }

	    return (val);
    }

    /**
     * @brief GetValue関数
     * @param section_name (section_name)
     * @param key (key)
     * @return val (value)<br>
     * null=失敗
     */
    public string GetValue(string section_name, string key)
    {
        if (!this.valueContainer.TryGetValue(section_name, out Dictionary<string, string> key_cont)) {
    	    return (null);
        }

        if (!key_cont.TryGetValue(key, out string val)) {
    	    return (null);
        }

	    return (val);
    }
}

/**
 * @brief IniFileReadDescDataクラス
 */
public class IniFileReadDescData : Lib.Data.TextFileReadDescData
{
    /**
     * @brief コンストラクタ
     */
    public IniFileReadDescData() : base()
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
 * @brief IniFileWriteDescDataクラス
 */
public class IniFileWriteDescData : Lib.Data.TextFileWriteDescData
{
    /**
     * @brief コンストラクタ
     */
    public IniFileWriteDescData() : base()
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
 * @brief IniFileクラス
 */
public class IniFile : Lib.Data.File
{
	public Lib.Data.IniFileData data = new();
	public Lib.Data.FileReadDesc<Lib.Data.IniFileReadDescData> readDesc = new();
	public Lib.Data.FileWriteDesc<Lib.Data.IniFileWriteDescData> writeDesc = new();

    /**
     * @brief コンストラクタ
     */
    public IniFile() : base()
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
        int section_start_str_index;
        int section_end_str_index;
        int equal_str_index;
        int comment_str_index;
        string section_name;
        string key;
        string val;

        section_name = "";

	    foreach (var txt_file_line_txt in txt_file.data.lineTextContainer) {
	        if (txt_file_line_txt.Length <= 0) {
		        continue;
	        }

	        line_txt = txt_file_line_txt;

	        {// コメントを削除
		        comment_str_index = line_txt.IndexOf(Lib.Data.IniFileUtil.COMMENT_CODE);

		        if (comment_str_index >= 0) {
			        line_txt = line_txt.Remove(comment_str_index);
		        }
	        }

	        if (line_txt.Length <= 0) {
		        continue;
	        }

	        {// ｢=｣を確認
		        equal_str_index = line_txt.IndexOf(Lib.Data.IniFileUtil.EQUAL_CODE);

		        if (equal_str_index < 0) {
			        section_start_str_index = line_txt.IndexOf(Lib.Data.IniFileUtil.SECTION_START_CODE);

			        if (section_start_str_index < 0) {
				        continue;
			        }

			        section_end_str_index = line_txt.IndexOf(Lib.Data.IniFileUtil.SECTION_END_CODE, section_start_str_index + Lib.Data.IniFileUtil.SECTION_START_CODE.Length);

			        if (section_end_str_index < 0) {
				        continue;
			        }

			        string tmp_section_name = line_txt.Substring(section_start_str_index + Lib.Data.IniFileUtil.SECTION_START_CODE.Length, section_end_str_index - (section_start_str_index + Lib.Data.IniFileUtil.SECTION_START_CODE.Length));

			        if (tmp_section_name.Length > 0) {
				        section_name = tmp_section_name;

                        if (!this.data.valueContainer.ContainsKey(section_name)) {
					        this.data.valueContainer.Add(section_name, new Dictionary<string, string>());
                        }
			        }

			        continue;
		        }
	        }

            if (!this.data.valueContainer.TryGetValue(section_name, out Dictionary<string, string> key_cont)) {
		        continue;
            }

	        key = line_txt.Substring(0, equal_str_index);
	        key = key.Trim();

	        if (key.Length <= 0) {
		        continue;
	        }

	        val = line_txt.Substring(equal_str_index + Lib.Data.IniFileUtil.EQUAL_CODE.Length);
	        val = val.Trim();

	        key_cont.Add(key, val);
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

		    foreach (var key_cont in this.data.valueContainer) {
			    line_txt = Lib.Data.IniFileUtil.SECTION_START_CODE;
			    line_txt += key_cont.Key;
			    line_txt += Lib.Data.IniFileUtil.SECTION_END_CODE;

			    txt_file.data.lineTextContainer.Add(line_txt);

			    foreach (var val in key_cont.Value) {
				    line_txt = val.Key;
				    line_txt += Lib.Data.IniFileUtil.EQUAL_CODE;
				    line_txt += val.Value;

				    txt_file.data.lineTextContainer.Add(line_txt);
			    }

			    txt_file.data.lineTextContainer.Add(System.String.Empty);
		    }
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
