using System;

namespace Mankind
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] studentInfo = Console.ReadLine().Split();

                string studentFirstName = studentInfo[0];
                string studentLastName = studentInfo[1];
                string facultyNumber = studentInfo[2];

                Student student = new Student(studentFirstName, studentLastName, facultyNumber);

                string[] workerInfo = Console.ReadLine().Split();

                string workerFirstName = workerInfo[0];
                string workerLastName = workerInfo[1];
                decimal weekSalary = decimal.Parse(workerInfo[2]);
                double workingHours = double.Parse(workerInfo[3]);

                Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workingHours);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }
    }
}
