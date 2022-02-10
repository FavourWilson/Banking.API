using Banking.API.Entities;

namespace Banking.API.Services
{
    public interface IAccountRepository
    {
        IEnumerable<AccountBalance> GetBalance();
        void AddBalance (AccountBalance accountBalance);
        void UpdateBalance (Guid accountBalId, AccountBalance accountBalance);
        AccountBalance GetBalance(string acctNumber);



        IEnumerable<AccountDetails> GetAccountDetails();
        void AddAccountDetails(AccountDetails accountDetails);
        void UpdateAccountDetails(Guid accountId, AccountDetails accountDetails);
        void DeleteAccountDetails(Guid accountId);
        AccountDetails GetAccountDetail(string acctnumber);



        IEnumerable<Users> Users();
        void AddUsers(Users users); 
        void UpdateUsers(Users users);
        void DeleteUsers(Guid usersId);
        Users GetUser(Guid userId);

        bool AccountBalanceExits(Guid accountBalId);
        bool AccountDetailsExits(Guid accountId);
        bool UsersExits(Guid userId);
        bool save();
    }
}
