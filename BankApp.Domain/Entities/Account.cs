using System.ComponentModel.DataAnnotations;

namespace BankApp.Domain.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
