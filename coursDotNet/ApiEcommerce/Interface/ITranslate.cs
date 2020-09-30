using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Interface
{
    public interface ITranslate
    {
        string Translate(string word);

        void ChangeLang(string lang);
        List<string> GetLang();
    }
}
