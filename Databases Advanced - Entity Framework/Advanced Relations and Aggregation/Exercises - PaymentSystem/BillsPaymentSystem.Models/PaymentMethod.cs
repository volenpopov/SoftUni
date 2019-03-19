using BillsPaymentSystem.Models.Attributes;
using BillsPaymentSystem.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Xor(nameof(CreditCardId))]
        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
