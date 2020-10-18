using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AteshgahApp.Core.Models
{
    public partial class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public int InvoiceNr { get; set; }

        public int OrderNr { get; set; }

        public int LoanId { get; set; }

        public virtual Loan Loan { get; set; }
    }
}
