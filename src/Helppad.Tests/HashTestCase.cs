using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Helppad.Tests
{
    public class HashComprobation : HashSet<byte[]>
    {
        public bool IsFail { get; set; } = false;

        /// <summary>
        /// Process to next hash comprobation.
        public void CheckNext(byte[] sequence){
            var result = Helppad.Algorithms.Hash.HashReducted(sequence);

            // check if the result is in the set
            if (this.Contains(result))
            {
                    this.IsFail = true;
            } else {
                // add the result to the set
                this.Add(result);
            }
        }
    }

    /// <summary>
    /// Tests for the <see cref="Hash"/> class.
    /// </summary>
    public class HashTestCase
    {
        private const int SequencesToTest = 100;

        /// <summary>
        /// Generates a random byte array.
        /// </summary>
        public static byte[][] MockSequences(int sequences)
        {
            byte[][] sequencesArray = new byte[sequences][];

            // use random sequences
            var random = new Random();

            for (int i = 0; i < sequences; i++)
            {
                sequencesArray[i] = new byte[i];

                // generate sequences until 40 bytes
                for (int j = 0; j < random.Next(4, 40); j++)
                {
                    sequencesArray[i][j] = (byte)random.Next(0, 255);
                }
            }

            return sequencesArray;
        }

        /// <summary>
        /// Tests the <see cref="Hash.HashReducted(byte[])"/> method.
        /// </summary>
        [Test]
        public void HashReductedTest()
        {
            // generate random sequences
            var sequences = MockSequences(SequencesToTest);

            // create a new hash comprobation
            var hashComprobation = new HashComprobation();

            // index of the sequence to test
            int index = 0;

            // check until fail
            while (!hashComprobation.IsFail && index < SequencesToTest)
            {
                // get a random sequence
                var sequence = sequences[new Random().Next(0, sequences.Length)];

                // check the next sequence
                hashComprobation.CheckNext(sequence);
            }

            // check if the hash comprobation is fail
            Assert.IsFalse(hashComprobation.IsFail);
        }
    }
}