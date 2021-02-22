using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebServer.Database.Exceptions;
using WebServerEntityFramework.DTOs;
using WebServerEntityFramework.Interfaces;

namespace WebServerEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();

                return Ok(users);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("Nem található user az adatbázisban.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewUser([FromBody] UserDto user)
        {
            try
            {
                var result = await _userService.CreateNewUser(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);

                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound("Nem található a user az adatbázisban.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDto user)
        {
            try
            {
                var response = await _userService.UpdateUser(id, user);

                return Ok(response);
            }
            catch (EntityNotFoundException)
            {
                return NotFound("Nem található a user az adatbázisban.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
