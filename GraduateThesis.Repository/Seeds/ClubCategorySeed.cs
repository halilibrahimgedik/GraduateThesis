using GraduateThesis.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateThesis.Repository.Seeds
{
    public class ClubCategorySeed : IEntityTypeConfiguration<ClubCategory>
    {
        public void Configure(EntityTypeBuilder<ClubCategory> builder)
        {
            builder.HasData(
            new ClubCategory() { ClubId = 1, CategoryId = 1 },
            new ClubCategory() { ClubId = 2, CategoryId = 3 },
            new ClubCategory() { ClubId = 3, CategoryId = 2 },
            new ClubCategory() { ClubId = 4, CategoryId = 2 },
            new ClubCategory() { ClubId = 5, CategoryId = 5 },
            new ClubCategory() { ClubId = 6, CategoryId = 6 }
            );
        }
    }
}

