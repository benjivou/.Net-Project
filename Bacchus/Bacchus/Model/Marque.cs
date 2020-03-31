using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// Marque model from Marques Tables
    /// </summary>
    class Marque
    {
        public int RefMarque { get; set; }
        public String Nom { get; set; }

        public Marque()
        {

        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Ref"> -1 for no Reference</param>
        public Marque(string Name, int Ref = -1)
        {
            RefMarque = Ref;
            Nom = Name;
        }
    }
}
