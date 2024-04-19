/**
 * @file
 * @brief Fileファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Data {
/**
 * @brief FileReadDescDataクラス
 */
public abstract class FileReadDescData
{
    public string filePath;
    public bool addressablesFlag;

    /**
     * @brief コンストラクタ
     */
    public FileReadDescData()
    {
        this.Init();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this.filePath = "";
        this.addressablesFlag = false;

        return;
    }

    /**
     * @brief IsEmpty関数
     * @return result_flg (result_flag)<br>
     * false=非空,true=空
     */
    public virtual bool IsEmpty()
    {
        return (this.filePath.Length == 0);
    }
}

/**
 * @brief FileReadDescクラス
 */
public class FileReadDesc<T> where T : Lib.Data.FileReadDescData, new()
{
    public T data = new();
    public T parentData;

    /**
     * @brief コンストラクタ
     */
    public FileReadDesc()
    {
        this.Init();

        return;
    }

    /**
     * @brief コンストラクタ
     * @param file_path (file_path)
     */
    public FileReadDesc(string file_path)
    {
        this.Init(file_path);

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
	    this.data.Init();
	    this.parentData = null;

        return;
    }

    /**
     * @brief Init関数
     * @param file_path (file_path)
     */
    public virtual void Init(string file_path)
    {
	    this.data.Init();
        this.data.filePath = file_path;
	    this.parentData = null;

        return;
    }

    /**
     * @brief GetDataByParent関数
     * @return dat (data)
     */
    public T GetDataByParent()
    {
        return (this.parentData ?? this.data);
    }
}

/**
 * @brief FileWriteDescDataクラス
 */
public abstract class FileWriteDescData
{
    public string filePath;
    public bool appendFlag;

    /**
     * @brief コンストラクタ
     */
    public FileWriteDescData()
    {
        this.Init();

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this.filePath = "";
        this.appendFlag = false;

        return;
    }

    /**
     * @brief IsEmpty関数
     * @return result_flg (result_flag)<br>
     * false=非空,true=空
     */
    public virtual bool IsEmpty()
    {
        return (this.filePath.Length == 0);
    }
}

/**
 * @brief FileWriteDescクラス
 */
public class FileWriteDesc<T> where T : Lib.Data.FileWriteDescData, new()
{
    public T data = new();
    public T parentData;

    /**
     * @brief コンストラクタ
     */
    public FileWriteDesc()
    {
        this.Init();

        return;
    }

    /**
     * @brief コンストラクタ
     * @param file_path (file_path)
     */
    public FileWriteDesc(string file_path)
    {
        this.Init(file_path);

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
	    this.data.Init();
	    this.parentData = null;

        return;
    }

    /**
     * @brief Init関数
     * @param file_path (file_path)
     */
    public virtual void Init(string file_path)
    {
	    this.data.Init();
        this.data.filePath = file_path;
	    this.parentData = null;

        return;
    }

    /**
     * @brief GetDataByParent関数
     * @return dat (data)
     */
    public T GetDataByParent()
    {
        return (this.parentData ?? this.data);
    }
}

/**
 * @brief Fileクラス
 */
public abstract class File
{
    /**
     * @brief コンストラクタ
     */
    public File()
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

    /**
     * @brief Read関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int Read()
    {
        return (this._OnRead());
    }

    /**
     * @brief _OnRead関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected virtual int _OnRead()
    {
        return (0);
    }

    /**
     * @brief Write関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public int Write()
    {
        return (this._OnWrite());
    }

    /**
     * @brief _OnWrite関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected virtual int _OnWrite()
    {
        return (0);
    }
}
}
}
