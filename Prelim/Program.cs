using System;
using System.Linq;
using System.Reflection.Metadata;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string decision = "";
            while (true)
            {
                Console.WriteLine("Would you like to encrypt or decrpt a message? [E / D]");
                decision = Console.ReadLine().ToUpper();
                Console.WriteLine(decision);
                Console.Clear();

                if (decision == "E" || decision == "D")
                    break;
            }

            Console.Clear();
            Console.WriteLine("Entering Machine Mode");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter key");
            string key = Console.ReadLine();
            string Cipher = BuildCipher(key);

            if (decision == "E")
            {
                Console.WriteLine("Enter word to be ciphered: ");
                string Word = Console.ReadLine().ToUpper();
                string CipheredWord = Translate(Word, Cipher, "Cipher");
                streamWrite(CipheredWord);
                Console.WriteLine(CipheredWord);
                Console.ReadLine();
            }
            else if (decision == "D")
            {
                string Word = streamRead();
                string DecipheredWord = Translate (Word, Cipher, "Decipher");
                Console.WriteLine(DecipheredWord);
                Console.ReadLine();
            }
        }

        static string Translate(string word, string cipher, string mode)
        {
            string alphabet = initializeAlphabet();
            string newText = "";

            for (int i = 0; i < word.Length; i++) 
            {
                if (!isUpperCaseAlphabet(word[i].ToString()))
                    newText += word[i];
                else
                {
                    if (mode == "Cipher")
                    {
                        int index = Array.IndexOf(alphabet.ToArray(), word[i]);
                        newText += cipher[index];
                    }
                    else if (mode == "Decipher")
                    {
                        int index = Array.IndexOf(cipher.ToArray(), word[i]);
                        newText += alphabet[index];
                    }
                }
            }
            return newText;
        }

        static bool isUpperCaseAlphabet(string letter)
        {
            for (int ascii = 65; ascii < 91; ascii++)
                if (letter == (((char)ascii).ToString()))
                    return true;
            return false;
        }

        static string initializeAlphabet()
        {
            string alphabet = "";
            for (int ascii = 65; ascii < 91; ascii++)
                alphabet += (((char)ascii).ToString());
            return alphabet;
        }

        static string BuildCipher(string key)
        {
            return cipherFiller(removeDuplicates(sanitize(key.ToUpper())));
        }

        static string sanitize(string word)
        {
            string newKey = "";
            for (int letter = 0; letter < word.Length; letter++)
                for (int ascii = 65; ascii < 91; ascii++)
                    if ((char)ascii == word[letter])
                        newKey += (char)ascii;
            return newKey;
        }
        static List<string> removeDuplicates(string word)
        {
            List<string> letters = new List<string>();
            for (int i = 0; i < word.Length; i++)
                if (!letters.Contains(word[i].ToString()))
                    letters.Add(word[i].ToString());
            return letters;
        }
    
        static string cipherFiller(List<string> letters)
        {
            for (int ascii = 65; ascii < 91; ascii++)
                if (!letters.Contains(((char)ascii).ToString()))
                    letters.Add(((char)ascii).ToString());
            return string.Join("", letters);
        }

        static string streamRead()
        {
            using (StreamReader sr = new StreamReader("eMessage.txt"))
                return sr.ReadLine();
        }

        static void streamWrite(string word)
        {
            using (StreamWriter sw = new StreamWriter("eMessage.txt", false))
                sw.WriteLine(word);
        }
    }
}
