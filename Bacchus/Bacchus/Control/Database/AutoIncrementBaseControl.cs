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

		public int GetMaxRef()
        {
            if (TableIsEmpty() == true)
                return 0;
            OpenConnection();
            var Result = ExecuteSelect("SELECT MAX(" + RefName + "), Nom FROM " + TableName);
            int Ref;
            if (Result.Read())
            {
                Ref = Result.GetInt16(0);
            }
            else
                Ref = 0;

            CloseConnection();
            return Ref;
        }


		


		abstract public Obj FindByRef(int Ref);
    }
}
