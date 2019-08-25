using System;

namespace homework_07_part_01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool process = true;
            int wordsCounter = 0;
            int aCounter = 0;
            string inputString = null;

            while (process)
            {
                Console.WriteLine("Enter string that contains more that one word. You can have only one ' ' symbol between words");
                try
                {
                    inputString = Console.ReadLine();

                    string[] words = inputString.Split(' ');

                    foreach (string word in words)
                    {
                        if (word[0] != ' ') wordsCounter++;
                        if (word[0] == 'A' || word[0] == 'a') aCounter++;
                    }

                    if (wordsCounter > 1)
                    {
                        process = false;
                        Console.WriteLine(aCounter);

                    }
                }
                catch
                {
                    if (string.IsNullOrWhiteSpace(inputString) == true || string.IsNullOrEmpty(inputString) == true)
                    {
                        throw new Exception("String was empty.");
                    }
                }
            }
        }
    }
}
