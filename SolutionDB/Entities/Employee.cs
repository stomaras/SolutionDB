using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime HireDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Country Country { get; set; }
        public double Salary { get; set; }
        public string PhotoUrl { get; set; }

        [NotMapped]
        public int Age
        {
            get { return DateTime.Now.Year - this.DateOfBirth.Year; }
        }


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
