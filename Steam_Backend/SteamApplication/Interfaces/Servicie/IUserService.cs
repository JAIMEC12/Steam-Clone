using SteamApplication.Models.Dtos;
using SteamApplication.Models.Request.Users;
using SteamApplication.Models.Response;

namespace SteamApplication.Interfaces.Servicie
{
    public interface IUserService // Define la interfaz IUserService que contiene los métodos para gestionar usuarios
    {
        GenericResponse<UserDto> CreateUser(CreateUsersRequest model);
        GenericResponse<UserDto> UpdateUser(Guid id, UpdateUserRequest model);
        bool DeleteUser(Guid id);
        List<UserDto> GetAllUsers();
        GenericResponse<UserDto> GetUserById(Guid id);
    }
}
