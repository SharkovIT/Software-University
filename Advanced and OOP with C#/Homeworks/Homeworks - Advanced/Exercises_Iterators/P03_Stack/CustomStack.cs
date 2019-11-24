using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {

        private Stack<T> data;

        public CustomStack()
        {
            this.data = new Stack<T>();
        }

        public void Pop()
        {
            if (this.data.Count > 0)
            {
                data.Pop();
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public void Push(T value)
        {
            this.data.Push(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
