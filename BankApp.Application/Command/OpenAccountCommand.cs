namespace BankApp.Application.Command
{
    public class OpenAccountCommand
    {
        public int CustomerId { get; set; }
        public decimal InitialCredit { get; set; }
    }

}
