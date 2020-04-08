using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Control
{
    abstract class AutoIncrementBaseControl<Obj> : BaseControl<Obj>
    {
		protected string ValueName = "Nom";
        
		abstract public Obj FindByRef(int Ref);
    }
}
