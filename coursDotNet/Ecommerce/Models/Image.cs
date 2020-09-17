using Ecommerce.Tools;
using System;
using System.Collections.Generic;
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

        public static List<Image> GetImagesByProduct(int productId)
        {
            List<Image> images = new List<Image>();
            string request = "SELECT Id, Url FROM Image where ProductId = @id";
            SqlCommand command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@id", productId));
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Image image = new Image()
                {
                    Id = reader.GetInt32(0),
                    Url = reader.GetString(1),
                    ProductId = productId
                };
                images.Add(image);
            }

            return images;
        }
    }
}
