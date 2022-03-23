using AutoMapper;
using Banking.API.Entities;
using Banking.API.JwtFeatures;
using Banking.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Banking.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        private readonly UserManager<RegisterUser> _userManager;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LoginController(IMapper mapper, JwtHandler jwtHandler, UserManager<RegisterUser> userManager)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _userManager = userManager;
        }

        public JwtHandler JwtHandler { get; }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
    }
}
