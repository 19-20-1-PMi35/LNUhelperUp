using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LNUhelperUp.Models.ViewModels
{
    public class PhotoViewModel
    {
        [Required(ErrorMessage = "Виберіто фото")]
        public IFormFile Photo { get; set; }
    }
}
