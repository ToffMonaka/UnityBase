/**
 * @file
 * @brief Managerファイル
 */


using UnityEngine;


namespace ToffMonaka.Lib.Sound {
/**
 * @brief ManagerCreateDescクラス
 */
public class ManagerCreateDesc
{
}

/**
 * @brief Managerクラス
 */
public class Manager
{
    public ToffMonaka.Lib.Sound.ManagerCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public Manager()
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
    public virtual int Create(ToffMonaka.Lib.Sound.ManagerCreateDesc desc = null)
    {
        this.Init();

        if (desc != null) {
            this.SetCreateDesc(desc);
        }

        {// This Create
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
    public virtual void SetCreateDesc(ToffMonaka.Lib.Sound.ManagerCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
    }
}
}
