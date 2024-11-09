//using System.Text;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        Task<List<Transaction>> GetTransactionsByAccountIdAsync(int accountId);
    }
}
