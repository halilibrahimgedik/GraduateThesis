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
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();

            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.ClubId).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Cv).IsRequired();
            builder.Property(x=>x.isApproved).HasDefaultValue(false).IsRequired();

            builder.HasOne(ap => ap.AppUser).WithMany(appUser => appUser.Applications);
        }
    }
}
