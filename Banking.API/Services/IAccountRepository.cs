using Banking.API.Entities;

namespace Banking.API.Services
{
    public interface IAccountRepository
    {
        IEnumerable<AccountBalance> GetBalance();
        void AddBalance (AccountBalance accountBalance);
        void UpdateBalance (AccountBalance accountBalance);
        AccountBalance GetBalance(string acctNumber);



        IEnumerable<AccountDetails> GetAccountDetails();
        void AddAccountDetails(AccountDetails accountDetails);
        void UpdateAccountDetails(AccountDetails accountDetails);
        void DeleteAccountDetails(Guid accountId);
        AccountDetails GetAccountDetail(string acctnumber);



        IEnumerable<Users> Users();
        void AddUsers(Users users); 
        void UpdateUsers(Users users);
        void DeleteUsers(Guid usersId);
        Users GetUser(Guid userId);


        RegisterUser GetRegisterUser(string registerId);
        

        bool AccountBalanceExits(string acctNumber);
        bool AccountDetailsExits(Guid accountId);
        bool UsersExits(Guid userId);
        bool save();
    }
}
