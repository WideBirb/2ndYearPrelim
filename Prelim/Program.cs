using System;

namespace MyApp // Note: actual namespace depends on the project name.
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

            Console.WriteLine("Enter key");
            string key = Console.ReadLine();
            string Cipher = cipherFiller(removeDuplicates(sanitize(key.ToUpper())));

            // encrypt
            if (decision == "E")
            {
                Console.WriteLine("ENTER WORD TO BE CIPHERED");
                string Word = Console.ReadLine().ToUpper();

                string Ciphered = CipherWord(Word, Cipher);
                outputWord(Ciphered);
                Console.WriteLine(Ciphered);
            }
            // decrypt
            else if (decision == "D")
            {
                string Word = WordToDecipher();
                string DecipheredWord = DecipherWord(Word, Cipher);
                Console.WriteLine(DecipheredWord);
                Console.ReadLine();
            }
        }

        static string CipherWord(string word, string cipher)
        {
            string alphabet = initializeAlphabet();
            string temp = "";

            for (int i = 0; i < word.Length; i++) 
            {
                if (word[i].ToString() == " ")
                    temp += " ";
                else
                {
                    //Console.WriteLine("ALPHABET: " + alphabet);
                   //Console.WriteLine("CIPHER: " + cipher);
                    //Console.WriteLine("WORD: " + word);
                    //Console.WriteLine("WORD[i]: " +  word[i]);
                    int index = Array.IndexOf(alphabet.ToArray(), word[i]);
                    //Console.WriteLine("INDEX IS: " + index);
                    //Console.WriteLine("ALPHABET COUNT: " + alphabet.Count());
                    temp += cipher[index];
                }
                    
            }
            return temp;
        }

        static string DecipherWord(string word, string cipher)
        {
            string alphabet = initializeAlphabet();
            string temp = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].ToString() == " ")
                    temp += " ";
                else
                {
                    int index = Array.IndexOf(cipher.ToArray(), word[i]);
                    temp += alphabet[index];
                }

            }
            return temp;
        }

        static string initializeAlphabet()
        {
            string alphabet = "";
            for (int ascii = 65; ascii < 91; ascii++)
            { 
                alphabet += (((char)ascii).ToString());
            }
            return alphabet;
        }

        // finishes the cypher
        static string cipherFiller(List<string> letters)
        {
            // fills in the remaining cipher
            for (int ascii = 65; ascii < 91; ascii++)
                // if the cypher does not contain the letter yet, it will be added
                if (!letters.Contains(((char)ascii).ToString()))
                    letters.Add(((char)ascii).ToString());

            //turns the list into string
            string CipherString = "";
            for (int letter = 0; letter < letters.Count; letter++)
                CipherString += letters[letter];
            return CipherString;
        }

        static List<string> removeDuplicates(string word)
        {
            List<string> letters = new List<string>();
            for (int i = 0; i < word.Length; i++)
                if (!letters.Contains(word[i].ToString()))
                    letters.Add(word[i].ToString());

            return letters;
        }


        // removes every special characters and number
        static string sanitize(string word)
        {
            string newKey = "";
            for (int letter = 0; letter < word.Length; letter++)
                for (int ascii = 65; ascii < 91; ascii++)
                    if ((char)ascii == word[letter])
                        newKey += (char)ascii;
            return newKey;
        }

        static string WordToDecipher()
        {
            string temp = "";
            using (StreamReader sr = new StreamReader("eMessage.txt"))
                temp = sr.ReadLine();
            return temp;
        }

        static void outputWord(string word)
        {
            using (StreamWriter sw = new StreamWriter("eMessage.txt", false))
                sw.WriteLine(word);
        }
    }
}

//using System;

//namespace MyApp // Note: actual namespace depends on the project name.
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            string decision = "";
//            while (true)
//            {
//                Console.WriteLine("Would you like to encrypt or decrpt a message? [E / D]");
//                decision = Console.ReadLine().ToUpper();
//                Console.WriteLine(decision);
//                Console.Clear();

//                if (decision == "E" || decision == "D")
//                    break;
//            }

//            Console.WriteLine("Enter key");
//            string key = Console.ReadLine();
//            string Cipher = cipherFiller(removeDuplicates(sanitize(key.ToUpper())));

//            // encrypt
//            if (decision.ToUpper() == "E")
//            {
//                Console.WriteLine("ENTER WORD TO BE CIPHERED");
//                string Word = Console.ReadLine();

//                string Ciphered = CipherWord(Word, Cipher);
//                outputWord(Ciphered);
//            }
//            // decrypt
//            else if (decision.ToUpper() == "D")
//            {
//                string Word = WordToDecipher();
//                string DecipheredWord = DecipherWord(Word, Cipher);
//                Console.WriteLine(DecipheredWord);
//            }



//        }

//        static string CipherWord(string word, string cipher)
//        {
//            string alphabet = initializeAlphabet();
//            string temp = "";

//            for (int i = 0; i < word.Length; i++)
//            {
//                if (word[i].ToString() == " ")
//                    temp += " ";
//                else
//                {
//                    int index = Array.IndexOf(alphabet.ToArray(), word[i]);
//                    temp += cipher[index];
//                }


//            }
//            return temp;
//        }

//        static string DecipherWord(string word, string cipher)
//        {
//            string alphabet = initializeAlphabet();
//            string temp = "";

//            for (int i = 0; i < word.Length; i++)
//            {
//                if (word[i].ToString() == " ")
//                    temp += " ";
//                else
//                    temp += alphabet[Array.IndexOf(cipher.ToArray(), word[i])];

//            }
//            return temp;

//        }

//        static string initializeAlphabet()
//        {
//            string alphabet = "";
//            for (int ascii = 65; ascii < 91; ascii++)
//            {
//                alphabet += (((char)ascii).ToString());
//            }
//            return alphabet;
//        }

//        // finishes the cypher
//        static string cipherFiller(List<string> letters)
//        {
//            // fills in the remaining cipher
//            for (int ascii = 65; ascii < 91; ascii++)
//                // if the cypher does not contain the letter yet, it will be added
//                if (!letters.Contains(((char)ascii).ToString()))
//                    letters.Add(((char)ascii).ToString());

//            //turns the list into string
//            string CipherString = "";
//            for (int letter = 0; letter < letters.Count; letter++)
//                CipherString += letters[letter];
//            return CipherString;
//        }

//        static List<string> removeDuplicates(string word)
//        {
//            List<string> letters = new List<string>();
//            for (int i = 0; i < word.Length; i++)
//                if (!letters.Contains(word[i].ToString()))
//                    letters.Add(word[i].ToString());

//            return letters;
//        }


//        // removes every special characters and number
//        static string sanitize(string word)
//        {
//            string newKey = "";
//            for (int letter = 0; letter < word.Length; letter++)
//                for (int ascii = 65; ascii < 91; ascii++)
//                    if ((char)ascii == word[letter])
//                        newKey += (char)ascii;
//            return newKey;
//        }

//        static string WordToDecipher()
//        {
//            string temp = "";
//            using (StreamReader sr = new StreamReader("eMessage.txt"))
//                temp = sr.ReadLine();
//            return temp;
//        }

//        static void outputWord(string word)
//        {
//            using (StreamWriter sw = new StreamWriter("eMessage.txt", false))
//                sw.WriteLine(word);
//        }
//    }
//}

