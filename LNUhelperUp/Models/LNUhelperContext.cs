using LNUhelperUp.Models.Configurations;
using LNUhelperUp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models
{
    public class LNUhelperContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Image> Images { get; set; }

        public LNUhelperContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AnnouncementConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new FacultyConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());


            base.OnModelCreating(builder);
        }
    }

}

