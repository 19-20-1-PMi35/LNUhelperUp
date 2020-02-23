using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }
        public int CommentId { get; set; }
        public Comment ThisComment { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Comment()
        {
            Comments = new Collection<Comment>();
        }
    }
}
