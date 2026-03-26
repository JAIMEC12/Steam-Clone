namespace SteamApplication.Models.Dtos
{
    public class UserDto
    {

        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }


    }
}
