using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ExempleHashtable
{
    class Program
    {
        static Hashtable MonHashTable = new Hashtable();
        static Dictionary<String, Note> MonDictionaire = new Dictionary<string, Note>();
        static Note on;
        static void Main(string[] args)
        {
            string rep="oui";
            do
            {
                on = new Note();
                on.saisrValeur();
                if (MonDictionaire.ContainsKey(on.Matiere))
                    Console.WriteLine("Cette matière existe déja");
                else
                {
                    MonDictionaire.Add(on.Matiere, on);
                    MonHashTable.Add(on.Matiere, on);
                }
                Console.Write("Voulez vous continuez ? oui / non ");
                rep = Console.ReadLine();
            } while (!rep.Equals("oui"));


            foreach (String cle in MonDictionaire.Keys)
                Console.WriteLine("Cle avec valeur : " + cle);

            foreach (String cle in MonHashTable.Keys)
                Console.WriteLine("Cle avec valeur : " + cle);

            foreach (Note n in MonDictionaire.Values)
            {
                n.afficherValeur();
                Console.WriteLine("le Coeff  : " + n.Coeff);
            }

            foreach (Note n in MonHashTable.Values)
            {
                n.afficherValeur();
                Console.WriteLine("le Coeff  : " + n.Coeff);
            }

            foreach (DictionaryEntry d in MonHashTable)
            {
                Console.WriteLine(d.Key);
                on = (Note)d.Value;
                on.afficherValeur();
            }

            foreach (KeyValuePair<String, Note> d in MonDictionaire)
            {
                Console.WriteLine(d.Key);
                d.Value.afficherValeur();
            }

            Console.WriteLine("Saisir une matiere :");
            string ma = Console.ReadLine();

            if (!MonDictionaire.ContainsKey(ma))
                Console.WriteLine("Cette matière n'existe pas !!!!");
            else
                MonDictionaire[ma].afficherValeur();

            if (!MonHashTable.ContainsKey(ma))
                Console.WriteLine("Cette matière n'existe pas !!!!");
            else
            {
                on = (Note)MonHashTable[ma];
                on.afficherValeur();
            }
                

        }
    }
}
