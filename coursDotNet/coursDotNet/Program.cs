using coursDotNet.Classes;
using System;
using System.Collections.Generic;
using System.Text.Json;


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
            //Remplir un tableau avec des éléments des l'initialisation
            //int[] tab = new int[] {1,2,3,5,9};
            //Exercice 2
            //Console.Write("Merci de saisir le nombre d'élément dans le tableau : ");
            //int nombre = Convert.ToInt32(Console.ReadLine());
            //string[] chaines = new string[nombre];
            //string choix;
            //do
            //{
            //    Console.WriteLine("1---- Remplir le tableau : ");
            //    Console.WriteLine("2---- Faire une recherche : ");
            //    choix = Console.ReadLine();
            //    switch(choix)
            //    {
            //        case "1":
            //            for(int i=1; i <= chaines.Length; i++ )
            //            {
            //                Console.Write("Merci de saisir l'élément n° : "+i+" ");
            //                chaines[i - 1] = Console.ReadLine();
            //            }
            //            break;
            //        case "2":
            //            Console.Write("L'élément à rechercher : ");
            //            string recherche = Console.ReadLine();
            //            int nombreOcc = 0;                        
            //            for(int i=0; i < chaines.Length; i++)
            //            {
            //                if(chaines[i] == recherche)
            //                {
            //                    Console.WriteLine("Trouvé à la position : " + (i + 1));
            //                    nombreOcc++;
            //                }
            //            }
            //            if(nombreOcc != 0)
            //            {
            //                Console.WriteLine("Élément touvé : " + nombreOcc + " fois");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Élément non trouvé");
            //            }
            //            break;
            //    }
            //} while (choix != "0");
            //Exercice 3
            //Console.Write("Merci de saisir une chaine : ");
            //string chaine = Console.ReadLine();
            //string chaineTmp = "";
            //char tmp = chaine[0];
            //for (int i = 1; i < chaine.Length; i++)
            //{
            //    chaineTmp += chaine[i];
            //}
            //chaineTmp += tmp;
            //chaine = chaineTmp;
            //Console.WriteLine(chaine);
            //Exercice 4
            //int[] tab2018 = new int[12];
            //int[] tab2019 = new int[12];
            //string choix;
            //int annee;
            //int mois;
            //int inflationMois;
            //int nombreMoisInf = 0;
            //int inflation2018 = 0;
            //int inflation2019 = 0;
            //do
            //{
            //    Console.WriteLine("1---- Saisir les inflations : ");
            //    Console.WriteLine("2---- Afficher les inflations : ");
            //    Console.WriteLine("3---- Calculer l'inflation à l'année : ");
            //    Console.WriteLine("4---- Afficher les inflations inférieures à un mois : ");
            //    Console.WriteLine("5---- Afficher les inflations inférieures pour chaque mois : ");
            //    Console.WriteLine("0---- Quitter");
            //    choix = Console.ReadLine();
            //    switch (choix)
            //    {
            //        case "1":
            //            Console.WriteLine("Pour quelle année voulez vous saisir les inflations ? ");
            //            annee = Convert.ToInt32(Console.ReadLine());
            //            if (annee == 2018)
            //            {
            //                Console.WriteLine("Pour l'année 2018 : ");
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    Console.WriteLine("Tapez le chiffre d'inflation du mois numéro " + (i + 1) + " : ");
            //                    tab2018[i] = Convert.ToInt32(Console.ReadLine());
            //                }
            //            }
            //            else if (annee == 2019)
            //            {
            //                Console.WriteLine("Pour l'année 2019 : ");
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    Console.WriteLine("Tapez le chiffre d'inflation du mois numéro " + (i + 1) + " : ");
            //                    tab2019[i] = Convert.ToInt32(Console.ReadLine());
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Impossible de saisir les inflations pour cette année là...");
            //            }
            //            break;
            //        case "2":
            //            Console.WriteLine("Pour quelle année voulez vous afficher les inflations ? ");
            //            annee = Convert.ToInt32(Console.ReadLine());
            //            if (annee == 2018)
            //            {
            //                Console.WriteLine("Pour l'année 2018 : ");
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    Console.WriteLine("L'inflation du mois numéro " + (i + 1) + " est de " + tab2018[i]);
            //                }
            //            }
            //            else if (annee == 2019)
            //            {
            //                Console.WriteLine("Pour l'année 2019 : ");
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    Console.WriteLine("L'inflation du mois numéro " + (i + 1) + " est de " + tab2019[i]);
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Impossible d'afficher les inflations pour cette année là...");
            //            }
            //            break;
            //        case "3":
            //            Console.WriteLine("Pour quelle année voulez vous calculer l'inflation ? ");
            //            annee = Convert.ToInt32(Console.ReadLine());
            //            if (annee == 2018)
            //            {
            //                inflation2018 = 0;
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    inflation2018 += tab2018[i];
            //                }
            //                Console.WriteLine("L'inflation pour l'année 2018 est de : " + inflation2018);
            //            }
            //            else if (annee == 2019)
            //            {
            //                inflation2019 = 0;
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    inflation2019 += tab2019[i];
            //                }
            //                Console.WriteLine("L'inflation pour l'année 2018 est de : " + inflation2019);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Impossible d'afficher l'inflations pour cette année là...");
            //            }
            //            break;
            //        case "4":
            //            Console.WriteLine("Dans quelle année recherchez vous ? ");
            //            annee = Convert.ToInt32(Console.ReadLine());
            //            Console.WriteLine("Pour quel mois recherchez vous ? ");
            //            mois = Convert.ToInt32(Console.ReadLine());
            //            nombreMoisInf = 0;
            //            if (annee == 2018)
            //            {
            //                inflationMois = tab2018[(mois - 1)];
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    if (tab2018[i] < inflationMois)
            //                    {
            //                        nombreMoisInf++;
            //                    }
            //                }
            //                Console.WriteLine("Le nombre de mois dont l'inflation est plus petite est de : " + nombreMoisInf);
            //            }
            //            else if (annee == 2019)
            //            {
            //                inflationMois = tab2019[(mois - 1)];
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    if (tab2019[i] < inflationMois)
            //                    {
            //                        nombreMoisInf++;
            //                    }
            //                }
            //                Console.WriteLine("Le nombre de mois dont l'inflation est plus petite est de : " + nombreMoisInf);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Impossible d'afficher pour cette année là...");
            //            }
            //            break;
            //        case "5":
            //            Console.WriteLine("Dans quelle année recherchez vous ? ");
            //            annee = Convert.ToInt32(Console.ReadLine());
            //            nombreMoisInf = 0;
            //            if (annee == 2018)
            //            {
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    for (int j = 0; j < 12; j++)
            //                    {
            //                        if (tab2018[i] < tab2018[j])
            //                        {
            //                            nombreMoisInf++;
            //                        }
            //                    }
            //                    Console.WriteLine("Pour le mois numéro " + (i + 1) + " le nombre de mois donc l'inflation est inférieur est de : " + nombreMoisInf);
            //                    nombreMoisInf = 0;
            //                }
            //            }
            //            else if (annee == 2019)
            //            {
            //                for (int i = 0; i < 12; i++)
            //                {
            //                    for (int j = 0; j < 12; j++)
            //                    {
            //                        if (tab2019[i] < tab2019[j])
            //                        {
            //                            nombreMoisInf++;
            //                        }
            //                    }
            //                    Console.WriteLine("Pour le mois numéro " + (i + 1) + " le nombre de mois donc l'inflation est inférieur est de : " + nombreMoisInf);
            //                    nombreMoisInf = 0;
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Impossible d'afficher pour cette année là...");
            //            }
            //            break;
            //        default:
            //            Console.WriteLine("Erreur de saisie, veuillez recommencer...");
            //            break;
            //    }
            //} while (choix != "0");
            //generer un aléatoire
            //Random r = new Random();
            //for (int i = 1; i <= 10; i++)
            //{
            //    int aleatoire = r.Next(100);
            //    Console.WriteLine(aleatoire);
            //}

            #endregion
            #region POO en c#
            Voiture v1 = new Voiture();
            v1.Immatriculation = "AA-000-AA";
            v1.NombreKm = 10;
            v1.Model = "FORD";
            //Console.WriteLine(v1.immatriculation);
            //Console.WriteLine(v1.nombreKm);
            //Console.WriteLine(v1.model);
            v1.Afficher();
            Voiture v2 = new Voiture();
            v2.Immatriculation = "AF-0001-AF";
            v2.NombreKm = 100;
            v2.Model = "OPEL";
            //Console.WriteLine(v2.immatriculation);
            //Console.WriteLine(v2.nombreKm);
            //Console.WriteLine(v2.model);
            v2.Afficher();

            v1.Rouler(100);
            //v1.Afficher();
            v2.Rouler(300);
            //v2.Afficher();
            Console.WriteLine(v1.Information());
            Voiture v3 = new Voiture("mercedes", "AE6000AR", 1000);
            v3.Afficher();
            #endregion
        }
    }

    
}
