using System;
using System.Runtime.CompilerServices;

namespace Helppad.Unsafe
{
    /// <summary>
    /// This static class provide a set of methods to work with pointers
    /// </summary>
    public static class PointerKit
    {
        internal static readonly bool s_IsLittleEndian = BitConverter.IsLittleEndian;

        /// <summary>Converts a 4-bytes unsigned integer to a byte array.</summary>
        /// <param name="value">The <see cref="T:System.uint"/> to convert.</param>
        /// <returns>A <see cref="T:System.byte"/>[] value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] TobyteArray32(uint value)
        {
            byte[] array = new byte[4];

            fixed (byte* pointer = array)
                *((uint*)pointer) = value;

            return array;
        }

        /// <summary>Converts a 8-bytes unsigned integer to a 4-bytes array.</summary>
        /// <param name="value">The <see cref="T:System.ulong"/> to convert.</param>
        /// <returns>A <see cref="T:System.byte"/>[] value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] TobyteArray32(ulong value)
        {
            byte[] array = new byte[4];

            fixed (byte* pointer = array)
                *((uint*)pointer) = (uint)value;

            return array;
        }

        /// <summary>Converts an array of a 4-bytes unsigned integers to a byte array.</summary>
        /// <param name="values">The <see cref="T:System.uint"/>[] value to convert.</param>
        /// <returns>A <see cref="T:System.byte"/>[] value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] TobyteArray32(params uint[] values)
        {
            int length = values.Length;
            byte[] array = new byte[4 * length];

            fixed (byte* pin = array)
            {
                uint* pointer = (uint*)pin;

                for (int i = 0; i < length; ++i)
                    pointer[i] = values[i];
            }

            return array;
        }

        /// <summary>Converts a 4-bytes unsigned integer to a 8-bytes array.</summary>
        /// <param name="value">The <see cref="T:System.ulong"/> to convert.</param>
        /// <returns>A <see cref="T:System.byte"/>[] value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] TobyteArray64(uint value)
        {
            byte[] array = new byte[8];

            fixed (byte* pointer = array)
                *((ulong*)pointer) = value;

            return array;
        }

        /// <summary>Converts a 8-bytes unsigned integer to a byte array.</summary>
        /// <param name="value">The <see cref="T:System.ulong"/> to convert.</param>
        /// <returns>A <see cref="T:System.byte"/>[] value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] TobyteArray64(ulong value)
        {
            byte[] array = new byte[8];

            fixed (byte* pointer = array)
                *((ulong*)pointer) = value;

            return array;
        }

        /// <summary>Converts an array of a 8-bytes unsigned integers to a byte array.</summary>
        /// <param name="values">The <see cref="T:System.ulong"/>[] value to convert.</param>
        /// <returns>A <see cref="T:System.byte"/>[] value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe byte[] TobyteArray64(params ulong[] values)
        {
            int length = values.Length;
            byte[] array = new byte[8 * length];

            fixed (byte* pin = array)
            {
                ulong* pointer = (ulong*)pin;

                for (int i = 0; i < length; ++i)
                    pointer[i] = values[i];
            }

            return array;
        }

        /// <summary>Reads a 2-bytes unsigned integer from the specified byte pointer, without increment.</summary>
        /// <param name="pointer">The <see cref="T:System.byte"/>* to read.</param>
        /// <returns>An <see cref="T:System.ushort"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ushort Fetch16(byte* pointer)
        {
            ushort v;

            if (s_IsLittleEndian)
                v = *((ushort*)pointer);
            else
                v = (ushort)((pointer[0] << 8) | pointer[1]);

            return v;
        }

        /// <summary>Reads a 4-bytes unsigned integer from the specified byte pointer, without increment.</summary>
        /// <param name="pointer">The <see cref="T:System.byte"/>* to read.</param>
        /// <returns>An <see cref="T:System.uint"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe uint Fetch32(byte* pointer)
        {
            uint v;

            if (s_IsLittleEndian)
                v = *((uint*)pointer);
            else
                v = ((uint)pointer[0] << 24) | ((uint)pointer[1] << 16) | ((uint)pointer[2] << 8) | pointer[3];

            return v;
        }

        /// <summary>Reads a 8-bytes unsigned integer from the specified byte pointer, without increment.</summary>
        /// <param name="pointer">The <see cref="T:System.byte"/>* to read.</param>
        /// <returns>An <see cref="T:System.ulong"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ulong Fetch64(byte* pointer)
        {
            ulong v;

            if (s_IsLittleEndian)
                v = *((ulong*)pointer);
            else
                v = ((ulong)pointer[0] << 56) | ((ulong)pointer[1] << 48) | ((ulong)pointer[2] << 40) | ((ulong)pointer[3] << 32) | ((ulong)pointer[4] << 24) | ((ulong)pointer[5] << 16) | ((ulong)pointer[6] << 8) | pointer[7];

            return v;
        }

        /// <summary>Reads a 2-bytes unsigned integer from the specified byte pointer, with increment.</summary>
        /// <param name="pointer">The <see cref="T:System.byte"/>* to read.</param>
        /// <returns>An <see cref="T:System.ushort"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ushort Read16(ref byte* pointer)
        {
            ushort v;

            if (s_IsLittleEndian)
                v = *((ushort*)pointer);
            else
                v = (ushort)((pointer[0] << 8) | pointer[1]);

            pointer += 2;

            return v;
        }

        /// <summary>Reads a 4-bytes unsigned integer from the specified byte pointer, with increment.</summary>
        /// <param name="pointer">The <see cref="T:System.byte"/>* to read.</param>
        /// <returns>An <see cref="T:System.uint"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe uint Read32(ref byte* pointer)
        {
            uint v;

            if (s_IsLittleEndian)
                v = *((uint*)pointer);
            else
                v = ((uint)pointer[0] << 24) | ((uint)pointer[1] << 16) | ((uint)pointer[2] << 8) | pointer[3];

            pointer += 4;

            return v;
        }

        /// <summary>Reads a 8-bytes unsigned integer from the specified byte pointer, with increment.</summary>
        /// <param name="pointer">The <see cref="T:System.byte"/>* to read.</param>
        /// <returns>An <see cref="T:System.ulong"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ulong Read64(ref byte* pointer)
        {
            ulong v;

            if (s_IsLittleEndian)
                v = *((ulong*)pointer);
            else
                v = ((ulong)pointer[0] << 56) | ((ulong)pointer[1] << 48) | ((ulong)pointer[2] << 40) | ((ulong)pointer[3] << 32) | ((ulong)pointer[4] << 24) | ((ulong)pointer[5] << 16) | ((ulong)pointer[6] << 8) | pointer[7];

            pointer += 8;

            return v;
        }
    }
}