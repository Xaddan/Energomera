using System;

namespace BracketSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var bracketString = Console.ReadLine()?.Trim();

            Console.WriteLine(CheckBracketSequences(bracketString));

            Console.ReadKey();
        }
        
        private static bool CheckBracketSequences(string bracketString)
        {
            int counter = 0;

            foreach (var bracket in bracketString)
            {
                if (bracket is '(' or '{' or '[')
                {
                    counter++;
                }

                if(bracket is ')' or '}' or ']')
                {
                    counter--;
                }
            }

            return counter == 0;
        }
    }
}