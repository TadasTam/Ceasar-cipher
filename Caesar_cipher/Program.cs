using System;
using System.IO;

namespace Caesar_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting file
            string CFr = Environment.CurrentDirectory;
            CFr = CFr.Substring(0, CFr.Length-10) + "\\App_Data\\InputText.txt";

            string inputText;
            try { inputText = InOutUtils.ReadText(CFr); }
            catch {
                Console.WriteLine("Can't read from input file");
                return;
            }

            //inputText = "";  //Input text can also be inserted here for testing purposes

            //Shift number
            int cipherNumber = 3;

            //Information regarding areas of symbols to cipher
            //Now set to default latin letters
            int[] Floors = { (int)'a',(int)'A' };
            int[] Roofs = { (int)'z', (int)'Z' };
            int windowsCount = Math.Min(Floors.Length, Roofs.Length);

            //Testing of the program
            string cipheredText;

            Console.WriteLine("Input text: ");
            Console.WriteLine(inputText);

            Console.WriteLine();

            Console.WriteLine("Encyphered text (by {0}): ", cipherNumber);
            cipheredText = TaskUtils.Cipher(cipherNumber, inputText, Floors, Roofs, windowsCount);
            Console.WriteLine(cipheredText);

            Console.WriteLine();

            Console.WriteLine("Decyphered text: ");
            cipheredText = TaskUtils.DeCipher(cipherNumber, cipheredText, Floors, Roofs, windowsCount);
            Console.WriteLine(cipheredText);
        }
    }
}
