using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Announcement> Announcements { get; set; }

        public Faculty()
        {
            Users = new Collection<User>();
            Events = new Collection<Event>();
            Announcements = new Collection<Announcement>();
        }
    }
}
