using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public Person(int number) : this()
        {
            this.age = number;
        }
        public Person(int number, string name) : this(number)
        {
            this.name = name;
        }
    }
}
