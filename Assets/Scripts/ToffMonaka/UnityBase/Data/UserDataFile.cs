/**
 * @file
 * @brief UserDataFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace UnityBase.Data {
/**
 * @brief UserDataFileDataクラス
 */
public class UserDataFileData
{
    public int testValue = 0;

    /**
     * @brief コンストラクタ
     */
    public UserDataFileData()
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

        this.testValue = 0;

        return;
    }
}

/**
 * @brief UserDataFileクラス
 */
public class UserDataFile : Lib.Data.File
{
	public UnityBase.Data.UserDataFileData data = new UnityBase.Data.UserDataFileData();
	public Lib.Data.FileReadDesc<Lib.Data.IniFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.IniFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.IniFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.IniFileWriteDescData>();

    private bool _writeFlag = false;

    /**
     * @brief コンストラクタ
     */
    public UserDataFile()
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
        this._writeFlag = false;

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
        if (this._writeFlag) {
            this.Write();
        }

	    var desc_dat = this.readDesc.GetDataByParent();

        var ini_file = new Lib.Data.IniFile();
        int ini_file_read_result_val;

        ini_file.readDesc.parentData = desc_dat;

        if ((ini_file_read_result_val = ini_file.Read()) < 0) {
	        return (ini_file_read_result_val);
        }

        this.data.Init();

        if (ini_file.data.valueContainer.Count <= 0) {
	        return (0);
        }

        Dictionary<string, string> key_cont;
        string val;

        {// Test Section Read
	        key_cont = ini_file.data.GetKeyContainer("TEST");

	        if (key_cont != null) {
		        val = ini_file.data.GetValue(key_cont, "VAL");

		        if (val != null) {
                    this.data.testValue = int.Parse(val);
		        }
	        }
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
	    const string section_start_str = "[";
	    const string section_end_str = "]";
	    const string equal_str = "=";

        this._writeFlag = false;

	    var desc_dat = this.writeDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    return (-1);
	    }

        var txt_file = new Lib.Data.TextFile();
        int txt_file_write_result_val;

        {// Test Section Write
	        txt_file.data.lineTextContainer.Add(section_start_str + "TEST" + section_end_str);
	        txt_file.data.lineTextContainer.Add("VAL" + equal_str + this.data.testValue.ToString());
	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        txt_file.writeDesc.parentData = desc_dat;

        if ((txt_file_write_result_val = txt_file.Write()) < 0) {
	        return (txt_file_write_result_val);
        }

        return (0);
    }

    /**
     * @brief Write関数
     * @param delay_flg (delay_flag)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int Write(bool delay_flg)
    {
        if (delay_flg) {
            this._writeFlag = true;

            return (0);
        }

        return (this.Write());
    }

    /**
     * @brief GetWriteFlag関数
     * @return write_flg (write_flag)
     */
    public bool GetWriteFlag()
    {
        return (this._writeFlag);
    }
}
}
}
