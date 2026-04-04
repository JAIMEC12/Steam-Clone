using SteamShared.Constants;
using System.ComponentModel.DataAnnotations;

namespace SteamApplication.Models.Request.Games
{
    public class CreateGameRequest
    {
        [Required(ErrorMessage = ValidationConstants.Required)]
        [MinLength(10, ErrorMessage = ValidationConstants.MinLength)]
        [MaxLength(100, ErrorMessage = ValidationConstants.MaxLength)]
        public required string Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = ValidationConstants.MinLength)]
        [MaxLength(255, ErrorMessage = ValidationConstants.MaxLength)]
        public required string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(0.0, double.PositiveInfinity, ErrorMessage = ValidationConstants.INVALID_DATA)]
        public required decimal Price { get; set; }

    }
}
