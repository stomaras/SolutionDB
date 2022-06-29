using ConsoleApp1.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Validations.EmployeeValidations
{
    public class EmployeeHelper
    {

        public int CheckNumOfManagers(int realNumOfManagers, string numOfManagers)
        {
            int numericValue;
            bool isNumber = false;
            bool isValidRange = false;
            int numOfManagersInput = -1;
            isNumber = int.TryParse(numOfManagers, out numericValue);
            if (isNumber)
            {
                Console.WriteLine("d");
                numOfManagersInput = numericValue;
                Func<int, int ,bool> isSmaller = IsSmallerFromNumOfManagers;
                bool isValidManagerNumbers = isSmaller.Invoke(numOfManagersInput,realNumOfManagers);
                if (isValidManagerNumbers)
                {
                    return numOfManagersInput;
                }
                else
                {
                    Func<int, string> inValidNumOfManagers = InvalidNumberOfManagersMessage;
                    string message = inValidNumOfManagers.Invoke(realNumOfManagers);
                    Console.WriteLine(message);
                    Console.ResetColor();
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("f");
                Func<string> managerInput = managerInputMustBeANumber;
                string message = managerInput.Invoke();
                Console.WriteLine(message);
                Console.ResetColor();
                return -1;
            }
        }

        public static int CheckEmployeeId(List<int> employeeIds, string employeeId)
        {

            int numericValue;
            bool isNumber = false;
            bool isVaVidRange = false;
            int eid = -1;
            while (!isNumber || !isVaVidRange)
            {
                isNumber = int.TryParse(employeeId, out numericValue);
                if (isNumber)
                {
                    eid = numericValue;
                    bool isFound = SearchForEmployeeId(eid, employeeIds);
                    if (isFound)
                    {
                        isVaVidRange = true;
                    }
                    else
                    {
                        ErrorMessage.InValidEmployeeIdToSeeDetails(employeeIds);
                        isVaVidRange = false;
                        employeeId = Console.ReadLine();
                    }
                }
                else
                {
                    ErrorMessage.EmployeeIdMustBeANumber();
                    employeeId = Console.ReadLine();
                }
            }

            int detailsEmployeeId = Convert.ToInt32(employeeId);
            return detailsEmployeeId;
        }

        public static bool SearchForEmployeeId(int eid, List<int> employeeIds)
        {
            int count = 0;
            for (int i = 0; i < employeeIds.Count-1; i++)
            {
                if (eid == employeeIds[i])
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region Delegates Helper Region
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
            string message = $"Invalid : number of managers must be among 0 - {RealNumOfManagers}";
            return message;
        }

        public string managerInputMustBeANumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Manager input must be a numeric value";
        }
        #endregion
    }
}
