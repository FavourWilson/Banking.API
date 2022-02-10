using Banking.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.DbContexts
{
    public class AppDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public DbSet<AccountDetails> accountDetails { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<AccountBalance> accountBalance { get; set; }
    }
}
