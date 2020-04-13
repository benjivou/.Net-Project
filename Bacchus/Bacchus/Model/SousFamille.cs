using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    public class SousFamille
    {
        public int RefSousFamille{ get; set; }
        public Famille Famille {get;set; }
        public string Nom { get; set; }

        public SousFamille(string Name, Famille Family = null , int Ref = -1)
        {
            RefSousFamille = Ref;
            Famille = Family;
            Nom = Name;
        }

		public SousFamille()
		{
		}

        public override string ToString()
        {
            return Nom;
        }
    }
}
