using System.Collections.Generic;

namespace AteshgahApp.UI.Models
{
    public class LoanDetailsViewModel : LoanViewModel
    {
        public IEnumerable<InvoiceViewModel> Invoices { get; set; }
    }
}