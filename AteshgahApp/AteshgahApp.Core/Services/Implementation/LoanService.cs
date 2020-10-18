using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AteshgahApp.Core.DataContext;
using AteshgahApp.Core.Models;

namespace AteshgahApp.Core.Services
{
    public class LoanService : ILoanService
    {
        private readonly MainDataContext _mainDataContext;
        public LoanService(MainDataContext mainDataContext)
        {
            _mainDataContext = mainDataContext;
        }
        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _mainDataContext.Loans.OrderByDescending(x => x.Amount).ToListAsync();
        }

        public async Task<Loan> GetLoansDetailAsync(int loanId)
        {
            return await _mainDataContext.Loans.FindAsync(loanId);
        }
    }
}
