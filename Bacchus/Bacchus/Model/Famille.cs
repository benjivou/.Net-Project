using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// Represent a famille object in the database
    /// </summary>
    public class Famille
    {
        public int RefFamille { get; set; }
        public String Nom { get; set; }

        public Famille(string Name, int Ref = -1)
        {
            RefFamille = Ref;
            Nom = Name;
        }

		public Famille()
		{
		}

        public override string ToString()
        {
            return Nom;
        }
    }
}
