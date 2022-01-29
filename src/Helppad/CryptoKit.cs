using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using System.IO;
using System.Runtime.CompilerServices;

namespace Helppad
{

    /// <summary>
    /// The kit of helper for crypto functions
    /// </summary>
    public static class CryptoKit
    {
        /// <summary>
        /// Generate an sequence with random bytes.
        /// </summary>
        /// <param name="length">The size of sequence to generate.</param>
        /// <returns>The generated sequence.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] RandomBytes(int length)
        {
            // from range
            return Enumerable.Range(0, length)
                .Select(x => (byte)SimpleToolkit.SharedRandom.Next(0,255))
                .ToArray();
        }

        /// <summary>
        /// Generate an sequence with random token.
        /// </summary>
        /// <param name="length">The size of token sequence.</param>
        /// <returns>The generated token.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string RandomToken(int length)
        {
            // from range
            return Convert.ToBase64String(RandomBytes(length));
        }

        /// <summary>
        /// The passed algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetHash(string src, HashAlgorithm algorithm, Encoding encoding = null)
        {
            Review.NotNull(src, "The text source cannot be null");
            Review.NotNull(src, "The algorithm implementation is required");

            encoding = SimpleToolkit.FallbackValue(encoding, () => Encoding.UTF8);

            return FormatBytes(algorithm.ComputeHash(encoding.GetBytes(src)), StandardFormat.HexLarge);
        }

        /// <summary>
        /// The passed algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetHash(byte[] src, HashAlgorithm algorithm)
        {
            Review.NotNull(src, "The bytes source cannot be null");
            Review.NotNull(src, "The algorithm implementation is required");

            return FormatBytes(algorithm.ComputeHash(src), StandardFormat.HexLarge);
        }

        /// <summary>
        /// The sha256 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Sha256(byte[] src, SHA256 alg = null)
        {
            Review.NotNull(src, "The bytes source cannot be null");
            bool transient = alg is null;

            alg = SimpleToolkit.FallbackValue(alg, () => SHA256.Create());
            if(transient) alg.Dispose();

            return FormatBytes(alg.ComputeHash(src), StandardFormat.HexLarge);
        }

        /// <summary>
        /// The sha348 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Sha238(byte[] src, SHA384 alg = null)
        {
            Review.NotNull(src, "The bytes source cannot be null");
            bool transient = alg is null;

            alg = SimpleToolkit.FallbackValue(alg, () => SHA384.Create());
            if(transient) alg.Dispose();

            return FormatBytes(alg.ComputeHash(src), StandardFormat.HexLarge);
        }

        /// <summary>
        /// The sha512 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Sha512(byte[] src, SHA512 alg = null)
        {
            Review.NotNull(src, "The bytes source cannot be null");
            bool transient = alg is null;

            alg = SimpleToolkit.FallbackValue(alg, () => SHA512.Create());
            if(transient) alg.Dispose();

            return FormatBytes(alg.ComputeHash(src), StandardFormat.HexLarge);
        }

        /// <summary>
        /// The sha1 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Sha1(byte[] src, SHA1 alg = null)
        {
            Review.NotNull(src, "The bytes source cannot be null");

            bool transient = alg is null;
            alg = SimpleToolkit.FallbackValue(alg, () => SHA1.Create());

            if (transient) alg.Dispose();
            return FormatBytes(alg.ComputeHash(src), StandardFormat.HexLarge);
        }

        /// <summary>
        /// The sha256 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Sha256(string src, Encoding encoding = null, SHA256 alg = null)
        {
            Review.NotNull(src, "The text source cannot be null");

            bool transient = alg is null;
            encoding = SimpleToolkit.FallbackValue(encoding, () => Encoding.UTF8);

            alg = SimpleToolkit.FallbackValue(alg, () => SHA256.Create());
            byte[] result = alg.ComputeHash(encoding.GetBytes(src));
            if(transient) alg.Dispose();

            return FormatBytes(result, StandardFormat.HexLarge);
        }

        /// <summary>
        /// The sha348 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Sha348(string src, Encoding encoding = null, SHA384 alg = null)
        {
            Review.NotNull(src, "The text source cannot be null");
            bool transient = alg is null;

            encoding = SimpleToolkit.FallbackValue(encoding, () => Encoding.UTF8);
            alg = SimpleToolkit.FallbackValue(alg, () => SHA384.Create());

            byte[] result = alg.ComputeHash(encoding.GetBytes(src));
            if(transient) alg.Dispose();

            return FormatBytes(result, StandardFormat.HexLarge);
        }

        /// <summary>
        /// The sha512 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Sha512(string src, Encoding encoding = null, SHA512 alg = null)
        {
            Review.NotNull(src, "The text source cannot be null");
            bool transient = alg is null;

            encoding = SimpleToolkit.FallbackValue(encoding, () => Encoding.UTF8);
            alg = SimpleToolkit.FallbackValue(alg, () => SHA512.Create());

            byte[] result = alg.ComputeHash(encoding.GetBytes(src));
            if(transient) alg.Dispose();

            return FormatBytes(result, StandardFormat.HexLarge);
        }

        /// <summary>
        /// The sha1 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Sha1(string src, Encoding encoding = null, SHA1 alg = null)
        {
            Review.NotNull(src, "The text source cannot be null");
            bool transient = alg is null;

            encoding = SimpleToolkit.FallbackValue(encoding, () => Encoding.UTF8);
            alg = SimpleToolkit.FallbackValue(alg, () => SHA1.Create());

            byte[] result = alg.ComputeHash(encoding.GetBytes(src));
            if (transient) alg.Dispose();

            return FormatBytes(result, StandardFormat.HexLarge);
        }

        /// <summary>
        /// The md5 algorithm to hash the entry data
        /// </summary>
        /// <param name="src"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string MD5(string src, Encoding encoding = null, MD5 alg = null)
        {
            Review.NotNull(src, "The text source cannot be null");
            bool transient = alg is null;
            encoding = SimpleToolkit.FallbackValue(encoding, () => Encoding.UTF8);
            alg = SimpleToolkit.FallbackValue(alg, () => System.Security.Cryptography.MD5.Create());
            byte[] result = alg.ComputeHash(encoding.GetBytes(src));
            if (transient) alg.Dispose();
            return FormatBytes(result, StandardFormat.HexLarge);
        }

        /// <summary>
        /// Decrypt a data package from an key and string.
        /// </summary>
        /// <param name="keyCipher">Key Chipher for encryptation.</param>
        /// <param name="data">Data package.</param>
        /// <returns>Decrypted text.</returns>
        public static string Decrypt(string keyCipher, string data)
        {
            var key = Encoding.UTF8.GetBytes(keyCipher);

            return Decrypt(key, data);
        }

        /// <summary>
        /// Encrypt a data package from an key and string.
        /// </summary>
        /// <param name="keyCipher">Key Chipher for encryptation.</param>
        /// <param name="text">Data package.</param>
        /// <returns>Encrypted text.</returns>
        public static string Encrypt(string keyCipher, string text)
        {
            var key = Encoding.UTF8.GetBytes(keyCipher);

            return Encrypt(key, text);
        }

        /// <summary>
        /// Decrypt a data package from an key and string.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decrypt(byte[] key, string data)
        {
            var fullCipher = Convert.FromBase64String(data);

            var iv = new byte[16];
            var cipher = new byte[16];

            // get IV and body cipher
            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);

            using var aesAlg = Aes.Create();
            using var decryptor = aesAlg.CreateDecryptor(key, iv);
            string result = DecryptFrom(cipher, decryptor);

            return result;
        }

        /// <summary>
        /// Decryptation from a chipher block and transformer.
        /// </summary>
        /// <param name="cipher"></param>
        /// <param name="decryptor"></param>
        /// <returns></returns>
        public static string DecryptFrom(byte[] cipher, ICryptoTransform decryptor)
        {
            string result;
            using (var msDecrypt = new MemoryStream(cipher))
            {
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                result = srDecrypt.ReadToEnd();
            }

            return result;
        }

        /// <summary>
        /// Encrypt a data package from an key and string.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(byte[] key, string text)
        {
            using var aesAlg = Aes.Create();
            using var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV);
            MemoryStream msEncrypt = EncryptData(text, encryptor);
            var iv = aesAlg.IV;
            return Convert.ToBase64String(PutIVInBlock(msEncrypt, iv));
        }

        /// <summary>
        /// Put the Initial Vector in data block.
        /// </summary>
        /// <param name="msEncrypt"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        private static byte[] PutIVInBlock(MemoryStream msEncrypt, byte[] iv)
        {
            var decryptedContent = msEncrypt.ToArray();


            var result = new byte[iv.Length + decryptedContent.Length];

            // put IV and body cipher
            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);
            return result;
        }

        /// <summary>
        /// Make a encryptation from text and algorithm.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="encryptor"></param>
        /// <returns></returns>
        public static MemoryStream EncryptData(string text, ICryptoTransform encryptor)
        {
            var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(text);
            }

            return msEncrypt;
        }

        /// <summary>
        /// The format to bytes
        /// </summary>
        /// <param name="result"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static string FormatBytes(byte[] result, string format)
        {
            return string.Join("", result.Select(x => x.ToString(format)).ToArray());
        }
    }
}
