/**
 * @file
 * @brief TextFileファイル
 */


using UnityEngine;
using System.Collections.Generic;
using System.Text;


namespace ToffMonaka.Lib.File {
/**
 * @brief TextFileDataクラス
 */
public class TextFileData
{
    public List<string> lineTextContainer = new List<string>();

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

        this.lineTextContainer.Clear();

        return;
    }
}

/**
 * @brief TextFileReadDescDataクラス
 */
public class TextFileReadDescData : ToffMonaka.Lib.File.BinaryFileReadDescData
{
    public string text = "";
    public string charsetName = "shift_jis";
    public ToffMonaka.Lib.String.Util.NEWLINE_TYPE newlineType = ToffMonaka.Lib.String.Util.NEWLINE_TYPE.CRLF;

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

        this.text = "";
        this.charsetName = "shift_jis";
        this.newlineType = ToffMonaka.Lib.String.Util.NEWLINE_TYPE.CRLF;

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
	    if (this.text.Length > 0) {
		    return (false);
	    }

        return (base.IsEmpty());
    }
}

/**
 * @brief TextFileWriteDescDataクラス
 */
public class TextFileWriteDescData : ToffMonaka.Lib.File.BinaryFileWriteDescData
{
	public int appendNewlineCount = 1;
    public string charsetName = "shift_jis";
    public ToffMonaka.Lib.String.Util.NEWLINE_TYPE newlineType = ToffMonaka.Lib.String.Util.NEWLINE_TYPE.CRLF;

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
        this.charsetName = "shift_jis";
        this.newlineType = ToffMonaka.Lib.String.Util.NEWLINE_TYPE.CRLF;

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
public class TextFile : ToffMonaka.Lib.File.File
{
	public ToffMonaka.Lib.File.TextFileData data = new ToffMonaka.Lib.File.TextFileData();
	public ToffMonaka.Lib.File.FileReadDesc<ToffMonaka.Lib.File.TextFileReadDescData> readDesc = new ToffMonaka.Lib.File.FileReadDesc<ToffMonaka.Lib.File.TextFileReadDescData>();
	public ToffMonaka.Lib.File.FileWriteDesc<ToffMonaka.Lib.File.TextFileWriteDescData> writeDesc = new ToffMonaka.Lib.File.FileWriteDesc<ToffMonaka.Lib.File.TextFileWriteDescData>();

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
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected override int _OnRead()
    {
	    var desc_dat = this.readDesc.GetDataByParent();

	    if (desc_dat.filePath.Length <= 0) {
		    if (desc_dat.buffer.Length <= 0) {
		        this.data.Init();

		        if (desc_dat.text.Length > 0) {
                    this.data.lineTextContainer = new List<string>(desc_dat.text.Split(ToffMonaka.Lib.String.Util.GetNewlineCode(desc_dat.newlineType)));
		        }

		        return (0);
            }
	    }

        var bin_file = new ToffMonaka.Lib.File.BinaryFile();

        bin_file.readDesc.parentData = desc_dat;

        if (bin_file.Read() < 0) {
	        return (-1);
        }

        this.data.Init();

        if (bin_file.data.buffer.Length <= 0) {
	        return (0);
        }

        string buf_str = Encoding.GetEncoding(desc_dat.charsetName).GetString(bin_file.data.buffer);

        this.data.lineTextContainer = new List<string>(buf_str.Split(ToffMonaka.Lib.String.Util.GetNewlineCode(desc_dat.newlineType)));

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

        string buf_str = System.String.Join(ToffMonaka.Lib.String.Util.GetNewlineCode(desc_dat.newlineType), this.data.lineTextContainer);

        if (buf_str.Length > 0) {
	        if ((desc_dat.appendFlag)
	        && (desc_dat.appendNewlineCount > 0)) {
		        string newline_code = "";

		        for (int newline_i = 0; newline_i < desc_dat.appendNewlineCount; ++newline_i) {
			        newline_code += ToffMonaka.Lib.String.Util.GetNewlineCode(desc_dat.newlineType);
		        }

		        buf_str = buf_str.Insert(0, newline_code);
	        }
        }

        var bin_file = new ToffMonaka.Lib.File.BinaryFile();

        bin_file.data.buffer = Encoding.GetEncoding(desc_dat.charsetName).GetBytes(buf_str);

        bin_file.writeDesc.parentData = desc_dat;

        if (bin_file.Write() < 0) {
	        return (-1);
        }

        return (0);
    }
}
}
