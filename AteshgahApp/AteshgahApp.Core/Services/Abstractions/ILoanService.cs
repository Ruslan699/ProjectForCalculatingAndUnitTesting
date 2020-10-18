using AteshgahApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AteshgahApp.Core.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoansDetailAsync(int loanId);
    }
}
