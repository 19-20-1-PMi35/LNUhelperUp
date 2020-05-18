using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Choose your faculty")]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "Empty nickname")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Empty e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Empty password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int ImageId { get; set; }
    }
}
