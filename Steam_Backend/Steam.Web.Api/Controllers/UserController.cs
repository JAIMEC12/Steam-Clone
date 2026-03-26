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

        [HttpPost] // Create a new user
        public IActionResult Create([FromBody] CreateUsersRequest model)
        {
            var rsp = _service.CreateUser(model);
            return Ok(rsp);
        }

        [HttpGet] // Get all users
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllUsers());
        }

        [HttpGet("{id:guid}")] // Get a user by ID
        public IActionResult GetById(Guid id)
        {
            return Ok(_service.GetUserById(id));
        }

        [HttpPut("{id:guid}")] // Update a user by ID
        public IActionResult Update(Guid id, [FromBody] UpdateUserRequest request)
        {
            return Ok(_service.UpdateUser(id, request));
        }

        [HttpDelete("{id:guid}")] // Delete a user by ID
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.DeleteUser(id));
        }
    }
}
