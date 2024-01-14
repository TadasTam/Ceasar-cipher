using System;

namespace Caesar_cipher
{
    public class TaskUtils
    {
        /// <summary>
        /// Shifts letters to the left by a specified cipher number
        /// according to a Ceasar cipher
        /// </summary>
        /// <param name="cipherNumber">Number, by which to shift letters</param>
        /// <param name="inputText">Input text to cipher</param>
        /// <param name="Floors">Start symbols of cipher windows</param>
        /// <param name="Roofs">End symbols of cipher windows</param>
        /// <param name="windowCount">Number of letters windows</param>
        /// <returns>Ciphered input text as string</returns>
        public static string Cipher(int cipherNumber, string inputText, int[] Floors, int[] Roofs, int windowCount)
        {
            char[] Symbols = inputText.ToCharArray();

            for (int i = 0; i < Symbols.Length; i++)
            {
                int asciiCode = (int)Symbols[i];

                for (int windowIndex = 0; windowIndex < windowCount; windowIndex++)     //Iterate through every window of symbols (2 windows in default case)
                    if (asciiCode >= Floors[windowIndex] && asciiCode <= Roofs[windowIndex])    //If letter fits to window
                        Symbols[i] = cipherLetter(asciiCode, Floors[windowIndex], Roofs[windowIndex], cipherNumber);   //cipher that symbol
            }

            return new string(Symbols);
        }

        /// <summary>
        /// Ciphers one symbol by a specifed cipher number
        /// </summary>
        /// <param name="asciiCode">ASCII code of a symbol to cipher</param>
        /// <param name="floor">Start letter of a window to cipher at</param>
        /// <param name="roof">End letter of a window to cipher at</param>
        /// <param name="cipherNumber">Number by which to shift letter to the left</param>
        /// <returns>Ciphered symbol</returns>
        public static char cipherLetter (int asciiCode, int floor, int roof, int cipherNumber)
        {
            if (asciiCode < floor || asciiCode > roof) throw new Exception("Symbol is outside window area");

            int cipheredCode = asciiCode - floor - cipherNumber;    //Brings ascii code to the floor (base of 0). Then shifts left (substracts cipher number)

            if (cipheredCode < 0) cipheredCode = (roof - floor + 1) - Math.Abs(cipheredCode) % (roof - floor + 1);  //If, after shifting, code got negative, take it back to interval [0 ; window size]

            return (char)(((cipheredCode) % (roof - floor + 1)) + floor);   //Divide by window size, and whats left is new ascii code. Add floor back to bring ascii code to the start windows of symbols
        }

        /// <summary>
        /// Shifts letters to the right by a specified cipher number
        /// according to a Ceasar cipher
        /// </summary>
        /// <param name="cipherNumber">Number, by which to shift letters</param>
        /// <param name="inputText">Input text to cipher</param>
        /// <param name="Floors">Start symbols of cipher windows</param>
        /// <param name="Roofs">End symbols of cipher windows</param>
        /// <param name="windowCount">Number of letters windows</param>
        /// <returns>Ciphered input text as string</returns>
        public static string DeCipher(int cipherNumber, string inputText, int[] Floors, int[] Roofs, int windowCount)
        {
            return Cipher(-cipherNumber, inputText, Floors, Roofs, windowCount);
        }
    }
}
