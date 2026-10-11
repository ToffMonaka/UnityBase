/**
 * @file
 * @brief InputManagerファイル
 */

namespace ToffMonaka {
namespace UnityBase.Input {
/**
 * @brief InputManagerCreateDescクラス
 */
public class InputManagerCreateDesc : ToffMonaka.Tml.Input.InputManagerCreateDesc
{
}

/**
 * @brief InputManagerクラス
 */
public class InputManager : ToffMonaka.Tml.Input.InputManager
{
    public new InputManagerCreateDesc createDesc{get; private set;} = null;

    /**
     * @brief コンストラクタ
     */
    public InputManager()
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
    public override void SetCreateDesc(ToffMonaka.Tml.Input.InputManagerCreateDesc create_desc = null)
    {
        if (create_desc == null) {
            this.SetCreateDesc(new InputManagerCreateDesc());

            return;
        }

	    this.createDesc = create_desc as InputManagerCreateDesc;

        base.SetCreateDesc(this.createDesc);

        return;
    }
}
}
}
