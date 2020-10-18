using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AteshgahApp.UI.Models
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int OrderNr { get; set; }

        public int InvoiceNr { get; set; }

        public DateTime DueDate { get; set; }

    }
}