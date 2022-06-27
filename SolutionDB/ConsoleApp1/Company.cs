using ConsoleApp1.Controller;
using ConsoleApp1.Enums;
using ConsoleApp1.Validations;
using MyDatabase;
using Repositories.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Company
    {

        public void Start()
        {
            //MyDBContext dBContext = new MyDBContext();
            //UnitOfWork CompanyUnit = new UnitOfWork(dBContext);

            //var employees = CompanyUnit.Employees.EmployeesWithProjects();

            //foreach (var employee in employees)
            //{

            //    if (employee.Project == null)
            //    {
            //        string projectName = "No Project Yet";
            //        Console.WriteLine($"Employee with first name {employee.FirstName}, with last name {employee.LastName}, with project name {projectName}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Employee with first name {employee.FirstName}, with last name {employee.LastName}, with project name {employee.Project.ProjectName}");

            //    }
            //}
            string input = "";
            bool isNumber = false;
            ConsoleHelper consoleHelper = new ConsoleHelper();
            while (input != "e" && input != "E")
            {
                Menu.ShowMenu();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Choose an option!");
                Console.ResetColor();
                input = Console.ReadLine();
                isNumber = consoleHelper.CheckIfIsNumber(input);
                if (isNumber)
                {
                    EmployeeController employeeController = new EmployeeController();



                    int inputt = Convert.ToInt32(input);
                    Console.Clear();

                    Choice choice = (Choice)inputt;

                    switch (choice)
                    {
                        case Choice.ReadEmployees: employeeController.ReadEmployees();break;
                        case Choice.ReadEmployeesPerProject: employeeController.ReadEmployeesPerProject();break;
                        case Choice.ReadingEmployeesPerProjectPerManager: employeeController.ReadEmployeesPerProjectPerManager();break;
                        case Choice.EmployeeDetails: employeeController.ReadEmployeeDetails();break;
                        case Choice.CreateEmployee: employeeController.CreateEmployees();break;
                        default: employeeController.ErrorService();break;
                    }









                }
                else
                {
                    if (input != "e" && input != "E")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Press a <<number>> or <<e>> or <<E>> to exit the program...");
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("Program Ends");
        }
    }
}
