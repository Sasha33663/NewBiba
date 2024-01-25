using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/")]
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
            var b = await _userServes.UserCreatAsync(userDTO.Name, userDTO.Email);

            return Json(b);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody]UserDTO userDTO)
        {
            var b = await _userServes.UserDeleteFromRepositoryAsync(userDTO.Name);
            return Json(b); 
        }
    }
}