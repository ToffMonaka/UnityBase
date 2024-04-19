/**
 * @file
 * @brief Utilファイル
 */


using UnityEngine;
using System.Text;


namespace ToffMonaka {
namespace Lib.Buffer {
/**
 * @brief Utilクラス
 */
public static class Util
{
    /**
     * @brief SetIndex関数
     * @param index (index)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void SetIndex(int index, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if (index > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf_index = index;

        dst_result_val = 0;

        return;
    }

    /**
     * @brief AddIndex関数
     * @param add_index (add_index)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void AddIndex(int add_index, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        long tmp_buf_index = (long)buf_index + add_index;

        if ((tmp_buf_index < 0L)
        || (tmp_buf_index > (long)buf_size)) {
            dst_result_val = -1;

            return;
        }

        buf_index = (int)tmp_buf_index;

        dst_result_val = 0;

        return;
    }

    /**
     * @brief ReadByte関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static byte ReadByte(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        byte val = (byte)0;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(byte)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val = buf[buf_index++];

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadCharB関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static char ReadCharB(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        char val = (char)0;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(char)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val |= (char)(((int)buf[buf_index++] & 0xFF) <<  8);
        val |= (char)(((int)buf[buf_index++] & 0xFF) <<  0);

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadCharL関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static char ReadCharL(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        char val = (char)0;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(char)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val |= (char)(((int)buf[buf_index++] & 0xFF) <<  0);
        val |= (char)(((int)buf[buf_index++] & 0xFF) <<  8);

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadShortB関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static short ReadShortB(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        short val = (short)0;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(short)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val |= (short)(((int)buf[buf_index++] & 0xFF) <<  8);
        val |= (short)(((int)buf[buf_index++] & 0xFF) <<  0);

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadShortL関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static short ReadShortL(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        short val = (short)0;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(short)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val |= (short)(((int)buf[buf_index++] & 0xFF) <<  0);
        val |= (short)(((int)buf[buf_index++] & 0xFF) <<  8);

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadIntB関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static int ReadIntB(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        int val = 0;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(int)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val |= ((int)buf[buf_index++] & 0xFF) << 24;
        val |= ((int)buf[buf_index++] & 0xFF) << 16;
        val |= ((int)buf[buf_index++] & 0xFF) <<  8;
        val |= ((int)buf[buf_index++] & 0xFF) <<  0;

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadIntL関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static int ReadIntL(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        int val = 0;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(int)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val |= ((int)buf[buf_index++] & 0xFF) <<  0;
        val |= ((int)buf[buf_index++] & 0xFF) <<  8;
        val |= ((int)buf[buf_index++] & 0xFF) << 16;
        val |= ((int)buf[buf_index++] & 0xFF) << 24;

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadLongB関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static long ReadLongB(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        long val = 0L;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(long)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val |= ((long)buf[buf_index++] & 0xFF) << 56;
        val |= ((long)buf[buf_index++] & 0xFF) << 48;
        val |= ((long)buf[buf_index++] & 0xFF) << 40;
        val |= ((long)buf[buf_index++] & 0xFF) << 32;
        val |= ((long)buf[buf_index++] & 0xFF) << 24;
        val |= ((long)buf[buf_index++] & 0xFF) << 16;
        val |= ((long)buf[buf_index++] & 0xFF) <<  8;
        val |= ((long)buf[buf_index++] & 0xFF) <<  0;

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadLongL関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static long ReadLongL(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        long val = 0L;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(long)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val |= ((long)buf[buf_index++] & 0xFF) <<  0;
        val |= ((long)buf[buf_index++] & 0xFF) <<  8;
        val |= ((long)buf[buf_index++] & 0xFF) << 16;
        val |= ((long)buf[buf_index++] & 0xFF) << 24;
        val |= ((long)buf[buf_index++] & 0xFF) << 32;
        val |= ((long)buf[buf_index++] & 0xFF) << 40;
        val |= ((long)buf[buf_index++] & 0xFF) << 48;
        val |= ((long)buf[buf_index++] & 0xFF) << 56;

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadFloatB関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static float ReadFloatB(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        float val = 0.0f;
        int tmp_val = Lib.Buffer.Util.ReadIntB(buf, buf_size, ref buf_index, ref dst_result_val);

        if (dst_result_val < 0) {
            return (val);
        }

        val = System.BitConverter.ToSingle(System.BitConverter.GetBytes(tmp_val), 0);

        if (float.IsNaN(val)) {
            dst_result_val = -1;

            return (0.0f);
        }

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadFloatL関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static float ReadFloatL(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        float val = 0.0f;
        int tmp_val = Lib.Buffer.Util.ReadIntL(buf, buf_size, ref buf_index, ref dst_result_val);

        if (dst_result_val < 0) {
            return (val);
        }

        val = System.BitConverter.ToSingle(System.BitConverter.GetBytes(tmp_val), 0);

        if (float.IsNaN(val)) {
            dst_result_val = -1;

            return (0.0f);
        }

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadDoubleB関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static double ReadDoubleB(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        double val = 0.0;
        long tmp_val = Lib.Buffer.Util.ReadLongB(buf, buf_size, ref buf_index, ref dst_result_val);

        if (dst_result_val < 0) {
            return (val);
        }

        val = System.BitConverter.ToDouble(System.BitConverter.GetBytes(tmp_val), 0);

        if (double.IsNaN(val)) {
            dst_result_val = -1;

            return (0.0);
        }

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadDoubleL関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static double ReadDoubleL(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        double val = 0.0;
        long tmp_val = Lib.Buffer.Util.ReadLongL(buf, buf_size, ref buf_index, ref dst_result_val);

        if (dst_result_val < 0) {
            return (val);
        }

        val = System.BitConverter.ToDouble(System.BitConverter.GetBytes(tmp_val), 0);

        if (double.IsNaN(val)) {
            dst_result_val = -1;

            return (0.0);
        }

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief ReadArray関数
     * @param read_size (read_size)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return ary (array)
     */
    public static byte[] ReadArray(int read_size, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        byte[] ary = System.Array.Empty<byte>();

        if (dst_result_val < 0) {
            return (ary);
        }

        if ((buf_index + read_size) > buf_size) {
            dst_result_val = -1;

            return (ary);
        }

        ary = new byte[read_size];

        System.Buffer.BlockCopy(buf, buf_index, ary, 0, read_size);
        buf_index += read_size;

        dst_result_val = 0;

        return (ary);
    }

    /**
     * @brief ReadStringB関数
     * @param charset (charset)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return str (string)
     */
    public static string ReadStringB(string charset, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        string str = "";

        if (dst_result_val < 0) {
            return (str);
        }

    	int str_size = Lib.Buffer.Util.ReadShortB(buf, buf_size, ref buf_index, ref dst_result_val);

        if (str_size <= 0) {
            return (str);
        }

        if ((buf_index + str_size) > buf_size) {
            dst_result_val = -1;

            return (str);
        }

        str = Encoding.GetEncoding(charset).GetString(buf, buf_index, str_size);
        buf_index += str_size;

        dst_result_val = 0;

        return (str);
    }

    /**
     * @brief ReadStringL関数
     * @param charset (charset)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return str (string)
     */
    public static string ReadStringL(string charset, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        string str = "";

        if (dst_result_val < 0) {
            return (str);
        }

    	int str_size = Lib.Buffer.Util.ReadShortL(buf, buf_size, ref buf_index, ref dst_result_val);

        if (str_size <= 0) {
            return (str);
        }

        if ((buf_index + str_size) > buf_size) {
            dst_result_val = -1;

            return (str);
        }

        str = Encoding.GetEncoding(charset).GetString(buf, buf_index, str_size);
        buf_index += str_size;

        dst_result_val = 0;

        return (str);
    }

    /**
     * @brief ReadBool関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     * @return val (value)
     */
    public static bool ReadBool(byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        bool val = false;

        if (dst_result_val < 0) {
            return (val);
        }

        if ((buf_index + sizeof(bool)) > buf_size) {
            dst_result_val = -1;

            return (val);
        }

        val = System.Convert.ToBoolean(buf[buf_index++]);

        dst_result_val = 0;

        return (val);
    }

    /**
     * @brief WriteByte関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteByte(byte val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(byte)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = val;

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteCharB関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteCharB(char val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(char)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = (byte)((val >>  8) & 0xFF);
        buf[buf_index++] = (byte)((val >>  0) & 0xFF);

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteCharL関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteCharL(char val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(char)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = (byte)((val >>  0) & 0xFF);
        buf[buf_index++] = (byte)((val >>  8) & 0xFF);

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteShortB関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteShortB(short val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(short)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = (byte)((val >>  8) & 0xFF);
        buf[buf_index++] = (byte)((val >>  0) & 0xFF);

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteShortL関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteShortL(short val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(short)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = (byte)((val >>  0) & 0xFF);
        buf[buf_index++] = (byte)((val >>  8) & 0xFF);

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteIntB関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteIntB(int val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(int)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = (byte)((val >> 24) & 0xFF);
        buf[buf_index++] = (byte)((val >> 16) & 0xFF);
        buf[buf_index++] = (byte)((val >>  8) & 0xFF);
        buf[buf_index++] = (byte)((val >>  0) & 0xFF);

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteIntL関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteIntL(int val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(int)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = (byte)((val >>  0) & 0xFF);
        buf[buf_index++] = (byte)((val >>  8) & 0xFF);
        buf[buf_index++] = (byte)((val >> 16) & 0xFF);
        buf[buf_index++] = (byte)((val >> 24) & 0xFF);

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteFloatB関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteFloatB(float val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        int tmp_val = System.BitConverter.ToInt32(System.BitConverter.GetBytes(val), 0);

    	Lib.Buffer.Util.WriteIntB(tmp_val, buf, buf_size, ref buf_index, ref dst_result_val);

        return;
    }

    /**
     * @brief WriteFloatL関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteFloatL(float val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        int tmp_val = System.BitConverter.ToInt32(System.BitConverter.GetBytes(val), 0);

    	Lib.Buffer.Util.WriteIntL(tmp_val, buf, buf_size, ref buf_index, ref dst_result_val);

        return;
    }

    /**
     * @brief WriteDoubleB関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteDoubleB(double val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        long tmp_val = System.BitConverter.ToInt64(System.BitConverter.GetBytes(val), 0);

    	Lib.Buffer.Util.WriteLongB(tmp_val, buf, buf_size, ref buf_index, ref dst_result_val);

        return;
    }

    /**
     * @brief WriteDoubleL関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteDoubleL(double val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        long tmp_val = System.BitConverter.ToInt64(System.BitConverter.GetBytes(val), 0);

    	Lib.Buffer.Util.WriteLongL(tmp_val, buf, buf_size, ref buf_index, ref dst_result_val);

        return;
    }

    /**
     * @brief WriteLongB関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteLongB(long val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(long)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = (byte)((val >> 56) & 0xFF);
        buf[buf_index++] = (byte)((val >> 48) & 0xFF);
        buf[buf_index++] = (byte)((val >> 40) & 0xFF);
        buf[buf_index++] = (byte)((val >> 32) & 0xFF);
        buf[buf_index++] = (byte)((val >> 24) & 0xFF);
        buf[buf_index++] = (byte)((val >> 16) & 0xFF);
        buf[buf_index++] = (byte)((val >>  8) & 0xFF);
        buf[buf_index++] = (byte)((val >>  0) & 0xFF);

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteLongL関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteLongL(long val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(long)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = (byte)((val >>  0) & 0xFF);
        buf[buf_index++] = (byte)((val >>  8) & 0xFF);
        buf[buf_index++] = (byte)((val >> 16) & 0xFF);
        buf[buf_index++] = (byte)((val >> 24) & 0xFF);
        buf[buf_index++] = (byte)((val >> 32) & 0xFF);
        buf[buf_index++] = (byte)((val >> 40) & 0xFF);
        buf[buf_index++] = (byte)((val >> 48) & 0xFF);
        buf[buf_index++] = (byte)((val >> 56) & 0xFF);

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteArray関数
     * @param ary (array)
     * @param write_size (write_size)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteArray(byte[] ary, int write_size, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if (((buf_index + write_size) > buf_size)
        || (write_size > ary.Length)) {
            dst_result_val = -1;

            return;
        }

        System.Buffer.BlockCopy(ary, 0, buf, buf_index, write_size);
        buf_index += write_size;

        dst_result_val = 0;

        return;
    }

    /**
     * @brief WriteStringB関数
     * @param str (string)
     * @param charset (charset)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteStringB(string str, string charset, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        var str_buf = Encoding.GetEncoding(charset).GetBytes(str);

    	Lib.Buffer.Util.WriteIntB(str_buf.Length, buf, buf_size, ref buf_index, ref dst_result_val);
    	Lib.Buffer.Util.WriteArray(str_buf, str_buf.Length, buf, buf_size, ref buf_index, ref dst_result_val);

        return;
    }

    /**
     * @brief WriteStringB関数
     * @param str_buf (string_buffer)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteStringB(byte[] str_buf, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

    	Lib.Buffer.Util.WriteShortB((short)str_buf.Length, buf, buf_size, ref buf_index, ref dst_result_val);
    	Lib.Buffer.Util.WriteArray(str_buf, str_buf.Length, buf, buf_size, ref buf_index, ref dst_result_val);

        return;
    }

    /**
     * @brief WriteStringL関数
     * @param str (string)
     * @param charset (charset)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteStringL(string str, string charset, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        var str_buf = Encoding.GetEncoding(charset).GetBytes(str);

    	Lib.Buffer.Util.WriteShortL((short)str_buf.Length, buf, buf_size, ref buf_index, ref dst_result_val);
    	Lib.Buffer.Util.WriteArray(str_buf, str_buf.Length, buf, buf_size, ref buf_index, ref dst_result_val);

        return;
    }

    /**
     * @brief WriteStringL関数
     * @param str_buf (string_buffer)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteStringL(byte[] str_buf, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

    	Lib.Buffer.Util.WriteIntL(str_buf.Length, buf, buf_size, ref buf_index, ref dst_result_val);
    	Lib.Buffer.Util.WriteArray(str_buf, str_buf.Length, buf, buf_size, ref buf_index, ref dst_result_val);

        return;
    }

    /**
     * @brief WriteBool関数
     * @param val (value)
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param buf_index (buffer_index)
     * @param dst_result_val (dst_result_value)<br>
     * 0未満=失敗
     */
    public static void WriteBool(bool val, byte[] buf, int buf_size, ref int buf_index, ref int dst_result_val)
    {
        if (dst_result_val < 0) {
            return;
        }

        if ((buf_index + sizeof(byte)) > buf_size) {
            dst_result_val = -1;

            return;
        }

        buf[buf_index++] = System.Convert.ToByte(val);

        dst_result_val = 0;

        return;
    }
}
}
}
