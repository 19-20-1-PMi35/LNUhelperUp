using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.Configurations
{
	public class EventConfiguration : IEntityTypeConfiguration<Event>
	{
		public void Configure(EntityTypeBuilder<Event> builder)
		{
			builder.ToTable("Events");

			builder.HasKey(p => p.Id);

			builder.HasOne(uc => uc.Faculty)
				.WithMany(u => u.Events)
				.HasForeignKey(uc => uc.FacultyId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(uc => uc.User)
				.WithMany(c => c.Events)
				.HasForeignKey(uc => uc.UserId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
