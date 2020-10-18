using System;
using System.ComponentModel.DataAnnotations;

namespace AteshgahApp.UI.Models
{
    public class EstimateViewModel
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string TelephoneNumber { get; set; }

        [Range(minimum: 3, maximum: 24)]
        public int LoanPeriod { get; set; }

        [Range(minimum: 100, maximum: 5000)]
        public decimal LoanAmount { get; set; }

        public int MonthlyRate { get; set; }

        public DateTime PayDate { get; set; }
    }
}