using ConsoleApp1.Validations.EmployeeValidations;
using ConsoleApp1.View.EmployeeView;
using Entities;
using MyDatabase;
using Repositories.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Controller
{
    public class EmployeeController
    {

        public static MyDBContext catalogos = new MyDBContext();
        UnitOfWork companyUnit;

        public EmployeeController()
        {
            companyUnit = new UnitOfWork(catalogos);
        }

        public void ReadEmployees()
        {
            try
            {
                var employees = companyUnit.Employees.GetAll();
                PrintEmployee printEmployee = new PrintEmployee();
                printEmployee.ShowEmployees(employees);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadEmployeesPerProject()
        {
            try
            {
                var group = companyUnit.Employees.EmployeesWithProjects();
                PrintEmployee printEmployee = new PrintEmployee();
                printEmployee.ShowEmployeesPerProject(group);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadEmployeeDetails()
        {
            EmployeeHelper employeeHelper = Factory.Factory.EmployeeHelperCreate();
            IEnumerable<Employee> employees = companyUnit.Employees.GetAll();
            List<int> employessIds = companyUnit.Employees.GetAllEmployeesIds(employees);
            PrintEmployee pr = new PrintEmployee();
            pr.EnterIdToSeeDetails();
            string employeeId = Console.ReadLine();
            int? employeeIdReal = EmployeeHelper.CheckEmployeeId(employessIds, employeeId);
            if (employeeIdReal is null)
            {
                throw new ArgumentNullException("Id Not Found");
            }
            Employee employee = companyUnit.Employees.GetEmployeesWithProjectWithManagersById(employeeIdReal);
            if (employee is null)
            {
                throw new ArgumentNullException("Employee Not Found");
            }
            pr.ShowEmployeeDetails(employee);


        }

        public void ReadEmployeesPerProjectPerManager()
        {
            try
            {
                var group = companyUnit.Employees.EmployeesWithProjectsWithManagers();
                PrintEmployee printEmployee = new PrintEmployee();
                printEmployee.ShowEmployeesPerProjectPerManager(group);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        

        public void ErrorService()
        {
            Console.WriteLine("Error service");
        }
    }
}
