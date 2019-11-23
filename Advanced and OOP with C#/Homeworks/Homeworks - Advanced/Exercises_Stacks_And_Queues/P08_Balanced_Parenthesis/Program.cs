using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackOfParenthesis = new Stack<char>();
            char[] input = Console.ReadLine()
                .ToCharArray();

            char[] openParenthesis = new char[] { '(', '[', '{' };

            bool isValid = true;

            foreach (var item in input)
            {
                if (openParenthesis.Contains(item))
                {
                    stackOfParenthesis.Push(item);
                    continue;
                }

                if (stackOfParenthesis.Count == 0)
                {
                    isValid = false;
                    break;  
                }

                if (stackOfParenthesis.Peek() == '(' && item == ')')
                {
                    stackOfParenthesis.Pop();
                }
                else if (stackOfParenthesis.Peek() == '[' && item == ']')
                {
                    stackOfParenthesis.Pop();
                }
                else if (stackOfParenthesis.Peek() == '{' && item == '}')
                {
                    stackOfParenthesis.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
