using GraduateThesis.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Repository.Seeds
{
    public class ClubAppUserSeed : IEntityTypeConfiguration<ClubAppUser>
    {
        public void Configure(EntityTypeBuilder<ClubAppUser> builder)
        {
            builder.HasData(
                    
                    new ClubAppUser()
                    {
                        AppUserId = "c4652099-e1b3-4572-9b94-1462d39dd114",
                        ClubId = 1,
                    },

                    new ClubAppUser()
                    {
                        AppUserId = "c8bac547-a2d3-474c-87c4-dd2c1a1d1daa",
                        ClubId = 6,
                    }
                    
                );
        }
    }
}
