using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Cart
    {
        private int id;
        private List<ProductCart> products;

        public int Id { get => id; set => id = value; }
        public List<ProductCart> Products { get => products; set => products = value; }
    }
}
