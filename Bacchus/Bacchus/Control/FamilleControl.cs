using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.Model;

namespace Bacchus.Control
{
    class FamilleControl : AutoIncrementBaseControl<Famille>
    {
        
        private string NameName = "Nom";        // Name 

        public FamilleControl()
        {
            TableName = "Familles";  // Tablename
            RefName = "RefFamille";  // primary  key
        }

        /// <summary>
        /// Delete a Famille Row in Database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Delete(Famille Objet) // TO-DO
        {
            // TODO CASCADE
            if (Objet == null)
                return false;
            return ExecuteUpdate("DELETE FROM " + TableName + " WHERE " + RefName + " = " + Objet.RefFamille);
        }

        /// <summary>
        /// Get all element in Familles Table
        /// </summary>
        /// <returns></returns>
        public override HashSet<Famille> GetAll()
        {
            OpenConnection();
            HashSet<Famille> Liste = new HashSet<Famille>();
            var Result = ExecuteSelect("SELECT * FROM " + TableName);
            while (Result.Read())
            {
                Famille Family = new Famille(Result.GetString(1), Result.GetInt16(0));
                Liste.Add(Family);
            }
            CloseConnection();
            return Liste;
        }

        /// <summary>
        /// Insert a famille object in the database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Insert(Famille Objet)
        {
            if (Objet == null || Exist(Objet.Nom))
                return false;
            if (Objet.RefFamille > 0 )
                return ExecuteUpdate("INSERT INTO " + TableName + " (" + RefName + "," + NameName + ") VALUES (" + Objet.RefFamille + ",'" + Objet.Nom + "')");
            else
            {
                return ExecuteUpdate("INSERT INTO " + TableName + "(" + RefName + ", " + NameName + ") VALUES (" + (GetMaxRef() + 1) + ",'" + Objet.Nom + "')");
            }
        }


        /// <summary>
        /// Update Famille element
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Update(Famille Objet)
        {
            if (Objet != null && Objet.RefFamille > 0)
                return ExecuteUpdate("UPDATE " + TableName + " SET Nom = '" + Objet.Nom + "' WHERE " + RefName + " = " + Objet.RefFamille);
            else
                return false;
        }


        /// <summary>
        /// Find a Family by his reference
        /// </summary>
        /// <param name="Ref"></param>
        /// <returns></returns>
        public override Famille FindByRef(int Ref)
        {
            OpenConnection();
            var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE " + RefName + " = " + Ref);
            Famille Family;
            if (Result.Read())
            {
                Family = new Famille(Result.GetString(1), Result.GetInt16(0));
            }
            else
                Family = null;
            CloseConnection();
            return Family;
        }
    }
}
