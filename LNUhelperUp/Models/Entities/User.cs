using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Announcement> Announcements { get; set; }

        public User()
        {
            Comments = new Collection<Comment>();
            Events = new Collection<Event>();
            Announcements = new Collection<Announcement>();
        }


    }
}
