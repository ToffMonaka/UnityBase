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
 * @brief BinaryFileUtilクラス
 */
public static class BinaryFileUtil
{
}

/**
 * @brief BinaryFileDataクラス
 */
public class BinaryFileData
{
    public Lib.Buffer.Buffer buffer = new();

    /**
     * @brief コンストラクタ
     */
    public BinaryFileData()
    {
        this.Init();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this.buffer.Init();

        return;
    }
}

/**
 * @brief BinaryFileReadDescDataクラス
 */
public class BinaryFileReadDescData : Lib.Data.FileReadDescData
{
    public Lib.Buffer.Buffer buffer = new();

    /**
     * @brief コンストラクタ
     */
    public BinaryFileReadDescData() : base()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        base.Init();

        this.buffer.Init();

        return;
    }

    /**
     * @brief IsEmpty関数
     * @return result_flg (result_flag)<br>
     * false=非空,true=空
     */
    public override bool IsEmpty()
    {
	    if (this.buffer.GetLength() > 0) {
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
    public BinaryFileWriteDescData() : base()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
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
	public Lib.Data.BinaryFileData data = new();
	public Lib.Data.FileReadDesc<Lib.Data.BinaryFileReadDescData> readDesc = new();
	public Lib.Data.FileWriteDesc<Lib.Data.BinaryFileWriteDescData> writeDesc = new();

    /**
     * @brief コンストラクタ
     */
    public BinaryFile() : base()
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

		    if (desc_dat.buffer.GetLength() > 0) {
			    this.data.buffer.Init(desc_dat.buffer);
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
		    this.data.buffer.Init(buf, buf.Length, true);
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
        if (this.data.buffer.GetWriteResultValue() < 0) {
	        return (-1);
        }

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

        byte[] buf = this.data.buffer.GetArray();
        int buf_size = this.data.buffer.GetLength();
	    int buf_index = 0;

	    var write_buf = new byte[2048];
	    int write_size;
        int write_result_val = 0;

        try {
            using (var fs = new FileStream(desc_dat.filePath, (desc_dat.appendFlag) ? FileMode.Append : FileMode.Create, FileAccess.Write)) {
                while (true) {
				    write_size = System.Math.Min(buf_size - buf_index, write_buf.Length);

                    System.Buffer.BlockCopy(buf, buf_index, write_buf, 0, write_size);

				    fs.Write(write_buf, 0, write_size);

				    buf_index += write_size;

				    if (buf_index >= buf_size) {
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
