using System;

namespace Core
{
    /// <summary>
    /// Author: Laurent Goffin
    /// </summary>
    public static class BinaryUtilities
    {
        /// <summary>
        /// Bitwise right shift with the specified number
        /// </summary>
        /// <param name="number">Number to operate on</param>
        /// <param name="bits">Number of bits to shift</param>
        /// <returns>Shifted number</returns>
        public static Int32 RightShift(Int32 number, byte bits)
        {
            if (number >= 0) return number >> bits;
            else return (number >> bits) + (2 << ~bits);
        }

        /// <summary>
        /// Bit-reversal permutation
        /// </summary>
        /// <param name="number">Number to reverse</param>
        /// <param name="bits">Number of bits to use</param>
        /// <returns>Reversed number</returns>
        public static UInt32 BitReversal(Int32 number, byte numberOfBits)
        {
            var bitString = Convert.ToString(number, 2).PadLeft(numberOfBits, '0');
            char[] charArr = bitString.ToCharArray();
            Array.Reverse(charArr);
            UInt32 result = Convert.ToUInt32(new string(charArr), 2);
            return result;
        }
    }
}
