using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LNUhelperUp.Models.ViewModels
{
    public class PhotoViewModel
    {
        public IFormFile Photo { get; set; }
    }
}
