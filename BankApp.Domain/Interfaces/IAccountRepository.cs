using BankApp.Domain.Entities;

namespace BankApp.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> CreateAccountAsync(Account account);
        Task<Account?> GetAccountByCustomerIdAsync(int customerId);
    }
}
