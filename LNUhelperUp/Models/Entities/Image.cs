using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<User> Users { get; set; }

        public Image()
        {
            Events = new Collection<Event>();
            Users = new Collection<User>();
        }
    }
}
