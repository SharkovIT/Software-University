using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
        where T : IComparable<T>
    {
        public List<T> boxCollection;

        public int Count { get; set; }
        public void Compare(List<T> collection, T item)
        {
            foreach (var currentItem in collection)
            {
                if (currentItem.CompareTo(item) > 0)
                {
                    Count++;
                }
            }
        }
        public List<T> Swap(List<T> boxCollection, int[] indexes)
        {
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            var temp = boxCollection[firstIndex];

            boxCollection[firstIndex] = boxCollection[secondIndex];
            boxCollection[secondIndex] = temp;

            return boxCollection;
        }

        public Box()
        {
            this.boxCollection = new List<T>();
        }

        public void Add(T item)
        {
            boxCollection.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in boxCollection)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
