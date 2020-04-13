using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
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
	}
}
