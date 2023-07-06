﻿/**
 * @file
 * @brief SystemConfigFileファイル
 */


using UnityEngine;
using System.Collections.Generic;


namespace ToffMonaka.UnityBase.Data {
/**
 * @brief SystemConfigFileDataクラス
 */
public class SystemConfigFileData
{
    public ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.ENGLISH;
    public float soundBgmVolume = 0.5f;
    public bool soundBgmMuteFlag = false;
    public float soundSeVolume = 0.5f;
    public bool soundSeMuteFlag = false;

    /**
     * @brief コンストラクタ
     */
    public SystemConfigFileData()
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

        this.languageType = ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE.ENGLISH;
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
public class SystemConfigFile : ToffMonaka.Lib.File.File
{
	public ToffMonaka.UnityBase.Data.SystemConfigFileData data = new ToffMonaka.UnityBase.Data.SystemConfigFileData();
	public ToffMonaka.Lib.File.FileReadDesc<ToffMonaka.Lib.File.IniFileReadDescData> readDesc = new ToffMonaka.Lib.File.FileReadDesc<ToffMonaka.Lib.File.IniFileReadDescData>();
	public ToffMonaka.Lib.File.FileWriteDesc<ToffMonaka.Lib.File.IniFileWriteDescData> writeDesc = new ToffMonaka.Lib.File.FileWriteDesc<ToffMonaka.Lib.File.IniFileWriteDescData>();

    /**
     * @brief コンストラクタ
     */
    public SystemConfigFile()
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
	    var desc_dat = this.readDesc.GetDataByParent();

        var ini_file = new ToffMonaka.Lib.File.IniFile();

        ini_file.readDesc.parentData = desc_dat;

        if (ini_file.Read() < 0) {
	        return (-1);
        }

        this.data.Init();

        if (ini_file.data.valueContainer.Count <= 0) {
	        return (0);
        }

        Dictionary<string, string> val_name_cont;
        string val;

        {// Application Section Read
	        val_name_cont = ini_file.data.GetValueNameContainer("APPLICATION");

	        if (val_name_cont != null) {
		        val = ini_file.data.GetValue(val_name_cont, "LANGUAGE_TYPE");

		        if (val != null) {
                    this.data.languageType = (ToffMonaka.Lib.Constant.Util.LANGUAGE_TYPE)(int.Parse(val));
		        }
	        }
        }

        {// Graphic Section Read
	        val_name_cont = ini_file.data.GetValueNameContainer("GRAPHIC");

	        if (val_name_cont != null) {
	        }
        }

        {// Sound Section Read
	        val_name_cont = ini_file.data.GetValueNameContainer("SOUND");

	        if (val_name_cont != null) {
		        val = ini_file.data.GetValue(val_name_cont, "BGM_VOLUME");

		        if (val != null) {
                    this.data.soundBgmVolume = float.Parse(val);
		        }

		        val = ini_file.data.GetValue(val_name_cont, "BGM_MUTE_FLAG");

		        if (val != null) {
                    this.data.soundBgmMuteFlag = System.Convert.ToBoolean(int.Parse(val));
		        }

		        val = ini_file.data.GetValue(val_name_cont, "SE_VOLUME");

		        if (val != null) {
                    this.data.soundSeVolume = float.Parse(val);
		        }

		        val = ini_file.data.GetValue(val_name_cont, "SE_MUTE_FLAG");

		        if (val != null) {
                    this.data.soundSeMuteFlag = System.Convert.ToBoolean(int.Parse(val));
		        }
	        }
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

        {// Application Section Write
	        txt_file.data.lineTextContainer.Add(section_start_str + "APPLICATION" + section_end_str);
	        txt_file.data.lineTextContainer.Add("LANGUAGE_TYPE" + equal_str + ((int)this.data.languageType).ToString());
	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        {// Graphic Section Write
	        txt_file.data.lineTextContainer.Add(section_start_str + "GRAPHIC" + section_end_str);
	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        {// Sound Section Write
	        txt_file.data.lineTextContainer.Add(section_start_str + "SOUND" + section_end_str);
	        txt_file.data.lineTextContainer.Add("BGM_VOLUME" + equal_str + this.data.soundBgmVolume.ToString());
	        txt_file.data.lineTextContainer.Add("BGM_MUTE_FLAG" + equal_str + System.Convert.ToInt32(this.data.soundBgmMuteFlag).ToString());
	        txt_file.data.lineTextContainer.Add("SE_VOLUME" + equal_str + this.data.soundSeVolume.ToString());
	        txt_file.data.lineTextContainer.Add("SE_MUTE_FLAG" + equal_str + System.Convert.ToInt32(this.data.soundSeMuteFlag).ToString());
	        txt_file.data.lineTextContainer.Add(System.String.Empty);
        }

        txt_file.writeDesc.parentData = desc_dat;

        if (txt_file.Write() < 0) {
	        return (-1);
        }

        return (0);
    }
}
}
