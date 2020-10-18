using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AteshgahApp.Core.Models
{
    public partial class Client
    {
        public Client()
        {
            Loans = new HashSet<Loan>();
        }

        [Key]
        public Guid ClientUniqueId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(25)]
        public string TelephoneNr { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
