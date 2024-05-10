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

                    new Category() { Id = 1, Name = "Teknoloji", CreatedDate = DateTime.Now },
                    new Category() { Id = 2, Name = "Spor", CreatedDate = DateTime.Now },
                    new Category() { Id = 3, Name = "Kitap", CreatedDate = DateTime.Now },
                    new Category() { Id = 4, Name = "Sanat", CreatedDate = DateTime.Now },
                    new Category() { Id = 5, Name = "Dans", CreatedDate = DateTime.Now },
                    new Category() { Id = 6, Name = "Girişimcilik", CreatedDate = DateTime.Now }

                );
        }
    }
}
