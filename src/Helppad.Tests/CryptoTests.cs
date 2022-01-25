using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helppad.Tests
{
    class CryptoTests
    {
        public const string Msg = "hello world";
        public const string MsgSha256 = "b94d27b9934d3e08a52e52d7da7dabfac484efe37a5380ee9088f7ace2efcde9";
        public const string MsgSha348= "fdbd8e75a67f29f701a4e040385e2e23986303ea10239211af907fcbb83578b3e417cb71ce646efd0819dd8c088de1bd";
        public const string MsgSha512 = "309ecc489c12d6eb4cc40f50c902f2b4d0ed77ee511a7c7a9bcd3ca86d4cd86f989dd35bc5ff499670da34255b45b0cfd830e81f605dcf7dc5542e93ae9cd76f";
        public const string MsgMD5 = "5eb63bbbe01eeed093cb22bb8f5acdc3";

        [Test]
        public void TestShowHashes()
        {
            Assert.AreEqual(CryptoKit.Sha256(Msg), MsgSha256);
            Assert.AreEqual(CryptoKit.Sha348(Msg), MsgSha348);
            Assert.AreEqual(CryptoKit.Sha512(Msg), MsgSha512);
            Assert.AreEqual(CryptoKit.MD5(Msg), MsgMD5);
        }

        [Test]
        public void TestRandomBytes()
        {
            Console.WriteLine(string.Join("", CryptoKit.RandomBytes(16)));
        }

        [Test]
        public void TestEncryptation()
        {
            string key = "5eb63bbbe01eeed0";

            string encrypted = CryptoKit.Encrypt(key, Msg);

            Console.WriteLine(encrypted);

            Assert.AreEqual(Msg, CryptoKit.Decrypt(key, encrypted));
        }
    }
}
