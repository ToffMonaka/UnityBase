/**
 * @file
 * @brief BinaryFileファイル
 */


using UnityEngine;
using System;
using System.IO;


namespace ToffMonaka.Lib.File {
/**
 * @brief BinaryFileDataクラス
 */
public class BinaryFileData : ToffMonaka.Lib.File.FileData
{
    public byte[] buffer = System.Array.Empty<byte>();

    /**
     * @brief コンストラクタ
     */
    public BinaryFileData()
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

        this.buffer = System.Array.Empty<byte>();

        base.Init();

        return;
    }
}

/**
 * @brief BinaryFileReadDescDataクラス
 */
public class BinaryFileReadDescData : ToffMonaka.Lib.File.FileReadDescData
{
    public byte[] buffer = System.Array.Empty<byte>();

    /**
     * @brief コンストラクタ
     */
    public BinaryFileReadDescData()
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

        this.buffer = System.Array.Empty<byte>();

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
	    if (this.buffer.Length > 0) {
		    return (false);
	    }

        return (base.IsEmpty());
    }
}

/**
 * @brief BinaryFileWriteDescDataクラス
 */
public class BinaryFileWriteDescData : ToffMonaka.Lib.File.FileWriteDescData
{
    public bool appendFlag = false;

    /**
     * @brief コンストラクタ
     */
    public BinaryFileWriteDescData()
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

        this.appendFlag = false;

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
 * @brief BinaryFileクラス
 */
public class BinaryFile : ToffMonaka.Lib.File.File
{
	public ToffMonaka.Lib.File.BinaryFileData data;
	public ToffMonaka.Lib.File.FileReadDesc<ToffMonaka.Lib.File.BinaryFileReadDescData> readDesc;
	public ToffMonaka.Lib.File.FileWriteDesc<ToffMonaka.Lib.File.BinaryFileWriteDescData> writeDesc;

    /**
     * @brief コンストラクタ
     */
    public BinaryFile()
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

	    if (desc_dat.filePath.Length <= 0) {
		    this.data.Init();

		    if (desc_dat.buffer.Length > 0) {
			    this.data.buffer = (byte[])desc_dat.buffer.Clone();
		    }

		    return (0);
	    }

		this.data.Init();

        return (0);
    }

    /**
     * @brief _OnWrite関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnWrite()
    {
	    var desc_dat = this.writeDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    return (-1);
	    }

        int fs_res = 0;
	    int buf_index = 0;
	    var write_buf = new byte[2048];
	    int write_size = 0;

        try {
            using (var fs = new FileStream(Application.persistentDataPath + "/" + desc_dat.filePath, (this.writeDesc.data.appendFlag) ? FileMode.Append : FileMode.Create, FileAccess.Write)) {
                while (true) {
				    write_size = Math.Min(this.data.buffer.Length - buf_index, write_buf.Length);

                    Buffer.BlockCopy(this.data.buffer, buf_index, write_buf, 0, write_size);

				    fs.Write(write_buf, 0, write_size);

				    buf_index += write_size;

				    if (buf_index >= this.data.buffer.Length) {
					    break;
				    }
                }
            }
        } catch (IOException e) {
            Debug.Log(e);

            fs_res = -1;
        }

        return (fs_res);
    }
}
}
