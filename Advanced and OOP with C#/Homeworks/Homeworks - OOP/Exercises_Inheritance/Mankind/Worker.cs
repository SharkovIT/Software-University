using System;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;
        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }
        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public string CalculateEarnMoney()
        {
            var moneyPerHour = (this.WeekSalary / 5) / (decimal) this.WorkHoursPerDay;

            return moneyPerHour.ToString("f2") ;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");

            sb.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");

            sb.AppendLine($"Salary per hour: {this.CalculateEarnMoney()}");

            return base.ToString() + sb.ToString();
        }
    }
}
