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
            /*int a = 35;
            int b = 11;
            double res = (double)a / b;
            a += 34;
            //Incrémentation  et décrémentation
            //int t = a++;
            int t = ++a;
            Console.WriteLine(t);
            Console.WriteLine(a);*/
            //Structure conditionnelle
            //if else
            //int age = 32;
            //Opérateur de comparaison
            // == -> égalité, != -> diff, >=, <=, >, <
            /*if(age >= 18)
            {
                Console.WriteLine("Majeur");
            }
            else
            {
                Console.WriteLine("Mineur");
            }*/
            //opérateur logique
            // && => ET, || => OU, ! => Négation
            //ternaire
            /*string message;
            if (age >= 18)
            {
                message = "majeur";
            }
            else
            {
                message = "mineur";
            }*/
            //string message = (age >= 18) ? "majeur" : "mineur";
            //Instruction lecture, Ecriture dans une console.
            //Console.WriteLine("test");
            //Console.Write("Votre nom : ");
            //string nom = Console.ReadLine();
            //Console.Write("Votre age : ");
            //int age = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(age);
            //Ex 1
            Console.WriteLine("Saisir AB");
            double ab = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Saisir BC");
            double bc = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Saisir AC");
            double ac = Convert.ToDouble(Console.ReadLine());
            if (ac == ab)
            {
                if (ac == bc)
                {
                    Console.WriteLine("Triangle équilatéral");
                }
                else
                {
                    Console.WriteLine("Triange isocéle en A");
                }
            }
            else
            {
                if (ab == bc)
                {
                    Console.WriteLine("Triangle isocéle en B");
                }
                else if (ac == bc)
                {
                    Console.WriteLine("Triangel isocéle en C");
                }
                else
                {
                    Console.WriteLine("Ni isocéle ni équilatéral");
                }
            }
        }
    }
}
