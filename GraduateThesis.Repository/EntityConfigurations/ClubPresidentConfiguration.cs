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
    public class ClubPresidentConfiguration : IEntityTypeConfiguration<ClubPresident>
    {
        public void Configure(EntityTypeBuilder<ClubPresident> builder)
        {
            builder.HasKey(x => new { x.AppUserId, x.ClubId });

            builder.HasOne(x=>x.AppUser)
                .WithMany(appUser=>appUser.ClubPresidents)
                .HasForeignKey(x=>x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Club)
                .WithMany(club => club.ClubPresidents)
                .HasForeignKey(x => x.ClubId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
