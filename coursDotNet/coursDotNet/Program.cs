using coursDotNet.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            //Voiture v1 = new Voiture();
            //v1.Immatriculation = "AA-000-AA";
            //v1.NombreKm = 10;
            //v1.Model = "FORD";
            ////Console.WriteLine(v1.immatriculation);
            ////Console.WriteLine(v1.nombreKm);
            ////Console.WriteLine(v1.model);
            //v1.Afficher();
            //Voiture v2 = new Voiture();
            //v2.Immatriculation = "AF-0001-AF";
            //v2.NombreKm = 100;
            //v2.Model = "OPEL";
            ////Console.WriteLine(v2.immatriculation);
            ////Console.WriteLine(v2.nombreKm);
            ////Console.WriteLine(v2.model);
            //v2.Afficher();

            //v1.Rouler(100);
            ////v1.Afficher();
            //v2.Rouler(300);
            ////v2.Afficher();
            //Console.WriteLine(v1.Information());
            //Voiture v3 = new Voiture("mercedes", "AE6000AR", 1000);
            //v3.Afficher();
            //Console.WriteLine(Voiture.nombreVoitures);
            //Correction ex1
            //ClsSalarie s1 = new ClsSalarie("m1", "c1", "s1", "toto", 10000);
            //ClsSalarie s2 = new ClsSalarie("m1", "c1", "s1", "tata", 5000);
            //s1.CalculerSalaire();
            //s2.CalculerSalaire();
            //Console.WriteLine(ClsSalarie.NombreSalarie);

            //Album a = new Album(10, "t", "t");
            //Titre t1 = new Titre("t1", 120);
            //a.AjouterTitre(t1);
            //IHM gestionAlbum = new IHM();
            //gestionAlbum.Start();
            //héritage
            //Etudiant e = new Etudiant();
            //e.Nom = "ne1";
            //e.Prenom = "pe1";
            //Personne e2 = new Etudiant("toto", "tata", 10);
            //Personne e3 = new Etudiant("titi", "minet", 15);
            //Personne p1 = new Prof("nom p1", "prenom p1", "math");
            //Personne p2 = new Prof("nom p2", "prenom p2", "info");
            //Personne[] tabPersonnes = new Personne[4];
            //tabPersonnes[0] = e2;
            //tabPersonnes[1] = e3;
            //tabPersonnes[2] = p1;
            //tabPersonnes[3] = p2;
            //foreach(Personne p in tabPersonnes)
            //{
            //    Console.WriteLine("------------------------");
            //    //Comme la méthode Afficher est surchargée en utilisant override, les objets utilseront la version définit dans leur propre classe
            //    p.Afficher();
            //    //Comme la méthode AfficherWithNew est surchagée en utilsant new, les objets utiliseront la version définit dans la classe mère
            //    p.AfficherWithNew();
            //    Console.WriteLine("------------------------");
            //}
            //Personne person = new Personne();
            //Console.WriteLine(e2);
            //Maison m = new Maison(3, "Lille");
            //Console.WriteLine(m);
            //Exercice commerciale héritage
            //Commerciale com = new Commerciale("aa", "info", "info", "toto", 1000, 100000, 3);
            //com.CalculerSalaire();
            //Exercice Véhicule héritage
            //Vehicule v1 = new Voiture(2010, 5000);
            //Vehicule v2 = new Voiture(2020, 25000);
            //Vehicule v3 = new Voiture(2015, 15000);
            //Vehicule v4 = new Camion(2005, 20000);
            //Vehicule v5 = new Camion(2018, 60000);
            //Vehicule[] tab = new Vehicule[] { v1, v2, v3, v4, v5 };
            //foreach(Vehicule v in tab)
            //{
            //    v.Demarrer();
            //    v.Accelerer();
            //}
            #endregion

            #region suite POO en c#
            //Personne e1 = new Etudiant("toto", "tata", 1);
            //Personne e2 = new Etudiant("titi", "minet", 2);
            //Personne p1 = new Prof("titi", "tata", "math");
            //Personne p2 = new Prof("tyty", "tttt", "info");
            //Personne[] tab = new Personne[] { e1, e2, p1, p2 };
            //foreach(Personne p in tab)
            //{
            //    //Affichage du type de p
            //    //Console.WriteLine(p.GetType());
            //    //Vérification du type de p
            //    //if(p.GetType() == typeof(Etudiant))
            //    //{
            //    //    //Convertir p en etudiant => si echec de convertion e égale à null
            //    //    //Etudiant e = p as Etudiant;
            //    //    //e.SpecialEtudiant();
            //    //    (p as Etudiant).SpecialEtudiant();
            //    //}
            //    //else if(p.GetType() == typeof(Prof))
            //    //{
            //    //    //Convertir p en prof => si echec de convertion, le programme lève une exception
            //    //    Prof pf = (Prof)p;
            //    //    pf.SpecialProf();
            //    //}
            //    // <=> is
            //    //if(p is Etudiant e)
            //    //{
            //    //    e.SpecialEtudiant();
            //    //}
            //    //else if(p is Prof pf)
            //    //{
            //    //    pf.SpecialProf();
            //    //}
            //    

            //}
            //les génériques
            //Salle<Prof> salleProf = new Salle<Prof>();
            //Salle<Etudiant> salleEtudiant = new Salle<Etudiant>();
            //Pile<string> chaines = new Pile<string>(10);
            //chaines.Empiler("bonjour");
            //chaines.Empiler("tout le monde");
            //Console.WriteLine(chaines.GetElement(1));
            //chaines.Depiler();
            //Liste est une classe générique
            //List<string> chaines = new List<string>();
            //List<string> sousChaines = new List<string>() { "toto", "titi" };

            ////Ajouter un élément dans la liste
            //chaines.Add("coucou");
            ////Ajouter une sous liste
            //chaines.AddRange(sousChaines);
            ////supprimer un element
            //chaines.Remove("coucou");
            ////supprimer un element avec son index
            //chaines.RemoveAt(1);
            ////la taille de la liste
            //Console.WriteLine(chaines.Count);
            ////parcourir une liste
            //foreach (string s in chaines)
            //{
            //    Console.WriteLine(s);
            //}
            //DateTime date = DateTime.Now;
            //Console.WriteLine(date.Ticks);
            //foreach(string a in args)
            //{
            //    Console.WriteLine(a);
            //}
            //Cours interface
            //List<IAffichable> listeAffichable = new List<IAffichable>();
            //listeAffichable.Add(new Camion(2010, 20000));
            //listeAffichable.Add(new Maison(10, "tourcoing"));
            //foreach(IAffichable affichable in listeAffichable)
            //{
            //    affichable.Afficher();
            //}
            //List<ICri> listeICri = new List<ICri>();
            //listeICri.Add(new Chat());
            //listeICri.Add(new Lapin());
            //listeICri.Add(new Chien());
            //foreach(ICri a in listeICri)
            //{
            //    Console.WriteLine(a.Crier());
            //} 
            //List<IDeformable> figures = new List<IDeformable>();
            //figures.Add(new Rectangle(10, 10, 10, 20));
            //figures.Add(new Carre(10, 10, 10));
            //figures.Add(new Triangle(10, 10, 10, 30));
            //foreach(IDeformable f in figures)
            //{
            //    Console.WriteLine(f.GetType());
            //    Figure figure = f.Deformation(2, 1);
            //    figure.Afficher();
            //    Console.WriteLine(figure.GetType());
            //}
            #endregion

            #region cours passage de paramètres
            //int nombre;
            //MultiplierPar2(ref nombre);
            //MultiplierPar2(out nombre);
            //Console.WriteLine(nombre);
            //Personne p = new Etudiant("titi", "minet", 1);
            //EditPersonne(p);
            //Console.WriteLine(p.Nom);
            //Console.WriteLine(Addition("coucou",-10,10, 20)) ;
            #endregion

            #region cours gestion des exceptions
            //bool error = false;
            //do
            //{
            //    try
            //    {
            //        Console.Write("Merci de saisir un nombre : ");
            //        int a = Convert.ToInt32(Console.ReadLine());
            //        error = false;
            //        Console.WriteLine(a);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Merci de saisir un entier");
            //        error = true;
            //    }
            //    //finally
            //    //{
            //    //    Console.WriteLine("Merci d'avoir essayé");
            //    //}
            //} while (error);
            //Etudiant e = new Etudiant("toto", "tata", 1);

            //try
            //{
            //    Console.Write("Merci de saisir un nombre : ");
            //    int a = Convert.ToInt32(Console.ReadLine());
            //    e.Age = 10; 
            //} 
            //catch(FormatException ex)
            //{
            //    Console.WriteLine("Vous avez une erreur de format");
            //    Console.WriteLine(ex.Message);
            //}
            //catch(AgeException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //Console.WriteLine(default(char));
            //Console.Write("Merci de saisir un nombre : ");
            //int a;
            //if (!Int32.TryParse(Console.ReadLine(), out a))
            //{
            //    Console.WriteLine("Merci de saisir un entier");
            //}
            //Console.WriteLine(a);
            //if (!OurIntTryParse(Console.ReadLine(), out a))
            //{
            //    Console.WriteLine("Merci de saisir un entier");
            //}
            #endregion

            #region cours gestion de fichier texte
            //création d'un dossier file
            //string path = Directory.GetCurrentDirectory();
            //////string pathToFolder = path + @"\files";
            //string pathToFolder = Path.Combine(path, "files");
            //////Vérifier si dossier n'existe pas
            ////if (!Directory.Exists(pathToFolder))
            ////{
            ////    Directory.CreateDirectory(pathToFolder);
            ////}
            ////Ecrire dans un flux  => StreamWriter
            ////StreamWriter writer = new StreamWriter(Path.Combine(pathToFolder,"fichier.txt"));
            ////writer.Write("coucou \n bonjour tout le monde");
            ////writer.Close();
            ////StreamWriter writer = new StreamWriter(Path.Combine(pathToFolder, "fichier.csv"));
            ////writer.WriteLine("nom;prenom;telephone;");
            ////writer.WriteLine("toto;tata;06060606;");
            ////writer.Close();
            ////Lire un flux
            ////StreamReader reader = new StreamReader(Path.Combine(pathToFolder, "fichier.txt"));
            ////Console.WriteLine(reader.ReadToEnd());
            ////reader.Close();
            ////StreamReader reader = new StreamReader(Path.Combine(pathToFolder, "fichier.csv"));
            ////string data;
            ////int nbLigne = 0;
            ////do
            ////{
            ////    data = reader.ReadLine();

            ////    if(data != null)
            ////    {
            ////        if(nbLigne > 0)
            ////        {
            ////            string[] ligne = data.Split(";");
            ////            Etudiant e = new Etudiant(ligne[0], ligne[1], 1);
            ////            //foreach (string s in ligne)
            ////            //{
            ////            //    Console.Write(s + " ");
            ////            //}
            ////            Console.WriteLine(e);
            ////        }     
            ////    }
            ////    else
            ////    {
            ////        Console.WriteLine("Fin");
            ////    }
            ////    nbLigne++;
            ////} 
            ////while (data != null);
            ////reader.Close();
            ////Convertir un objet en json et json en objet
            ////Etudiant e = new Etudiant("toto", "tata", 1);
            ////e.Age = 24;
            ////string chaineJson = JsonConvert.SerializeObject(e);
            ////Etudiant e2 = JsonConvert.DeserializeObject<Etudiant>(chaineJson);
            ////Ecriture d'une liste dans un fichier sous format json
            ////List<Etudiant> etudiants = new List<Etudiant>() { };
            ////etudiants.Add(new Etudiant { Nom = "abadi", Prenom="Ihab", Age=24});
            ////etudiants.Add(new Etudiant { Nom = "minet", Prenom="titi", Age=24});
            ////StreamWriter writer = new StreamWriter(Path.Combine(pathToFolder, "etudiants.json"));
            ////writer.WriteLine(JsonConvert.SerializeObject(etudiants));
            ////writer.Close();
            ////Lire json à partir d'un fichier et le convertir en objet
            //StreamReader reader = new StreamReader(Path.Combine(pathToFolder, "etudiants.json"));
            //List<Etudiant> etudiants = JsonConvert.DeserializeObject<List<Etudiant>>(reader.ReadToEnd());
            //reader.Close();
            #endregion

            #region Delegate et event
            ////Calcule c = new Calcule();
            //////c.Calculer(10, 10, c.Addition);
            //////c.Calculer(10, 10, c.Soustraction);
            //////c.Calculer(10, 10, Multiplication);
            ////c.AllCalcule = c.Addition;
            ////c.AllCalcule += c.Soustraction;
            ////c.AllCalcule += Multiplication;
            ////c.StartCalcule(10, 15);
            ////c.AllCalcule -= c.Addition;
            ////c.AllCalcule += (a, b) => { Console.WriteLine(a / b); };
            ////c.StartCalcule(20, 30);
            //Voiture v = new Voiture(2020, 20000);
            //v.Promotion += EnvoieSMS;
            //v.Promotion += EnvoieEmail;
            //decimal reduc;
            //int nbReduc = 0;
            //do
            //{
            //    Console.WriteLine("Est ce qu'il y a une promotion ? ");
            //    Decimal.TryParse(Console.ReadLine(), out reduc);
            //    if(reduc != 0)
            //    {
            //        nbReduc++;
            //        v.Reduction(reduc);
            //        if(nbReduc >= 3)
            //        {
            //            v.Promotion -= EnvoieSMS;
            //        }
            //    }
            //} while (true);
            #endregion
            #region méthode d'extension
            string toto = "Bonjour tout le monde";
            Console.WriteLine(toto.CountWord());
            #endregion
        }
        #region methodes pour cours passage paramètres
        //Passage par valeur et reference
        //static void MultiplierPar2(int a)
        //{
        //    a = a * 2;
        //    Console.WriteLine(a);
        //}

        //Passage par reference
        //static void MultiplierPar2(ref int a)
        //{
        //    a = a * 2;
        //    Console.WriteLine(a);
        //}
        //static void MultiplierPar2(out int a)
        //{
        //    a = 20;
        //    Console.WriteLine(a);
        //}

        //static void EditPersonne(Personne p)
        //{
        //    p.Nom = "New Name " + p.Nom;
        //}

        //Mulit params


        //static int Addition(int a, int b)
        //{
        //    return a + b;
        //}

        static int Addition(params int[] tab)
        {
            if(tab.Length > 0)
            {
                int somme = tab[0];
                for(int i=1; i < tab.Length; i++)
                {
                    somme += tab[i];
                }
                return somme;
            }
            return 0;
        }
        static int Addition(string message, params int[] tab)
        {
            Console.WriteLine(message);
            if (tab.Length > 0)
            {
                int somme = tab[0];
                for (int i = 1; i < tab.Length; i++)
                {
                    somme += tab[i];
                }
                return somme;
            }
            return 0;
        }
        #endregion

        static void EnvoieSMS(decimal prix)
        {
            Console.WriteLine("Sms envoyé avec nouveau prix " + prix);
        }
        static void EnvoieEmail(decimal prix)
        {
            Console.WriteLine("email envoyé avec nouveau prix " + prix);
        }
        static bool OurIntTryParse(string chaine, out int res)
        {
            bool result = false;
            try
            {
                res = Convert.ToInt32(chaine);
                result = true;
            }catch(Exception e)
            {
                res = default(int);
            }
            return result;
        }

        //static double Multiplication(double a, double b)
        //{
        //    return a * b;
        //}
        static void Multiplication(double a, double b)
        {
            Console.WriteLine(a * b);
        }
    }


}
