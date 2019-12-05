
using MiniORM.App.Data;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-G9R4701\\SQLEXPRESS;Database=MiniORM;Integrated Security=True";

            var context = new SoftUniDbContext(connectionString);

            var employees = context.Employees.ToList();
        }
    }
}
