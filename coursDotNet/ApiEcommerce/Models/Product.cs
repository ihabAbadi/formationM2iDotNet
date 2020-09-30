using Ecommerce.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("product")]
    public class Product
    {

        private int id;
        private string title;
        private decimal price;
        private string description;
        private List<Image> images;

        [Key]
        [Column("MonId")]
        public int Id { get => id; set => id = value; }
        [MaxLength(255)]
        [Required]
        public string Title { get => title; set => title = value; }
        public decimal Price { get => price; set => price = value; }
        [Column(TypeName = "Text")]
        public string Description { get => description; set => description = value; }
        public List<Image> Images { get => images; set => images = value; }

        public Product()
        {
            Images = new List<Image>();
        }

        public static List<Product> GetProducts()
        {
            //List<Product> products = new List<Product>();
            //string request = "SELECT Id, Title, Price, Description " +
            //    "from Product ";
            //SqlCommand command = new SqlCommand(request, Connection.Instance);
            //Connection.Instance.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //while(reader.Read())
            //{
            //    Product p = new Product()
            //    {
            //        Id = reader.GetInt32(0),
            //        Title = reader.GetString(1),
            //        Price = reader.GetDecimal(2),
            //        Description = reader.GetString(3)
            //    };
            //    products.Add(p);
            //}
            //reader.Close();
            //command.Dispose();
            //Connection.Instance.Close();
            //return products
            return DataContext.Instance.Products.Include(p=>p.Images).ToList();
        }

        public static Product GetProductById(int id)
        {
            //Product product = null;
            //string request = "SELECT Id, Title, Price, Description " +
            //    "from Product where Id=@id";
            //SqlCommand command = new SqlCommand(request, Connection.Instance);
            //command.Parameters.Add(new SqlParameter("@id", id));
            //Connection.Instance.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    product = new Product()
            //    {
            //        Id = reader.GetInt32(0),
            //        Title = reader.GetString(1),
            //        Price = reader.GetDecimal(2),
            //        Description = reader.GetString(3)
            //    };

            //}
            //reader.Close();
            //command.Dispose();
            //Connection.Instance.Close();
            //return product;
            //return db.Products.FirstOrDefault((p) => p.Id == id);
            return DataContext.Instance.Products.Include(p=>p.Images).FirstOrDefault((p) => p.Id == id);
        }

        public bool Add()
        {
            //string request = "INSERT INTO Product(Title, Price, Description) OUTPUT INSERTED.ID values(@title, @price, @description)";
            //SqlCommand command = new SqlCommand(request, Connection.Instance);
            //command.Parameters.Add(new SqlParameter("@title", Title));
            //command.Parameters.Add(new SqlParameter("@price", Price));
            //command.Parameters.Add(new SqlParameter("@description", Description));
            //Connection.Instance.Open();
            //Id = (int)command.ExecuteScalar();
            //command.Dispose();
            //Connection.Instance.Close()
            DataContext.Instance.Products.Add(this);
            DataContext.Instance.SaveChanges();
            return Id > 0;

        }
    }
}
