/**
 * @file
 * @brief Fileファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.File {
/**
 * @brief FileCreateDescクラス
 */
public class FileCreateDesc
{
}

/**
 * @brief Fileクラス
 */
public abstract class File
{
    public ToffMonaka.Lib.File.FileCreateDesc createDesc{get; private set;} = null;

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
     * @brief Create関数
     * @param desc (desc)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public virtual int Create(ToffMonaka.Lib.File.FileCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }
        }

        int create_res = this._OnCreate();

        if (create_res < 0) {
            this.Init();

            return (create_res);
        }

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result (result)<br>
     * 0未満=失敗
     */
    protected virtual int _OnCreate()
    {
        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public virtual void SetCreateDesc(ToffMonaka.Lib.File.FileCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
    }
}
}
