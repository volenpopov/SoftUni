using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class User
    {
        public User()
        {
            this.Problems = new HashSet<Problem>();
            this.Submissions = new HashSet<Submission>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Problem> Problems { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}