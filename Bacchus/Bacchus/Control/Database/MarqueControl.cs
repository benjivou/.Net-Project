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
    class MarqueControl : AutoIncrementBaseControl<Marque>
    {
		       // Name 
		public MarqueControl()
        {
            TableName = "Marques";
            RefName = "RefMarque";
        }

        /// <summary>
        /// Create a Marque Row in Database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Insert(Marque Objet)
        {
            if (Objet == null || Exist(Objet))
                return false;
            if(Objet.RefMarque > 0)
                return ExecuteUpdate("INSERT INTO " + TableName + " (" + RefName + ",Nom) VALUES (null,'" + Objet.Nom + "')");
            else
            {
                // Auto-inc
                return ExecuteUpdate("INSERT INTO " + TableName + "(" + RefName + " ,Nom) VALUES (null,'" + Objet.Nom + "')");
            }
        }

        /// <summary>
        /// Delete a Marque Row in Database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Delete(Marque Objet)
        {
            
            if (Objet == null)
                return false;

			/*
			 * Step 1 : Remove Articles linked tot this Marque
			 */
			ArticleControl ACont = new ArticleControl();
			HashSet<Article> Liste = ACont.FindByMarque(Objet);
			foreach(Article Element in Liste)
			{
				//Console.WriteLine(Element.ToString());
				ACont.Delete(Element);
			}
			/*
			 * Step 2 : remopve from the Database the "Marque"
			 */
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
            var Result = ExecuteSelect("SELECT * FROM " + TableName + " ORDER BY Nom");
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
        public override Marque FindByRef(int Ref)
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

		public override Marque GetByName(Marque obj)
		{
			OpenConnection();
			var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE " + ValueName + " LIKE '" + obj.Nom + "'");
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

	}
}
