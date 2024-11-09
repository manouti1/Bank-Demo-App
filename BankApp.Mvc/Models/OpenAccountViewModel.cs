using System.ComponentModel.DataAnnotations;

namespace BankApp.Mvc.Models
{
    public class OpenAccountViewModel
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Initial Credit is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Initial Credit must be a non-negative number.")]
        public decimal InitialCredit { get; set; }
    }

}
