using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validations
{
    public class EmployeeConsoleValidations
    {
        public Employee EmployeeToEdit(List<Employee> employees, int employeeId)
        {
            int count = 0;
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == employeeId)
                {
                    count = i;
                }
            }
            if (count == 0)
            {
                return null;
            }
            else
            {
                return employees[count];
            }
            

            
        }

        public int EnterIdOfEmployeeToEdit()
        {
            bool isNumber = false;
            int numericValue;
            string id = Console.ReadLine();
            isNumber = int.TryParse(id, out numericValue);

            Console.ForegroundColor = ConsoleColor.Red;
            while (!isNumber)
            {
                Console.WriteLine("\t Employee Id To Edit Must Be Numeric Value");
                id = Console.ReadLine();
                isNumber = int.TryParse(id, out numericValue);
            }
            Console.ResetColor();

            return Convert.ToInt32(id);
        }
    }
}
