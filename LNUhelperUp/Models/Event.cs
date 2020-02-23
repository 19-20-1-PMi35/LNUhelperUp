using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public string Place { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public bool IsOfficial { get; set; }
    }
}
