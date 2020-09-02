using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CompteBancaireWPF.Classes
{
    public class Connection
    {
        private static SqlConnection instance = null;
        public static SqlConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
                }
                return instance;
            }
        }
        private Connection()
        {

        }
    }
}
