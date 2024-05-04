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
    public class ClubCategoryConfiguration : IEntityTypeConfiguration<ClubCategory>
    {
        public void Configure(EntityTypeBuilder<ClubCategory> builder)
        {
            builder.HasKey(cc => new { cc.ClubId, cc.CategoryId });

            builder.HasOne(cc => cc.Club)
                .WithMany(c => c.ClubCategories)
                .HasForeignKey(cc => cc.ClubId);

            builder.HasOne(cc => cc.Category)
                .WithMany(c => c.ClubCategories)
                .HasForeignKey(cc => cc.CategoryId);
        }
    }
}
