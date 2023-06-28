/**
 * @file
 * @brief Fileファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.File {
/**
 * @brief FileDataクラス
 */
public abstract class FileData
{
    /**
     * @brief コンストラクタ
     */
    public FileData()
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
 * @brief FileReadDescDataクラス
 */
public abstract class FileReadDescData
{
    public string filePath = "";

    /**
     * @brief コンストラクタ
     */
    public FileReadDescData()
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

        this.filePath = "";

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
public class FileReadDesc<T> where T : ToffMonaka.Lib.File.FileReadDescData, new()
{
    public T data = new T();
    public T parentData = null;

    /**
     * @brief コンストラクタ
     */
    public FileReadDesc()
    {
        return;
    }

    /**
     * @brief コンストラクタ
     * @param file_path (file_path)
     */
    public FileReadDesc(string file_path)
    {
        this.data.filePath = file_path;

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
        this._Release();

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
    public string filePath = "";

    /**
     * @brief コンストラクタ
     */
    public FileWriteDescData()
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

        this.filePath = "";

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
public class FileWriteDesc<T> where T : ToffMonaka.Lib.File.FileWriteDescData, new()
{
    public T data = new T();
    public T parentData = null;

    /**
     * @brief コンストラクタ
     */
    public FileWriteDesc()
    {
        return;
    }

    /**
     * @brief コンストラクタ
     * @param file_path (file_path)
     */
    public FileWriteDesc(string file_path)
    {
        this.data.filePath = file_path;

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
        this._Release();

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

    /**
     * @brief Read関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Read()
    {
        return (this._OnRead());
    }

    /**
     * @brief _OnRead関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected virtual int _OnRead()
    {
        return (0);
    }

    /**
     * @brief Write関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Write()
    {
        return (this._OnWrite());
    }

    /**
     * @brief _OnWrite関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected virtual int _OnWrite()
    {
        return (0);
    }
}
}
