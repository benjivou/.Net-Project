using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.Model;

namespace Bacchus.Control
{
    class SousFamilleControl : AutoIncrementBaseControl<SousFamille>
    {
		       // Name
		public SousFamilleControl()
        {
            TableName = "SousFamilles";
            RefName = "RefSousFamille";
        }
		
        /// <summary>
        /// Delete a sousFamille object in dataBase
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Delete(SousFamille Objet)
        {
            
            if (Objet == null)
                return false;


			ArticleControl ACont = new ArticleControl();
			HashSet<Article> Liste;
			/*
			 * Step : 1 Remove all Articles linked to this "Sous-Famille"
			 */

			// get all "Articles" linked 

			Liste = ACont.FindBySousFamille(Objet);

			// remove all of them

			foreach(Article ElementArticle in Liste)
			{
				ACont.Delete(ElementArticle);
			}

            return ExecuteUpdate("DELETE FROM " + TableName + " WHERE " + RefName + " = " + Objet.RefSousFamille);
        }

        /// <summary>
        /// Return all element in the table sousFamille
        /// </summary>
        /// <returns></returns>
        public override HashSet<SousFamille> GetAll()
        {
            OpenConnection();
            HashSet<SousFamille> Liste = new HashSet<SousFamille>();
            var Result = ExecuteSelect("SELECT * FROM " + TableName);
            FamilleControl FCont = new FamilleControl();
            while (Result.Read())
            {
                SousFamille ChildFamily = new SousFamille(Result.GetString(2), FCont.FindByRef(Result.GetInt32(1)), Result.GetInt16(0));
                Liste.Add(ChildFamily);
            }
            CloseConnection();
            return Liste;
        }

        /// <summary>
        /// Insert a sousfamille object in the database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Insert(SousFamille Objet)
        {
            if (Objet == null || !CheckFamille(Objet.Famille) || Exist(Objet))
                return false;
            if (Objet.RefSousFamille > 0)
                return ExecuteUpdate("INSERT INTO " + TableName + " (" + RefName + ",Nom,RefFamille) VALUES (null,'" + Objet.Nom + "' , " + Objet.Famille.RefFamille + ")");
            else
            {
                // Pseodo Auto-Increment
                return ExecuteUpdate("INSERT INTO " + TableName + "(" + RefName + " ,Nom,RefFamille) VALUES (null,'" + Objet.Nom + "'," + Objet.Famille.RefFamille + ")");
            }
        }

        /// <summary>
        /// Update a sousfamille object in the database (base on the ref)
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
        public override bool Update(SousFamille Objet)
        {
            if (Objet != null && Objet.Famille != null && Objet.RefSousFamille > 0 && CheckFamille(Objet.Famille)) 
                return ExecuteUpdate("UPDATE " + TableName + " SET Nom = '" + Objet.Nom + "', RefFamille = " + Objet.Famille.RefFamille + " WHERE " + RefName + " = " + Objet.RefSousFamille);
            else
                return false;
        }
        
        /// <summary>
        /// Return the sousfamille object from the database with his ref
        /// </summary>
        /// <param name="Ref"></param>
        /// <returns></returns>
        public override SousFamille FindByRef(int Ref)
        {
            OpenConnection();
            var Result = ExecuteSelect("SELECT Nom,RefFamille,RefSousFamille FROM " + TableName + " WHERE " + RefName + " = " + Ref);
            SousFamille ChildFamily = null;
            FamilleControl FCont = new FamilleControl();
            if (Result.Read())
            {
                ChildFamily = new SousFamille(Result.GetString(0), FCont.FindByRef(Result.GetInt32(1)),Result.GetInt16(2));
            }
            else
                ChildFamily = null;
            CloseConnection();
            return ChildFamily;
        }

        /// <summary>
        /// Check If the famille exist, true if exist
        /// </summary>
        /// <param name="Family"></param>
        /// <returns></returns>
        public bool CheckFamille(Famille Family)
        {
            if (Family == null)
                return false;
            FamilleControl FCont = new FamilleControl();
            if (FCont.FindByRef(Family.RefFamille) == null)
                return false;
            else
                return true;
        }

		/// <summary>
		/// Return the list of "SousFamille" object from the database with the FamilleRef equals to the family pass in parameter
		/// </summary>
		/// <param name="Ref"></param>
		/// <returns></returns>
		public HashSet<SousFamille> FindByFamily(Famille Objet)
		{
			OpenConnection();
			var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE " + "RefFamille" + " = " + Objet.RefFamille);
			HashSet<SousFamille> Liste = new HashSet<SousFamille>();

			FamilleControl FCont = new FamilleControl();
			while (Result.Read())
			{
				SousFamille ChildFamily = new SousFamille(Result.GetString(2), FCont.FindByRef(Result.GetInt32(1)), Result.GetInt16(0));
				Liste.Add(ChildFamily);
			}
			CloseConnection();
			return Liste;
		}

		public override SousFamille GetByName(SousFamille obj)
		{
			OpenConnection();

			// We have to compare the FamilleRef and the Sous Famille Name to fin it 
			var Result = ExecuteSelect("SELECT * FROM " + TableName + 
				" WHERE " + ValueName + " = '" + obj.Nom +
				"' ");


			SousFamille ChildFamily = null;
			FamilleControl FCont = new FamilleControl();


			if (Result.Read())
			{
				ChildFamily = new SousFamille(
					Result.GetString(2), 
					obj.Famille,
					Result.GetInt16(0));
			}
			else
				ChildFamily = null;
			CloseConnection();
			return ChildFamily;
		}
	}
}
