using ConsoleApp1.ErrorMessages;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Validations.EmployeeValidations
{
    public class EmployeeHelper
    {


        public List<int> CalculateManagersOfEmployee(List<int> managerIds , int numOfManagers)
        {
            List<int> managerIdsOfEmployee = new List<int>();
            for (int i = 0; i < numOfManagers; i++)
            {
                bool isValidManagerIdRange = false;
                bool isNumber = false;
                bool notAlreadyAdded = false;

                while (!isValidManagerIdRange || !isNumber || !notAlreadyAdded)
                {
                    Console.WriteLine("Enter Manager Id :\n");
                    int managerId = CheckManagerNumericValue(Console.ReadLine());
                    isNumber = true;
                    int minRange = 1;
                    int maxRange = managerIds.Count;
                    Func<int, int, int, bool> isManagerIdValidRange = ManagerIdValidRange;
                    isValidManagerIdRange = isManagerIdValidRange.Invoke(minRange, maxRange, managerId);
                    if (isValidManagerIdRange)
                    {
                        Func<List<int>, int, bool> mngrIdExists = ManagerIdAlreadyExists;
                        notAlreadyAdded = mngrIdExists.Invoke(managerIdsOfEmployee, managerId);
                        if (notAlreadyAdded)
                        {
                            SuccessAddEmployeeMessage(managerId);
                            managerIdsOfEmployee.Add(managerId);
                        }
                        else
                        {
                            ErrorMessage.ManagerAlreadyAdded(managerId);
                        }
                    }
                    else
                    {
                        minRange = 1;
                        maxRange = managerIds.Count;
                        ErrorMessage.InValidManagerIdRange(minRange, maxRange);

                    }
                    
                }
            }
            return managerIdsOfEmployee;
        }

        public static void SuccessAddEmployeeMessage(int managerId)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Manager with id {managerId} added successfully!");
            Console.ResetColor();
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

        public int CheckNumericValue(string numOfManagers)
        {
            bool isNumber = false;
            int numericValue;
            isNumber = int.TryParse(numOfManagers, out numericValue);

            while (!isNumber)
            {
                
                ErrorMessage.NumberOfManagersMustBeNumericValue();
                numOfManagers = Console.ReadLine();
                isNumber = int.TryParse(numOfManagers, out numericValue);
            }
            return Convert.ToInt32(numOfManagers);
        }

        public int CheckManagerNumericValue(string numOfManager)
        {
            bool isNumber = false;
            int numericValue;
            isNumber = int.TryParse(numOfManager, out numericValue);

            while (!isNumber)
            {

                ErrorMessage.ManagerIdMustBeANumber();
                numOfManager = Console.ReadLine();
                isNumber = int.TryParse(numOfManager, out numericValue);
            }
            return Convert.ToInt32(numOfManager);
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

        public bool ManagerIdValidRange(int minRange, int maxRange, int managerId)
        {
            if (managerId >= minRange && managerId <= maxRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ManagerIdAlreadyExists(List<int> managerIds, int managerId)
        {
            int count = 0;
            for (int i = 0; i < managerIds.Count; i++)
            {
                if (managerId == managerIds[i])
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
