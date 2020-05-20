using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.DTOs
{
    public class AnnouncementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreateAt { get; set; }
        public int UserId { get; set; }
        public int FacultyId { get; set; }
    }
}
