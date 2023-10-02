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
 * @brief TextFileDataクラス
 */
public class TextFileData
{
    public List<string> lineStringContainer = new List<string>();

    /**
     * @brief コンストラクタ
     */
    public TextFileData()
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

        this.lineStringContainer.Clear();

        return;
    }
}

/**
 * @brief TextFileReadDescDataクラス
 */
public class TextFileReadDescData : Lib.Data.BinaryFileReadDescData
{
    public string string_ = "";
    public string charset = "utf-8";
    public Lib.String.Util.NEWLINE_TYPE newlineType = Lib.String.Util.NEWLINE_TYPE.CRLF;

    /**
     * @brief コンストラクタ
     */
    public TextFileReadDescData()
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

        this.string_ = "";
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
	    if (this.string_.Length > 0) {
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
	public int appendNewlineCount = 1;
    public string charset = "utf-8";
    public Lib.String.Util.NEWLINE_TYPE newlineType = Lib.String.Util.NEWLINE_TYPE.CRLF;

    /**
     * @brief コンストラクタ
     */
    public TextFileWriteDescData()
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
	public Lib.Data.TextFileData data = new Lib.Data.TextFileData();
	public Lib.Data.FileReadDesc<Lib.Data.TextFileReadDescData> readDesc = new Lib.Data.FileReadDesc<Lib.Data.TextFileReadDescData>();
	public Lib.Data.FileWriteDesc<Lib.Data.TextFileWriteDescData> writeDesc = new Lib.Data.FileWriteDesc<Lib.Data.TextFileWriteDescData>();

    /**
     * @brief コンストラクタ
     */
    public TextFile()
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
		    if (desc_dat.buffer.Length <= 0) {
		        this.data.Init();

		        if (desc_dat.string_.Length > 0) {
                    this.data.lineStringContainer = new List<string>(desc_dat.string_.Split(Lib.String.Util.GetNewlineCode(desc_dat.newlineType)));
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

        if (bin_file.data.buffer.Length <= 0) {
	        return (0);
        }

        string buf_str = Encoding.GetEncoding(desc_dat.charset).GetString(bin_file.data.buffer);

        this.data.lineStringContainer = new List<string>(buf_str.Split(Lib.String.Util.GetNewlineCode(desc_dat.newlineType)));

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

        string buf_str = System.String.Join(Lib.String.Util.GetNewlineCode(desc_dat.newlineType), this.data.lineStringContainer);

        if (buf_str.Length > 0) {
	        if ((desc_dat.appendFlag)
	        && (desc_dat.appendNewlineCount > 0)) {
		        string newline_code = "";

		        for (int newline_i = 0; newline_i < desc_dat.appendNewlineCount; ++newline_i) {
			        newline_code += Lib.String.Util.GetNewlineCode(desc_dat.newlineType);
		        }

		        buf_str = buf_str.Insert(0, newline_code);
	        }
        }

        var bin_file = new Lib.Data.BinaryFile();
        int bin_file_write_result_val;

        bin_file.data.buffer = Encoding.GetEncoding(desc_dat.charset).GetBytes(buf_str);

        bin_file.writeDesc.parentData = desc_dat;

        if ((bin_file_write_result_val = bin_file.Write()) < 0) {
	        return (bin_file_write_result_val);
        }

        return (0);
    }
}
}
}
