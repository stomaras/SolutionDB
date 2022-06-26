using ConsoleApp1.Validations.EmployeeValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Factory
{
    public static class Factory
    {
        public static EmployeeHelper EmployeeHelperCreate()
        {
            return new EmployeeHelper();
        }
    }
}
