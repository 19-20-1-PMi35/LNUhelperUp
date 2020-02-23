using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Announcement()
        {
            Comments = new Collection<Comment>();
        }

    }
}
