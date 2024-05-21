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
    public class ClubConfiguration : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Summary).HasMaxLength(450).IsRequired();
            builder.Property(x => x.Url).HasMaxLength(300);
            builder.Property(x => x.IsActive).HasDefaultValue(false);


            builder.HasOne(club => club.University)
                .WithMany(university => university.Clubs)
                .HasForeignKey(club => club.UniversityId);
        }
    }
}
