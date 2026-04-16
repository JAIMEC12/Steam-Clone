namespace SteamApplication.Models.Dtos
{
    public class UserDto // Define la clase UserDto que representa un objeto de transferencia de datos para un usuario
    {

        public Guid UserId { get; set; }
        public string FullName { get; set; } = null;
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }


    }
}
