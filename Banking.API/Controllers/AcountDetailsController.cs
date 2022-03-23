using AutoMapper;
using Banking.API.Models;
using Banking.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AcountDetailsController : ControllerBase
    {
        private readonly AccountRepository _account;
        private readonly IMapper _mapper;

       
        public AcountDetailsController(AccountRepository account, IMapper mapper)
        {
            _account = account ?? throw new ArgumentNullException(nameof(account));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

         }

        [HttpPost("userdetails")]
        public ActionResult<AccountDetailsDto> CreateAccountDetails(AccountDetailsCreateRepo createRep)
        {
            var AcctDetailsEntity = _mapper.Map<Entities.AccountDetails>(createRep);
            _account.AddAccountDetails(AcctDetailsEntity);
            _account.save();

            var AcctDetailsReturn = _mapper.Map<AccountDetailsDto>(AcctDetailsEntity);
            return CreatedAtRoute("GetAccountDetail", new {accountDetailsId = AcctDetailsEntity.Id}, AcctDetailsReturn);
        }

        [HttpGet(Name = "GetAccountDetail")]
        public IActionResult GetAccountDetail(string accountNumber)
        {
            var acctDetailFromRepo = _account.GetAccountDetail(accountNumber);   
            if(accountNumber == null)
            {
                throw new ArgumentNullException(nameof(accountNumber));
            }

            return Ok(_mapper.Map<AccountDetailsDto>(acctDetailFromRepo));
        }

    }
}
