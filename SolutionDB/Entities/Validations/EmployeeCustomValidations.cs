using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entities.Validations
{
    public class EmployeeCustomValidations
    {
        public static ValidationResult ValidateFirstName(string firstName, ValidationContext context)
        {
                bool containsRegularDigits = false;
                string AlertMessageErrors = "";

            
                if (string.IsNullOrEmpty(firstName))
                {
                    AlertMessageErrors = CustomFirstNameNullError(context);
                    return new ValidationResult(AlertMessageErrors, new List<string> { context.MemberName });
                }
                containsRegularDigits = Regex.IsMatch(firstName, @"^[a-zA-Z]+$");
                if (!containsRegularDigits)
                {
                    AlertMessageErrors = CustomValidationAlertErrors(context);
                    return new ValidationResult(AlertMessageErrors, new List<string> { context.MemberName });
                }
                else
                {
                    return ValidationResult.Success;
                }
        }

        public static ValidationResult ValidateLastName(string lastName, ValidationContext context)
        {
            bool containsRegularDigits = false;
            string AlertMessageErrors = "";


            if (string.IsNullOrEmpty(lastName))
            {
                AlertMessageErrors = CustomFirstNameNullError(context);
                return new ValidationResult(AlertMessageErrors, new List<string> { context.MemberName });
            }
            containsRegularDigits = Regex.IsMatch(lastName, @"^[a-zA-Z]+$");
            if (!containsRegularDigits)
            {
                AlertMessageErrors = CustomValidationAlertErrors(context);
                return new ValidationResult(AlertMessageErrors, new List<string> { context.MemberName });
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        public static ValidationResult ValidateCountries(string countryIntro, ValidationContext context)
        {

            string alertMessageErrors = "";
            if (countryIntro is null)
            {
                alertMessageErrors = CustomCountryNullError(context);
                return new ValidationResult(alertMessageErrors, new List<string> { context.MemberName });
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        //public static ValidationResult ValidateSalary(int salary, ValidationContext context)
        //{
        //    double numericValue;
        //    bool isValidDoubleNumber = false;
        //    bool isValidRange = false;
        //    double inputSalary = -1.0;
        //    string alertMessageErrors = "";
        //    if (salary < 0)
        //    {
        //        alertMessageErrors = CustomSalaryNullError(context);
        //        return new ValidationResult(alertMessageErrors, new List<string> { context.MemberName });
        //    }

        //    isValidDoubleNumber = double.TryParse(salary, out numericValue);
        //    if (isValidDoubleNumber)
        //    {
        //        inputSalary = numericValue;

        //        Func<double, bool> IsValidSalary = ValidSalaryRange;
        //        if (IsValidSalary.Invoke(inputSalary))
        //        {
        //            return ValidationResult.Success;
        //        }
        //        else
        //        {
        //            Func<double> SalaryUpperBound = SalaryUpperBounds;
        //            double salaryUpperBound = SalaryUpperBound.Invoke();
        //            Func<double> SalaryLowerBound = SalaryLowerBounds;
        //            double salaryLowerBound = SalaryLowerBound.Invoke();
        //            alertMessageErrors = CustomSalaryOuterBounds(context, salaryLowerBound, salaryUpperBound);
        //            return new ValidationResult(alertMessageErrors, new List<string> { context.MemberName });
        //        }

        //    }
        //    else
        //    {
        //        alertMessageErrors = CustomSalaryMustBeDouble(context);
        //        return new ValidationResult(alertMessageErrors, new List<string> { context.MemberName });
        //    }
        //}












        #region Delegates Helpers Methods

        public static bool ValidSalaryRange(double salary)
        {
            if (salary >= 1000.00 && salary <= 100000.00)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double SalaryUpperBounds()
        {
            return 100000.00;
        }

        public static double SalaryLowerBounds()
        {
            return 500.00;
        }

        #endregion


        #region Show Error Functions
        public static string CustomValidationAlertErrors(ValidationContext context)
        {
            string alertErrors = $"The field {context.MemberName}, can not contain numbers or special characters";
            return alertErrors;
        }

        public static string CustomFirstNameNullError(ValidationContext context)
        {
            string alertErrors = $"The first name {context.MemberName} can not be null or empty";
            return alertErrors;
        }

        public static string CustomCountryNullError(ValidationContext context)
        {
            string alerErrors = $"The country {context.MemberName} can not be null or empty";
            return alerErrors;
        }

        public static string CustomSalaryNullError(ValidationContext context)
        {
            string alertErrors = $"The Salary {context.MemberName} can not be null or empty";
            return alertErrors;
        }

        public static string CustomSalaryOuterBounds(ValidationContext context, double lowerBound, double higherBound)
        {
            string alertErrors = $"The Salary {context.MemberName} must be among {lowerBound} - {higherBound}";
            return alertErrors;
        }

        public static string CustomSalaryMustBeDouble(ValidationContext context)
        {
            string alertErrors = $"The Salary {context.MemberName} must be double value";
            return alertErrors;
        }

        #endregion

    }
}
