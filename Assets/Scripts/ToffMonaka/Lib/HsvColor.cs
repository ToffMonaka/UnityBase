/**
 * @file
 * @brief HsvColorファイル
 */


namespace ToffMonaka {
namespace Lib {
/**
 * @brief HsvColorクラス
 */
public class HsvColor
{
    public ushort h = 0;
    public ushort s = 0;
    public ushort v = 0;

    /**
     * @brief コンストラクタ
     */
    public HsvColor()
    {
        this.h = 0;
        this.s = 0;
        this.v = 0;

        return;
    }

    /**
     * @brief コンストラクタ
     * @param hsv_col (hsv_color)
     */
    public HsvColor(HsvColor hsv_col)
    {
        this.Set(hsv_col);

        return;
    }

    /**
     * @brief コンストラクタ
     * @param h (h)
     * @param s (s)
     * @param v (v)
     */
    public HsvColor(ushort h, ushort s, ushort v)
    {
        this.Set(h, s, v);

        return;
    }

    /**
     * @brief Set関数
     * @param hsv_col (hsv_color)
     */
    public void Set(HsvColor hsv_col)
    {
        this.h = hsv_col.h;
        this.s = hsv_col.s;
        this.v = hsv_col.v;

        return;
    }

    /**
     * @brief Set関数
     * @param h (h)
     * @param s (s)
     * @param v (v)
     */
    public void Set(ushort h, ushort s, ushort v)
    {
        this.h = h;
        this.s = s;
        this.v = v;

        return;
    }

    /**
     * @brief Clone関数
     * @return hsv_col (hsv_color)
     */
    public HsvColor Clone()
    {
        return ((HsvColor)MemberwiseClone());
    }

    /**
     * @brief GetRgbColor関数
     * @return rgb_col (rgb_color)
     */
    public Lib.RgbColor GetRgbColor()
    {
        var rgb_col = new RgbColor();

        rgb_col.SetHsvColor(this);

        return (rgb_col);
    }

    /**
     * @brief SetRgbColor関数
     * @param rgb_col (rgb_color)
     */
    public void SetRgbColor(Lib.RgbColor rgb_col)
    {
        var hsv_col = rgb_col.GetHsvColor();

        this.h = hsv_col.h;
        this.s = hsv_col.s;
        this.v = hsv_col.v;

        return;
    }
}
}
}
