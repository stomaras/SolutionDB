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
                EmployeeHelper empHelp = new EmployeeHelper();
                List<Project> projects = GetProjects();
                List<Manager> managers = GetManagers();
                List<string> projectsTitles = GetAllProjectTitles(projects);
                List<int> projectIds = GetAllProjectIds(projects);
                List<int> managerIds = GetManagerIds(managers);
                
                int numOfManagers = managers.Count;
                List<Manager> managersOfEmployee = GetManagersOfEmployee(numOfManagers, managerIds ,managers);
                

                (string, string, DateTime, DateTime, Enum, double) employee = ("","",DateTime.Now,DateTime.Now,Country.greece, 0.00);
                pr.EnterEmployeeDetails(out employee);
                string ProjectName = pr.EnterProjectEmployee(projects);
                
                
                Project project = companyUnit.Projects.GetProjectByTitle(ProjectName);
                Employee employee1 = new Employee()
                {
                   FirstName = employee.Item1,
                   LastName = employee.Item2,
                   DateOfBirth = employee.Item3,
                   HireDate = employee.Item4,
                   Country = (Country)employee.Item5,
                   Salary = employee.Item6,
                   Project = project,
                   Managers = managersOfEmployee
                };

                companyUnit.Employees.Insert(employee1);

                pr.EmployeeCreatedSuccessfully(employee1);

                
                

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


        /*
         * Non - Action Methods
         * 
         */

        private List<string> GetManagerFirstNames(List<Manager> managers)
        {
            return companyUnit.Managers.GetManagersByFirstName(managers);
        }

        public List<string> GetManagerLastNames(List<Manager> managers)
        {
            return companyUnit.Managers.GetManagersByLastName(managers);
        }

        public List<Project> GetProjects()
        {
            return (List<Project>) companyUnit.Projects.GetAll();
        }

        public List<Manager> GetManagers()
        {
            return (List<Manager>)companyUnit.Managers.GetAll();
        }

        public List<string> GetAllProjectTitles(List<Project> projects)
        {
            return (List<string>)companyUnit.Projects.GetProjectTitles(projects);
        }

        public List<int> GetAllProjectIds(List<Project> projects)
        {
            return (List<int>)companyUnit.Projects.GetProjectIds(projects);
        }

        public List<int> GetManagerIds(List<Manager> managers)
        {
            List<int> managerIds = new List<int>();
            foreach (var manager in managers)
            {
                managerIds.Add(manager.ManagerId);
            }
            return managerIds;
        }

        public void SuccessNumberOfManagers(int numOfManagerss)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (numOfManagerss == 1)
            {
                Console.WriteLine($"Employee will have {numOfManagerss} manager");
            }
            else
            {
                Console.WriteLine($"Employee will have {numOfManagerss} managers");
            }
            Console.ResetColor();
        }

        public List<Manager> GetManagersOfEmployees(List<int> managersOfEmployees)
        {
            List<Manager> managers = new List<Manager>();
            for (int i = 0; i < managersOfEmployees.Count; i++)
            {
                var manager = companyUnit.Managers.GetById(managersOfEmployees[i]);
                managers.Add(manager);
            }
            return managers;
        }

        public List<Manager> GetManagersOfEmployee(int numOfManagers,List<int> managerIds,List<Manager> managers)
        {
            EmployeeHelper empHelp = new EmployeeHelper();
            Console.WriteLine("Enter number of Managers:\n");
            Console.WriteLine($"Number of Managers must be among 1 - {numOfManagers}");
            int numOfManagerss = empHelp.CheckNumericValue(Console.ReadLine());

            List<int> managersOfEmployeeIds = new List<int>();
            List<Manager> managersOfEmployees = new List<Manager>();
            if (numOfManagerss <= numOfManagers && numOfManagerss > 0)
            {
                SuccessNumberOfManagers(numOfManagerss);
                managersOfEmployeeIds = empHelp.CalculateManagersOfEmployee(managerIds, numOfManagerss);
                managersOfEmployees = GetManagersOfEmployees(managersOfEmployeeIds);
            }
            else
            {
                FailNumberOfManagers();
                managersOfEmployeeIds = null;
                managersOfEmployees = null;
            }
            return managersOfEmployees;
        }

        public void FailNumberOfManagers()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This Employee does not have managers yet!");
            Console.ResetColor();
        }






    }
}
