﻿/**
 * @file
 * @brief MstStringTableFileファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Data {
/**
 * @brief MstStringEntityクラス
 */
public class MstStringEntity
{
	public int mstStringId = 0;
	public string string_ = "";

    /**
     * @brief コンストラクタ
     */
    public MstStringEntity()
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

        this.mstStringId = 0;
        this.string_ = "";

        return;
    }
}

/**
 * @brief MstStringTableFileDataクラス
 */
public class MstStringTableFileData
{
	public UnityBase.Data.MstStringEntity[] entityArray = System.Array.Empty<UnityBase.Data.MstStringEntity>();

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

    	this.entityArray = System.Array.Empty<UnityBase.Data.MstStringEntity>();

        return;
    }

    /**
     * @brief GetEntity関数
     * @param mst_str_id (mst_string_id)
     * @return entity (entity)<br>
     * null=失敗
     */
    public UnityBase.Data.MstStringEntity GetEntity(int mst_str_id)
    {
	    if (mst_str_id >= this.entityArray.Length) {
		    return (null);
	    }

	    return (this.entityArray[mst_str_id]);
    }

    /**
     * @brief GetEntityFast関数
     * @param mst_str_id (mst_string_id)
     * @return entity (entity)<br>
     * null=失敗
     */
    public UnityBase.Data.MstStringEntity GetEntityFast(int mst_str_id)
    {
	    return (this.entityArray[mst_str_id]);
    }
}

/**
 * @brief MstStringTableFileクラス
 */
public class MstStringTableFile : Lib.Data.File
{
	public UnityBase.Data.MstStringTableFileData data = new UnityBase.Data.MstStringTableFileData();
	public Lib.Data.FileReadDesc<Lib.Data.CsvFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.CsvFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.CsvFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.CsvFileWriteDescData>();

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
     * @return result_val (result_value)<br>
     * 0未満=失敗,-2=ファイル存在無し
     */
    protected override int _OnRead()
    {
	    var desc_dat = this.readDesc.GetDataByParent();

        var csv_file = new Lib.Data.CsvFile();
        int csv_file_read_result_val;

        csv_file.readDesc.parentData = desc_dat;

        if ((csv_file_read_result_val = csv_file.Read()) < 0) {
	        return (csv_file_read_result_val);
        }

        this.data.Init();

        if (csv_file.data.GetRowCount() <= 0) {
	        return (0);
        }

        if (csv_file.data.GetColumnCount() < 2) {
	        return (-1);
        }

        this.data.entityArray = new UnityBase.Data.MstStringEntity[csv_file.data.GetRowCount()];

        for (int val_i = 0; val_i < csv_file.data.GetRowCount(); ++val_i) {
            var entity = new UnityBase.Data.MstStringEntity();

            entity.mstStringId = int.Parse(csv_file.data.GetValueFast(val_i, 0));
            entity.string_ = csv_file.data.GetValueFast(val_i, 1);

            this.data.entityArray[val_i] = entity;
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
        return (-1);
    }
}
}
}
