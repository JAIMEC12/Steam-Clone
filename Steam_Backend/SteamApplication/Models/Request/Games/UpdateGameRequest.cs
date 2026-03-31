namespace SteamApplication.Models.Request.Games
{
    public class UpdateGameRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid DeveloperId { get; set; }
        public Guid PublisherId { get; set; }
    }
}
