using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEQ2MIDI
{
    public static class BEBitConv
    {
        public static short FromInt16(byte[] str, int offset)
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (offset + 2 > str.Length)
                throw new ArgumentOutOfRangeException("offset");
            int result = 0;
            result |= str[offset + 0] << 8 * 1;
            result |= str[offset + 1] << 8 * 0;
            return (short)result;
        }

        public static int FromInt32(byte[] str, int offset)
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (offset + 4 > str.Length)
                throw new ArgumentOutOfRangeException("offset");
            int result = 0;
            result |= str[offset + 0] << 8 * 3;
            result |= str[offset + 1] << 8 * 2;
            result |= str[offset + 2] << 8 * 1;
            result |= str[offset + 3] << 8 * 0;
            return result;
        }

        public static void ToInt16(byte[] str, int offset, short value)
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (offset + 2 > str.Length)
                throw new ArgumentOutOfRangeException("offset");
            str[offset + 0] = (byte)((value >> 8 * 1) & 0xFF);
            str[offset + 1] = (byte)((value >> 8 * 0) & 0xFF);
        }

        public static void ToInt32(byte[] str, int offset, int value)
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (offset < 0)
                throw new ArgumentOutOfRangeException("offset");
            if (offset + 4 > str.Length)
                throw new ArgumentOutOfRangeException("offset");
            str[offset + 0] = (byte)((value >> 8 * 3) & 0xFF);
            str[offset + 1] = (byte)((value >> 8 * 2) & 0xFF);
            str[offset + 2] = (byte)((value >> 8 * 1) & 0xFF);
            str[offset + 3] = (byte)((value >> 8 * 0) & 0xFF);
        }
    }
}
