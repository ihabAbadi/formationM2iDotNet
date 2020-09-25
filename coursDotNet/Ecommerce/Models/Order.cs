using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Order
    {
        private int id;

        private decimal total;

        private List<ProductOrder> products;

        private Euser user;

        public int Id { get => id; set => id = value; }
        public decimal Total { get => total; set => total = value; }
        public List<ProductOrder> Products { get => products; set => products = value; }
        public Euser User { get => user; set => user = value; }

        public Order()
        {
            Products = new List<ProductOrder>();
        }
    }
}
