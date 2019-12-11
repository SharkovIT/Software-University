namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
              .Where(e => e.EmployeesTasks
                  .Any(et => et.Task.OpenDate.Date >= date))
              .Select(e => new 
              {
                  Username = e.Username,
                  Tasks = e.EmployeesTasks
                      .Select(et => new 
                      {
                          TaskName = et.Task.Name,
                          OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                          DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                          LabelType = et.Task.LabelType.ToString(),
                          ExecutionType = et.Task.ExecutionType.ToString()
                      })
                      .OrderByDescending(et => et.DueDate)
                      .ThenBy(et => et.TaskName)
                      .ToArray()
              })
              .ToArray()
              .OrderByDescending(e => e.Tasks.Length)
              .ThenBy(e => e.Username)
              .Take(10)
              .ToArray();


            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            throw new NotImplementedException();
        }
    }
}