namespace BloggingSite.API.DTOs
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserRole { get; set; }
        public string Bio { get; set; }
    }
}
