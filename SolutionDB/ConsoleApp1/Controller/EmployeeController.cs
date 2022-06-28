using ConsoleApp1.Validations.EmployeeValidations;
using ConsoleApp1.View.EmployeeView;
using Entities;
using Entities.Enums;
using MyDatabase;
using Repositories.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public void CreateEmployees()
        {
            try
            {
                PrintEmployee pr = new PrintEmployee();
                List<Project> projects = (List<Project>) companyUnit.Projects.GetAll();
                List<string> projectsTitles = companyUnit.Projects.GetProjectTitles(projects);
                List<int> projectIds = companyUnit.Projects.GetProjectIds(projects);
                (string, string, DateTime, DateTime, Enum, double) employee = ("","",DateTime.Now,DateTime.Now,Country.greece, 0.00);
                pr.EnterEmployeeDetails(out employee);
                Employee employee1 = new Employee()
                {
                   FirstName = employee.Item1,
                   LastName = employee.Item2,
                   DateOfBirth = employee.Item3,
                   HireDate = employee.Item4,
                   Country = (Country)employee.Item5,
                   Salary = employee.Item6,
                };

                Console.WriteLine($"{employee1.FirstName}{employee1.LastName}{employee1.DateOfBirth}{employee1.HireDate}{employee1.Country}{employee1.Salary}{employee1.Project}");

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        public static Project CheckProject(List<Project> projects, string projectName)
        {
            foreach (var pro in projects)
            {
                if (pro.ProjectName == projectName)
                {
                    return pro;
                    
                }
            }
            return null;
        }



        public void ErrorService()
        {
            Console.WriteLine("Error service");
        }

        
    }
}
