using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillsPaymentSystem.Models
{
    public class User
    {
        public User()
        {
            this.PaymentMethods = new List<PaymentMethod>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        [MinLength(3), MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        [MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(80)]
        [RegularExpression(@"^[\w]+\@[\w]+\.[\w]+$")]
        public string Email { get; set; }

        [Required]
        [MinLength(5), MaxLength(25)]
        public string Password { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
