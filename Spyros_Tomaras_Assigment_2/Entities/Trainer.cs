using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Entities.CustomValidations;

namespace Entities
{
    public class Trainer : SchoolEntity
    {

        
        public int TrainerId { get; set; }

        [Required(ErrorMessage ="Your First Name Required")]
        [StringLength(30, MinimumLength =4, ErrorMessage ="Last Name should be between 4 and 30 characters long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Your Last Name Required")]
        [StringLength(30, MinimumLength = 4, ErrorMessage ="Last Name should be between 4 and 30 characters long!")]
        
        public string LastName { get; set; }

        [Required(ErrorMessage ="Your Subject Required")]
        [CustomValidation(typeof(Helper), "ValidateSubject")]
        public string Subject { get; set; }


    }
}
