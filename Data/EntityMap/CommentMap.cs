using BloggingSite.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BloggingSite.API.Data.EntityMap
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Content)
                .IsRequired(true)
                .HasMaxLength(1000)
                .HasColumnType("nvarchar");
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.HasOne(x => x.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
