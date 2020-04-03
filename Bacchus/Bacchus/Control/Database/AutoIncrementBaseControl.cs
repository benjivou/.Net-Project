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

        public bool Exist(string Name)
        {
            OpenConnection();
            var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE Nom = '" + Name + "'");
            bool state;
            if (Result != null && Result.Read())
                state = true;
            else
                state = false;
            CloseConnection();
            return state;
        }

        abstract public Obj FindByRef(int Ref);
    }
}
