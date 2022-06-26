using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee : CompanyEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Managers = new HashSet<Manager>();
        }

        // Foreign Keys 
        public int? ProjectId { get; set; }

        // Navigation Properties
        public Project Project { get; set; }

        public ICollection<Manager> Managers { get; set; }


    }
}
