using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10249843_PROG6212_ICE1
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public static Product operator +(Product product, int quantity)
        {
            product.StockQuantity += quantity;
            return product;
        }

        public static Product operator -(Product product, int quantity)
        {
            product.StockQuantity -= quantity;
            return product;
        }
    }

}
