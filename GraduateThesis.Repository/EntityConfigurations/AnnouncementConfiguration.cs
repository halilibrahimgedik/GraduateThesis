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
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Message).IsRequired().HasMaxLength(350);
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.Header).IsRequired().HasMaxLength(40);
            builder.Property(x => x.CreatedDate).IsRequired();

            builder.HasOne(x => x.Club)
                    .WithMany(club => club.Announcements)
                    .HasForeignKey(x=>x.ClubId);
        }
    }
}
