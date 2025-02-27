using BloggingSite.API.Data.EntityMap;
using BloggingSite.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BloggingSite.API.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            // DbSet properties for custom models
            public DbSet<Category> Categories { get; set; }
            public DbSet<Post> Posts { get; set; }
            public DbSet<Comment> Comments { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder); // Required for Identity
                modelBuilder.ApplyConfiguration(new PostMap());
                modelBuilder.ApplyConfiguration(new CommentMap());
                modelBuilder.ApplyConfiguration(new ApplicationUserMap());
                modelBuilder.ApplyConfiguration(new CategoryMap());
                modelBuilder.ApplyConfiguration(new PostContentBlockMap());

        }
        
    }
}
