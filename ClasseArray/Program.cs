using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesTableaux
{
    class Program
    {
        static void Main(string[] args)
        {
            exemple1();
            Console.WriteLine("\n\nExemple 2 :");
            exemple2();
        }

        static void exemple1()
        {
            // Créer un tableau de string de taille 5
            string[] Noms = new string[5];

            // Lire les noms de 5 employés
            System.Console.WriteLine("Entrer les noms de 5 emplyés:");
            for (int i = 0; i < Noms.Length; i++)
            {
                Noms[i] = Console.ReadLine();
            }

            // Afficher les éléments du tableau saisi
            Console.WriteLine("les noms siasis :");
            foreach (string nom in Noms)
            {
                Console.WriteLine("{0}  ", nom);
            }

            // Inverser le tableau
            Array.Reverse(Noms);

            // Afficher le tableau inversé
            Console.WriteLine("\nLes noms dans l’ordre inverse:");
            foreach (string nom in Noms)
            {
                Console.WriteLine("{0}  ", nom);
            }

            // Trier le tableau
            Array.Sort(Noms);

            // chercher la position de la première occurrence de jilali dans le tableau t
            int p = Array.IndexOf(Noms, "jilali");
            Console.WriteLine("la première position de jilali est: " + p);

            // chercher la position de la dernière occurrence de c dans le tableau t
            p = Array.LastIndexOf(Noms, "jilali");
            Console.WriteLine("la dérnière position de jilali est: " + p);
            
            
            //  Afficher le tableau trié
            Console.WriteLine("\nLes noms trié:");
            foreach (string nom in Noms)
            {
                Console.WriteLine("{0}  ", nom);
            }
        }
        static void exemple2()
        {
            Personne[] t = new Personne[3];
            t[0] = new Personne("Jilali", "said", 23);
            t[1] = new Personne("Lahssini", "Omar", 20);
            t[2] = new Personne("Lahssini", "Omar", 20);

            // afficher tous les éléments du tableau t
            foreach (Personne a in t)
                Console.WriteLine(a.Nom);
    
          
            Personne[] T = new Personne[3];
            // copier 3 éléments du tableau t dans T
            Array.Copy(t, T, 3);

            //copier t dans T à partir de la position 0
            t.CopyTo(T, 0);

            // tester si t et T sont egaux
            bool res = Array.Equals(t, T);
            Console.WriteLine("res= " + res);

            // affecte null à la case 2, le dernier parametre (1) désigne le nombre de cases auxquelles on veut affecter null
            Array.Clear(T, 2, 1);

            // redimensioner le tableau T 
            Array.Resize(ref T, 2);
            foreach (Personne a in T)
                Console.WriteLine(a.Nom);

            // recupperer le type
            Console.WriteLine("type: " + t.GetType());
            Console.Read();

        }
    }
}
