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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(

                    new Category() { Id = 1, CategoryName = "Teknoloji", CreatedDate = DateTime.Now },
                    new Category() { Id = 2, CategoryName = "Spor", CreatedDate = DateTime.Now },
                    new Category() { Id = 3, CategoryName = "Kitap", CreatedDate = DateTime.Now },
                    new Category() { Id = 4, CategoryName = "Sanat", CreatedDate = DateTime.Now },
                    new Category() { Id = 5, CategoryName = "Dans", CreatedDate = DateTime.Now },
                    new Category() { Id = 6, CategoryName = "Girişimcilik", CreatedDate = DateTime.Now }

                );
        }
    }
}
