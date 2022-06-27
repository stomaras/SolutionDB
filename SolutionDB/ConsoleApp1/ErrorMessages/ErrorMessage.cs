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

        public static void NameCannotBeNull()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Employee Name cannot be null");
            Console.ResetColor();
        }

        public static void NameMustBeInRange()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Employee Nmae must be between 2 and 50 characters long !");
            Console.ResetColor();
        }
        
        public static void NameCannotContainsNumbersOrSpecialChars()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Employee Name cannot contains numbers or special characters");
            Console.ResetColor();
        }

        public static void DayMustBeInValidRange()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Day must be between 1 and 30");
            Console.ResetColor();
        }

        public static void DayMustBeInteger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Day must be numeric value");
            Console.ResetColor();
        }

        public static void MonthMustBeInValidRange()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Month must be between 1 and 12:\n");
            Console.ResetColor();
        }

        public static void MonthMustBeInteger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Month must be numeric value:\n");
            Console.ResetColor();
        }

        public static void YearMustBeInValidRange(int minRange, int maxRange)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Year must be between {minRange} and {maxRange}");
            Console.ResetColor();
        }

        public static void DayCannotBeNull()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Day cannot be null !\n");
            Console.ResetColor();
        }

        public static void MonthCannotBeNull()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Month cannot be null !\n");
            Console.ResetColor();
        }

        public static void YearCannotBeNull()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Year cannot be null !\n");
            Console.ResetColor();
        }

    }
}
