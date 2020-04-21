using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPNotePooTableau
{
    class Etudiant
    {
        private string ni;
        private string nom;
        private string prenom;
        private string filiere;

        private Note[] Notes = new Note[20];
        private int nbrNote;
        private Note oN;

        public string Ni
        {
            get { return ni; }
            set { ni = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public string Filiere
        {
            get { return filiere; }
            set { filiere    = value; }
        }
        
        //Constructeur
        public Etudiant()
        {

        }

        public Etudiant(string ni, string nom, string prenom, string filiere)
        {
            this.ni = ni;
            this.nom = nom;
            this.prenom = prenom;
            this.filiere = filiere;
        }

        public void saisrValeur()
        {
            Console.Write("Saisir le numInscription : "); ni = Console.ReadLine();
            Console.Write("Saisir le Nom : "); nom = Console.ReadLine();
            Console.Write("Saisir le Prenom : "); prenom = Console.ReadLine();
            Console.Write("Saisir la Filière : "); filiere = Console.ReadLine();
        }

        public void ajouterNote()
        {
            if (nbrNote < 20)
            {
                oN = new Note(); //instancier un objet note
                oN.saisrValeur(); //Remplir les info de la nouvelle note
                Notes[nbrNote] = oN; //affecter la nouvelle note à notre tableau de note
                nbrNote++; //incrementer le compteur des notes
            }
            else
                Console.WriteLine("Impossible d'ajouter unr autre notes!!!!!!!");
        }

        public float moyenne()
        {
            float s = 0; int sc = 0;
            for (int i = 0; i < nbrNote; i++)
            {
                oN = Notes[i];
                s = s + oN.mc();
                sc = sc + oN.Coeff;
            }
            if (sc == 0)
            {
                Console.WriteLine("Attention à la division sur 0 si votre étudiant n'a aucune note");
                return 0;
            }
            return s / sc;//Attention à la division sur 0 si votre étudiant n'a aucune note
        }

        public void afficherValeur()
        {
            Console.WriteLine("Le num Etu : {0}",ni);
            Console.WriteLine("Le nom Etu : {0}",nom);
            Console.WriteLine("Le prenom Etu : {0}", prenom);
            Console.WriteLine("La filiere Etu : {0}",filiere);
            Console.WriteLine("La moyenne Etu : {0}",moyenne().ToString());
        }

        public void supprimerNote()
        {
            for (int i = 0; i < nbrNote; i++)
            {
                oN = Notes[i];
                Console.WriteLine("{0} - {1} note : {2}", i+1 , oN.Matiere, oN.Valeur);
            }

            Console.Write("Saisir le num Note à supprimer : "); int rep = int.Parse( Console.ReadLine());

            for (int j = rep - 1; j < nbrNote - 1; j++)
            {
                Notes[j] = Notes[j + 1];
            }

            nbrNote--;
        }

        public void relever()
        {
            Console.WriteLine("NI : {0} \t Nom : {1} \t Prenom : {2} \n", ni, nom, prenom);
            Console.WriteLine("Matiere \t Note \t Coeff \t NoteCoeff");
             for (int i = 0; i < nbrNote; i++)
            {
                oN = Notes[i];
               Console.WriteLine("{0} \t\t {1} \t {2} \t {3}",oN.Matiere,oN.Valeur,oN.Coeff,oN.mc());
            }

             Console.WriteLine("\n\n \t\t Maoyenne Generale : {0}", moyenne());
            

        }
    }
}
