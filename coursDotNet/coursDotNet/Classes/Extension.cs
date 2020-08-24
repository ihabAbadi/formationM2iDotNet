using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    static class Extension
    {
        public static int CountWord(this String chaine)
        {
            return chaine.Split(' ').Length;
        }

        public static void Shuffle<T>(this List<T> liste)
        {
            Random r = new Random();
            for(int i=0; i < liste.Count; i++)
            {
                int indexTmp = r.Next(liste.Count);
                T tmp = liste[indexTmp];
                liste[indexTmp] = liste[i];
                liste[i] = tmp;
            }
        }
    }
}
