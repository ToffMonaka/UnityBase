/**
 * @file
 * @brief RgbColorファイル
 */


namespace ToffMonaka {
namespace Lib {
/**
 * @brief RgbColorクラス
 */
public class RgbColor
{
    public byte r = 0;
    public byte g = 0;
    public byte b = 0;

    /**
     * @brief コンストラクタ
     */
    public RgbColor()
    {
        this.r = 0;
        this.g = 0;
        this.b = 0;

        return;
    }

    /**
     * @brief コンストラクタ
     * @param rgb_col (rgb_color)
     */
    public RgbColor(RgbColor rgb_col)
    {
        this.Set(rgb_col);

        return;
    }

    /**
     * @brief コンストラクタ
     * @param r (r)
     * @param g (g)
     * @param b (b)
     */
    public RgbColor(byte r, byte g, byte b)
    {
        this.Set(r, g, b);

        return;
    }

    /**
     * @brief コンストラクタ
     * @param code (code)
     */
    public RgbColor(int code)
    {
        this.Set(code);

        return;
    }

    /**
     * @brief Set関数
     * @param rgb_col (rgb_color)
     */
    public void Set(RgbColor rgb_col)
    {
        this.r = rgb_col.r;
        this.g = rgb_col.g;
        this.b = rgb_col.b;

        return;
    }

    /**
     * @brief Set関数
     * @param r (r)
     * @param g (g)
     * @param b (b)
     */
    public void Set(byte r, byte g, byte b)
    {
        this.r = r;
        this.g = g;
        this.b = b;

        return;
    }

    /**
     * @brief Set関数
     * @param code (code)
     */
    public void Set(int code)
    {
        this.SetCode(code);

        return;
    }

    /**
     * @brief Clone関数
     * @return rgb_col (rgb_color)
     */
    public RgbColor Clone()
    {
        return ((RgbColor)MemberwiseClone());
    }

    /**
     * @brief GetCode関数
     * @return code (code)
     */
    public int GetCode()
    {
        return ((this.r << 16) | (this.g << 8) | this.b);
    }

    /**
     * @brief SetCode関数
     * @param code (code)
     */
    public void SetCode(int code)
    {
        this.r = (byte)((code >> 16) & 0xFF);
        this.g = (byte)((code >> 8) & 0xFF);
        this.b = (byte)(code & 0xFF);

        return;
    }

    /**
     * @brief GetHsvColor関数
     * @return hsv_col (hsv_color)
     */
    public Lib.HsvColor GetHsvColor()
    {
        var hsv_col = new HsvColor();

        float h = 0.0f;
        float s = 0.0f;
        float v = 0.0f;
        float r = (float)this.r;
        float g = (float)this.g;
        float b = (float)this.b;
        float max = System.Math.Max(System.Math.Max(r, g), b);
        float min = System.Math.Min(System.Math.Min(r, g), b);

        if ((r == g) && (r == b)) {
            h = 0.0f;
        } else if ((r >= g) && (r >= b)) {
            h = 60.0f * ((g - b) / (max - min));
        } else if ((g >= r) && (g >= b)) {
            h = 60.0f * ((b - r) / (max - min)) + 120.0f;
        } else if ((b >= r) && (b >= g)) {
            h = 60.0f * ((r - g) / (max - min)) + 240.0f;
        }

        if (h < 0.0f) {
            h += 360.0f;
        }

        if (max == 0.0f) {
            s = 0.0f;
        } else {
            s = (max - min) / max * 100.0f;
        }

        v = max / 255.0f * 100.0f;
            
        hsv_col.h = (ushort)System.Math.Round(h, System.MidpointRounding.AwayFromZero);
        hsv_col.s = (ushort)System.Math.Round(s, System.MidpointRounding.AwayFromZero);
        hsv_col.v = (ushort)System.Math.Round(v, System.MidpointRounding.AwayFromZero);

        return (hsv_col);
    }

    /**
     * @brief SetHsvColor関数
     * @param hsv_col (hsv_color)
     */
    public void SetHsvColor(Lib.HsvColor hsv_col)
    {
        float r = 0.0f;
        float g = 0.0f;
        float b = 0.0f;
        float h = (float)hsv_col.h;
        float s = (float)hsv_col.s / 100.0f;
        float v = (float)hsv_col.v / 100.0f;
        float max = v * 255.0f;
        float min = max - (s * max);

        if (h < 60.0f) {
            r = max;
            g = (h / 60.0f) * (max - min) + min;
            b = min;
        } else if (h < 120.0f) {
            r = ((120.0f - h) / 60.0f) * (max - min) + min;
            g = max;
            b = min;
        } else if (h < 180.0f) {
            r = min;
            g = max;
            b = ((h - 120.0f) / 60.0f) * (max - min) + min;
        } else if (h < 240.0f) {
            r = min;
            g = ((240.0f - h) / 60.0f) * (max - min) + min;
            b = max;
        } else if (h < 300.0f) {
            r = ((h - 240.0f) / 60.0f) * (max - min) + min;
            g = min;
            b = max;
        } else {
            r = max;
            g = min;
            b = ((360.0f - h) / 60.0f) * (max - min) + min;
        }

        this.r = (byte)System.Math.Round(r, System.MidpointRounding.AwayFromZero);
        this.g = (byte)System.Math.Round(g, System.MidpointRounding.AwayFromZero);
        this.b = (byte)System.Math.Round(b, System.MidpointRounding.AwayFromZero);

        return;
    }
}
}
}
