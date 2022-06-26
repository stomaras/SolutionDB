using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Project : CompanyEntity
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public ICollection<Employee> Employees { get; set; }  
    }
}
