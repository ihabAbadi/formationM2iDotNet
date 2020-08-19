using GestionCompteBancaire.Classes;
using System;

namespace GestionCompteBancaire
{
    class Program
    {
        static void Main(string[] args)
        {
            IHM ihm = new IHM();
            ihm.Start();
        }
    }
}
