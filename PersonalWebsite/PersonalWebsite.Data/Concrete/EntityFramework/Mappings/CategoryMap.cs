using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalWebsite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalWebsite.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(308);
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(469);
            builder.ToTable("Categories");

            builder.HasData(new Category
            {
                Id = 1,
                Name = ".Net Core",
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Note = ".Net Blog Category",
                Description = "Applications with .Net Core framework and theoritical informations",

            },
            new Category
            {
                Id = 2,
                Name = "Deep Learning",
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Note = "Deep Learning Blog Category",
                Description = "Deep Learning Algorithms and Applications",
            },
            new Category
            {
                Id = 3,
                Name = "Sql",
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Note = "Sql Blog Category",
                Description = "Applications with SQL Query Lenguage",
            }
            );
        }
    }
}
