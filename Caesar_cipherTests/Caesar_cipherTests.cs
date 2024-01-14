using Microsoft.VisualStudio.TestTools.UnitTesting;
using Caesar_cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Caesar_cipher.Tests
{
    [TestClass()]
    public class Caesar_cipherTests
    {
        static int[] Floors = { (int)'a', (int)'A' };
        static int[] Roofs = { (int)'z', (int)'Z' };
        static int windowsCount = 2;

        [TestClass()]
        public class CipherTests
        {

            [TestMethod()]
            public void Should_notChange_whenCipherNumberIs_0()
            {
                string actual = "abcdefABCDEF";

                string ciphered = TaskUtils.Cipher(0, actual, Floors, Roofs, windowsCount);

                actual.Should().BeEquivalentTo(ciphered);
            }


            [TestMethod()]
            public void Should_Cipher_and_decipher_back()
            {
                string actual = "abcdefABCDEF";

                string ciphered = TaskUtils.Cipher(3, actual, Floors, Roofs, windowsCount);
                ciphered = TaskUtils.DeCipher(3, ciphered, Floors, Roofs, windowsCount);

                actual.Should().BeEquivalentTo(ciphered);
            }

            [TestMethod()]
            public void Should_notThrow_inputStringEmpty()
            {
                Action act = () => TaskUtils.DeCipher(3, "", Floors, Roofs, windowsCount);

                act.Should().NotThrow();
            }

            [TestMethod()]
            public void Should_notThrow_CipherNumberVeryBig()
            {
                Action act = () => TaskUtils.DeCipher(300, "abcdefABCDEF", Floors, Roofs, windowsCount);

                act.Should().NotThrow();
            }

            [TestMethod()]
            public void Should_Cipher_and_decipherBback_CipherNumberVeryBig()
            {
                string actual = "abcdefABCDEF";

                string ciphered = TaskUtils.Cipher(300, actual, Floors, Roofs, windowsCount);
                ciphered = TaskUtils.DeCipher(300, ciphered, Floors, Roofs, windowsCount);

                actual.Should().BeEquivalentTo(ciphered);
            }

            [TestMethod()]
            public void Should_notThrow_CipherNumberNegative()
            {
                Action act = () => TaskUtils.DeCipher(-3, "abcdefABCDEF", Floors, Roofs, windowsCount);

                act.Should().NotThrow();
            }

            [TestMethod()]
            public void Should_Cipher_and_decipherBback_CipherNumberNegative()
            {
                string actual = "abcdefABCDEF";

                string ciphered = TaskUtils.Cipher(-3, actual, Floors, Roofs, windowsCount);
                ciphered = TaskUtils.DeCipher(-3, ciphered, Floors, Roofs, windowsCount);

                actual.Should().BeEquivalentTo(ciphered);
            }

            [TestMethod()]
            public void Should_notThrow_CipherNumberNegativeLarge()
            {
                Action act = () => TaskUtils.DeCipher(-300, "abcdefABCDEF", Floors, Roofs, windowsCount);

                act.Should().NotThrow();
            }

            [TestMethod()]
            public void Should_Cipher_and_decipherBback_CipherNumberNegativeLarge()
            {
                string actual = "abcdefABCDEF";

                string ciphered = TaskUtils.Cipher(-300, actual, Floors, Roofs, windowsCount);
                ciphered = TaskUtils.DeCipher(-300, ciphered, Floors, Roofs, windowsCount);

                actual.Should().BeEquivalentTo(ciphered);
            }
        }

        [TestClass()]
        public class cipherLetter
        {
            [TestMethod()]
            public void Should_CipherCorrectly_cipherNumber3()
            {
                char actual = 'a';

                char cipheredLetter = TaskUtils.cipherLetter((int)'d', Floors[0], Roofs[0], 3);

                (actual.ToString()).Should().BeEquivalentTo(cipheredLetter.ToString());
            }

            [TestMethod()]
            public void Should_CipherCorrectly_cipherNumberNegative()
            {
                char actual = 'g';

                char cipheredLetter = TaskUtils.cipherLetter((int)'d', Floors[0], Roofs[0], -3);

                (actual.ToString()).Should().BeEquivalentTo(cipheredLetter.ToString());
            }

            [TestMethod()]
            public void Should_NotThrow_CipherNumberNegativeLarge()
            {
                Action act = () => TaskUtils.cipherLetter((int)'d', Floors[0], Roofs[0], -300);

                act.Should().NotThrow();
            }

            [TestMethod()]
            public void Should_NotThrow_CipherNumberLarge()
            {
                Action act = () => TaskUtils.cipherLetter((int)'d', Floors[0], Roofs[0], 300);

                act.Should().NotThrow();
            }

            [TestMethod()]
            public void Should_CipherAndDecypher_Correct_NumberLarge()
            {
                char actual = 'g';

                char cipheredLetter = TaskUtils.cipherLetter((int)actual, Floors[0], Roofs[0], 300);
                cipheredLetter = TaskUtils.cipherLetter((int)cipheredLetter, Floors[0], Roofs[0], -300);

                (actual.ToString()).Should().BeEquivalentTo(cipheredLetter.ToString());
            }

            [TestMethod()]
            public void Should_Throw_ifSymbolIs_OutsideWindow()
            {
                Action act = () => TaskUtils.cipherLetter((int)'d', Floors[1], Roofs[1], 300);

                act.Should().Throw<Exception>();
            }

        }

        [TestClass()]
        public class ReadInputTests
        {
            [TestMethod()]
            public void Should_Throw_inputFileNotExists()
            {
                Action act = () => InOutUtils.ReadText("");

                act.Should().Throw<Exception>();
            }

            [TestMethod()]
            public void Should_NotThrow_InputFileExists()
            {
                //Input should be in default place
                string CFr = Environment.CurrentDirectory;
                CFr = CFr.Substring(0, CFr.Length - 15) + "\\App_Data\\InputText.txt";

                Action act = () => InOutUtils.ReadText(CFr);

                act.Should().NotThrow();
            }
        }
    }
}