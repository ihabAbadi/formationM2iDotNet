using Ecommerce.Interface;
using Ecommerce.Tools;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class TranslateService : ITranslate
    {
        private IHttpContextAccessor _accessor;

        public TranslateService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public void ChangeLang(string lang)
        {
            if(lang != null)
            {
                _accessor.HttpContext.Session.SetString("lang", lang);
            }
        }

        public List<string> GetLang()
        {
            List<string> liste = new List<string>();
            string request = "SELECT Langue from Translate group by Langue";
            SqlCommand command = new SqlCommand(request, Connection.Instance);
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                liste.Add(reader.GetString(0));
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return liste;
        }

        public string Translate(string word)
        {
            string lang = _accessor.HttpContext.Session.GetString("lang");
            lang = (lang == null) ? "fr" : lang;
            string translation = word;
            string request = "SELECT Value FROM Translate where Mot=@mot and Langue=@langue";
            SqlCommand command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@mot", word));
            command.Parameters.Add(new SqlParameter("@langue", lang));
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                translation = reader.GetString(0);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return translation;
        }
    }
}
