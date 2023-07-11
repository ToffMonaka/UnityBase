/**
 * @file
 * @brief MstStringTableFileファイル
 */


using UnityEngine;


namespace ToffMonaka.UnityBase.Data {
/**
 * @brief MstStringTableFileDataクラス
 */
public class MstStringTableFileData
{
    /**
     * @brief コンストラクタ
     */
    public MstStringTableFileData()
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

        return;
    }
}

/**
 * @brief MstStringTableFileクラス
 */
public class MstStringTableFile : ToffMonaka.Lib.Data.File
{
	public ToffMonaka.UnityBase.Data.MstStringTableFileData data = new ToffMonaka.UnityBase.Data.MstStringTableFileData();
	public ToffMonaka.Lib.Data.FileReadDesc<ToffMonaka.Lib.Data.CsvFileReadDescData> readDesc = new ToffMonaka.Lib.Data.FileReadDesc<ToffMonaka.Lib.Data.CsvFileReadDescData>();
	public ToffMonaka.Lib.Data.FileWriteDesc<ToffMonaka.Lib.Data.CsvFileWriteDescData> writeDesc = new ToffMonaka.Lib.Data.FileWriteDesc<ToffMonaka.Lib.Data.CsvFileWriteDescData>();

    /**
     * @brief コンストラクタ
     */
    public MstStringTableFile()
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
	    var desc_dat = this.readDesc.GetDataByParent();

        var csv_file = new ToffMonaka.Lib.Data.CsvFile();
        int csv_file_read_res;

        csv_file.readDesc.parentData = desc_dat;

        if ((csv_file_read_res = csv_file.Read()) < 0) {
	        return (csv_file_read_res);
        }

        this.data.Init();

        if (csv_file.data.valueArray.Length <= 0) {
	        return (0);
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
        return (-1);
    }
}
}
