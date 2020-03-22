using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.Configurations
{
	public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
	{
		public void Configure(EntityTypeBuilder<Announcement> builder)
		{
			builder.ToTable("Announcements");

			builder.HasKey(p => p.Id);

			builder.HasMany(c => c.Comments)
				.WithOne(c => c.Announcement)
				.HasForeignKey(c => c.AnnouncementId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(uc => uc.Faculty)
				.WithMany(u => u.Announcements)
				.HasForeignKey(uc => uc.FacultyId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(uc => uc.User)
				.WithMany(c => c.Announcements)
				.HasForeignKey(uc => uc.UserId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
