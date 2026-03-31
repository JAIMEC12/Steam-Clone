using Microsoft.AspNetCore.Mvc;
using SteamApplication.Interfaces.Servicie;
using SteamApplication.Models.Request.Games;

namespace Steam.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(IGameService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameRequest model)
        {
            var rsp = service.CreateGame(model);
            return Ok(rsp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllGameRequest model)
        {
            var rsp = service.Get(model.Limit ?? 0, model.offset ?? 0);
            return Ok(rsp);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rsp = service.GetById(id);
            return Ok(rsp);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateGameRequest model, Guid id)
        {
            return Ok();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok();
        }
    }
}
