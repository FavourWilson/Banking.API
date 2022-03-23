using AutoMapper;
using Banking.API.Entities;
using Banking.API.Models;
using Banking.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly UserManager<RegisterUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AccountRepository _account;
        public RegisterUserController( IMapper mapper, UserManager<RegisterUser> userManager, AccountRepository account)
        {
            _mapper = mapper;
            _userManager = userManager;
            _account = account;

        }
         
        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody] RegisterUserCreateRepo registerUser)
        {
            if (registerUser == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<RegisterUser>(registerUser);
            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return StatusCode(201);
        }
        
        [HttpGet("userid")]
        public IActionResult GetUserById(string userid)
        {
            var userId = _account.GetRegisterUser(userid);
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userid));
            }

            return Ok(_mapper.Map<RegisterUserDto>(userId));
        }
    }
}
