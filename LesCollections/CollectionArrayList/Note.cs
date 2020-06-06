using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExempleCollection
{
    [Serializable]
    class Note
    {

        //Attributs
        private string matiere;
        private int coeff;
        private float valeur;


        //Les propertys
        public string Matiere
        {
            get { return matiere; }
            set { matiere = value; }
        }

        public int Coeff
        {
            get { return coeff; }
            set { coeff = value; }
        }

        public float Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        //Constructeurs
        //Constructeur par defaut
        public Note()
        {

        }

        //Generique
        public Note(string matiere, int coeff, float valeur)
        {
            this.matiere = matiere;
            this.coeff = coeff;
            this.valeur = valeur;
        }

        //de Copie
        public Note(Note o)
        {
            this.valeur = o.valeur;
            this.coeff = o.coeff;
            this.matiere = o.matiere;
        }

        public float mc()
        {
            return valeur * coeff;
        }

        public void saisrValeur()
        {
            Console.Write("Saisir la Matière : "); matiere = Console.ReadLine();
            Console.Write("Saisir le Coeel : "); coeff = int.Parse( Console.ReadLine());
            Console.Write("Saisir la Note : "); valeur  = float.Parse( Console.ReadLine());
        }
    }
}
