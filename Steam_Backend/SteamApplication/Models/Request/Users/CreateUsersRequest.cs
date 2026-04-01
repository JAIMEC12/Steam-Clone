using SteamShared.Constants;
using System.ComponentModel.DataAnnotations;


namespace SteamApplication.Models.Request.Users
{
    public class CreateUsersRequest // Define la clase CreateUsersRequest que representa la estructura de los datos necesarios para crear un nuevo usuario
    {
        [Required(ErrorMessage = ValidationConstants.Required)]
        [MinLength(10, ErrorMessage = ValidationConstants.MinLength)]
        public string FullName { get; set; }

        [Required(ErrorMessage = ValidationConstants.Required)]
        [EmailAddress(ErrorMessage = ValidationConstants.INVALID_EMAIL)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.Required)]
        [MinLength(5, ErrorMessage = ValidationConstants.MinLength)]
        public string Username { get; set; }


        [Required(ErrorMessage = ValidationConstants.Required)]
        [MinLength(6)]
        public string Password { get; set; }



    }
}
