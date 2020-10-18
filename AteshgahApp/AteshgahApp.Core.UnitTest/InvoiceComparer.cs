using AteshgahApp.Core.Models;
using System.Collections;

namespace AteshgahApp.Core.UnitTest
{
    public class InvoiceComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var first = (Invoice)(x);
            var second = (Invoice)(y);

            if (first.OrderNr == second.OrderNr 
                                            && first.InvoiceNr == second.InvoiceNr 
                                               && first.DueDate == second.DueDate)
                return 0;
            else
                return 1;
        }
    }
}
