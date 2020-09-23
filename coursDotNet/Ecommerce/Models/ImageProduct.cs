using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class ImageProduct
    {
        private int id;

        private Image image;

        private Product product;

        public int Id { get => id; set => id = value; }
        public Product Product { get => product; set => product = value; }
        public Image Image { get => image; set => image = value; }
    }
}
