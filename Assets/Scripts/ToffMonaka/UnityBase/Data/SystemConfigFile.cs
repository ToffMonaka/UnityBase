/**
 * @file
 * @brief SystemConfigFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka {
namespace UnityBase.Data {
/**
 * @brief SystemConfigFileDataクラス
 */
public class SystemConfigFileData
{
    public UnityBase.Util.LANGUAGE_TYPE systemLanguageType;
    public float soundBgmVolume;
    public bool soundBgmMuteFlag;
    public float soundSeVolume;
    public bool soundSeMuteFlag;

    /**
     * @brief コンストラクタ
     */
    public SystemConfigFileData()
    {
        this.Init();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
		switch (Application.systemLanguage) {
		case SystemLanguage.Japanese: {
            this.systemLanguageType = UnityBase.Util.LANGUAGE_TYPE.JAPANESE;

			break;
		}
		default: {
            this.systemLanguageType = UnityBase.Util.LANGUAGE_TYPE.ENGLISH;

			break;
		}
		}

        this.soundBgmVolume = 0.5f;
        this.soundBgmMuteFlag = false;
        this.soundSeVolume = 0.5f;
        this.soundSeMuteFlag = false;

        return;
    }
}

/**
 * @brief SystemConfigFileクラス
 */
public class SystemConfigFile : Lib.Data.File
{
	public UnityBase.Data.SystemConfigFileData data = new();
	public Lib.Data.FileReadDesc<Lib.Data.IniFileReadDescData> readDesc = new();
	public Lib.Data.FileWriteDesc<Lib.Data.IniFileWriteDescData> writeDesc = new();

    private bool _writeFlag;
    private bool _deleteFlag;

    /**
     * @brief コンストラクタ
     */
    public SystemConfigFile() : base()
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
        this._writeFlag = false;
        this._deleteFlag = false;

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
        this._writeFlag = false;

	    var desc_dat = this.writeDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    return (-1);
	    }

        var txt_file = new Lib.Data.TextFile();
        int txt_file_write_result_val;

        {// System Section Write
	        txt_file.data.lineTextContainer.Add(Lib.Data.IniFileUtil.SECTION_START_CODE + "SYS" + Lib.Data.IniFileUtil.SECTION_END_CODE);
	        txt_file.data.lineTextContainer.Add("LANGUAGE_TYPE" + Lib.Data.IniFileUtil.EQUAL_CODE + ((int)this.data.systemLanguageType).ToString());
	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        {// Graphic Section Write
	        txt_file.data.lineTextContainer.Add(Lib.Data.IniFileUtil.SECTION_START_CODE + "GRAPHIC" + Lib.Data.IniFileUtil.SECTION_END_CODE);
	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        {// Sound Section Write
	        txt_file.data.lineTextContainer.Add(Lib.Data.IniFileUtil.SECTION_START_CODE + "SOUND" + Lib.Data.IniFileUtil.SECTION_END_CODE);
	        txt_file.data.lineTextContainer.Add("BGM_VOL" + Lib.Data.IniFileUtil.EQUAL_CODE + this.data.soundBgmVolume.ToString());
	        txt_file.data.lineTextContainer.Add("BGM_MUTE_FLG" + Lib.Data.IniFileUtil.EQUAL_CODE + System.Convert.ToInt32(this.data.soundBgmMuteFlag).ToString());
	        txt_file.data.lineTextContainer.Add("SE_VOL" + Lib.Data.IniFileUtil.EQUAL_CODE + this.data.soundSeVolume.ToString());
	        txt_file.data.lineTextContainer.Add("SE_MUTE_FLG" + Lib.Data.IniFileUtil.EQUAL_CODE + System.Convert.ToInt32(this.data.soundSeMuteFlag).ToString());
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

    /**
     * @brief Delete関数
     * @param delay_flg (delay_flag)
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int Delete(bool delay_flg = false)
    {
        if (delay_flg) {
            this._deleteFlag = true;

            return (0);
        }

        this._deleteFlag = false;

        this.data.Init();

        return (this.Write());
    }

    /**
     * @brief GetDeleteFlag関数
     * @return delete_flg (delete_flag)
     */
    public bool GetDeleteFlag()
    {
        return (this._deleteFlag);
    }
}
}
}
