
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillsPaymentSystem.Models
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        [MinLength(3), MaxLength(50)]
        public string BankName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        [MinLength(3), MaxLength(20)]
        public string SWIFT { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }
    }
}
