using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Menu
    {
        
            const int first = -45;
            const int second = -50;
            const int third = -45;
            const int fourth = -50;

            public static void ShowMenu()
            {
                Console.WriteLine("--------------------------------------------------------Main Menu-----------------------------------------------------");
                Console.WriteLine($"{"Press 1 Reading Employees",first}{"Press 2 Reading EmployeesPerProject",second}{"Press 3 ReadingEmployeesPerProjectPerManager",third}");
                Console.WriteLine($"{"Press 4 Reading EmployeeDetails",first}{"Press 5 Reading EmployeesPerProjectPerManager",second}{"Press 6 Create Employees",third}");
                Console.WriteLine($"{"Press 7 Create Projects",first}{"Press 8 Create Managers",second}{"Press 9 Delete Employees",third}");
                Console.WriteLine($"{"Press 10 Delete Projects",first}{"Press 11 Delete Managers ",second}{" Press 12 Update Employees",third}");
                Console.WriteLine($"{"Press 13 Update Projects",first}{"Press 14 Update Managers",second}{"Press e or E to Exit",third}");
            }
        }
    }

