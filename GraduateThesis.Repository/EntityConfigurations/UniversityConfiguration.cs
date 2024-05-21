using GraduateThesis.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Repository.EntityConfigurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.UniversityName).HasMaxLength(125).IsRequired();

            builder.Property(x => x.Website).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Mail).HasMaxLength(60).IsRequired();

            builder.Property(x => x.Phone).HasMaxLength(16);

            // University - AppUser many to n
            builder.HasMany(university => university.Users)
                .WithOne(user => user.University).HasForeignKey(user => user.UniversityId);

            // Club - University many to n
            builder.HasMany(u => u.Clubs)
                .WithOne(c => c.ClubUniversity);
        }
    }
}
