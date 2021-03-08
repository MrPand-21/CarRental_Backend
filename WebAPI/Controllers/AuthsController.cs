using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin =_authService.Login(userForLoginDto);
            if (!userToLogin.Success) 
            {
                return BadRequest(userToLogin);
            }

            var token = _authService.CreateAccessToken(userToLogin.Data);
            if (!token.Success)
            {
                return BadRequest(token);
            }
            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userToRegister = _authService.Register(userForRegisterDto);
            if (!userToRegister.Success)
            {
                return BadRequest(userToRegister);
            }
            var token = _authService.CreateAccessToken(userToRegister.Data);
            if (!token.Success)
            {
                return BadRequest(token);
            }
            return Ok(token);
        }
    }
}
