﻿using AutoMapper;
using Banking.API.Models;
using Banking.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AccountRepository _accountRepository;
        private readonly IMapper _mapper;

        
        public UsersController(AccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }
        [HttpPost]
        public ActionResult<UsersDto> CreateUsers(UsersCreateRepo user)
        {
            var userEntity = _mapper.Map<Entities.Users>(user);
            _accountRepository.AddUsers(userEntity);
            _accountRepository.save();

            var userReturn = _mapper.Map<UsersDto>(userEntity);
            return CreatedAtRoute("Getuser", new { userId = userReturn.Id }, userReturn);
        }

        [HttpGet(Name = "Getuser")]
        public IActionResult GetUser(Guid userId)
        {
            var userFromRepo = _accountRepository.GetUser(userId);
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return Ok(_mapper.Map<UsersDto>(userFromRepo));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsersDto>> GetAllUser()
        {
            var usersAll = _accountRepository.Users();
            if(usersAll == null)
            {
                throw new ArgumentNullException(nameof(usersAll));
            }
            return Ok(_mapper.Map<IEnumerable<UsersDto>>(usersAll));
        }

        [HttpPut("{userid}")]
        public ActionResult UpdateUsers(Guid userId, UsersUpdateDto updateDto)
        {
            if(!_accountRepository.UsersExits(userId))
            {
                return NotFound();
            }

            var updateusers = _accountRepository.GetUser(userId);
            if(updateusers == null)
            {
                return NotFound();
            }

            _mapper.Map(updateDto, updateusers);

            _accountRepository.UpdateUsers(updateusers);
            _accountRepository.save();
            return NoContent();
        }
    }
}