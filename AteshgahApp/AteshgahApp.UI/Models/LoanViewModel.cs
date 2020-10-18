using System;

namespace AteshgahApp.UI.Models
{
    public class LoanViewModel
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int LoanPeriod { get; set; }

        public decimal InterestRate { get; set; }

        public DateTime PayoutDate { get; set; }

        public Guid ClientId { get; set; }

        public ClientViewModel Client { get; set; }
    }
}