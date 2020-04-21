using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPNotePooTableau
{
    class Program
    {
        static Etudiant[] Etudiants = new Etudiant[100];
        static int nbrEtu = 0;

        static Etudiant oE;

        static void Main(string[] args)
        {
            int choix;
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
            Console.Write("Faire un choix : ");
            return int.Parse(Console.ReadLine());          
        }

        static void ajouterEtudiant()
        {
            if (nbrEtu < 100)
            {
                oE = new Etudiant();
                oE.saisrValeur();
                Etudiants[nbrEtu] = oE;
                nbrEtu++;
            }
            else
                Console.WriteLine("Impossible d'ajouter des etudiants !!!!!!!");
        }

        static void lister()
        {
            for (int i = 0; i < nbrEtu; i++)
            {
                oE = Etudiants[i];
                Console.WriteLine("Information de l'etudiant N° {0} : " , i+1);
                oE.afficherValeur();
            }
        }

        static Etudiant rechercherEtu()
        {
            Etudiant oR;
            Console.Write("Saisir le Num Etu : "); string ni = Console.ReadLine();
            for (int i = 0; i < nbrEtu; i++)
            {
                oR = Etudiants[i];

                if (ni.Equals(oR.Ni)) return oR;
                
            }
            Console.WriteLine("Cet etudiant n'existe pas !!!!!!!!");
            return  null;
            
        }

        static int rechercherPosition()
        {
            Console.Write("Saisir le Num Etu : "); string ni = Console.ReadLine();
            for (int i = 0; i < nbrEtu; i++)
            {
                oE = Etudiants[i];

                if (ni.Equals(oE.Ni)) return i;

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
            int p = rechercherPosition();
            if (p != -1)
            {
                Etudiants[p].afficherValeur();
                for (int i = p; i < nbrEtu - 1; i++)
                {
                    Etudiants[i] = Etudiants[i+1];
                }
                nbrEtu--;
            }
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
    }
}
