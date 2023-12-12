using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Data.Interfaces;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userRepository)
        {
            _userService = userRepository;
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser(UserForCreationDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }

        [HttpGet("AllUrls")]
        public IActionResult GetAllUrls(int userId)
        {
            return Ok(_userService.GetAllUrls(userId));
        }

        [HttpGet]
        public IActionResult GetRemainingShort(int userId) 
        {
            return Ok(_userService.Remainingshort(userId));
        }

        [HttpPut]
        public IActionResult ResetShortAmount(int userId)
        {
            _userService.ResetShortAmount(userId);
            return Ok();
        }

        



    }
}
