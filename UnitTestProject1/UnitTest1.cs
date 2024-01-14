using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Caesar_cipher.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class CipherTests
        {
            [TestMethod]
            public void TestMethod1()
            {
                Action act = () => TaskUtils.Cipher();
            }
        }

        [TestClass]
        public class cipherLetterTests
        {
            [TestMethod]
            public void TestMethod1()
            {

            }
        }

        
    }
}
