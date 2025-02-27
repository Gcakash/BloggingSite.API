using BloggingSite.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BloggingSite.API.Data.EntityMap
{
    public class PostContentBlockMap : IEntityTypeConfiguration<PostContentBlock>
    {
        public void Configure(EntityTypeBuilder<PostContentBlock> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.BlockType)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");
            builder.Property(x => x.Text)
                .IsRequired(false) // If text is optional
                .HasColumnType("nvarchar(max)");
            builder.Property(x => x.Image)
                .IsRequired(false) // If image is optional
                .HasColumnType("nvarchar(max)"); // Store URL or Base64 string
            builder.Property(x => x.Order)
                .IsRequired(true);

            builder.HasOne(x => x.Post)
                .WithMany(p => p.ContentBlocks)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}