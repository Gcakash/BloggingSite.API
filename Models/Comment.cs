namespace BloggingSite.API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public int PostId { get; set; } // Foreign key for the post
        public Post Post { get; set; } // Navigation property for the post
        public ApplicationUser User { get; set; }
    }
}
