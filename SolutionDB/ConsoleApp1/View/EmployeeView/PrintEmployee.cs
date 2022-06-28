
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

        public void EnterProjectEmployee(List<Project> projects)
        {
            
            List<string> projectTitles = new List<string>();
            foreach (var pro in projects)
            {
                projectTitles.Add(pro.ProjectName);
            }
            PrintService.ShowProjectTitles(projectTitles);
            Console.WriteLine("Enter Employee Project Name If You Want:\n");
            string projectName = Console.ReadLine();

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

        
    }
}
