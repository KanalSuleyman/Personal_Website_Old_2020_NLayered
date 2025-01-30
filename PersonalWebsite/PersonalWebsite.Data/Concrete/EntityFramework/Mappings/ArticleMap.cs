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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(98);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(245);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(49);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoDescription).HasMaxLength(147);
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(312);
            builder.Property(a => a.ViewCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(469);
            builder.ToTable("Articles");

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);

            //builder.HasData(new Article
            //{
            //    Id = 1,
            //    Title = "Sample Article Title",
            //    Content = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum,",
            //    Thumbnail = "Default.jpg",
            //    ViewCount = 1,
            //    CommentCount = 1,
            //    Date = DateTime.UtcNow,
            //    SeoAuthor = "Suleyman Kanal",
            //    SeoDescription = "A sample article for testing the blog website",
            //    SeoTags = ".Net C# Deep Learning Python Sample Test Blog Article Programmer",
            //    CategoryId = 1,
            //    UserId = 1,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.UtcNow,
            //    ModifiedDate = DateTime.UtcNow,
            //    Note = "Article 1",
            //},
            //new Article
            //{
            //    Id = 2,
            //    Title = "Sample Article Title 2",
            //    Content = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written lintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of G in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem I",
            //    Thumbnail = "Default.jpg",
            //    ViewCount = 1,
            //    CommentCount = 1,


            //    Date = DateTime.UtcNow,
            //    SeoAuthor = "Suleyman Kanal",
            //    SeoDescription = "A sample article for testing the blog website 2",
            //    SeoTags = ".Net C# Deep Learning Python Sample Test Blog Article Programmer Second Article",
            //    CategoryId = 2,
            //    UserId = 1,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.UtcNow,
            //    ModifiedDate = DateTime.UtcNow,
            //    Note = "Article 2",
            //},
            //new Article
            //{
            //    Id = 3,
            //    Title = "Sample Article Title 3",
            //    Content = "Contrary to popul of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written lintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passag of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written lintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passagar belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written lintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of G in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum,",
            //    Thumbnail = "Default.jpg",
            //    ViewCount = 1,
            //    CommentCount = 1,
            //    Date = DateTime.UtcNow,
            //    SeoAuthor = "Suleyman Kanal",
            //    SeoDescription = "A sample article for testing the blog website 3",
            //    SeoTags = ".Net C# Deep Learning Python Sample Test Blog Article Programmer Third Article",
            //    CategoryId = 3,
            //    UserId = 1,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.UtcNow,
            //    ModifiedDate = DateTime.UtcNow,
            //    Note = "Article 3",
            //});
        }
    }
}
