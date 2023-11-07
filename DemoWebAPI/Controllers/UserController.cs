using BLL_Pizzeria.Interface;
using DemoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLLService _userService;

        public UserController(IUserBLLService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserModel u)
        {
            if(!ModelState.IsValid) 
                return BadRequest();
            _userService.Register(u.Email, u.Password, u.Nickname);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserModel u)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return Ok(_userService.Login(u.Email, u.Password));
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetById(id));
        }

    }
}
