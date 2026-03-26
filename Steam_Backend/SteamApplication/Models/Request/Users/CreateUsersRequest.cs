using SteamShared.Constants;
using System.ComponentModel.DataAnnotations;


namespace SteamApplication.Models.Request.Users
{
    public class CreateUsersRequest
    {
        [Required(ErrorMessage = ValidationConstants.Required)]
        [MinLength(10, ErrorMessage = ValidationConstants.MinLength)]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationConstants.Required)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.Required)]
        [MinLength(5, ErrorMessage = ValidationConstants.MinLength)]
        public string Username { get; set; }



    }
}
