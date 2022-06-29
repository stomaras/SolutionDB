using ConsoleApp1.ErrorMessages;
using Entities.Enums;
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

        public int CheckHireDay(string day)
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
                        Func<int> minValidDayRangeHire = InitializeMinDayHire;
                        int minDayHire = minValidDayRangeHire.Invoke();
                        Func<int> maxValidDayRangeHire = InitializeMaxDayHire;
                        int maxDayHire = maxValidDayRangeHire.Invoke();
                        isValidRange = false;
                        ErrorMessage.HireDayMustBeInValidRange(minDayHire, maxDayHire);
                        day = Console.ReadLine();
                    }
                }
                else
                {
                    isNumber = false;
                    ErrorMessage.HireDayMustBeInteger();
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

        public int CheckHireMonth(string month)
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
                        Func<int> minHireValidMonth = InitializeMinHireMonth;
                        int minHireMonth = minHireValidMonth.Invoke();
                        Func<int> maxHireValidMonth = InitializeMaxHireMonth;
                        int maxHireMonth = maxHireValidMonth.Invoke();
                        isValidRange = false;
                        ErrorMessage.HireMonthMustBeInValidRange(minHireMonth, maxHireMonth);
                        month = Console.ReadLine();
                    }
                }
                else
                {
                    isNumber = false;
                    ErrorMessage.HireMonthMustBeInteger();
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
                else
                {
                    ErrorMessage.YearMustBeNumericValue();
                    isNumber = false;
                }
            }
            return inputYear;


        }

        public int CheckHireYear(string year)
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

                    Func<int, bool> IsValidHireYear = ValidHireYearRange;
                    bool IsInValidYearRange = IsValidHireYear.Invoke(inputYear);

                    if (IsInValidYearRange)
                    {
                        isValidRange = true;
                    }
                    else
                    {
                        isValidRange = false;
                        Func<int> HireYearUpperBound = HireYearUpperBounds;
                        int yearUpperBound = HireYearUpperBound.Invoke();
                        ErrorMessage.YearUpperBoundRange(yearUpperBound);
                        year = Console.ReadLine();
                    }
                }
                else
                {
                    ErrorMessage.YearMustBeNumericValue();
                    isNumber = false;
                }
            }
            return inputYear;

        }

        public string CheckCountry(string countryIntro)
        {

            Dictionary<int, string> availableCountries = 
                Enum.GetValues(typeof(Country))
                .Cast<Country>()
                .ToDictionary(t => (int)t, t => t.ToString());

            
            List<int> keys = new List<int>(availableCountries.Keys);
            List<string> values = new List<string>(availableCountries.Values);

            bool isValidCountry = false;
            while (!isValidCountry)
            {
                int count = 0;
                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i].ToLower() == countryIntro.ToLower())
                    {
                        isValidCountry = true;
                        count++;
                    }
                }
                if (count == 0)
                {
                    Func<List<string>, List<string>> availableCountrie = AllAvailableCountries;
                    List<string> allAvailableCountriess = availableCountrie.Invoke(values);
                    ErrorMessage.CountriesMustBeAmong(allAvailableCountriess);
                    isValidCountry = false;
                    countryIntro = Console.ReadLine();

                }
                else
                {
                    isValidCountry = true;
                }
            }
            return countryIntro;
        }

        public double CheckValidSalary(string salary)
        {
            double numericValue;
            bool isValidDoubleNumber = false;
            bool isValidRange = false;
            double inputSalary = -1.0;

            while (!isValidDoubleNumber || !isValidRange)
            {
                while (string.IsNullOrEmpty(salary))
                {
                    ErrorMessage.SalaryCannotBeNull();
                    salary = Console.ReadLine();
                }

                isValidDoubleNumber = double.TryParse(salary, out numericValue);

                if (isValidDoubleNumber)
                {
                    inputSalary = numericValue;

                    Func<double, bool> IsValidSalary = ValidSalaryRange;
                    bool IsInValidSalaryRange = IsValidSalary.Invoke(inputSalary);

                    if (IsInValidSalaryRange)
                    {
                        isValidRange = true;
                    }
                    else
                    {
                        isValidRange = false;
                        Func<double> SalaryUpperBound = SalaryUpperBounds;
                        double salaryUpperBound = SalaryUpperBound.Invoke();
                        Func<double> SalaryLowerBound = SalaryLowerBounds;
                        double salaryLowerBound = SalaryLowerBound.Invoke();
                        ErrorMessage.SalaryBoundRange(salaryLowerBound,salaryUpperBound);
                        salary = Console.ReadLine();
                    }
                }
                else
                {
                    ErrorMessage.SalaryMustBeDoubleValue();
                    isValidDoubleNumber = false;
                    salary = Console.ReadLine();
                }
            }
            return Convert.ToDouble(salary);
        }

        public string CheckProject(string projectName, List<string> projectTitles, List<int> projectIds, out Tuple<string> projectTitle)
        {

                int count = 0;
                for (int i = 0; i < projectTitles.Count; i++)
                {
                    if (projectName.Equals(projectTitles[i]))
                    {
                        count++;
                    }
                }
                if (count != 0)
                {
                    projectTitle = new Tuple<string>(projectName);
                }
                else
                {
                    ErrorMessage.WrongProjectTitle(projectTitles);
                    projectTitle = null;
                    projectName = null;
                }

            return projectName;
            
        }

        public int CheckNumOfManagers(int realNumOfManagers, string numOfManagers)
        {
            int numericValue;
            bool isNumber = false;
            bool isValidRange = false;
            int numOfManagersInput = -1;
            isNumber = int.TryParse(numOfManagers, out numericValue);
            if (isNumber)
            {
                numOfManagersInput = numericValue;
                Func<int, int, bool> isSmaller = IsSmallerFromNumOfManagers;
                bool isValidManagerNumbers = isSmaller.Invoke(numOfManagersInput, realNumOfManagers);
                if (isValidManagerNumbers)
                {
                    return numOfManagersInput;
                }
                else
                {
                    Func<int, string> inValidNumOfManagers = InvalidNumberOfManagersMessage;
                    inValidNumOfManagers.Invoke(realNumOfManagers);
                    Console.ResetColor();
                    return -1;
                }
            }
            else
            {
                Func<string> managerInput = managerInputMustBeANumber;
                managerInput.Invoke();
                Console.ResetColor();
                return -1;
            }
        }







        #region Delegates Which Help For Employee Validations

        public bool ValidYearRange(int inputYear)
        {
            bool isValidYear = (inputYear >= 1960 && inputYear <= DateTime.Now.Year - 18);
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

        public int InitializeMinDayHire()
        {
            return 1;
        }

        public int InitializeMaxDayHire()
        {
            return 30;
        }

        public int InitializeMinHireMonth()
        {
            return 1;
        }

        public int InitializeMaxHireMonth()
        {
            return 12;
        }

        public int HireYearUpperBounds()
        {
            int upperBound = DateTime.Now.Year;
            return upperBound;
        }

        public bool ValidHireYearRange(int hireYear)
        {
            if (hireYear > DateTime.Now.Year)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidSalaryRange(double salary)
        {
            if (salary > 1000.00 && salary < 100000.00)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double SalaryUpperBounds()
        {
            return 100000.00;
        }

        public double SalaryLowerBounds()
        {
            return 1000.00;
        }

        public List<string> AllAvailableCountries(List<string> values)
        {
            List<string> countries = new List<string>();
            for (int i = 0; i < values.Count; i++)
            {
                countries.Add(values[i]);
            }
            return countries;
        }

        public bool IsSmallerFromNumOfManagers(int numOfManagersInput, int realNumOfManagers)
        {
            if (numOfManagersInput <= realNumOfManagers)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string InvalidNumberOfManagersMessage(int RealNumOfManagers)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string message = $"Invalid number of managers range managers range must be among 0 - {RealNumOfManagers}";
            return message;
        }

        public string managerInputMustBeANumber()
        {
            return "Manager input number must be a numeric value";
        }



        #endregion
    }
}
