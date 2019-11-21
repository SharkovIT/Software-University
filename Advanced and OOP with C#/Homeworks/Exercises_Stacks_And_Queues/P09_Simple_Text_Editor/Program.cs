using System;
using System.Collections.Generic;
using System.Text;

namespace P09_Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            var stack = new Stack<string>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string command = input[0];                

                if (command == "1")
                {
                    stack.Push(text.ToString());
                    text.Append(input[1]);
                }
                else if (command == "2")
                {
                    int index = int.Parse(input[1]);
                    stack.Push(text.ToString());
                    text.Remove(text.Length - index, index);
                    
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);

                    Console.WriteLine($"{text[index-1]}");
                }
                else if (command == "4")
                {
                    text.Clear();
                    text.Append(stack.Pop());
                }
            }

        }
    }
}
