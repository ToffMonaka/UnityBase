/**
 * @file
 * @brief GraphicManagerファイル
 */

namespace ToffMonaka {
namespace UnityBase.Graphic {
/**
 * @brief GraphicManagerCreateDescクラス
 */
public class GraphicManagerCreateDesc : ToffMonaka.Tml.Graphic.GraphicManagerCreateDesc
{
}

/**
 * @brief GraphicManagerクラス
 */
public class GraphicManager : ToffMonaka.Tml.Graphic.GraphicManager
{
    public new GraphicManagerCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public GraphicManager()
    {
        return;
    }

    /**
     * @brief Init関数
     */
    public override void Init()
    {
        base.Init();

        return;
    }

    /**
     * @brief _OnCreate関数
     * @return result_val (result_value)<br>
     * 0未満=失敗
     */
    protected override int _OnCreate()
    {
        if (base._OnCreate() < 0) {
            return (-1);
        }

        return (0);
    }

    /**
     * @brief SetCreateDesc関数
     * @param create_desc (create_desc)
     */
    public override void SetCreateDesc(ToffMonaka.Tml.Graphic.GraphicManagerCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new GraphicManagerCreateDesc());

            return;
        }

	    this.createDesc = create_desc as GraphicManagerCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }
}
}
}
