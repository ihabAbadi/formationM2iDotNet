using Ecommerce.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class LogService : ILog
    {
        public void Logging(string error)
        {
            string log = "";
            if(File.Exists("log.txt"))
            {
                StreamReader reader = new StreamReader("log.txt");
                log = reader.ReadToEnd();
                reader.Close();
            }
            StreamWriter writer = new StreamWriter("log.txt");
            writer.WriteLine(log);
            writer.WriteLine(error);
            writer.Close();
        }
    }
}
