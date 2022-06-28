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

        public static void HireDayMustBeInValidRange(int minDayRange, int maxDayRange)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Min Day you can hire an employee must be at least {minDayRange} and max day to hire employee must be {maxDayRange}");
            Console.ResetColor();
        }

        public static void HireDayMustBeInteger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hire Day Must be a Number:\n");
            Console.ResetColor();
        }

        public static void HireMonthMustBeInValidRange(int minHireMonth, int maxHireMonth)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hire Month of an employee must be between {minHireMonth} and {maxHireMonth}");
            Console.ResetColor();
        }

        public static void HireMonthMustBeInteger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hire Month must be a numeric value :\n");
            Console.ResetColor();
        }

        public static void YearUpperBoundRange(int upperBound)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hire Year must be less than {upperBound}");
            Console.ResetColor();
        }

        public static void YearMustBeNumericValue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hire Year Must be a number!");
            Console.ResetColor();
        }

        public static void CountriesMustBeAmong(List<string> countries)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            const int first = -2;
            const int second = -3;
            Console.WriteLine($"Country must be something among:\n");
            for (int i = 0; i < countries.Count; i++)
            {
                Console.WriteLine($"{i, first} -> {countries[i],second}\n");
            }
            Console.ResetColor();
        }

        public static void SalaryBoundRange(double lowerBound, double higherBound)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Salary must be between ${lowerBound} and ${higherBound} ");
            Console.ResetColor();
        }

        public static void SalaryCannotBeNull()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Salary cannot be null");
            Console.ResetColor();
        }

        public static void SalaryMustBeDoubleValue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Salary must be double value");
            Console.ResetColor();
        }

        public static void WrongProjectTitle(List<string> projectTitles)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }



    }
}
