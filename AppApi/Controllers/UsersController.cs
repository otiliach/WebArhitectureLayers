using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DataAccess.Database.Models;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;


        public UsersController(IUserService userService,ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserForList>  GetUsers([Range(0,int.MaxValue)]int offet=1,[Range(1,100)] int limit=4)
        {
            
            return _userService.GetAll(offet, limit);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UserForList>> GetUserByid([Required][FromRoute] int userId)
        {
            var user=_userService.GetById(userId);
            if (user == null)
            {
                _logger.LogWarning("Cannot find the user with id {userId}", userId);
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<UserForList>> CreateUser(
            [Required][FromForm] string userName,
            [Required][FromForm] string password
            )
        {
            var createdUser = await _userService.CreateUser(userName,password);
            return Ok(createdUser);
        }


        /*[HttpPost]
        [Consumes("application/json")]
        [Route("json")]
        public async Task<ActionResult<UserForList>> CreateUser(
            [Required][FromBody] UserCreationDto userCreationDto)
        {

        }*/

        [HttpPatch]
        [Route("{userId}")]

        public async Task<ActionResult<UserForList>> ModifyUser(
             [Required][FromRoute] int userId,
             [Required][FromForm] string userName)
        {
            var existingUser = await _userService.GetById(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = userName;

            var modifiedUSer = await _userService.ModifyUser(userId, userName);
            return Ok(modifiedUSer);
        }

        [HttpDelete]
        [Route("{userId}")]

        public async Task<ActionResult<UserForList>> DeleteUser([Required][FromRoute] int userId)
        {
            var existingUser = await _userService.GetById(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(userId);

            return NoContent();
        }


    }
}
