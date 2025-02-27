using Microsoft.AspNetCore.Identity;

namespace BloggingSite.API.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
