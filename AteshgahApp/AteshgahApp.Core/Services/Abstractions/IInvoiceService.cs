using AteshgahApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AteshgahApp.Core.Services
{
   public interface IInvoiceService
    {
        Task AddInvoiceAsync(Loan loan, IEnumerable<Invoice> invoices);
        Task<IEnumerable<Invoice>> EstimateInvoicesAsync(Loan loan);
    }
}
