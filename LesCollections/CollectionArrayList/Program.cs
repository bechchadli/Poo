using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace ExempleCollection
{
    class Program
    {
        static List<Etudiant> Etudiants = new List<Etudiant>();
        static Dictionary<int, Etudiant> DicEtudiants = new Dictionary<int, Etudiant>();
        static Hashtable HashEtudiants = new Hashtable();
        static Etudiant oE;

        static void listerDictionnaire()
        {
            foreach (KeyValuePair<int,Etudiant> de in DicEtudiants)
            {
                Console.WriteLine(de.Key + "  " + de.Value);
            }

            foreach (DictionaryEntry de in HashEtudiants)
            {
                Console.WriteLine(de.Key + "  " + de.Value);
            }
            foreach (Etudiant e in DicEtudiants.Values)
            {
                Console.WriteLine(de.Key + "  " + de.Value.Ni);
            }
        }
        static void Main(string[] args)
        {
            int choix;
            Deserialiser();
            do
            {
                choix = menu();
                Console.Clear();

                switch (choix)
                {
                    case 1:
                        ajouterEtudiant();
                        break;
                    case 2:
                        rechercherEtuMenu();
                        break;
                    case 3:
                        lister();
                        break;
                    case 4:
                        modifierEtu();
                        break;
                    case 5:
                        supprimerEtu();
                        break;
                    case 6:
                        ajouternote();
                        break;
                    case 7:
                        supprimerNote();
                        break;
                    case 8:
                        relever();
                        break;


                }
                Console.ReadKey();
            } while (choix != 15);
            Serialiser();
        }

        static int menu()
        {
            Console.Clear();
            Console.WriteLine("****************************");
            Console.WriteLine("********** Menu ************");
            Console.WriteLine("****************************");
            Console.WriteLine(" 1- Ajouter Etudiant       *");
            Console.WriteLine(" 2- Rechercher Etudiant    *");
            Console.WriteLine(" 3- Lister Etudiant et Moy *");
            Console.WriteLine(" 4- Modifier Etudiant      *");
            Console.WriteLine(" 5- Supprimer Etudiant     *");
            Console.WriteLine(" 6- Ajouter une note       *");
            Console.WriteLine(" 7- Supprimer Note         *");
            Console.WriteLine(" 8- Relever                *");
            Console.WriteLine(" 9- Le premier             *");
            Console.WriteLine("10- Le dernier             *");
            Console.WriteLine("11- Les Admis              *");
            Console.WriteLine("12- Les eliminés           *");
            Console.WriteLine("15- Quitter                *");
            Console.WriteLine("****************************");
            return int.Parse(Console.ReadLine());
        }

        static void ajouterEtudiant()
        {
                oE = new Etudiant();
                oE.saisrValeur();
                Etudiants.Add(oE);
        }

        static void lister()
        {
            
            foreach (Etudiant e in Etudiants)
            {
                Console.WriteLine("Information de l'etudiant N° {0} : ", Etudiants.IndexOf(e) + 1);
                e.afficherValeur();
                Console.WriteLine("\n");
            }
        }

        static Etudiant rechercherEtu()
        {
            Console.Write("Saisir le Num Etu : "); string ni = Console.ReadLine();
            foreach (Etudiant e in Etudiants)
            {
                if (ni.Equals(e.Ni)) return e;

            }
            Console.WriteLine("Cet etudiant n'existe pas !!!!!!!!");
            return null;
        }

        static int rechercherPosition()
        {
            Console.Write("Saisir le Num Etu : "); string ni = Console.ReadLine();

            //Solution 1
            //for (int i = 0; i < Etudiants.Count; i++)
            //{
            //    oE = Etudiants[i];

            //    if (ni.Equals(oE.Ni)) return i;

            //}
            //Console.WriteLine("Cet etudiant n'existe pas !!!!!!!!");
            //return -1;

            //Solution 2
            foreach (Etudiant e in Etudiants)
            {
                if (ni.Equals(e.Ni)) return Etudiants.IndexOf(e);

            }
            Console.WriteLine("Cet etudiant n'existe pas !!!!!!!!");
            return -1;
        }

        static void rechercherEtuMenu()
        {
            oE = rechercherEtu();
            if (oE != null)
            {
                oE.afficherValeur();
            }

        }

        static void modifierEtu()
        {
            oE = rechercherEtu();
            if (oE != null)
            {
                oE.afficherValeur();
                oE.saisrValeur();
            }
        }

        static void supprimerEtu()
        {
            //solution 1
            int p = rechercherPosition();
            if (p != -1) Etudiants.RemoveAt(p);
            
            //solution2
            oE = rechercherEtu();
            if (p != null) Etudiants.Remove(oE);
        }

        static void ajouternote()
        {
            oE = rechercherEtu();
            if (oE != null)
            {
                oE.afficherValeur();
                oE.ajouterNote();
            }
        }

        static void supprimerNote()
        {
            oE = rechercherEtu();
            if (oE != null)
            {
                oE.afficherValeur();
                oE.supprimerNote();
            }
        }

        static void relever()
        {
            oE = rechercherEtu();
            if (oE != null)
            {
                oE.relever();
            }
        }

        public static void Serialiser()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("MonFichier.dat", FileMode.Create, FileAccess.Write);
            formatter.Serialize(fs, Etudiants);
            fs.Close();
        }
        public static void Deserialiser()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream("MonFichier.dat", FileMode.Open, FileAccess.Read);
                Etudiants = (List<Etudiant>)formatter.Deserialize(fs);
                fs.Close();
                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Fichier Introuvable!!!!");
            }
            
        }
    }
}
