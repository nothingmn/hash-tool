using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace hash.tests
{
    public class BasicHashTests
    {
        private string input = "TEST";
        private string MD5 = "70659f64a0d9277bb3d15f5215ba50ab";
        private string SHA1 = "676e1309992ecd8cd1e6db0effeb77a1b34aafd8";
        private string SHA256 = "cf357a0a1528d9b4d2fd4a4ec9e498b373d7a731f99b80f02c9b81f9ba721db6";
        private string SHA384 = "b25d38242b6bb1fa3f7c85969293aa87ef9a823e01404e665aaf3e3155ef45a0cf3c7eb9290639615608d8925cdca300";
        private string SHA512 = "ca5cf1e991630ae78764dfc35e52109f40dae844bd560981c9f0d2ebccb905b2e65416b14cec9781fe0a30f21d67051be6b6355271cda2d09369971b894a95fa";
        private string Murmur2 = "1765845542";
        private string Murmur3 = "1281354141";


        [Test]
        public void MurMur2Basic()
        {
            Assert.AreEqual(Murmur2, hash.Hash.GetHash(input, Hash.HashType.Murmur2));
        }

        [Test]
        public void MurMur3Basic()
        {
            Assert.AreEqual(Murmur3, hash.Hash.GetHash(input, Hash.HashType.Murmur3));
        }
        [Test]
        public void MD5Basic()
        {
            Assert.AreEqual(MD5, hash.Hash.GetHash(input, Hash.HashType.MD5));
        }
        [Test]
        public void SHA1Basic()
        {
            Assert.AreEqual(SHA1, hash.Hash.GetHash(input, Hash.HashType.SHA1));
        }
        [Test]
        public void SHA256Basic()
        {
            Assert.AreEqual(SHA256, hash.Hash.GetHash(input, Hash.HashType.SHA256));
        }
        [Test]
        public void SHA384Basic()
        {
            Assert.AreEqual(SHA384, hash.Hash.GetHash(input, Hash.HashType.SHA384));
        }
        [Test]
        public void SHA512Basic()
        {
            Assert.AreEqual(SHA512, hash.Hash.GetHash(input, Hash.HashType.SHA512));
        }
    }
}
