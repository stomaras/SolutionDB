using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Validations
{
    public class ConsoleHelper
    {
        /// <summary>
        /// Check If An input string is a numeric value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CheckIfIsNumber(string input)
        {
            if (input.All(char.IsDigit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
