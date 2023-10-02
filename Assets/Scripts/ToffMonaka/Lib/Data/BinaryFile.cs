/**
 * @file
 * @brief BinaryFileファイル
 */


using UnityEngine;
using UnityEngine.AddressableAssets;
using System.IO;


namespace ToffMonaka {
namespace Lib.Data {
/**
 * @brief BinaryFileDataクラス
 */
public class BinaryFileData
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
    public virtual void Init()
    {
        this._Release();

        this.buffer = System.Array.Empty<byte>();

        return;
    }
}

/**
 * @brief BinaryFileReadDescDataクラス
 */
public class BinaryFileReadDescData : Lib.Data.FileReadDescData
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
public class BinaryFileWriteDescData : Lib.Data.FileWriteDescData
{
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
public class BinaryFile : Lib.Data.File
{
	public Lib.Data.BinaryFileData data = new Lib.Data.BinaryFileData();
	public Lib.Data.FileReadDesc<Lib.Data.BinaryFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.BinaryFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.BinaryFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.BinaryFileWriteDescData>();

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
     * @return result_val (result_value)<br>
     * 0未満=失敗,-2=ファイル存在無し
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

        byte[] buf = System.Array.Empty<byte>();

        if (desc_dat.addressablesFlag) {
            var asset = Addressables.LoadAssetAsync<TextAsset>(desc_dat.filePath).WaitForCompletion();

            if (asset == null) {
                return (-2);
            }

            buf = (byte[])asset.bytes.Clone();

            Addressables.Release(asset);
        } else {
	        var read_buf = new byte[2048];
	        int read_size;
            int read_result_val = 0;

            try {
                using (var fs = new FileStream(desc_dat.filePath, FileMode.Open, FileAccess.Read)) {
    			    while (true) {
                        read_size = fs.Read(read_buf, 0, read_buf.Length);

				        if (read_size > 0) {
                            byte[] tmp_buf = new byte[buf.Length + read_size];

                            System.Buffer.BlockCopy(buf, 0, tmp_buf, 0, buf.Length);
                            System.Buffer.BlockCopy(read_buf, 0, tmp_buf, buf.Length, read_size);

                            buf = tmp_buf;
				        } else {
					        break;
				        }
                    }
                }
            } catch (FileNotFoundException e) {
                Debug.Log(e);

                read_result_val = -2;
            } catch (IOException e) {
                Debug.Log(e);

                read_result_val = -1;
            }

            if (read_result_val < 0) {
                return (read_result_val);
            }
        }

		this.data.Init();

	    if (buf.Length > 0) {
		    this.data.buffer = buf;
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
	    var desc_dat = this.writeDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    return (-1);
	    }

        string dir_path = Path.GetDirectoryName(desc_dat.filePath);

        if (dir_path.Length > 0) {
            if (!Directory.Exists(dir_path)) {
                Directory.CreateDirectory(dir_path);
            }
        }

	    int buf_index = 0;

	    var write_buf = new byte[2048];
	    int write_size;
        int write_result_val = 0;

        try {
            using (var fs = new FileStream(desc_dat.filePath, (desc_dat.appendFlag) ? FileMode.Append : FileMode.Create, FileAccess.Write)) {
                while (true) {
				    write_size = System.Math.Min(this.data.buffer.Length - buf_index, write_buf.Length);

                    System.Buffer.BlockCopy(this.data.buffer, buf_index, write_buf, 0, write_size);

				    fs.Write(write_buf, 0, write_size);

				    buf_index += write_size;

				    if (buf_index >= this.data.buffer.Length) {
					    break;
				    }
                }
            }
        } catch (IOException e) {
            Debug.Log(e);

            write_result_val = -1;
        }

        if (write_result_val < 0) {
            return (write_result_val);
        }

        return (0);
    }
}
}
}
