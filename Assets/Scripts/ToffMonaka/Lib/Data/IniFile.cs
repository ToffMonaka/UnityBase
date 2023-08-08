/**
 * @file
 * @brief IniFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace Lib.Data {
/**
 * @brief IniFileDataクラス
 */
public class IniFileData
{
	public Dictionary<string, Dictionary<string, string>> valueContainer = new Dictionary<string, Dictionary<string, string>>();

    /**
     * @brief コンストラクタ
     */
    public IniFileData()
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
     * @brief GetKeyContainer関数
     * @param section_name (section_name)
     * @return key_cont (key_container)<br>
     * null=失敗
     */
    public Dictionary<string, string> GetKeyContainer(string section_name)
    {
        Dictionary<string, string> key_cont;

        if (!this.valueContainer.TryGetValue(section_name, out key_cont)) {
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
        string val;

        if (!key_cont.TryGetValue(key, out val)) {
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
        Dictionary<string, string> key_cont;

        if (!this.valueContainer.TryGetValue(section_name, out key_cont)) {
    	    return (null);
        }

        string val;

        if (!key_cont.TryGetValue(key, out val)) {
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
    public IniFileReadDescData()
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
 * @brief IniFileWriteDescDataクラス
 */
public class IniFileWriteDescData : Lib.Data.TextFileWriteDescData
{
    /**
     * @brief コンストラクタ
     */
    public IniFileWriteDescData()
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
 * @brief IniFileクラス
 */
public class IniFile : Lib.Data.File
{
	public Lib.Data.IniFileData data = new Lib.Data.IniFileData();
	public Lib.Data.FileReadDesc<Lib.Data.IniFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.IniFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.IniFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.IniFileWriteDescData>();

    /**
     * @brief コンストラクタ
     */
    public IniFile()
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
        const string section_start_str = "[";
        const string section_end_str = "]";
        const string equal_str = "=";
        const string comment_str = ";";

	    var desc_dat = this.readDesc.GetDataByParent();

        var txt_file = new Lib.Data.TextFile();
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
        int section_start_str_index;
        int section_end_str_index;
        int equal_str_index;
        int comment_str_index;
        string section_name = "";
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
			        section_start_str_index = line_str.IndexOf(section_start_str);

			        if (section_start_str_index < 0) {
				        continue;
			        }

			        section_end_str_index = line_str.IndexOf(section_end_str, section_start_str_index + section_start_str.Length);

			        if (section_end_str_index < 0) {
				        continue;
			        }

			        string tmp_section_name = line_str.Substring(section_start_str_index + section_start_str.Length, section_end_str_index - (section_start_str_index + section_start_str.Length));

			        if (tmp_section_name.Length > 0) {
				        section_name = tmp_section_name;

                        if (!this.data.valueContainer.ContainsKey(section_name)) {
					        this.data.valueContainer.Add(section_name, new Dictionary<string, string>());
                        }
			        }

			        continue;
		        }
	        }

            Dictionary<string, string> key_cont;

            if (!this.data.valueContainer.TryGetValue(section_name, out key_cont)) {
		        continue;
            }

	        key = line_str.Substring(0, equal_str_index);
	        key = key.Trim();

	        if (key.Length <= 0) {
		        continue;
	        }

	        val = line_str.Substring(equal_str_index + equal_str.Length);
	        val = val.Trim();

	        key_cont.Add(key, val);
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
        const string section_start_str = "[";
        const string section_end_str = "]";
        const string equal_str = "=";

	    var desc_dat = this.writeDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    return (-1);
	    }

        var txt_file = new Lib.Data.TextFile();
        int txt_file_write_res;

        if (this.data.valueContainer.Count > 0) {
		    string line_str;

		    foreach (var key_cont in this.data.valueContainer) {
			    line_str = section_start_str;
			    line_str += key_cont.Key;
			    line_str += section_end_str;

			    txt_file.data.lineStringContainer.Add(line_str);

			    foreach (var val in key_cont.Value) {
				    line_str = val.Key;
				    line_str += equal_str;
				    line_str += val.Value;

				    txt_file.data.lineStringContainer.Add(line_str);
			    }

			    txt_file.data.lineStringContainer.Add(System.String.Empty);
		    }
        }

        txt_file.writeDesc.parentData = desc_dat;

        if ((txt_file_write_res = txt_file.Write()) < 0) {
	        return (txt_file_write_res);
        }

        return (0);
    }
}
}
}
