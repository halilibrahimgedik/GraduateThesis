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

            builder.Property(x => x.UniversityName).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Website).IsRequired();
            builder.Property(x => x.Mail).IsRequired();
            builder.Property(x => x.Address).IsRequired();

            builder.Property(x => x.Phone).HasMaxLength(14);

            builder.HasMany(u => u.Users)
                .WithOne(user => user.University).HasForeignKey(user => user.UniversityId);
        }
    }
}
