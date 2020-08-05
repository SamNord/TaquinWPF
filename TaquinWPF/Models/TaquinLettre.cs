using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinWPF.Models
{
    public class TaquinLettre
    {
        private List<string> lettres;
       

        public List<string> Lettres { get => lettres; set => lettres = value; }

      
        public TaquinLettre()
        {
            Lettres = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
        }

        //Mélanger la liste Lettres et retourne une liste mélangée
        public List<string> Shuffle()
        {
            List<string> liste = new List<string>();
            Random r = new Random();

            while (Lettres.Count > 0 && liste.Count < 9)
            {
                //on génère un nombre aléatoire entre 0 et 8 -> taille de la liste
                int aleatoire = r.Next(0, Lettres.Count);
                //on place la valeur de la liste Lettres à l'indice correspondant au nombre aléatoire
                liste.Add(Lettres[aleatoire]);
                //on n'oublie pas de supprimer la valeur déjà générée pour ne pas créer de doublons
                Lettres.Remove(Lettres[aleatoire]);
            }
            //on retourne la nouvelle liste de lettres mélangée
            return liste;
        }
    }
}
