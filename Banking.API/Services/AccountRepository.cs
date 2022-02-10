using Banking.API.DbContexts;
using Banking.API.Entities;

namespace Banking.API.Services
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private readonly AppDbContext _context;

        public string AcctNumber;
        private string numbers;
        public AccountRepository(AppDbContext context)
        {
            _context = context;

            var defaultNumber = 001;
            Random random = new Random();

            numbers = random.Next(8904567).ToString();

            AcctNumber = String.Concat(defaultNumber, numbers);
        }

        public bool AccountBalanceExits(Guid accountBalId)
        {
            throw new NotImplementedException();
        }

        public bool AccountDetailsExits(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public void AddAccountDetails(AccountDetails accountDetails)
        {
            if (accountDetails == null)
            {
                throw new ArgumentNullException(nameof(accountDetails));
            }

            accountDetails.Id = Guid.NewGuid();
            accountDetails.AccountNumber = AcctNumber;

            foreach (var users  in accountDetails.Users)
            {
                users.Id = Guid.NewGuid();
            }

            _context.accountDetails.Add(accountDetails);
        }

        public void AddBalance(AccountBalance accountBalance)
        {
            if(accountBalance == null)
            {
                throw new ArgumentNullException(nameof(accountBalance));
            }
            accountBalance.Id = Guid.NewGuid();
            accountBalance.Withdrawal = 0;
            accountBalance.Deposit = 0;
            accountBalance.TotalBalance = accountBalance.Withdrawal - accountBalance.Deposit;

            foreach (var acctDetails in accountBalance.accountDetails)
            {
                acctDetails.Id = Guid.NewGuid();
                foreach (var users in acctDetails.Users)
                {
                    users.Id = Guid.NewGuid();
                }
                
            }
        }

        public void AddUsers(Users users)
        {
            if(users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            _context.Users.Add(users);
        }

        public void DeleteAccountDetails(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsers(Guid usersId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        

        public IEnumerable<AccountDetails> GetAccountDetails()
        {
            return _context.accountDetails.ToList();
        }

        public IEnumerable<AccountBalance> GetBalance()
        {
            throw new NotImplementedException();
        }

        public AccountBalance GetBalance(string acctNumber)
        {
            if(acctNumber == null)
            {
                throw new ArgumentNullException(nameof(acctNumber));
            }

#pragma warning disable CS8603 // Possible null reference return.
            return GetBalance().FirstOrDefault(n => n.accountDetails.Any(a => a.AccountNumber == acctNumber));
#pragma warning restore CS8603 // Possible null reference return.
        }

        public Users GetUsers(Guid userId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Users.FirstOrDefault(n => n.Id == userId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public bool save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAccountDetails(Guid accountId, AccountDetails accountDetails)
        {
            throw new NotImplementedException();
        }

        public void UpdateBalance(Guid accountBalId, AccountBalance accountBalance)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsers(Users users)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> Users()
        {
            return _context.Users.ToList();
        }

        public bool UsersExits(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Users GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

#pragma warning disable CS8603 // Possible null reference return.
            return _context.Users.FirstOrDefault(a => a.Id == userId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public AccountDetails GetAccountDetail(string acctnumber)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return GetAccountDetails().FirstOrDefault(n => n.AccountNumber == acctnumber);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
