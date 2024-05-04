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
            builder.HasKey(x=> x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();

            builder.Property(x => x.ClubName).IsRequired();
            builder.Property(x => x.ClubSummary).IsRequired();
            builder.Property(x => x.IsClubActive).HasDefaultValue(false);

        }
    }
}
