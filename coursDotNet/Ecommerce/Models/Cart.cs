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
        public decimal Total
        {
            get
            {
                decimal total = 0;
                Products.ForEach(p =>
                {
                    total += p.Product.Price * p.Qty;
                });
                return total;
            }
        }
        public Cart()
        {
            Products = new List<ProductCart>();
        }
        public void AddProduct(Product product, int qty)
        {
            bool found = false;
            Products.ForEach((p) =>
            {
                if (p.Product.Id == product.Id)
                {
                    p.Qty += qty;
                    found = true;
                }
            });
            if (!found)
            {
                ProductCart productCart = new ProductCart() { Product = product, Qty = qty };
                Products.Add(productCart);
            }
        }
    }
}
