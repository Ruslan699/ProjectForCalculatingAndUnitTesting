using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AteshgahApp.Core.Models
{
    public partial class Loan
    {
        public Loan()
        {
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public decimal InterestRate { get; set; }

        public int LoanPeriod { get; set; }

        public DateTime PayoutDate { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}