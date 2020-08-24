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
    }
}
