using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.Model;
namespace Bacchus.Control
{
    class FamilleControl : BaseControl<Famille>

    {
        private String TableName = "Familles";  // Tablename

        // attributs 
        private String RefName = "RefFamille";  // primary  key
        private String NameName = "Nom";        // Name 


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

        public override bool Insert(Famille Objet)
        {
            if (Objet.RefFamille > 0)
                return ExecuteUpdate("INSERT INTO " + TableName + " (" + RefName + "," + NameName + ") VALUES (" + Objet.RefFamille + ",'" + Objet.Nom + "')");
            else
            {
                return ExecuteUpdate("INSERT INTO " + TableName + "(" + RefName + ", " + NameName + ") VALUES (" + (GetMaxRef() + 1) + ",'" + Objet.Nom + "')");
            }
            throw new NotImplementedException();
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
        public Famille FindByRef(int Ref)
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
