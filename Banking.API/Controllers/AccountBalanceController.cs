using AutoMapper;
using Banking.API.Models;
using Banking.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/accountbalance")]
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
    }
}
