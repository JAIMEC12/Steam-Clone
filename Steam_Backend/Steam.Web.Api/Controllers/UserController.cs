using Microsoft.AspNetCore.Mvc;
using SteamApplication.Interfaces.Servicie;
using SteamApplication.Models.Request.Users;


namespace Steam.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpPost] // Create a new user
        public async Task<IActionResult> Create([FromBody] CreateUsersRequest model)
        {
            var rsp = await userService.CreateUser(model);
            return Ok(rsp);
        }

        [HttpGet] // Get all users
        public async Task<IActionResult> GetAll([FromQuery] FilterUserRequest model)
        {
            var rsp = userService.GetUsers(model);
            return Ok(rsp);
        }

        [HttpGet("{id:guid}")] // Get a user by ID
        public async Task<IActionResult> GetById(Guid userId)
        {
            var rsp = await userService.GetUserById(userId);
            return Ok(rsp);
        }

        [HttpPut("{id:guid}")] // Update a user by ID
        public async Task<IActionResult> Update(Guid userId, [FromBody] UpdateUserRequest request)
        {
            var rsp = await userService.UpdateUser(userId, request);
            return Ok(rsp);
        }

        [HttpDelete("{id:guid}")] // Delete a user by ID
        public async Task<IActionResult> Delete(Guid userId)
        {
            var rsp = await userService.DeleteUser(userId);
            return Ok(rsp);
        }
    }
}
