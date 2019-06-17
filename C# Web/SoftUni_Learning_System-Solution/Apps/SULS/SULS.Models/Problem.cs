using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class Problem
    {
        public Problem()
        {
            this.Submissions = new HashSet<Submission>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Range(50, 300)]
        public int Points { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}
