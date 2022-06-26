using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Manager : CompanyEntity
    {
        public int ManagerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Manager()
        {
            Employees = new HashSet<Employee>();    
        }

        // Navigation Properties
        public ICollection<Employee> Employees { get; set; }
        
    }
}
