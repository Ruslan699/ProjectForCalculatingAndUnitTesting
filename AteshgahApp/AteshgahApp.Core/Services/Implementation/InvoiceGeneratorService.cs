using System.Collections.Generic;
using AteshgahApp.Core.Models;

namespace AteshgahApp.Core.Services
{
    public class InvoiceGeneratorService : IInvoiceGeneratorService
    {
        public IEnumerable<Invoice> Generate(Loan loan)
        {
            List<Invoice> invoices = new List<Invoice>();

            for (int i = 0; i < loan.LoanPeriod; i++)
            {
                invoices.Add(new Invoice()
                {
                    DueDate = loan.PayoutDate.AddMonths(i + 1),
                    OrderNr = i + 1,
                    InvoiceNr = i + 1
                });
            }
            return invoices;
        }
    }
}
