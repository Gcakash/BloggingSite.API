using BloggingSite.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingSite.API.Data.EntityMap
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(x => x.LastName)
                .IsRequired(true)
                .HasMaxLength(100)
                .HasColumnType("nvarchar");

            builder.Property(x => x.ProfilePicture)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.DateOfBirth);

            builder.Property(x => x.Bio)
                .IsRequired(false)
                .HasColumnType("nvarchar(max)");

            // Relationships
            builder.HasMany(x => x.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
