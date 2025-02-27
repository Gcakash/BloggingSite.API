
namespace BloggingSite.API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string UserId { get; set; }

        public bool IsPublished { get; set; }

        public int? CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // List of content blocks
        public ICollection<PostContentBlock> ContentBlocks { get; set; }
        public ApplicationUser User { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
