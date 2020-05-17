using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.ViewModels
{
    public class EditViewModel
    {
        [Required(ErrorMessage = "Empty Nickname")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Empty e-mail")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Empty Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Empty FacultyId")]
        public int FacultyId { get; set; }
    }
}
