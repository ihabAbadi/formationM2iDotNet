using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Tools
{
    public class Connection
    {
        private static SqlConnection _instance;
        private static object _lock = new object();

        public static SqlConnection Instance
        {
            get
            {
                lock(_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
                        CreateTable();
                    }
                    return _instance;
                }
                
            }
        }
        private Connection()
        {

        }

        private static void CreateTable()
        {
            string request = "if not exists(SELECT * FROM sysobjects where name='Product' and xtype='U') " +
                "CREATE TABLE [Product] (" +
                "Id int PRIMARY KEY IDENTITY," +
                "Title varchar(50) NOT NULL," +
                "Price decimal NOT NULL," +
                "Description TEXT NOT NULL)";
            SqlCommand command = new SqlCommand(request, Instance);
            Instance.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            request = "if not exists(SELECT * FROM sysobjects where name='Image' and xtype='U') " +
                "CREATE TABLE [Image] (" +
                "Id int PRIMARY KEY IDENTITY," +
                "Url varchar(200) NOT NULL," +
                "ProductId INT NOT NULL)";
            command = new SqlCommand(request, Instance);
            command.ExecuteNonQuery();
            command.Dispose();
            Instance.Close();
        }

    }
}
