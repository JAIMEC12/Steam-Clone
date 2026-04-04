namespace SteamApplication.Models.Request.Users
{
    public class FilterUserRequest : BaseRequest
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
    }
}
