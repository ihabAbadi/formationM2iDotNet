using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EcoreAspNET
{
    static class Extension
    {
        public static ObservableCollection<T> CastToObservable<T>(this List<T> liste)
        {
            ObservableCollection<T> retour = new ObservableCollection<T>();
            foreach(T element in liste)
            {
                retour.Add(element);
            }
            return retour;
        }
        //Methode d'extension pour avoir la possibilité d'utiliser un ternaire dans razor
        public static HtmlString Ternaire(this HtmlHelper helper, object Obj, object ConditionOk, object ConditionNotOk)
        {
            if(Obj != null)
            {
                return new HtmlString(ConditionOk.ToString());
            }
            else
            {
                return new HtmlString(ConditionNotOk.ToString());
            }
        }
    }
}
