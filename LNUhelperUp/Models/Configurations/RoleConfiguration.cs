using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.ToTable("Roles");

			builder.HasKey(p => p.Id);

			builder.HasMany(c => c.Users)
				.WithOne(c => c.Role)
				.HasForeignKey(c => c.RoleId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
