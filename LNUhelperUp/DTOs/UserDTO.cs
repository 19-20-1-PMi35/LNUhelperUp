using LNUhelperUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Login { get; set; }
        public int RoleId { get; set; }
        public string FacultyName { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
    }
}
