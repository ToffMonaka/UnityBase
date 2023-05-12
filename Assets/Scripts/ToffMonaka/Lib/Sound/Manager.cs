/**
 * @file
 * @brief Managerファイル
 */


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
     * @brief Create関数
     * @param desc (desc)
     * @return result (result)<br>
     * 0未満=失敗
     */
    public int Create(ToffMonaka.Lib.Sound.ManagerCreateDesc desc = null)
    {
        if (desc != null) {
            this.SetCreateDesc(desc);
        }

        int create_res = this._OnCreate();

        if (create_res < 0) {
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
