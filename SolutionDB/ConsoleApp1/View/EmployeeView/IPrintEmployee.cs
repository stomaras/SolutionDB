using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.View.EmployeeView
{
    interface IPrintEmployee
    {
        void ShowEmployees(IEnumerable<Employee> employees);

        void ShowEmployeesPerProject(IEnumerable<Employee> employees);

        void ShowEmployeesPerProjectPerManager(IEnumerable<Employee> employees);

        void ShowEmployeeDetails(Employee employee);
        void EnterIdToSeeDetails();
        void EnterEmployeeDetails(out (string, string, DateTime, DateTime, Enum, double) employee);

        void EmployeeCreatedSuccessfully(Employee employee);

        int EnterManagersOfEmployees(int numOfManagers, out (string, string) managerFirstLastNames);

        List<int> EnterManagerIds(List<int> managerIds, int numOfManagers);

    }
}
