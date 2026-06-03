/**
 * @file
 * @brief Bufferファイル
 */

using System.Text;

namespace ToffMonaka {
namespace Tml {
/**
 * @brief Bufferクラス
 */
public class Buffer
{
    private byte[] _array = System.Array.Empty<byte>();
    private int _size;
    private int _length;
    private int _readIndex;
    private int _readResultValue;
    private int _writeIndex;
    private int _writeResultValue;
    private string _charsetName;
    private bool _autoSizeFlag;

    /**
     * @brief コンストラクタ
     */
    public Buffer()
    {
        this.Init();

        return;
    }

    /**
     * @brief コンストラクタ
     * @param size (size)
     */
    public Buffer(int size)
    {
        this.Init(size);

        return;
    }

    /**
     * @brief コンストラクタ
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param reference_flg (reference_flag)
     */
    public Buffer(byte[] buf, int buf_size, bool reference_flg = false)
    {
        this.Init(buf, buf_size, reference_flg);

        return;
    }

    /**
     * @brief コンストラクタ
     * @param other (other)
     */
    public Buffer(Buffer other)
    {
        this.Init(other);

        return;
    }

    /**
     * @brief Init関数
     */
    public virtual void Init()
    {
        this._size = 0;
        this._length = 0;
        this._readIndex = 0;
        this._readResultValue = 0;
        this._writeIndex = 0;
        this._writeResultValue = 0;
        this._charsetName = "utf-8";
        this._autoSizeFlag = true;

        return;
    }

    /**
     * @brief Init関数
     * @param size (size)
     */
    public virtual void Init(int size)
    {
        if (size > this._array.Length) {
            this._array = new byte[size];
        }

        this._size = size;
        this._length = 0;
        this._readIndex = 0;
        this._readResultValue = 0;
        this._writeIndex = 0;
        this._writeResultValue = 0;
        this._charsetName = "utf-8";
        this._autoSizeFlag = true;

        return;
    }

    /**
     * @brief Init関数
     * @param buf (buffer)
     * @param buf_size (buffer_size)
     * @param reference_flg (reference_flag)
     */
    public virtual void Init(byte[] buf, int buf_size, bool reference_flg = false)
    {
        if (reference_flg) {
            this._array = buf;
        } else {
            if (buf_size > this._array.Length) {
                this._array = new byte[buf_size];
            }

            System.Buffer.BlockCopy(buf, 0, this._array, 0, buf_size);
        }

        this._size = buf_size;
        this._length = buf_size;
        this._readIndex = 0;
        this._readResultValue = 0;
        this._writeIndex = buf_size;
        this._writeResultValue = 0;
        this._charsetName = "utf-8";
        this._autoSizeFlag = true;

        return;
    }

    /**
     * @brief Init関数
     * @param other (other)
     */
    public virtual void Init(Buffer other)
    {
        if (other == this) {
            return;
        }

        if (other._size > this._array.Length) {
            this._array = new byte[other._size];
        }

        System.Buffer.BlockCopy(other._array, 0, this._array, 0, other._size);

        this._size = other._size;
        this._length = other._length;
        this._readIndex = other._readIndex;
        this._readResultValue = other._readResultValue;
        this._writeIndex = other._writeIndex;
        this._writeResultValue = other._writeResultValue;
        this._charsetName = other._charsetName;
        this._autoSizeFlag = other._autoSizeFlag;

        return;
    }

    /**
     * @brief GetArray関数
     * @return ary (array)
     */
    public byte[] GetArray()
    {
        return (this._array);
    }

    /**
     * @brief GetSize関数
     * @return size (size)
     */
    public int GetSize()
    {
        return (this._size);
    }

    /**
     * @brief SetSize関数
     * @param size (size)
     */
    public void SetSize(int size)
    {
        if (size > this._array.Length) {
            var ary = new byte[size];

            System.Buffer.BlockCopy(this._array, 0, ary, 0, this._array.Length);

            this._array = ary;
        }

        this._size = size;
        this._length = System.Math.Min(this._length, this._size);
        this._readIndex = System.Math.Min(this._readIndex, this._length);
        this._writeIndex = System.Math.Min(this._writeIndex, this._length);

        return;
    }

    /**
     * @brief GetLength関数
     * @return len (length)
     */
    public int GetLength()
    {
        return (this._length);
    }

    /**
     * @brief SetLength関数
     * @param len (length)
     */
    public void SetLength(int len)
    {
        this._length = System.Math.Min(len, this._size);
        this._readIndex = System.Math.Min(this._readIndex, this._length);
        this._writeIndex = System.Math.Min(this._writeIndex, this._length);

        return;
    }

    /**
     * @brief GetReadIndex関数
     * @return read_index (read_index)
     */
    public int GetReadIndex()
    {
        return (this._readIndex);
    }

    /**
     * @brief SetReadIndex関数
     * @param read_index (read_index)
     */
    public void SetReadIndex(int read_index)
    {
        BufferUtil.SetIndex(read_index, this._length, ref this._readIndex, ref this._readResultValue);

        return;
    }

    /**
     * @brief AddReadIndex関数
     * @param add_read_index (add_read_index)
     */
    public void AddReadIndex(int add_read_index)
    {
        BufferUtil.AddIndex(add_read_index, this._length, ref this._readIndex, ref this._readResultValue);

        return;
    }

    /**
     * @brief GetReadResultValue関数
     * @return read_result_val (read_result_value)
     */
    public int GetReadResultValue()
    {
        return (this._readResultValue);
    }

    /**
     * @brief GetWriteIndex関数
     * @return write_index (write_index)
     */
    public int GetWriteIndex()
    {
        return (this._writeIndex);
    }

    /**
     * @brief SetWriteIndex関数
     * @param write_index (write_index)
     */
    public void SetWriteIndex(int write_index)
    {
        BufferUtil.SetIndex(write_index, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief AddWriteIndex関数
     * @param add_write_index (add_write_index)
     */
    public void AddWriteIndex(int add_write_index)
    {
        BufferUtil.AddIndex(add_write_index, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief GetWriteResultValue関数
     * @return write_result_val (write_result_value)
     */
    public int GetWriteResultValue()
    {
        return (this._writeResultValue);
    }

    /**
     * @brief GetCharsetName関数
     * @return charset_name (charset_name)
     */
    public string GetCharsetName()
    {
        return (this._charsetName);
    }

    /**
     * @brief SetCharsetName関数
     * @param charset_name (charset_name)
     */
    public void SetCharsetName(string charset_name)
    {
        this._charsetName = charset_name;

        return;
    }

    /**
     * @brief GetAutoSizeFlag関数
     * @return auto_size_flg (auto_size_flag)
     */
    public bool GetAutoSizeFlag()
    {
        return (this._autoSizeFlag);
    }

    /**
     * @brief SetAutoSizeFlag関数
     * @param auto_size_flg (auto_size_flag)
     */
    public void SetAutoSizeFlag(bool auto_size_flg)
    {
        this._autoSizeFlag = auto_size_flg;

        return;
    }

    /**
     * @brief ReadByte関数
     * @return val (value)
     */
    public byte ReadByte()
    {
        return (BufferUtil.ReadByte(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadCharB関数
     * @return val (value)
     */
    public char ReadCharB()
    {
        return (BufferUtil.ReadCharB(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadCharL関数
     * @return val (value)
     */
    public char ReadCharL()
    {
        return (BufferUtil.ReadCharL(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadShortB関数
     * @return val (value)
     */
    public short ReadShortB()
    {
        return (BufferUtil.ReadShortB(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadShortL関数
     * @return val (value)
     */
    public short ReadShortL()
    {
        return (BufferUtil.ReadShortL(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadIntB関数
     * @return val (value)
     */
    public int ReadIntB()
    {
        return (BufferUtil.ReadIntB(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadIntL関数
     * @return val (value)
     */
    public int ReadIntL()
    {
        return (BufferUtil.ReadIntL(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadLongB関数
     * @return val (value)
     */
    public long ReadLongB()
    {
        return (BufferUtil.ReadLongB(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadLongL関数
     * @return val (value)
     */
    public long ReadLongL()
    {
        return (BufferUtil.ReadLongL(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadFloatB関数
     * @return val (value)
     */
    public float ReadFloatB()
    {
        return (BufferUtil.ReadFloatB(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadFloatL関数
     * @return val (value)
     */
    public float ReadFloatL()
    {
        return (BufferUtil.ReadFloatL(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadDoubleB関数
     * @return val (value)
     */
    public double ReadDoubleB()
    {
        return (BufferUtil.ReadDoubleB(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadDoubleL関数
     * @return val (value)
     */
    public double ReadDoubleL()
    {
        return (BufferUtil.ReadDoubleL(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadArray関数
     * @param read_size (read_size)
     * @return ary (array)
     */
    public byte[] ReadArray(int read_size)
    {
        return (BufferUtil.ReadArray(read_size, this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadStringB関数
     * @return str (string)
     */
    public string ReadStringB()
    {
        return (BufferUtil.ReadStringB(this._charsetName, this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadStringL関数
     * @return str (string)
     */
    public string ReadStringL()
    {
        return (BufferUtil.ReadStringL(this._charsetName, this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief ReadBool関数
     * @return val (value)
     */
    public bool ReadBool()
    {
        return (BufferUtil.ReadBool(this._array, this._length, ref this._readIndex, ref this._readResultValue));
    }

    /**
     * @brief WriteByte関数
     * @param val (value)
     */
    public void WriteByte(byte val)
    {
        this._RunAutoSize(sizeof(byte));
        BufferUtil.WriteByte(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteCharB関数
     * @param val (value)
     */
    public void WriteCharB(char val)
    {
        this._RunAutoSize(sizeof(char));
        BufferUtil.WriteCharB(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteCharL関数
     * @param val (value)
     */
    public void WriteCharL(char val)
    {
        this._RunAutoSize(sizeof(char));
        BufferUtil.WriteCharL(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteShortB関数
     * @param val (value)
     */
    public void WriteShortB(short val)
    {
        this._RunAutoSize(sizeof(short));
        BufferUtil.WriteShortB(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteShortL関数
     * @param val (value)
     */
    public void WriteShortL(short val)
    {
        this._RunAutoSize(sizeof(short));
        BufferUtil.WriteShortL(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteIntB関数
     * @param val (value)
     */
    public void WriteIntB(int val)
    {
        this._RunAutoSize(sizeof(int));
        BufferUtil.WriteIntB(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteIntL関数
     * @param val (value)
     */
    public void WriteIntL(int val)
    {
        this._RunAutoSize(sizeof(int));
        BufferUtil.WriteIntL(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteLongB関数
     * @param val (value)
     */
    public void WriteLongB(long val)
    {
        this._RunAutoSize(sizeof(long));
        BufferUtil.WriteLongB(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteLongL関数
     * @param val (value)
     */
    public void WriteLongL(long val)
    {
        this._RunAutoSize(sizeof(long));
        BufferUtil.WriteLongL(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteFloatB関数
     * @param val (value)
     */
    public void WriteFloatB(float val)
    {
        this._RunAutoSize(sizeof(int));
        BufferUtil.WriteFloatB(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteFloatL関数
     * @param val (value)
     */
    public void WriteFloatL(float val)
    {
        this._RunAutoSize(sizeof(int));
        BufferUtil.WriteFloatL(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteDoubleB関数
     * @param val (value)
     */
    public void WriteDoubleB(double val)
    {
        this._RunAutoSize(sizeof(long));
        BufferUtil.WriteDoubleB(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteDoubleL関数
     * @param val (value)
     */
    public void WriteDoubleL(double val)
    {
        this._RunAutoSize(sizeof(long));
        BufferUtil.WriteDoubleL(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteArray関数
     * @param ary (array)
     * @param write_size (write_size)
     */
    public void WriteArray(byte[] ary, int write_size)
    {
        this._RunAutoSize(write_size);
        BufferUtil.WriteArray(ary, write_size, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteStringB関数
     * @param str (string)
     */
    public void WriteStringB(string str)
    {
        var str_buf = Encoding.GetEncoding(this._charsetName).GetBytes(str);

        this._RunAutoSize(sizeof(int) + str_buf.Length);
        BufferUtil.WriteStringB(str_buf, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteStringL関数
     * @param str (string)
     */
    public void WriteStringL(string str)
    {
        var str_buf = Encoding.GetEncoding(this._charsetName).GetBytes(str);

        this._RunAutoSize(sizeof(int) + str_buf.Length);
        BufferUtil.WriteStringL(str_buf, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief WriteBool関数
     * @param val (value)
     */
    public void WriteBool(bool val)
    {
        this._RunAutoSize(sizeof(bool));
        BufferUtil.WriteBool(val, this._array, this._size, ref this._writeIndex, ref this._writeResultValue);
        this._length = System.Math.Max(this._length, this._writeIndex);

        return;
    }

    /**
     * @brief _RunAutoSize関数
     * @param add_size (add_size)
     */
    private void _RunAutoSize(int add_size)
    {
        if (!this._autoSizeFlag) {
            return;
        }

        if ((this._length + add_size) <= this._size) {
            return;
        }

        int size = ((this._length + add_size) / 256 + 1) * 256;

        if (size > this._array.Length) {
            var ary = new byte[size];

            System.Buffer.BlockCopy(this._array, 0, ary, 0, this._array.Length);

            this._array = ary;
        }

        this._size = size;

        return;
    }
}
}
}
