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
    }
}
