using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10249843_PROG6212_ICE1
{
    public class ReportSummary
    {
        public IEnumerable<dynamic> GenerateSummary(List<Product> products)
        {
            return products.Select(p => new
            {
                p.Name,
                p.Category,
                p.StockQuantity
            });
        }
    }
}
