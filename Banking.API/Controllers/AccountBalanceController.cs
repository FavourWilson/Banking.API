using AutoMapper;
using Banking.API.Models;
using Banking.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/accountbalance")]
    [Authorize]
    [ApiController]
    public class AccountBalanceController : ControllerBase
    {
        private readonly AccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountBalanceController(AccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet(Name = "FetchBalance")]
        public IActionResult GetUserAccountBalance(string acctNumber)
        {
            var acctBalFromRepo = _accountRepository.GetBalance(acctNumber);
            if (acctBalFromRepo == null)
            {
                throw new ArgumentNullException(nameof(acctBalFromRepo));
            }

            return Ok(_mapper.Map<AccountBalDto>(acctBalFromRepo));
        }

        [HttpPost]
        public ActionResult<AccountBalDto> CreateAccountBalance(AccountBalCreateRepo accountBal)
        {
            var accountBalEntity = _mapper.Map<Entities.AccountBalance>(accountBal);
            _accountRepository.AddBalance(accountBalEntity);
            _accountRepository.save();

            var acctBalReturn = _mapper.Map<AccountBalDto>(accountBalEntity);
            return CreatedAtRoute("FetchBalance", new { accountBalId = accountBalEntity.Id }, acctBalReturn);
        }

        [HttpPut("update")]
        public IActionResult updateUserAccount(string acctNumber, AccountBalUpdateDto balUpdateDto)
        {
            if (!_accountRepository.AccountBalanceExits(acctNumber))
            { 
                return NotFound();
            }


            var UserBal = _accountRepository.GetBalance(acctNumber);
            if (UserBal == null)
            {
                var usersBalAdd = _mapper.Map<Entities.AccountBalance>(balUpdateDto);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                usersBalAdd.AccountDetails.AccountNumber = acctNumber;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                _accountRepository.AddBalance(usersBalAdd);

                var usersReturn = _mapper.Map<AccountBalDto>(usersBalAdd);
                return CreatedAtRoute("Getuser", new { userId = usersReturn.AccountDetailID }, usersReturn);
            }

            _mapper.Map(balUpdateDto, UserBal);

            _accountRepository.UpdateBalance(UserBal);
            _accountRepository.save();
            return NoContent();
        }
    }
}
