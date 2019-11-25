using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public string FirstDate { get; set; }

        public string SecondDate { get; set; }

        public void CalculateDifference(string dateOne, string dateTwo)
        {
            FirstDate = dateOne;
            SecondDate = dateTwo;

            var firstDate = DateTime.Parse(dateOne);
            var secondDate = DateTime.Parse(dateTwo);

            var result = firstDate > secondDate ? (firstDate - secondDate).TotalDays : (secondDate - firstDate).TotalDays;

            Console.WriteLine(result);
        }
    }
}
