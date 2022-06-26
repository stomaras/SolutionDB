using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ErrorMessages
{
    public static class ErrorMessage
    {
        public static void EmployeeIdMustBeANumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Employee Id must be a numeric value\n");
            Console.ResetColor();
        }

        public static void InValidEmployeeIdToSeeDetails(List<int> employeeIds)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid id in order to see employee details:\n");
            Console.WriteLine("Valid Employee ids are:\n");
            for (int i = 0; i < employeeIds.Count-1; i++)
            {
                Console.WriteLine(employeeIds[i]);
            }
            Console.WriteLine("Try Again:\n");
            Console.ResetColor();
        }
    }
}
