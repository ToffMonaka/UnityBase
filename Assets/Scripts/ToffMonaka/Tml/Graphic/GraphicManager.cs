/**
 * @file
 * @brief GraphicManagerファイル
 */

namespace ToffMonaka {
namespace Tml.Graphic {
/**
 * @brief GraphicManagerCreateDescクラス
 */
public class GraphicManagerCreateDesc
{
}

/**
 * @brief GraphicManagerクラス
 */
public class GraphicManager
{
    public GraphicManagerCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public GraphicManager()
    {
        this.Init();

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
    public virtual int Create(GraphicManagerCreateDesc desc = null)
    {
        this.Init();

        {// This Create
            this.SetCreateDesc(desc);
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
    public virtual void SetCreateDesc(GraphicManagerCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new GraphicManagerCreateDesc());

            return;
        }

        this.createDesc = create_desc;

        return;
    }
}
}
}
