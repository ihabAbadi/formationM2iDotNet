﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole
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
    }
}
