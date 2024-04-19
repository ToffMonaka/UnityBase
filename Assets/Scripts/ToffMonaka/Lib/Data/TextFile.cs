/**
 * @file
 * @brief TextFileファイル
 */


using UnityEngine;
using System.Collections.Generic;
using System.Text;


namespace ToffMonaka {
namespace Lib.Data {
/**
 * @brief TextFileUtilクラス
 */
public static class TextFileUtil
{
}

/**
 * @brief TextFileDataクラス
 */
public class TextFileData
{
    public List<string> lineTextContainer = new();

    /**
     * @brief コンストラクタ
     */
    public TextFileData()
    {
        this.Init();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this.lineTextContainer.Clear();

        return;
    }
}

/**
 * @brief TextFileReadDescDataクラス
 */
public class TextFileReadDescData : Lib.Data.BinaryFileReadDescData
{
    public string text;
    public string charset;
    public Lib.String.Util.NEWLINE_TYPE newlineType;

    /**
     * @brief コンストラクタ
     */
    public TextFileReadDescData() : base()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        base.Init();

        this.text = "";
        this.charset = "utf-8";
        this.newlineType = Lib.String.Util.NEWLINE_TYPE.CRLF;

        return;
    }

    /**
     * @brief IsEmpty関数
     * @return result_flg (result_flag)<br>
     * false=非空,true=空
     */
    public override bool IsEmpty()
    {
	    if (this.text.Length > 0) {
		    return (false);
	    }

        return (base.IsEmpty());
    }
}

/**
 * @brief TextFileWriteDescDataクラス
 */
public class TextFileWriteDescData : Lib.Data.BinaryFileWriteDescData
{
	public int appendNewlineCount;
    public string charset;
    public Lib.String.Util.NEWLINE_TYPE newlineType;

    /**
     * @brief コンストラクタ
     */
    public TextFileWriteDescData() : base()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        this.appendNewlineCount = 1;
        this.charset = "utf-8";
        this.newlineType = Lib.String.Util.NEWLINE_TYPE.CRLF;

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
 * @brief TextFileクラス
 */
public class TextFile : Lib.Data.File
{
	public Lib.Data.TextFileData data = new();
	public Lib.Data.FileReadDesc<Lib.Data.TextFileReadDescData> readDesc = new();
	public Lib.Data.FileWriteDesc<Lib.Data.TextFileWriteDescData> writeDesc = new();

    /**
     * @brief コンストラクタ
     */
    public TextFile() : base()
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
		    if (desc_dat.buffer.GetLength() <= 0) {
		        this.data.Init();

		        if (desc_dat.text.Length > 0) {
                    this.data.lineTextContainer = new List<string>(desc_dat.text.Split(Lib.String.Util.GetNewlineCode(desc_dat.newlineType)));
		        }

		        return (0);
            }
	    }

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

        byte[] buf = bin_file.data.buffer.GetArray();
        int buf_size = bin_file.data.buffer.GetLength();
        string buf_str = Encoding.GetEncoding(desc_dat.charset).GetString(buf, 0, buf_size);

        this.data.lineTextContainer = new List<string>(buf_str.Split(Lib.String.Util.GetNewlineCode(desc_dat.newlineType)));

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

        byte[] buf = System.Array.Empty<byte>();
        int buf_size = buf.Length;
        string buf_str = System.String.Join(Lib.String.Util.GetNewlineCode(desc_dat.newlineType), this.data.lineTextContainer);

        if (buf_str.Length > 0) {
	        if ((desc_dat.appendFlag)
	        && (desc_dat.appendNewlineCount > 0)) {
		        string newline_code = "";

		        for (int newline_i = 0; newline_i < desc_dat.appendNewlineCount; ++newline_i) {
			        newline_code += Lib.String.Util.GetNewlineCode(desc_dat.newlineType);
		        }

		        buf_str = buf_str.Insert(0, newline_code);
	        }

            buf = Encoding.GetEncoding(desc_dat.charset).GetBytes(buf_str);
            buf_size = buf.Length;
        }

        var bin_file = new Lib.Data.BinaryFile();
        int bin_file_write_result_val;

        bin_file.data.buffer.Init(buf, buf_size, true);

        bin_file.writeDesc.parentData = desc_dat;

        if ((bin_file_write_result_val = bin_file.Write()) < 0) {
	        return (bin_file_write_result_val);
        }

        return (0);
    }
}
}
}
