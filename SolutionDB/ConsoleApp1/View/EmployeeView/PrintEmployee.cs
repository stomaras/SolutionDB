
using ConsoleApp1.CustomValidations;
using Entities;
using Entities.Enums;
using Entities.GeneralServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.View.EmployeeView
{
    public class PrintEmployee : IPrintEmployee
    {
        public void EmployeeCreatedSuccessfully(Employee employee)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New Employee Created Successfully:\n");
            Console.WriteLine($"\t\t Employee {{ with First Name {employee.FirstName}, Last Name {employee.LastName}, with Date Of Birth {employee.DateOfBirth.ToString("d")}, with Hire Date {employee.HireDate.ToString("d")}, from Country {employee.Country}, with Salary {employee.Salary} }}\n");
            Console.WriteLine("\t\tProject:\n");
            if (employee.Project is null)
            {
                Console.WriteLine($"\t\t\t No Project Preferable");
            }
            else
            {
                Console.WriteLine($"\t\t\t{employee.Project.ProjectName}");
            }
            List<Manager> managers = (List<Manager>)employee.Managers;
            Console.WriteLine($"\t\t Managers:\n");
            if (managers == null)
            {
                Console.WriteLine($"\t\t\t No Managers Yet");
            }
            else
            {
                foreach (var manager in managers)
                {
                  
                    Console.WriteLine($"\t\t\tManager {{ Full Name: {manager.FirstName} {manager.LastName}, with main subject {manager.Subject}, with Salary {manager.Salary} }}");
                    
                }
            }

            Console.ResetColor();
        }



        public void EnterEmployeeDetails(out (string, string, DateTime, DateTime, Enum, double) employee)
        {
            EmployeeHelper employeeHelper = new EmployeeHelper();
           
            Console.WriteLine("Create Employee:\n");

            Console.WriteLine("Enter Employee First Name:\n");
            string firstName = employeeHelper.CheckName(Console.ReadLine());

            Console.WriteLine("Enter Employee Last Name:\n");
            string lastName = employeeHelper.CheckName(Console.ReadLine());

            Console.WriteLine("Enter Employee Day Of Birth:\n");
            int dayOfBirth = employeeHelper.CheckDay(Console.ReadLine());

            Console.WriteLine("Enter Employee Month Of Birth:\n");
            int monthOfBirth = employeeHelper.CheckMonth(Console.ReadLine());

            Console.WriteLine("Enter Employee Year Of Birth:\n");
            int yearOfBirth = employeeHelper.CheckYear(Console.ReadLine());

            DateTime dateOfBirth = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);

            Console.WriteLine("Enter Employee Hire Day:\n");
            int hireDay = employeeHelper.CheckHireDay(Console.ReadLine());

            Console.WriteLine("Enter Employee Hire Month:\n");
            int hireMonth = employeeHelper.CheckHireMonth(Console.ReadLine());

            Console.WriteLine("Enter Employee Hire Year:\n");
            int hireYear = employeeHelper.CheckHireYear(Console.ReadLine());

            DateTime hireDate = new DateTime(hireYear, hireMonth, hireDay);

            Console.WriteLine("Enter Country of Employee:\n");
            string country = Console.ReadLine();
            string countryin = employeeHelper.CheckCountry(country).ToLower();
            Country inputCountry = (Country)Enum.Parse(typeof(Country), countryin);

            Console.WriteLine("Enter Salary of Employee: \n");
            string salary = Console.ReadLine();
            double salaryValid = employeeHelper.CheckValidSalary(salary);


            employee = (firstName, lastName, dateOfBirth, hireDate, inputCountry, salaryValid);

        }

        public void EnterIdToSeeDetails()
        {
            Console.WriteLine($"Enter Employee ID to see details:\n");
        }

        public List<int> EnterManagerIds(List<int> managerIds, int numOfManagers)
        {

            return null;
        }

        public int EnterManagersOfEmployees(int numOfManagerss, out (string, string) managerFirstLastNames)
        {
            managerFirstLastNames = ("", "");
            EmployeeHelper employeeHelper = new EmployeeHelper();
            Console.WriteLine("Enter Number Of managers:\n");
            string numberOfManagers = Console.ReadLine();
            int numOfManagers = employeeHelper.CheckNumOfManagers(numOfManagerss, numberOfManagers);
            if (numOfManagers < 0)
            {
                managerFirstLastNames = ("", "");
                return -1;
            }
            string managerFirstName = employeeHelper.CheckName(Console.ReadLine());
            string managerLastName = employeeHelper.CheckName(Console.ReadLine());

            managerFirstLastNames = (managerFirstName, managerLastName);
            return numOfManagers;
        }

        public string EnterProjectEmployee(List<Project> projects)
        {
            
            List<string> projectTitles = new List<string>();
            foreach (var pro in projects)
            {
                projectTitles.Add(pro.ProjectName);
            }
            PrintService.ShowProjectTitles(projectTitles);
            Console.WriteLine("Enter Employee Project Name If You Want:\n");
            string projectName = Console.ReadLine();
            return projectName;

        }

        public void ShowEmployeeDetails(Employee employee)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Employee Details : \n");
            Console.WriteLine($"\t\tPersonal Infos:  First Name {employee.FirstName} , Last Name {employee.LastName}, with Age {employee.Age}, with hire date {employee.HireDate}, with Country {employee.Country}, with salary {employee.Salary}\n");
            if (employee.Project is null)
            {
                Console.WriteLine("\t\tProject :  No Project");
            }
            else
            {
                Console.WriteLine($"\t\tProject : {employee.Project.ProjectName} ");
            }
            if (employee.Managers.Count == 0)
            {
                Console.WriteLine("\t\tManagers : No Managers");
            }
            else
            {
                Console.WriteLine("\t\tManagers:\n");
                foreach (var manager in employee.Managers)
                {
                    Console.WriteLine($"\t\t\t\tManager : {manager.FirstName} {manager.LastName}\n");
                }
            }
            Console.ResetColor();
        }

        public void ShowEmployees(IEnumerable<Employee> employees)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employees:\n");
            foreach (var employee in employees)
            {
                Console.WriteLine($"\t\tEmployee {{ First Name {employee.FirstName} , Last Name {employee.LastName}, with Age {employee.Age}, with hire date {employee.HireDate}, with Country {employee.Country}, with salary {employee.Salary}\n }}  ");
            }
            Console.ResetColor();

        }

        public void ShowEmployeesPerProject(IEnumerable<Employee> employees)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employees:\n");
            foreach (var employee in employees)
            {
                if (employee.Project == null)
                {
                    string Noproject = "No Project";
                    Console.WriteLine($"\t\tFirst Name {employee.FirstName} , Last Name {employee.LastName}, with Age {employee.Age}, with hire date {employee.HireDate}, with Country {employee.Country}, with salary {employee.Salary}, with project {Noproject}}}");
                }
                else
                {
                    Console.WriteLine($"\t\tEmployee {{ First Name {employee.FirstName} , Last Name {employee.LastName}, with Age {employee.Age}, with hire date {employee.HireDate}, with Country {employee.Country}, with salary {employee.Salary}, with project {employee.Project.ProjectName}}}");

                }
            }
            Console.ResetColor();
        }

        public void ShowEmployeesPerProjectPerManager(IEnumerable<Employee> employees)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employees:\n");
            foreach (var employee in employees)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (employee.Project == null)
                {
                    string Noproject = "No Project";
                    Console.WriteLine($"\t\tEmployee {{ First Name {employee.FirstName} , Last Name {employee.LastName}, with Age {employee.Age}, with hire date {employee.HireDate}, with Country {employee.Country}, with salary {employee.Salary}, with project {Noproject}}}");
                }
                else
                {
                    Console.WriteLine($"\t\tEmployee {{ First Name {employee.FirstName} , Last Name {employee.LastName}, with Age {employee.Age}, with hire date {employee.HireDate}, with Country {employee.Country}, with salary {employee.Salary} with project {employee.Project.ProjectName}}}");

                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t\tManagers:\n");
              
                if (employee.Managers.Count == 0)
                {
                    string noManager = "No Manager Yet";
                    Console.WriteLine($"\t\t\t\t\t Manager {{ {noManager} }}");
                }
                else
                {
                    foreach (var manager in employee.Managers)
                    {
                        Console.WriteLine($"\t\t\t\t\tManager {{ First Name {manager.FirstName} , Last Name {manager.LastName}, with salary {manager.Salary}\n }}");
                    }
                }
                Console.ResetColor();
            }
        }

        public bool IsValidRangeIdsNums(List<int> managerIds, int inputManagerId)
        {
            int count = 0;
            for (int i = 0; i < managerIds.Count; i++)
            {
                if (managerIds[i] == inputManagerId)
                {
                    count = count + 1;
                    
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

        public bool IsManagerIdExists(List<int> selectedManagerIds, int managerId)
        {
            int count = 0;
            for (int i = 0; i < selectedManagerIds.Count; i++)
            {
                if (managerId == selectedManagerIds[i])
                {
                    count = count + 1;
                    
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

        public void ShowAllAvailableIds(List<int> mngrIds)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("All Available ids are :\n");
            for (int i = 0; i < mngrIds.Count; i++)
            {
                Console.WriteLine($"Id {i} -> {mngrIds[i]}");
            }
            Console.ResetColor();
        }

        public void ShowMngrIdsMustBeNumeric(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            message = "Manager Id must be numeric value try again :\n";
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }
}
