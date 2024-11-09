using BankApp.Application.Dtos;
using BankApp.Application.Query;
using BankApp.Domain.Interfaces;

namespace BankApp.Application.Handlers
{
    public class GetCustomerAccountDetailsHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public GetCustomerAccountDetailsHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<CustomerAccountDetailsDto> Handle(GetCustomerAccountDetailsQuery query)
        {
            var account = await _accountRepository.GetAccountByCustomerIdAsync(query.CustomerId);
            if (account == null) return null;

            var transactions = await _transactionRepository.GetTransactionsByAccountIdAsync(account.Id);

            return new CustomerAccountDetailsDto
            {
                CustomerId = account.CustomerId,
                Balance = account.Balance,
                Transactions = transactions.Select(t => new TransactionDto
                {
                    Amount = t.Amount,
                    Date = t.Date
                }).ToList()
            };
        }
    }

}
