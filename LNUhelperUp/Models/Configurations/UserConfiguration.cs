using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.Id);

			builder.HasMany(c => c.Comments)
				.WithOne(c => c.User)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(c => c.Announcements)
				.WithOne(c => c.User)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(c => c.Events)
				.WithOne(c => c.User)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(uc => uc.Faculty)
				.WithMany(u => u.Users)
				.HasForeignKey(uc => uc.FacultyId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(uc => uc.Role)
				.WithMany(c => c.Users)
				.HasForeignKey(uc => uc.RoleId)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
