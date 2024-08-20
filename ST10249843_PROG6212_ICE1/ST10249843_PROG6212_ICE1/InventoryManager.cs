using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10249843_PROG6212_ICE1
{
    public class InventoryManager
    {
        public void ProcessSale(dynamic product, int quantity)
        {
            if (product.StockQuantity >= quantity)
            {
                product -= quantity;
            }
            else
            {
                throw new InvalidOperationException("Insufficient stock to process the sale.");
            }
        }
    }

}
