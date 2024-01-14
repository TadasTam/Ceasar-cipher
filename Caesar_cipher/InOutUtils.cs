using System.IO;

namespace Caesar_cipher
{
    public class InOutUtils
    {
        /// <summary>
        /// Reads input text from a text file
        /// </summary>
        /// <param name="fileName">path to input file</param>
        /// <returns>String information from input file</returns>
        public static string ReadText(string fileName)
        {
            string inputText = "abcdefghijklmnoprqstuvzxABCDEFGHIJKLMNOPRSQTUVWZ";

            using (StreamReader reader = new StreamReader(fileName))
            {
                inputText = reader.ReadToEnd();
            }

            return inputText;
        }
    }
}
