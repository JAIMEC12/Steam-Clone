using SteamApplication.Models.Dtos;
using SteamApplication.Models.Request.Games;
using SteamApplication.Models.Response;

namespace SteamApplication.Interfaces.Servicie
{
    public interface IGameService
    {
        public GenericResponse<GameDto> CreateGame(CreateGameRequest model);
        public GenericResponse<GameDto> UpdateGame(Guid gameId, UpdateGameRequest model);
        public GenericResponse<List<GameDto>> Get(int limit, int offset);
        public GenericResponse<GameDto?> GetById(Guid gameId);
        public GenericResponse<bool> Delete(Guid gameId);
    }
}
