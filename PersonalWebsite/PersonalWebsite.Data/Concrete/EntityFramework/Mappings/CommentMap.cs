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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(469);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(469);
            builder.ToTable("Comments");

            builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);

            //builder.HasData(new Comment
            //{
            //    Id = 1,
            //    Text = "A comment for the article one that states its beauty",
            //    ArticleId = 1,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.UtcNow,
            //    ModifiedDate = DateTime.UtcNow,
            //    Note = "Comment 1",
            //},
            //new Comment
            //{
            //    Id = 2,
            //    ArticleId = 2,
            //    Text = "A comment that criticise the article 2",
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.UtcNow,
            //    ModifiedDate = DateTime.UtcNow,
            //    Note = "Comment 2",
            //},
            //new Comment
            //{
            //    Id = 3,
            //    Text = "A positive comment for the article 3 from a reader",
            //    ArticleId = 3,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.UtcNow,
            //    ModifiedDate = DateTime.UtcNow,
            //    Note = "Comment 3",
            //});
        }
    }
}
