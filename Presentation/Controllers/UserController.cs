using Application;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTO;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserServes _userServes;

        public UserController(IUserServes a)
        {
            _userServes = a;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserDTO userDTO)
        {
            return Json(await _userServes.UserCreatAsync(userDTO.Name, userDTO.Email));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]UserDTO userDTO)
        {
            await _userServes.UserDeleteFromRepositoryAsync(userDTO.Name);

            return Ok("Пользователь успешно удален"); 
        }
    }
}