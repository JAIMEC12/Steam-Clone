using SteamApplication.Helpers;
using SteamApplication.Interfaces.Servicie;
using SteamApplication.Models.Dtos;
using SteamApplication.Models.Request.Users;
using SteamApplication.Models.Response;
using SteamShared.Cache;


namespace SteamApplication.Servicios
{



    public class UserService(Cache<UserDto> cache) : IUserService // Define la clase UserService que implementa la interfaz IUserService y
                                                                  // utiliza un cache para almacenar los usuarios
    {


        //private static List<UserDto> _data = new(); 

        public GenericResponse<UserDto> CreateUser(CreateUsersRequest model) // Método para crear un nuevo usuario a partir de una solicitud de creación de usuario
        {
            var user = new UserDto
            {
                UserId = Guid.NewGuid(),
                FullName = model.FullName,
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            cache.Add(user.UserId.ToString(), user); // Agrega el nuevo usuario al cache utilizando su UserId como clave

            return ResponseHelper.Ok(user, "Usuario creado con cache");


            /*{
                Message = "Usuario creado",
                Data = user
            };*/
        }

        public List<UserDto> GetAllUsers() // Método para obtener todos los usuarios almacenados en el cache
        {

            var cachedUsers = cache.GetAll();
            return cache.GetAll();


        }


        public GenericResponse<UserDto> GetUserById(Guid id) // Método para obtener un usuario específico por su ID desde el cache
        {
            var user = cache.Get(id.ToString());
            if (user == null)
                return ResponseHelper.Fail<UserDto>("Usuario no encontrado en cache");

            return ResponseHelper.Ok(user, "Usuario encontrado en cache");
        }

        public GenericResponse<UserDto> UpdateUser(Guid id, UpdateUserRequest model) // Método para actualizar un usuario existente en el
                                                                                     // cache utilizando su ID y una solicitud de
                                                                                     // actualización de usuario
        {
            var user = cache.Get(id.ToString());

            if (user == null)
                return new GenericResponse<UserDto> { Message = "Usuario No encontrado" };

            user.FullName = model.FullName ?? user.FullName;
            user.Email = model.Email ?? user.Email;
            user.Username = model.Username ?? user.Username;


            if (!string.IsNullOrEmpty(model.Password))
            {

                user.Password = model.Password;

            }

            cache.Add(id.ToString(), user);


            return new GenericResponse<UserDto>
            {
                Message = " Usuario Actualizado",
                Data = user
            };
        }

        public bool DeleteUser(Guid id) // Método para eliminar un usuario del cache utilizando su ID
        {


            return cache.Delete(id.ToString());



        }



        //private readonly Cache<UserDto> _cache; // Inyección de dependencia del cache

    }
}
