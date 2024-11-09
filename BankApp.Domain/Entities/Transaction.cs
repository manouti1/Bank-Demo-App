using System.ComponentModel.DataAnnotations;

namespace BankApp.Domain.Entities;

public class Transaction
{
    [Key]
    public int Id { get; set; }
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
