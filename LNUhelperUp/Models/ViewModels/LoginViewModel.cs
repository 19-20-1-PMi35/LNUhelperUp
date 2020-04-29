using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Empty e-mail")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Empty password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
