/**
 * @file
 * @brief IniFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka.Lib.File {
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
     * @brief GetValueNameContainer関数
     * @param section_name (section_name)
     * @return val_name_cont (valalue_name_container)<br>
     * null=失敗
     */
    public Dictionary<string, string> GetValueNameContainer(string section_name)
    {
        Dictionary<string, string> val_name_cont;

        if (!this.valueContainer.TryGetValue(section_name, out val_name_cont)) {
    	    return (null);
        }

	    return (val_name_cont);
    }

    /**
     * @brief GetValue関数
     * @param val_name_cont (valalue_name_container)
     * @param val_name (value_name)
     * @return val (value)<br>
     * null=失敗
     */
    public string GetValue(Dictionary<string, string> val_name_cont, string val_name)
    {
        string val;

        if (!val_name_cont.TryGetValue(val_name, out val)) {
    	    return (null);
        }

	    return (val);
    }

    /**
     * @brief GetValue関数
     * @param section_name (section_name)
     * @param val_name (value_name)
     * @return val (value)<br>
     * null=失敗
     */
    public string GetValue(string section_name, string val_name)
    {
        Dictionary<string, string> val_name_cont;

        if (!this.valueContainer.TryGetValue(section_name, out val_name_cont)) {
    	    return (null);
        }

        string val;

        if (!val_name_cont.TryGetValue(val_name, out val)) {
    	    return (null);
        }

	    return (val);
    }
}

/**
 * @brief IniFileReadDescDataクラス
 */
public class IniFileReadDescData : ToffMonaka.Lib.File.TextFileReadDescData
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
public class IniFileWriteDescData : ToffMonaka.Lib.File.TextFileWriteDescData
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
public class IniFile : ToffMonaka.Lib.File.File
{
	public ToffMonaka.Lib.File.IniFileData data = new ToffMonaka.Lib.File.IniFileData();
	public ToffMonaka.Lib.File.FileReadDesc<ToffMonaka.Lib.File.IniFileReadDescData> readDesc = new ToffMonaka.Lib.File.FileReadDesc<ToffMonaka.Lib.File.IniFileReadDescData>();
	public ToffMonaka.Lib.File.FileWriteDesc<ToffMonaka.Lib.File.IniFileWriteDescData> writeDesc = new ToffMonaka.Lib.File.FileWriteDesc<ToffMonaka.Lib.File.IniFileWriteDescData>();

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
     * 0未満=失敗
     */
    protected override int _OnRead()
    {
        const string section_start_str = "[";
        const string section_end_str = "]";
        const string equal_str = "=";
        const string comment_str = "#";

	    var desc_dat = this.readDesc.GetDataByParent();

        var txt_file = new ToffMonaka.Lib.File.TextFile();

        txt_file.readDesc.parentData = desc_dat;

        if (txt_file.Read() < 0) {
	        return (-1);
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
        string val_name = "";
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

            Dictionary<string, string> val_name_cont;

            if (!this.data.valueContainer.TryGetValue(section_name, out val_name_cont)) {
		        continue;
            }

	        val_name = line_str.Substring(0, equal_str_index);
	        val_name = val_name.Trim();

	        if (val_name.Length <= 0) {
		        continue;
	        }

	        val = line_str.Substring(equal_str_index + equal_str.Length);
	        val = val.Trim();

	        val_name_cont.Add(val_name, val);
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

        var txt_file = new ToffMonaka.Lib.File.TextFile();

        if (this.data.valueContainer.Count > 0) {
		    string line_str;

		    foreach (var val_name_cont in this.data.valueContainer) {
			    line_str = section_start_str;
			    line_str += val_name_cont.Key;
			    line_str += section_end_str;

			    txt_file.data.lineStringContainer.Add(line_str);

			    foreach (var val in val_name_cont.Value) {
				    line_str = val.Key;
				    line_str += equal_str;
				    line_str += val.Value;

				    txt_file.data.lineStringContainer.Add(line_str);
			    }

			    txt_file.data.lineStringContainer.Add(System.String.Empty);
		    }
        }

        txt_file.writeDesc.parentData = desc_dat;

        if (txt_file.Write() < 0) {
	        return (-1);
        }

        return (0);
    }
}
}
