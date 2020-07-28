using System;

namespace coursDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Déclaration de variable
            //Les types de variable primitive
            //Les nombres
            //Entier simple
            //int a;
            //a = 35;
            ////Autre type nombre => short, long, byte 
            ////Float  et double
            //float f = 10.4F;
            //double d = 10.4;
            ////decimal
            //decimal de = 10.4M;         
            ////Boolean
            //bool test = true;
            ////char un seul caractère
            //char c = 'A';
            ////FIN Variable primitive
            ////Variable de type string
            //string nom = "abadi";
            //Console.WriteLine(nom);
            //rendre variable nullable
            //int? a = null;
            //int c = 10;
            //Console.WriteLine(a);
            //Operation sur les variables 
            int a = 35;
            int b = 11;
            double res = (double)a / b;
            a += 34;
            //Incrémentation  et décrémentation
            //int t = a++;
            int t = ++a;
            Console.WriteLine(t);
            Console.WriteLine(a);
        }
    }
}
