using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.Model;

namespace Bacchus.Control
{
    /// <summary>
    /// Link Marque between Model and SQLite
    /// </summary>
    class MarqueControl : BaseControl<Marque>
    {
        private string TableName = "Marques";
        private string RefName = "RefMarque";

        /// <summary>
        /// Create a Marque Row in Database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Insert(Marque Objet)
        {
            if (Objet == null)
                return false;
            if(Objet.RefMarque > 0)
                return ExecuteUpdate("INSERT INTO " + TableName + " (" + RefName + ",Nom) VALUES (" + Objet.RefMarque + ",'" + Objet.Nom + "')");
            else
            {
                // Auto-inc
                return ExecuteUpdate("INSERT INTO " + TableName + "(" + RefName + " ,Nom) VALUES (" + (GetMaxRef() + 1) + ",'" + Objet.Nom + "')");
            }
        }

        /// <summary>
        /// Delete a Marque Row in Database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Delete(Marque Objet)
        {
            // TODO Cascade
            if (Objet == null)
                return false;
            return ExecuteUpdate("DELETE FROM " + TableName + " WHERE " + RefName  + " = " + Objet.RefMarque );
        }

        /// <summary>
        /// Get all element in Marques Table
        /// </summary>
        /// <returns></returns>
        public override HashSet<Marque> GetAll()
        {
            OpenConnection();
            HashSet<Marque> Liste = new HashSet<Marque>();
            var Result = ExecuteSelect("SELECT * FROM " + TableName );
            while (Result.Read())
            {
                Marque Brand = new Marque(Result.GetString(1), Result.GetInt16(0));
                Liste.Add(Brand);
            }
            CloseConnection();
            return Liste;
        }

        /// <summary>
        /// Update Marque element
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Update(Marque Objet)
        {
            if (Objet != null && Objet.RefMarque > 0)
                return ExecuteUpdate("UPDATE " + TableName + " SET Nom = '" + Objet.Nom + "' WHERE " + RefName  + " = " + Objet.RefMarque);
            else
                return false;
        }

        /// <summary>
        /// Find a brand by his reference
        /// </summary>
        /// <param name="Ref"></param>
        /// <returns></returns>
        public Marque FindByRef(int Ref)
        {
            OpenConnection();
            var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE " + RefName  + " = " + Ref);
            Marque Brand;
            if (Result.Read())
            {
                Brand = new Marque(Result.GetString(1), Result.GetInt16(0));
            }
            else
                Brand = null;
            CloseConnection();
            return Brand;
        }
        
        public int GetMaxRef()
        {
            if (TableIsEmpty(TableName) == true)
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
            var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE Nom = '" + Name + "')");
            bool state;
            if (Result != null && Result.Read())
                state = true;
            else
                state = false;
            CloseConnection();
            return state;
        }
    }
}
