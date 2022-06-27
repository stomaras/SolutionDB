using ConsoleApp1.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.CustomValidations
{
    public class EmployeeHelper
    {
        public string CheckName(string name)
        {
            bool isValid = false;
            bool containsRegularDigits = false;

            while (!isValid || !containsRegularDigits)
            {
                if (string.IsNullOrEmpty(name))
                {
                    isValid = false;
                    ErrorMessage.NameCannotBeNull();
                    name = Console.ReadLine();
                }
                else
                {
                    containsRegularDigits = Regex.IsMatch(name, @"^[a-zA-Z]+$");
                    if (!containsRegularDigits)
                    {
                        ErrorMessage.NameCannotContainsNumbersOrSpecialChars();
                        name = Console.ReadLine();
                    }
                    else
                    {
                        containsRegularDigits = true;
                        if (name.Length < 2 || name.Length > 50)
                        {
                            isValid = false;
                            ErrorMessage.NameMustBeInRange();
                            name = Console.ReadLine();
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                }
            }
            return name;
        }

        public int CheckDay(string day)
        {
            int numericValue;
            bool isNumber = false;
            bool isValidRange = false;
            int inputDay = -1;

            while (!isNumber || !isValidRange)
            {
                
                while (string.IsNullOrEmpty(day))
                {
                    ErrorMessage.DayCannotBeNull();
                    day = Console.ReadLine();
                }

                isNumber = int.TryParse(day, out numericValue);
                if (isNumber)
                {
                    inputDay = numericValue;

                    bool IsInValidDayRange = (inputDay >= 1 && inputDay <= 30);
                    if (IsInValidDayRange)
                    {
                        isValidRange = true;
                    }
                    else
                    {
                        isValidRange = false;
                        ErrorMessage.DayMustBeInValidRange();
                        day = Console.ReadLine();
                    }
                }
                else
                {
                    isNumber = false;
                    ErrorMessage.DayMustBeInteger();
                    day = Console.ReadLine();
                }
            }
            return Convert.ToInt32(day);
        }

        public int CheckMonth(string month)
        {
            int numericValue;
            bool isNumber = false;
            bool isValidRange = false;
            int inputMonth = -1;

            while (!isNumber || !isValidRange)
            {
                while (string.IsNullOrEmpty(month))
                {
                    ErrorMessage.MonthCannotBeNull();
                    month = Console.ReadLine();
                }
                isNumber = int.TryParse(month, out numericValue);

                if (isNumber)
                {
                    inputMonth = numericValue;

                    bool IsInValidMonthRange = (inputMonth >= 1 && inputMonth <= 12);
                    if (IsInValidMonthRange)
                    {
                        isValidRange = true;
                    }
                    else
                    {
                        isValidRange = false;
                        ErrorMessage.MonthMustBeInValidRange();
                        month = Console.ReadLine();
                    }
                }
                else
                {
                    isNumber = false;
                    ErrorMessage.MonthMustBeInteger();
                    month = Console.ReadLine();
                }
            }
            return Convert.ToInt32(month);
        }

        public int CheckYear(string year)
        {
            int numericValue;
            bool isNumber = false;
            bool isValidRange = false;
            int inputYear = -1;

            while (!isNumber || !isValidRange)
            {
                while (string.IsNullOrEmpty(year))
                {
                    ErrorMessage.YearCannotBeNull();
                    year = Console.ReadLine();
                }

                isNumber = int.TryParse(year, out numericValue);

                if (isNumber)
                {
                    inputYear = numericValue;

                    Func<int, bool> IsValidYear = ValidYearRange;
                    bool IsInValidYearRange = IsValidYear.Invoke(inputYear);

                    if (IsInValidYearRange)
                    {
                        isValidRange = true;
                    }
                    else
                    {
                        isValidRange = false;
                        Func<int> minYearRange = MinRange;
                        Func<int> maxYearRange = MaxRange;
                        int minRange = minYearRange.Invoke();
                        int maxRange = maxYearRange.Invoke();
                        ErrorMessage.YearMustBeInValidRange(minRange, maxRange);
                        year = Console.ReadLine();
                    }
                }
            }
            return inputYear;


        }






        #region Delegates Which Help For Employee Validations

        public bool ValidYearRange(int inputYear)
        {
            bool isValidYear = (inputYear >= 1960 && 18 <= DateTime.Now.Year - 18);
            return isValidYear;
        }

        public int MinRange()
        {
            return 1960;
        }

        public int MaxRange()
        {
            return DateTime.Now.Year - 18;
        }

        #endregion
    }
}
