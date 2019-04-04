﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class User
    {      
        public User()
        {
            this.Cards = new HashSet<Card>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]+?\s[A-Z][a-z]+?$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
