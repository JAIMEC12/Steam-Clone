using SteamApplication.Interfaces.Servicie;
using SteamApplication.Models.Dtos;
using SteamApplication.Models.Request.Users;
using SteamApplication.Models.Response;


namespace SteamApplication.Servicios
{
    public class UserService : IUserService
    {
        private static List<UserDto> _data = new();

        public GenericResponse<UserDto> CreateUser(CreateUsersRequest model)
        {
            var user = new UserDto
            {
                UserId = Guid.NewGuid(),
                FullName = model.FullName,
                Email = model.Email,
                Username = model.Username,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _data.Add(user);

            return new GenericResponse<UserDto>
            {
                Message = "Usuario creado",
                Data = user
            };
        }

        public List<UserDto> GetAllUsers()
        {
            return _data;
        }

        public GenericResponse<UserDto> GetUserById(Guid id)
        {
            var user = _data.FirstOrDefault(x => x.UserId == id);

            return new GenericResponse<UserDto>
            {
                Message = user != null ? "OK" : "No encontrado",
                Data = user
            };
        }

        public GenericResponse<UserDto> UpdateUser(Guid id, UpdateUserRequest model)
        {
            var user = _data.FirstOrDefault(x => x.UserId == id);

            if (user == null)
                return new GenericResponse<UserDto> { Message = "No encontrado" };

            user.FullName = model.FullName;
            user.Email = model.Email;
            user.Username = model.Username;

            return new GenericResponse<UserDto>
            {
                Message = "Actualizado",
                Data = user
            };
        }

        public bool DeleteUser(Guid id)
        {
            var user = _data.FirstOrDefault(x => x.UserId == id);
            if (user == null) return false;

            _data.Remove(user);
            return true;
        }


    }
}
