using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Models.Configurations
{
	public class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.ToTable("Comments");

			builder.HasKey(p => p.Id);

			builder.HasOne(uc => uc.Announcement)
				.WithMany(u => u.Comments)
				.HasForeignKey(uc => uc.AnnouncementId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(uc => uc.User)
				.WithMany(c => c.Comments)
				.HasForeignKey(uc => uc.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasMany(u => u.Comments)
				.WithOne(u => u.ThisComment)
				.HasForeignKey(u => u.CommentId)
				.OnDelete(DeleteBehavior.NoAction);


			builder.HasOne(uc => uc.ThisComment)
				.WithMany(c => c.Comments)
				.HasForeignKey(uc => uc.CommentId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
