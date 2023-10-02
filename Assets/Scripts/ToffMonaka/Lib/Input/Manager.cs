/**
 * @file
 * @brief Managerファイル
 */


using UnityEngine;


namespace ToffMonaka {
namespace Lib.Input {
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
    public Lib.Input.ManagerCreateDesc createDesc{get; private set;} = null;

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
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    public virtual int Create(Lib.Input.ManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            if (desc != null) {
                this.SetCreateDesc(desc);
            }
        }

        int create_result_val = this._OnCreate();

        if (create_result_val < 0) {
            this.Init();

            return (create_result_val);
        }

        return (0);
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
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
    public virtual void SetCreateDesc(Lib.Input.ManagerCreateDesc create_desc)
    {
        this.createDesc = create_desc;

        return;
    }
}
}
}
