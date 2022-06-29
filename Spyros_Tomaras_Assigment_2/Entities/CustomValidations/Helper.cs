using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CustomValidations
{
    public class Helper
    {
        public static ValidationResult ValidateSubject(string subject, ValidationContext context)
        {
            bool isValid = true;
            string AlertMessageErrors = "";
            if (subject != null)
            {
                Func<string, bool> isValidSubject = ValidSubject;
                bool isValidSubjectName = isValidSubject.Invoke(subject);
                if (isValidSubjectName)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    AlertMessageErrors = CustomValidationAlertErrors(context); 
                }
            }
            if (isValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(AlertMessageErrors, new List<string> { context.MemberName });
            }
        }

        #region Delegates Helpers Methods 
        public static bool ValidSubject(string subject)
        {
            if (subject.ToLower() == "java" || subject.ToLower() == "python" || subject.ToLower() == "c#" || subject.ToLower() == "javascript")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Custom Validation Alert Errors for field subject
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string CustomValidationAlertErrors(ValidationContext context)
        {
            string alertErrors = $"The field {context.MemberName}, must be <<java>> or <<python>> or <<javascript>> or <<c#>>";
            return alertErrors;
        }



        #endregion



    }
}
