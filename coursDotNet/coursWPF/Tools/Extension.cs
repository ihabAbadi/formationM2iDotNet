using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursWPF
{
    public static class Extension
    {
        public static void Shuffle<T>(this T[] tab)
        {
            Random r = new Random();
            for(int i=0; i < tab.Length; i++)
            {
                int index = r.Next(tab.Length);
                T tmp = tab[index];
                tab[index] = tab[i];
                tab[i] = tmp;
            }
        }
    }
}
