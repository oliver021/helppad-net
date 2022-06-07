using System;
using System.Linq;
using System.Collections.Generic;

namespace Helppad.Algorithms
{
    /// <summary>
    /// Hashes methods.
    /// </summary>
    public static class Hash
    {
        /// <summary>
        /// Recive a byte sequence and return a hash 8 bytes long.
        /// Easy to use, but not secure.
        /// Name: Reducted
        /// </summary>
        /// <param name="sequence">The object for which to return a hash code.</param>
        /// <returns>A hash code for the specified object.</returns>
        public static byte[] HashReducted(byte[] sequence)
        {
            byte[] hash = new byte[8];

            for (int i = 0; i < sequence.Length; i++)
            {
                hash[i % 8] ^= sequence[i];

                if (i % 8 == 7)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        hash[j] = (byte)(hash[j] ^ hash[j - 1]);
                    }
                }
            }

            return hash;
        }

        /// <summary>
        /// Recive a byte sequence and make hash digest with length passed as parameter.
        /// Easy to use, but not secure.
        /// Name: Pull num
        /// </summary>
        /// <param name="sequence">The object for which to return a hash code.</param>
        /// <param name="pull">The length of the hash.</param>
        /// <returns>A hash code for the specified object.</returns>
        public static byte[] PullNum(byte[] sequence, int pull)
        {
            byte[] hash = new byte[pull];

            // split sequence into pull parts base in pull length
            byte[][] parts = new byte[pull][];
            for (int i = 0; i < pull; i++)
            {
                parts[i] = new byte[sequence.Length / pull];
                for (int j = 0; j < parts[i].Length; j++)
                {
                    parts[i][j] = sequence[i * parts[i].Length + j];
                }
            }

            // make digest for each part
            return parts.Select(part => PullNumHelper(part)).ToArray();
        }

        /// <summary>
        /// Pull num helper.
        /// </summary>
        /// <param name="sequence">The object for which to return a hash code.</param>
        /// <returns>The pull number</returns>
        public static byte PullNumHelper(byte[] sequence) 
        =>
            // reduce sequence to single byte
            sequence.Aggregate((byte)0, (current, b) => (byte)(current ^ b));
    }
}