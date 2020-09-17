using Ecommerce.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Product
    {
        private int id;
        private string title;
        private decimal price;
        private string description;
        private List<Image> images;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public decimal Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public List<Image> Images { get => images; set => images = value; }

        public Product()
        {
            Images = new List<Image>();
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string request = "SELECT Id, Title, Price, Description " +
                "from Product ";
            SqlCommand command = new SqlCommand(request, Connection.Instance);
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    Description = reader.GetString(3)
                };
                products.Add(p);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return products;
        }

        public static Product GetProductById(int id)
        {
            Product product = null;
            string request = "SELECT Id, Title, Price, Description " +
                "from Product where Id=@id";
            SqlCommand command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@id", id));
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                product = new Product()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    Description = reader.GetString(3)
                };
               
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return product;
        }
    }
}
