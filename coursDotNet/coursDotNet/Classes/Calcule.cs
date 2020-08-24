using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Calcule
    {
        public delegate double CalculeDelegate(double a, double b);
        public delegate void AutreCalculeDelegate(double a, double b);
        public Action<double, double> AllCalcule;
        //public double Addition(double a, double b)
        //{
        //    return a + b;
        //}

        public void Addition(double a, double b)
        {
            Console.WriteLine(a + b);
        }

        //public double Soustraction(double a, double b)
        //{
        //    return a - b;
        //}
        public void Soustraction(double a, double b)
        {
            Console.WriteLine(a - b);
        }

        //public void Calculer(double a, double b,CalculeDelegate Methode)
        //{
        //    Console.WriteLine(Methode(a, b));
        //}

        public void Calculer(double a, double b, Func<double, double, double> Methode)
        {
            Console.WriteLine(Methode(a, b));
        }

        //public void AutreCalculer(double a, double b,AutreCalculeDelegate Methode)
        //{
        //    Console.WriteLine("Voici le calcule ");
        //    Methode(a, b);
        //}
        public void AutreCalculer(double a, double b, Action<double, double> Methode)
        {
            Console.WriteLine("Voici le calcule ");
            Methode(a, b);
        }

        public void StartCalcule(double a, double b)
        {
            AllCalcule(a, b);
        }
    }
}
