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

            while (inputQueue.Count > 0)
            {
                var letter = inputQueue.Dequeue();

                switch (letter)
                {
                    case '{':
                        if (inputQueue.Peek() == ']' || inputQueue.Peek() == ')')
                            throw new Exception("Incorrect string");
                        break;
                    case '[':
                        if (inputQueue.Peek() == '}' || inputQueue.Peek() == ')')
                            throw new Exception("Incorrect string");
                        break;
                    case '(':
                        if (inputQueue.Peek() == ']' || inputQueue.Peek() == '}')
                            throw new Exception("Incorrect string");
                        break;
                }
                    if (letter.Equals('{'))
                        parenthesesCounter++;
                    if (letter.Equals('['))
                        parenthesesCounter += 2;
                    if (letter.Equals('('))
                        parenthesesCounter += 3;
                    if (letter.Equals('}'))
                        parenthesesCounter--;
                    if (letter.Equals(']'))
                        parenthesesCounter -= 2;
                    if (letter.Equals(')'))
                        parenthesesCounter -= 3;
            }

            if (parenthesesCounter != 0)
                Console.WriteLine("Parentheses are incorrect");
            else
                Console.WriteLine("Parentheses are correct");
        }
    }
}
