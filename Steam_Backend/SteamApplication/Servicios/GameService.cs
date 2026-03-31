using SteamApplication.Helpers;
using SteamApplication.Interfaces.Servicie;
using SteamApplication.Models.Dtos;
using SteamApplication.Models.Request.Games;
using SteamApplication.Models.Response;
using SteamShared;

namespace SteamApplication.Servicios
{
    public class GameService(Cache<GameDto> cache) : IGameService
    {
        public GenericResponse<GameDto> CreateGame(CreateGameRequest model)
        {
            var game = new GameDto
            {
                GameId = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
                Price = model.Price,
                DeveloperId = Guid.NewGuid(),
                PublisherId = Guid.NewGuid(),
            };
            cache.Add(game.GameId.ToString(), game);
            return ResponseHelper.Create(game);

        }

        public GenericResponse<bool> Delete(Guid gameId)
        {
            //PENSATIVA
            var isAlive = cache.Get(gameId.ToString());
            if (isAlive is null)
            {
                return ResponseHelper.Create(false);
            }
            cache.Delete(gameId.ToString());
            return ResponseHelper.Create(true);
        }

        public GenericResponse<List<GameDto>> Get(int limit, int offset)
        {
            var games = cache.Get();
            return ResponseHelper.Create(games);
        }

        public GenericResponse<GameDto?> GetById(Guid gameId)
        {
            var game = cache.Get(gameId.ToString());
            return ResponseHelper.Create(game);
        }

        public GenericResponse<GameDto> UpdateGame(Guid gameId, UpdateGameRequest model)
        {
            //PENSATIVA
            throw new NotImplementedException();
        }
    }
}
