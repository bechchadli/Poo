using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExempleCollection
{
    [Serializable]
    class Etudiant
    {
        private string ni;
        private string nom;
        private string prenom;
        private string filiere;

        private List<Note> Notes = new List<Note>();
        
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
                oN = new Note(); //instancier un objet note
                oN.saisrValeur(); //Remplir les info de la nouvelle note
                Notes.Add(oN); //affecter la nouvelle note à notre collection de note            
        }

        public float moyenne()
        {
            float s = 0; int sc = 0;

            //for (int i = 0; i < Notes.Count(); i++)
            //{
            //    oN = Notes[i];
            //    s = s + oN.mc();
            //    sc = sc + oN.Coeff;
            //}

            foreach(Note n in Notes)
            {
                s = s + n.mc();
                sc = sc + n.Coeff;
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
            for (int i = 0; i < Notes.Count; i++)
            {
                Console.WriteLine("{0} - {1} note : {2}", i + 1, Notes[i].Matiere, Notes[i].Valeur);
            }

            Console.Write("Saisir le num Note à supprimer : "); int rep = int.Parse( Console.ReadLine());

            
            Notes.RemoveAt(rep-1);
        }

        public void relever()
        {
            Console.WriteLine("NI : {0} \t Nom : {1} \t Prenom : {2} \n", ni, nom, prenom);
            Console.WriteLine("Matiere \t Note \t Coeff \t NoteCoeff");
             foreach (Note n in Notes)
            {
               Console.WriteLine("{0} \t\t {1} \t {2} \t {3}",n.Matiere,n.Valeur,n.Coeff,n.mc());
            }

             Console.WriteLine("\n\n \t\t Maoyenne Generale : {0}", moyenne());         
        }
    }
}
