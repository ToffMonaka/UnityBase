/**
 * @file
 * @brief UserDataFileファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Data {
/**
 * @brief UserDataFileDataクラス
 */
public class UserDataFileData
{
    /**
     * @brief コンストラクタ
     */
    public UserDataFileData()
    {
        this.Init();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        return;
    }
}

/**
 * @brief UserDataFileクラス
 */
public class UserDataFile : Lib.Data.File
{
	public UnityBase.Data.UserDataFileData data = new();
	public Lib.Data.FileReadDesc<Lib.Data.BinaryFileReadDescData> readDesc = new();
	public Lib.Data.FileWriteDesc<Lib.Data.BinaryFileWriteDescData> writeDesc = new();

    private bool _writeFlag;
    private bool _deleteFlag;

    /**
     * @brief コンストラクタ
     */
    public UserDataFile() : base()
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

        var bin_file = new Lib.Data.BinaryFile();
        int bin_file_read_result_val;

        bin_file.readDesc.parentData = desc_dat;

        if ((bin_file_read_result_val = bin_file.Read()) < 0) {
	        return (bin_file_read_result_val);
        }

        this.data.Init();

        if (bin_file.data.buffer.GetLength() <= 0) {
	        return (0);
        }

        int section_cnt = bin_file.data.buffer.ReadIntB();

        for (int section_i = 0; section_i < section_cnt; ++section_i) {
            /*
            int section_type = bin_file.data.buffer.ReadIntB();

		    switch (section_type) {
		    case 1: {// Section Read
			    break;
		    }
		    }
            */
        }

        if (bin_file.data.buffer.GetReadResultValue() < 0) {
            this.data.Init();

	        return (-1);
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

        var bin_file = new Lib.Data.BinaryFile();
        int bin_file_write_result_val;

        int section_cnt = 0;

        bin_file.data.buffer.WriteIntB(section_cnt);

        /*
        {// Section Write
            int section_type = 1;

            bin_file.data.buffer.WriteIntB(section_type);
        }
        */

        bin_file.writeDesc.parentData = desc_dat;

        if ((bin_file_write_result_val = bin_file.Write()) < 0) {
	        return (bin_file_write_result_val);
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
