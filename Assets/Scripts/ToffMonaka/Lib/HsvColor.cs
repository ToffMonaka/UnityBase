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
    public ushort h;
    public byte s;
    public byte v;

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
    public HsvColor(ushort h, byte s, byte v)
    {
        this.Set(h, s, v);

        return;
    }

    /**
     * @brief コンストラクタ
     * @param code (code)
     */
    public HsvColor(string code)
    {
        this.Set(code);

        return;
    }

    /**
     * @brief コンストラクタ
     * @param code_val (code_value)
     */
    public HsvColor(int code_val)
    {
        this.Set(code_val);

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
    public void Set(ushort h, byte s, byte v)
    {
        this.h = h;
        this.s = s;
        this.v = v;

        return;
    }

    /**
     * @brief Set関数
     * @param code (code)
     */
    public void Set(string code)
    {
        this.SetCode(code);

        return;
    }

    /**
     * @brief Set関数
     * @param code_val (code_value)
     */
    public void Set(int code_val)
    {
        this.SetCodeValue(code_val);

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
     * @brief GetCode関数
     * @return code (code)
     */
    public string GetCode()
    {
        return (this.GetCodeValue().ToString("X8"));
    }

    /**
     * @brief SetCode関数
     * @param code (code)
     */
    public void SetCode(string code)
    {
        this.SetCodeValue(System.Convert.ToInt32(code, 16));

        return;
    }

    /**
     * @brief GetCodeValue関数
     * @return code_val (code_value)
     */
    public int GetCodeValue()
    {
        return ((this.h << 16) | (this.s << 8) | this.v);
    }

    /**
     * @brief SetCodeValue関数
     * @param code_val (code_value)
     */
    public void SetCodeValue(int code_val)
    {
        this.h = (ushort)((code_val >> 16) & 0xFFFF);
        this.s = (byte)((code_val >> 8) & 0xFF);
        this.v = (byte)(code_val & 0xFF);

        return;
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
