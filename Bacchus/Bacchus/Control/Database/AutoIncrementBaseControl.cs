using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Control
{
    /// <summary>
    /// Control for identifiable table in database
    /// </summary>
    /// <typeparam name="Obj"></typeparam>
    abstract class AutoIncrementBaseControl<Obj> : BaseControl<Obj>
    {
        /// <summary>
        /// Default name label
        /// </summary>
		protected string ValueName = "Nom";
        
        /// <summary>
        /// Find an object by his reference
        /// </summary>
        /// <param name="Ref"></param>
        /// <returns></returns>
		abstract public Obj FindByRef(int Ref);
    }
}
