using System;

namespace coursDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            #region cours c# base
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
            #endregion
            #region correction exercice base c#
            //Ex 1
            //Console.WriteLine("Saisir AB");
            //double ab = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Saisir BC");
            //double bc = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Saisir AC");
            //double ac = Convert.ToDouble(Console.ReadLine());
            //if (ac == ab)
            //{
            //    if (ac == bc)
            //    {
            //        Console.WriteLine("Triangle équilatéral");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Triange isocéle en A");
            //    }
            //}
            //else
            //{
            //    if (ab == bc)
            //    {
            //        Console.WriteLine("Triangle isocéle en B");
            //    }
            //    else if (ac == bc)
            //    {
            //        Console.WriteLine("Triangel isocéle en C");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Ni isocéle ni équilatéral");
            //    }
            //}
            //Ex 2
            /*Console.WriteLine("veuillez saisir votre taille");
            int taille = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Veuillez saisir votre poids");
            int poids = Convert.ToInt32(Console.ReadLine());
            if ((poids >= 43) && (poids <= 47) && (taille >= 145) && (taille <= 169) ||
                 (poids >= 48) && (poids <= 53) && (taille >= 145) && (taille <= 166) ||
                (poids >= 54) && (poids <= 59) && (taille >= 145) && (taille <= 163) ||
                 (poids >= 60) && (poids <= 65) && (taille >= 145) && (taille <= 160))
            {
                Console.WriteLine("Taille: 01");
            }


            else if (poids >= 48 && poids <= 53 && taille >= 169 && taille <= 178 ||
                poids >= 54 && poids <= 59 && taille >= 166 && taille <= 175 ||
                poids >= 60 && poids <= 65 && taille >= 163 && taille <= 172 ||
                poids >= 66 && poids <= 71 && taille >= 160 && taille <= 169)
            {
                Console.WriteLine("Taille: 02");
            }


            else if (poids >= 54 && poids <= 59 && taille >= 178 && taille <= 183 ||
                 poids >= 60 && poids <= 65 && taille >= 175 && taille <= 183 ||
                 poids >= 66 && poids <= 71 && taille >= 172 && taille <= 183 ||
                 poids >= 72 && poids <= 77 && taille >= 163 && taille <= 183)
            {
                Console.WriteLine("Taille: 03");
            }*/
            #endregion
            #region suite cours c# base
            //Switch
            /*int mois = 1;*/
            //switch(mois)
            //{
            //    case 1:
            //        Console.WriteLine("Janvier");
            //        break;
            //    case 2:
            //        Console.WriteLine("Février");
            //        break;
            //    case 3:
            //        Console.WriteLine("Mars");
            //        break;
            //    //....
            //    default:
            //        Console.WriteLine("Erreur mois");
            //        break;
            //}
            /*switch(mois)
            {
                case int n when (n >= 1 && n <= 3):
                    Console.WriteLine("L'hiver");
                    break;
                case int n when (n >= 4 && n <= 6):
                    Console.WriteLine("printemps");
                    break;
                case int n when (n >= 7 && n <= 9):
                    Console.WriteLine("été");
                    break;
                case int n when (n >= 10 && n <= 12):
                    Console.WriteLine("automne");
                    break;
                default:
                    Console.WriteLine("Erreur mois");
                    break;
            }*/
            //Boucle
            //boucle for
            //Console.WriteLine("-----INCREMENTATION------");
            //for(int i=1; i <= 10; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("-----DECREMENTATION------");
            //for(int i=10; i >= 1; i = i - 2)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("-----INCREMENTATION CHAR-------");
            //for(char c='A'; c <= 'z'; c++)
            //{
            //    Console.WriteLine(c);
            //}
            //Boucle While
            //int a = 1;
            //while(a <= 10)
            //{
            //    Console.WriteLine(a);
            //    a++;
            //}
            //int k = 10;
            //while(k > 0)
            //{
            //    Console.WriteLine(k);
            //    k--; 
            //}
            //int a = 10;
            //do
            //{
            //    Console.WriteLine(a);
            //    a++;
            //} while (a < 10);
            //Exercice 3
            /* Console.WriteLine("Merci de saisir le capital annuel : ");
             decimal c = Convert.ToDecimal(Console.ReadLine());
             Console.WriteLine("Merci de saisir le taux : ");
             decimal t = Convert.ToDecimal(Console.ReadLine());
             Console.WriteLine("Merci de saisir le nombre d'années : ");
             int n = Convert.ToInt32(Console.ReadLine());


             decimal resultat = c;


             if (n > 1)
             {
                 for (int i = 1; i <= n; i++)
                 {
                     resultat += resultat * t;
                 }
             }
             else
             {
                 Console.WriteLine("Le nombre d'années doit être superieur à 1.");
             }
             Console.WriteLine("Le montant de capital pendant " + n + " années est " + resultat + ".");


             int yearsDouble = 0;
             decimal capitalDouble = c;


             do
             {
                 capitalDouble += capitalDouble * t;
                 yearsDouble++;
             }
             while (capitalDouble < c * 2);


             Console.WriteLine("Le capital sera doublé dans " + yearsDouble + " ans.");*/
            //Tableau en c#
            //déclaration de tableau
            //int[] tab = new int[10];
            //parcourir un tableau
            //for (int i = 0; i <= tab.Length - 1; i++)
            //{
            //    tab[i] = i + 1 ;
            //}
            //for (int i = 0; i <= tab.Length-1; i++)
            //{
            //    Console.WriteLine(tab[i]);
            //}
            //Exercice tableau
            //Console.Write("Le nombre d'élèves : ");
            //int nombre = Convert.ToInt32(Console.ReadLine());
            //double[] notes = new double[nombre];
            //string choix;
            //do
            //{
            //    Console.WriteLine("1---Saisir les notes : ");
            //    Console.WriteLine("2---La moyenne des notes : ");
            //    Console.WriteLine("3---le min et max: ");
            //    Console.WriteLine("4---Afficher les notes: ");
            //    choix = Console.ReadLine();
            //    switch(choix)
            //    {
            //        case "1":
            //            for(int i=0; i < notes.Length; i++)
            //            {
            //                Console.Write("Merci de saisir la note N° " + (i + 1) + " : ");
            //                notes[i] = Convert.ToDouble(Console.ReadLine());
            //            }
            //            break;
            //        case "2":
            //            double somme = 0;
            //            for (int i = 0; i < notes.Length; i++)
            //            {
            //                somme += notes[i];
            //            }
            //            double moyenne = somme / notes.Length;
            //            Console.WriteLine("La moyenne est de : " + moyenne);
            //            break;
            //        case "3":
            //            double min = notes[0];
            //            double max = notes[0];
            //            for (int i = 1; i < notes.Length; i++)
            //            {
            //                if(notes[i] < min)
            //                {
            //                    min = notes[i];
            //                } else if(notes[i] > max)
            //                {
            //                    max = notes[i];
            //                }
            //            }
            //            Console.WriteLine("Le min est de " + min + " et le max est de " + max);
            //            break;
            //        case "4":
            //            for (int i = 0; i < notes.Length; i++)
            //            {
            //                Console.WriteLine("la note N° " + (i + 1) + " : " + notes[i]); 
            //            }
            //            break;
            //    }
            //} while (choix != "0");
            //Exercice 2
            Console.Write("Merci de saisir le nombre d'élément dans le tableau : ");
            int nombre = Convert.ToInt32(Console.ReadLine());
            string[] chaines = new string[nombre];
            string choix;
            do
            {
                Console.WriteLine("1---- Remplir le tableau : ");
                Console.WriteLine("2---- Faire une recherche : ");
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        for(int i=1; i <= chaines.Length; i++ )
                        {
                            Console.Write("Merci de saisir l'élément n° : "+i+" ");
                            chaines[i - 1] = Console.ReadLine();
                        }
                        break;
                    case "2":
                        Console.Write("L'élément à rechercher : ");
                        string recherche = Console.ReadLine();
                        int nombreOcc = 0;
                        for(int i=0; i < chaines.Length; i++)
                        {
                            if(chaines[i] == recherche)
                            {
                                Console.WriteLine("Trouvé à la position : " + (i + 1));
                                nombreOcc++;
                            }
                        }
                        if(nombreOcc != 0)
                        {
                            Console.WriteLine("Élément touvé : " + nombreOcc + " fois");
                        }
                        else
                        {
                            Console.WriteLine("Élément non trouvé");
                        }
                        break;
                }
            } while (choix != "0");
            #endregion
        }
    }
}
