using System;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                foreach (var currentSymbol in value)
                {
                    if (!char.IsLetterOrDigit(currentSymbol))
                    {
                        throw new ArgumentException("Invalid faculty number!");
                    }
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Faculty number: {this.FacultyNumber}");

            return base.ToString() + sb.ToString();
        }
    }
}
