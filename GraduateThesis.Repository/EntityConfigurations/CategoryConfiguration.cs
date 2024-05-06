using GraduateThesis.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduateThesis.Repository.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c=> c.Id);
            builder.Property(c=>c.Id).UseIdentityColumn();

            builder.Property(c=>c.CategoryName).HasMaxLength(50).IsRequired();
        }
    }
}
