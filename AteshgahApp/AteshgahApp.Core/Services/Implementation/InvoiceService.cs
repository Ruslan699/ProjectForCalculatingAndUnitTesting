using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AteshgahApp.Core.DataContext;
using AteshgahApp.Core.Models;
using NLog;

namespace AteshgahApp.Core.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly MainDataContext _dataContext;
        private readonly ILogger _logger;

        public InvoiceService(MainDataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = LogManager.GetCurrentClassLogger();
        }
        public async Task AddInvoiceAsync(Loan loan, IEnumerable<Invoice> invoices)
        {
            var transaction = _dataContext.Database.BeginTransaction();
            try
            {
                _dataContext.Loans.Add(loan);
                await _dataContext.SaveChangesAsync();

                foreach (var item in invoices)
                {
                    item.LoanId = loan.Id;
                    _dataContext.Invoices.Add(item);
                }
                await _dataContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch (System.Exception)
            {
                transaction.Rollback();
                _logger.Error("InvoiceService.AddInvoice.Exception");
                throw;
            }
            finally
            {
            }
        }

        public async Task<IEnumerable<Invoice>> EstimateInvoicesAsync(Loan loan)
        {
            var result = Generate(loan);
            foreach (var item in result)
            {
                var loanAmount = new SqlParameter("@LoanAmount", loan.Amount);
                var loanRate = new SqlParameter("@InterestRate", loan.InterestRate);
                var invoiceOrderNum = new SqlParameter("@InvoiceOrderN", item.OrderNr);
                var loanPeriod = new SqlParameter("@LoanPeriod", loan.LoanPeriod);
                var procedurResult = _dataContext.Database.SqlQuery<decimal>("dbo.ESTIMATE_LOAN_AMOUNT @LoanAmount, @InterestRate, @LoanPeriod, @InvoiceOrderN",
                    loanAmount, loanRate, loanPeriod, invoiceOrderNum);
                item.Amount = await procedurResult.FirstOrDefaultAsync();
            }
            return result;
        }


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
