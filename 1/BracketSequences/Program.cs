using System;
using System.Collections.Generic;
using System.Linq;

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
            var stack = new Stack<char>();
            var brackets = new Dictionary<char, char>
            {
                {')', '('},
                {'}', '{'},
                {']', '['}
            };

            foreach (var bracket in bracketString)
            {
                switch (bracket)
                {
                    case '(' or '{' or '[':
                        stack.Push(bracket);
                        break;
                    case ')' or '}' or ']' when stack.Count == 0:
                    case ')' or '}' or ']' when brackets[bracket] != stack.Pop():
                        return false;
                }
            }

            return stack.Count == 0;
        }
    }
}