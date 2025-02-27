namespace BloggingSite.API.Models
{
    public class PostContentBlock
    {
           public int Id { get; set; }
            public int PostId { get; set; }
            public string BlockType { get; set; }
            public string Text { get; set; }
            public string Image { get; set; } // Image URL here or Base64 will decided later
            public int Order { get; set; }
            public Post Post { get; set; }
    }
}
