using Ecommerce.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Image
    {
        private int id;

        private string url;

        private int productId;

        public int Id { get => id; set => id = value; }
        public string Url { get => url; set => url = value; }
        public int ProductId { get => productId; set => productId = value; }
        
        public List<ImageProduct> Products { get; set; }
        //[ForeignKey("ProductId")]
        //public Product Product { get; set; }
        
    }
}
