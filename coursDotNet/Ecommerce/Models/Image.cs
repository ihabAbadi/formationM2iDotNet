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
                    
                    ProductId = productId
                };
                image.Url = (reader.GetString(1).Contains("http")) ? reader.GetString(1) : @"http://localhost:54485/"+ reader.GetString(1);
                images.Add(image);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return images;
        }

        public bool Add()
        {
            string request = "INSERT INTO Image (Url, ProductId) OUTPUT INSERTED.ID values(@url,@productId)";
            SqlCommand command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@url", Url));
            command.Parameters.Add(new SqlParameter("@productId", ProductId));
            Connection.Instance.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
            return Id > 0;
        }
    }
}
