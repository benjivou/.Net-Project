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
        /// <summary>
        /// Create a Marque Row in Database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Create(Marque Objet)
        {
            if(Objet.RefMarque > 0)
                return ExecuteUpdate("INSERT INTO Marques (RefMarque,Nom) VALUES (" + Objet.RefMarque + "," + Objet.Nom + ")");
            else
                return ExecuteUpdate("INSERT INTO Marques (Nom) VALUES (" + Objet.Nom + ")");
        }

        /// <summary>
        /// Delete a Marque Row in Database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Delete(Marque Objet)
        {
            return ExecuteUpdate("DELETE FROM Marques WHERE RefMarque = " + Objet.RefMarque );
        }

        /// <summary>
        /// Get all element in Marques Table
        /// </summary>
        /// <returns></returns>
        public override HashSet<Marque> GetAll()
        {
            OpenConnection();
            HashSet<Marque> Liste = new HashSet<Marque>();
            var Result = ExecuteSelect("SELECT * FROM Marques");
            if (Result.StepCount <= 0)
            {
                CloseConnection();
                return null;
            }
            while (Result.Read())
            {
                Marque Brand = new Marque( Result.GetString(1), Result.GetInt16(0) );
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
            if (Objet.RefMarque > 0)
                return ExecuteUpdate("UPDATE Marques SET Nom = " + Objet.Nom + " WHERE RefMarque = " + Objet.RefMarque);
            else
                return false;
        }
    }
}
