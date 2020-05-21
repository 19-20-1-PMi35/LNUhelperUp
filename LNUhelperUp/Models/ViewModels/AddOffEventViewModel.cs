﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.ViewModels
{
    public class AddOffEventViewModel
    {
        [Required(ErrorMessage = "Empty Nickname")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Empty Text")]
        public string Text { get; set; }
        public int? ParticipantAmount { get; set; }
        public DateTime Time { get; set; }
        public double? Price { get; set; }
        [Required(ErrorMessage = "Empty Place")]
        public string? Place { get; set; }
        [Required(ErrorMessage = "Виберіто фото")]
        public IFormFile Photo { get; set; }
    }
}