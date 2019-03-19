using BillsPaymentSystem.Models.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillsPaymentSystem.Models
{
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Limit { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal MoneyOwed { get; set; }

        [NotMapped]
        public decimal LimitLeft => Limit - MoneyOwed;

        [Required]
        [ExpirationDate]
        public DateTime ExpirationDate { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }
    }
}
