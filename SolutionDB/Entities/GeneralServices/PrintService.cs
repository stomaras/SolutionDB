using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GeneralServices
{
    public static class PrintService
    {

        public static void ShowProjectTitles(List<string> projectTitles)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter one of the below mentioned projects");
            for (int i = 0; i < projectTitles.Count; i++)
            {
                Console.WriteLine($"{i} -> {projectTitles[i]}");
            }
            Console.ResetColor();
        }
    }
}
