namespace BankApp.Application.Dtos
{
    public class CustomerAccountDetailsDto
    {
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
