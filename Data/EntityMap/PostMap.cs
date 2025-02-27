using BloggingSite.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingSite.API.Data.EntityMap
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(250)
                .HasColumnType("nvarchar");
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");
            builder.Property(x => x.CoverImage)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)"); 
            builder.Property(x => x.IsPublished).IsRequired(true);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);

            builder.HasOne(x => x.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.ContentBlocks)
                .WithOne(cb => cb.Post)
                .HasForeignKey(cb => cb.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
