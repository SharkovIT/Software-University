using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Employee
    {
        [Required]
        public string Name { get; set; }

        [Required]
       public double Salary { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Department { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        List<Employee> info = new List<Employee>();

        public Employee()
        {
            Email = "n/a";
            Age = -1;
        }

        public Employee(string name, double salary, string position, string department) : this()
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
        }

        public Employee(string name, double salary, string position, string department, string email) : this(name, salary, position, department)
        {
            Email = email;
        }

        public Employee(string name, double salary, string position, string department, int age) : this(name, salary, position, department)
        {
            Age = age;
        }
        public Employee(string name, double salary, string position, string department, string email, int age)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = email;
            Age = age;
        }

        public void AddEmplyees(Employee employee)
        {
            info.Add(new Employee(employee.Name, employee.Salary, employee.Position, employee.Department, employee.Email, employee.Age));
        }

        public string FindHighestSalary()
        {
            var dic = new Dictionary<string, double>();

            foreach (var item in info)
            {
                if (!dic.ContainsKey(item.Department))
                {
                    dic.Add(item.Department, item.Salary);
                }
                else
                {
                    dic[item.Department] += item.Salary;
                }
            }

            double max = int.MinValue;
            string dep = string.Empty;

            foreach (var item in dic)
            {
                if (item.Value > max)
                {
                    max = item.Value;
                    dep = item.Key;
                }
            }

            return dep;
        }

        public void Print(string department)
        {
            Console.WriteLine($"Highest Average Salary: {department}");

            foreach (var item in info.OrderByDescending(x => x.Salary))
            {
                if (department == item.Department)
                {
                    Console.WriteLine($"{item.Name} {item.Salary:f2} {item.Email} {item.Age}");
                }
            }
        }
    }
}
