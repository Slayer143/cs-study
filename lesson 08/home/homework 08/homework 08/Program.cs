using System;
using System.Collections;
using System.Collections.Generic;

namespace homework_08
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = null;
            Queue<char> inputQueue = new Queue<char>();
            int parenthesesCounter = 0;

            Console.WriteLine("Enter string with parentheses");
            inputString = Console.ReadLine();

            foreach (char letter in inputString)         
                    inputQueue.Enqueue(letter);

            foreach (char letter in inputQueue)
            {
                if (letter.Equals('{') == true)
                    parenthesesCounter++;
                else if (letter.Equals('[') == true)
                    parenthesesCounter += 2;
                else if (letter.Equals('(') == true)
                    parenthesesCounter += 3;
                else if (letter.Equals('}') == true)
                    parenthesesCounter--;
                else if (letter.Equals(']') == true)
                    parenthesesCounter -= 2;
                else if (letter.Equals(')') == true)
                    parenthesesCounter -= 3;
            }

            if (parenthesesCounter != 0)
                Console.WriteLine("Parentheses are incorrect");
            else
                Console.WriteLine("Parentheses are correct");
        }
    }
}
