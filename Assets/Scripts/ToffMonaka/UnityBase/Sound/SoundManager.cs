/**
 * @file
 * @brief SoundManagerファイル
 */

namespace ToffMonaka {
namespace UnityBase.Sound {
/**
 * @brief SoundManagerCreateDescクラス
 */
public class SoundManagerCreateDesc : ToffMonaka.Tml.Sound.SoundManagerCreateDesc
{
}

/**
 * @brief SoundManagerクラス
 */
public class SoundManager : ToffMonaka.Tml.Sound.SoundManager
{
    public new SoundManagerCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public SoundManager()
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
    public override void SetCreateDesc(ToffMonaka.Tml.Sound.SoundManagerCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new SoundManagerCreateDesc());

            return;
        }

	    this.createDesc = create_desc as SoundManagerCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }
}
}
}
