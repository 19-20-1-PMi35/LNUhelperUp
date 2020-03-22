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

            builder.HasData(
                new Faculty[]
                {
                    new Faculty {Id = 1, Name = "Біологічний"},
                    new Faculty {Id = 2, Name = "Географічний"},
                    new Faculty {Id = 3, Name = "Геологічний"},
                    new Faculty {Id = 4, Name = "Економічний"},
                    new Faculty {Id = 5, Name = "Електроніки та комп'ютерних технологій"},
                    new Faculty {Id = 6, Name = "Фурналістики"},
                    new Faculty {Id = 7, Name = "Іноземних мов"},
                    new Faculty {Id = 8, Name = "Історичний"},
                    new Faculty {Id = 9, Name = "Культури та мистецтв"},
                    new Faculty {Id = 10, Name = "Механіко-математичний факультет"},
                    new Faculty {Id = 11, Name = "Міжнародних відносин"},
                    new Faculty {Id = 12, Name = "Педагогічної освіти"},
                    new Faculty {Id = 13, Name = "Прикладної математики та інформатики"},
                    new Faculty {Id = 14, Name = "Управління фінансами та бізнесу"},
                    new Faculty {Id = 15, Name = "Фізичний"},
                    new Faculty {Id = 16, Name = "Філологічний"},
                    new Faculty {Id = 17, Name = "Філософський"},
                    new Faculty {Id = 18, Name = "Хімічний"},
                    new Faculty {Id = 19, Name = "Юридичний"}
                }
                );
        }
    }
}
