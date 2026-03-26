namespace SteamApplication.Models.Request.Users
{
    public class UpdateUserRequest // Define la clase UpdateUserRequest que representa la estructura de los datos necesarios para actualizar un usuario
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
