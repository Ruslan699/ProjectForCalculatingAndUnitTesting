using System;
using System.Collections.Generic;
using System.Linq;
using AteshgahApp.Core.Models;
using AteshgahApp.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AteshgahApp.Core.UnitTest
{
    [TestClass]
    public class InvoiceCreatorTest
    {
        [TestMethod]
        public void CalculateDefaultAmount()
        {
            InvoiceGeneratorService service = new InvoiceGeneratorService();
            var expectedResult = new List<Invoice>()
            {

                new Invoice() { OrderNr = 1, InvoiceNr = 1, DueDate = new DateTime(2020,10,18) },
                new Invoice() { OrderNr = 2, InvoiceNr = 2, DueDate = new DateTime(2020,11,18) },
                new Invoice() { OrderNr = 3, InvoiceNr = 3, DueDate = new DateTime(2020,12,18) }
            };


            var result = service.Generate(new Loan() { PayoutDate = new DateTime(2020, 09, 18), Amount = 1000, InterestRate = 5, LoanPeriod = 3 });

            CollectionAssert.AreEqual(expectedResult, result.ToList(), new InvoiceComparer());
        }
    }
}
