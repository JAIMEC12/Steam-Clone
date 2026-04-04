using SteamApplication.Models.Dtos;
using SteamApplication.Models.Request.Users;
using SteamApplication.Models.Response;

namespace SteamApplication.Interfaces.Servicie
{
    public interface IUserService // Define la interfaz IUserService que contiene los métodos para gestionar usuarios
    {
        public Task<GenericResponse<UserDto>> CreateUser(CreateUsersRequest model);
        public Task<GenericResponse<UserDto>> UpdateUser(Guid userId, UpdateUserRequest model);
        public GenericResponse<List<UserDto>> GetUsers(FilterUserRequest model);
        public Task<GenericResponse<UserDto>> GetUserById(Guid userId);
        public Task<GenericResponse<bool>> DeleteUser(Guid userId);
    }
}
