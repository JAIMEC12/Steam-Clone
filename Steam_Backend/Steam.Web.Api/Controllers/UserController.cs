using Microsoft.AspNetCore.Mvc;
using SteamApplication.Interfaces.Servicie;
using SteamApplication.Models.Request.Users;


namespace Steam.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        private readonly IUserService _service = service;

        [HttpPost]
        public IActionResult Create([FromBody] CreateUsersRequest model)
        {
            var rsp = _service.CreateUser(model);
            return Ok(rsp);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllUsers());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_service.GetUserById(id));
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] UpdateUserRequest model)
        {
            return Ok(_service.UpdateUser(id, model));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.DeleteUser(id));
        }
    }
}
