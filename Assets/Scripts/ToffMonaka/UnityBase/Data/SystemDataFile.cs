/**
 * @file
 * @brief SystemDataFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace UnityBase.Data {
/**
 * @brief SystemDataFileDataクラス
 */
public class SystemDataFileData
{
    public UnityBase.Util.LANGUAGE_TYPE systemLanguageType = UnityBase.Util.LANGUAGE_TYPE.ENGLISH;
    public float soundBgmVolume = 0.5f;
    public bool soundBgmMuteFlag = false;
    public float soundSeVolume = 0.5f;
    public bool soundSeMuteFlag = false;

    /**
     * @brief コンストラクタ
     */
    public SystemDataFileData()
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

        this.systemLanguageType = UnityBase.Util.LANGUAGE_TYPE.ENGLISH;
        this.soundBgmVolume = 0.5f;
        this.soundBgmMuteFlag = false;
        this.soundSeVolume = 0.5f;
        this.soundSeMuteFlag = false;

        return;
    }
}

/**
 * @brief SystemDataFileクラス
 */
public class SystemDataFile : Lib.Data.File
{
	public UnityBase.Data.SystemDataFileData data = new UnityBase.Data.SystemDataFileData();
	public Lib.Data.FileReadDesc<Lib.Data.IniFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.IniFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.IniFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.IniFileWriteDescData>();

    private bool _writeFlag = false;

    /**
     * @brief コンストラクタ
     */
    public SystemDataFile()
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

        {// System Section Read
	        key_cont = ini_file.data.GetKeyContainer("SYS");

	        if (key_cont != null) {
		        val = ini_file.data.GetValue(key_cont, "LANGUAGE_TYPE");

		        if (val != null) {
                    this.data.systemLanguageType = (UnityBase.Util.LANGUAGE_TYPE)(int.Parse(val));
		        }
	        }
        }

        {// Graphic Section Read
	        key_cont = ini_file.data.GetKeyContainer("GRAPHIC");

	        if (key_cont != null) {
	        }
        }

        {// Sound Section Read
	        key_cont = ini_file.data.GetKeyContainer("SOUND");

	        if (key_cont != null) {
		        val = ini_file.data.GetValue(key_cont, "BGM_VOL");

		        if (val != null) {
                    this.data.soundBgmVolume = float.Parse(val);
		        }

		        val = ini_file.data.GetValue(key_cont, "BGM_MUTE_FLG");

		        if (val != null) {
                    this.data.soundBgmMuteFlag = System.Convert.ToBoolean(int.Parse(val));
		        }

		        val = ini_file.data.GetValue(key_cont, "SE_VOL");

		        if (val != null) {
                    this.data.soundSeVolume = float.Parse(val);
		        }

		        val = ini_file.data.GetValue(key_cont, "SE_MUTE_FLG");

		        if (val != null) {
                    this.data.soundSeMuteFlag = System.Convert.ToBoolean(int.Parse(val));
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

        {// System Section Write
	        txt_file.data.lineTextContainer.Add(section_start_str + "SYS" + section_end_str);
	        txt_file.data.lineTextContainer.Add("LANGUAGE_TYPE" + equal_str + ((int)this.data.systemLanguageType).ToString());
	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        {// Graphic Section Write
	        txt_file.data.lineTextContainer.Add(section_start_str + "GRAPHIC" + section_end_str);
	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        {// Sound Section Write
	        txt_file.data.lineTextContainer.Add(section_start_str + "SOUND" + section_end_str);
	        txt_file.data.lineTextContainer.Add("BGM_VOL" + equal_str + this.data.soundBgmVolume.ToString());
	        txt_file.data.lineTextContainer.Add("BGM_MUTE_FLG" + equal_str + System.Convert.ToInt32(this.data.soundBgmMuteFlag).ToString());
	        txt_file.data.lineTextContainer.Add("SE_VOL" + equal_str + this.data.soundSeVolume.ToString());
	        txt_file.data.lineTextContainer.Add("SE_MUTE_FLG" + equal_str + System.Convert.ToInt32(this.data.soundSeMuteFlag).ToString());
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
