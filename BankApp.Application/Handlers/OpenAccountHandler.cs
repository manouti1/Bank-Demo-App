using BankApp.Application.Command;
using BankApp.Domain.Entities;
using BankApp.Domain.Interfaces;

namespace BankApp.Application.Handlers
{
    public class OpenAccountHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public OpenAccountHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Account> Handle(OpenAccountCommand command)
        {
            // Create new account
            var account = new Account
            {
                CustomerId = command.CustomerId,
                Balance = command.InitialCredit
            };
            await _accountRepository.CreateAccountAsync(account);

            // Add initial transaction if InitialCredit is greater than 0
            if (command.InitialCredit > 0)
            {
                var transaction = new Transaction
                {
                    AccountId = account.Id,
                    Amount = command.InitialCredit
                };
                await _transactionRepository.CreateTransactionAsync(transaction);
            }

            return account;
        }
    }
}
