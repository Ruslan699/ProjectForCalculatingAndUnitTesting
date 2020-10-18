using AteshgahApp.Core.Models;
using System.Collections.Generic;

namespace AteshgahApp.Core.Services
{
    public interface IInvoiceGeneratorService
    {
        IEnumerable<Invoice> Generate(Loan loan);
    }
}
