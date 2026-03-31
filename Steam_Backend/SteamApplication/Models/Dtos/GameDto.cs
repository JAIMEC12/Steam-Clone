namespace SteamApplication.Models.Dtos
{
    public class GameDto
    {
        public Guid GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public Guid DeveloperId { get; set; }
        public Guid PublisherId { get; set; }
        public DateTime? DeletedAt { get; set; } = null;
    }
}
