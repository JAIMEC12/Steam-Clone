namespace SteamApplication.Models.Request.Games
{
    public class GetAllGameRequest
    {
        public int? Limit { get; set; }
        public int? offset { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
