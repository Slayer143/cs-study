using System;

namespace homework_07_part_01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool process = true;
            int wordsCounter = 0;

            while (process)
            {
                Console.WriteLine("Enter string that contains more that one word");
                try
                {
                    string inputString = Console.ReadLine();

                    for (int i = 0; i < inputString.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(inputString) == false 
                            && inputString[i] == ' ')
                        {
                            wordsCounter++;

                            if (inputString[i] == ' ' 
                                && inputString[i++] == ' ')
                            {
                                wordsCounter--;
                            }
                        }

                    }

                    if (wordsCounter >= 1) process = false;
                    else Console.WriteLine("You should input more than one word");
                }
                catch
                {

                }
            }
        }
    }
}
