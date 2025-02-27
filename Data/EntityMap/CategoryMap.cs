using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Net;
using BloggingSite.API.Models;

namespace BloggingSite.API.Data.EntityMap
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(250).HasColumnType("nvarchar");
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
