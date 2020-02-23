using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.Configurations
{
	public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
	{
		public void Configure(EntityTypeBuilder<Faculty> builder)
		{
			builder.ToTable("Faculties");

			builder.HasKey(p => p.Id);

			builder.HasMany(c => c.Users)
				.WithOne(c => c.Faculty)
				.HasForeignKey(c => c.FacultyId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(c => c.Announcements)
				.WithOne(c => c.Faculty)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(c => c.Events)
				.WithOne(c => c.Faculty)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
