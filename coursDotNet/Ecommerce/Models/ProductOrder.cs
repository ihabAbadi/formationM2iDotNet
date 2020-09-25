using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class ProductOrder
    {
        private int id;

        private int qty;

        private Product product;

        public int Id { get => id; set => id = value; }
        public int Qty { get => qty; set => qty = value; }
        public Product Product { get => product; set => product = value; }
    }
}
