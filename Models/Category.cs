namespace BloggingSite.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
