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
    public class ClubAppUserConfiguration : IEntityTypeConfiguration<ClubAppUser>
    {
        public void Configure(EntityTypeBuilder<ClubAppUser> builder)
        {
            builder.HasKey(clubAppUser => new { clubAppUser.AppUserId, clubAppUser.ClubId });

            builder.HasOne(clubAppUser => clubAppUser.AppUser)
                .WithMany(appUser => appUser.ClubAppUsers)
                .HasForeignKey(clubAppUser => clubAppUser.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(clubAppUser => clubAppUser.Club)
                .WithMany(club => club.ClubAppUsers)
                .HasForeignKey(clubAppUser => clubAppUser.ClubId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
