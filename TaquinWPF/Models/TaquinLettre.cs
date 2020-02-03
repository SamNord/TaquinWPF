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
                int aleatoire = r.Next(0, Lettres.Count);
                liste.Add(Lettres[aleatoire]);
                Lettres.Remove(Lettres[aleatoire]);
            }
            return liste;
        }
    }
}
