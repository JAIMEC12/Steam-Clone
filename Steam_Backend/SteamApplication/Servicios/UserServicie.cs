using Steam.Domain.Database.SqlServer.Entities;
using Steam.Domain.Exceptions;
using Steam.Domain.Interfaces.Repositories;
using SteamApplication.Helpers;
using SteamApplication.Interfaces.Servicie;
using SteamApplication.Models.Dtos;
using SteamApplication.Models.Request.Users;
using SteamApplication.Models.Response;
using SteamShared.Helpers;

namespace SteamApplication.Servicios
{

    public class UserService(IUserRepository repository) : IUserService // Define la clase UserService que implementa la interfaz IUserService
    {
        public async Task<GenericResponse<UserDto>> CreateUser(CreateUsersRequest model) // Método para crear un nuevo usuario a partir de una solicitud de creación de usuario
        {
            var createUser = await repository.Create(new User
            {
                UserId = Guid.NewGuid(),
                Email = model.Email,
                UserName = model.Username,
                Password = model.Password,
                CreatedAt = DateTimeHelper.UtcNow(),
                DeletedAt = null
            });
            return ResponseHelper.Create(Map(createUser));
        }

        public async Task<GenericResponse<bool>> DeleteUser(Guid userId)
        {
            var user = await GetUser(userId);
            user.DeletedAt = DateTimeHelper.UtcNow();
            await repository.Update(user);
            return ResponseHelper.Create(true);
        }


        public GenericResponse<List<UserDto>> GetUsers(FilterUserRequest model) // Método para obtener todos los usuarios almacenados en el cache
        {
            var queryable = repository.Queryable();

            if (!string.IsNullOrWhiteSpace(model.Username))
            {
                queryable = queryable.Where(x => x.UserName.Contains(model.Username ?? ""));
            }

            var users = queryable.Skip(model.offset).Take(model.limit).ToList();

            List<UserDto> mapped = [];

            foreach (var user in users)
            {
                mapped.Add(Map(user));
            }

            return ResponseHelper.Create(mapped);
        }


        public async Task<GenericResponse<UserDto>> GetUserById(Guid userId)
        {
            var user = await GetUser(userId);
            return ResponseHelper.Create(Map(user));
        }

        public async Task<GenericResponse<UserDto>> UpdateUser(Guid userId, UpdateUserRequest model)                                                                                     // cache utilizando su ID y una solicitud de                                                                                                                                                                                             // actualización de usuario
        {
            var user = await GetUser(userId);
            user.UserName = model.Username;
            user.Email = model.Email;
            var updateUser = await repository.Update(user);
            return ResponseHelper.Create(Map(updateUser));

        }

        private async Task<User> GetUser(Guid userId)
        {
            return await repository.Get(userId)
                ?? throw new NotFoundException("Usuario no existe");
        }

        private static UserDto Map(User user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.UserName,
                Email = user.Email,
                Username = user.UserName,
                Password = user.Password,
                CreatedAt = user.CreatedAt ?? DateTime.UtcNow,
                IsActive = user.DeletedAt == null,
            };
        }
    }
}
