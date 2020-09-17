using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class ProductCart
    {
        private int id;
        private Product product;
        private int qty;
        public Product Product { get => product; set => product = value; }
        public int Id { get => id; set => id = value; }
        public int Qty { get => qty; set => qty = value; }
    }
}
