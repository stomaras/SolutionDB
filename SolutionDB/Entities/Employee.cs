using Entities.Enums;
using Entities.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee : CompanyEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name can not be null or empty")]
        [StringLength(50,MinimumLength = 2, ErrorMessage ="First Name should be between 2 and 50 characters long")]
        [CustomValidation(typeof(EmployeeCustomValidations), "ValidateFirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name can not be null or empty")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name should be between 2 and 50 characters long")]
        [CustomValidation(typeof(EmployeeCustomValidations), "ValidateLastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Hire Date can not be null or empty")]
        [DisplayFormat(DataFormatString ="{0:d}", ApplyFormatInEditMode =true)]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage ="Birth Date can not be null or empty")]
        [DisplayFormat(DataFormatString ="{0:d}", ApplyFormatInEditMode =true)]
        [Range(typeof(DateTime), "01-01-1970", "01-01-2004", ErrorMessage ="Date Of Birth Must Be Between 01-01-1970 and 01-01-2004")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage ="Country can not be null or empty")]
        [CustomValidation(typeof(EmployeeCustomValidations), "ValidateCountries")]
        public Country Country { get; set; }

        [Required(ErrorMessage ="Salary can not be null or empty")]
       
        public double Salary { get; set; }

        [DataType(DataType.Url, ErrorMessage ="Please Enter a valid URL")]
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
