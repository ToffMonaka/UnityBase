﻿/**
 * @file
 * @brief MstTextTableFileファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace UnityBase.Data {
/**
 * @brief MstTextEntityクラス
 */
public class MstTextEntity
{
	public int mstTextId = 0;
	public string text = "";

    /**
     * @brief コンストラクタ
     */
    public MstTextEntity()
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

        this.mstTextId = 0;
        this.text = "";

        return;
    }
}

/**
 * @brief MstTextTableFileDataクラス
 */
public class MstTextTableFileData
{
	public UnityBase.Data.MstTextEntity[] entityArray = System.Array.Empty<UnityBase.Data.MstTextEntity>();
	public UnityBase.Data.MstTextEntity[] entityArrayByMstTextId = System.Array.Empty<UnityBase.Data.MstTextEntity>();

    /**
     * @brief コンストラクタ
     */
    public MstTextTableFileData()
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

    	this.entityArray = System.Array.Empty<UnityBase.Data.MstTextEntity>();
    	this.entityArrayByMstTextId = System.Array.Empty<UnityBase.Data.MstTextEntity>();

        return;
    }
}

/**
 * @brief MstTextTableFileクラス
 */
public class MstTextTableFile : Lib.Data.File
{
	public UnityBase.Data.MstTextTableFileData data = new UnityBase.Data.MstTextTableFileData();
	public Lib.Data.FileReadDesc<Lib.Data.CsvFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.CsvFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.CsvFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.CsvFileWriteDescData>();

    /**
     * @brief コンストラクタ
     */
    public MstTextTableFile()
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

        this.data.entityArray = new UnityBase.Data.MstTextEntity[csv_file.data.GetRowCount()];
        this.data.entityArrayByMstTextId = new UnityBase.Data.MstTextEntity[csv_file.data.GetRowCount()];

        for (int val_i = 0; val_i < csv_file.data.GetRowCount(); ++val_i) {
            var entity = new UnityBase.Data.MstTextEntity();

            entity.mstTextId = int.Parse(csv_file.data.GetValueFast(val_i, 0));
            entity.text = csv_file.data.GetValueFast(val_i, 1);

            this.data.entityArray[val_i] = entity;

            if (this.data.entityArrayByMstTextId.Length <= entity.mstTextId) {
                Lib.Array.Util.Resize(ref this.data.entityArrayByMstTextId, entity.mstTextId + 128);
            }

            this.data.entityArrayByMstTextId[entity.mstTextId] = entity;
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
