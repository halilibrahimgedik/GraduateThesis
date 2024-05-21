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
    public class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                    new AppUser() {
                        Id = "35301441-b44f-4e60-92d1-bf29f86f8e33",
                        FullName = "Halil ibrahim gedik",
                        UserName = "admin",
                        UniversityId = 60,
                        Email = "halilgedik4234@gmail.com",
                        EmailConfirmed = true,
                    }
                );
        }
    }
}
