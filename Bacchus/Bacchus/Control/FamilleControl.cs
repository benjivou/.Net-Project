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
		private String ClassName = "Familles";	// Tablename

		// attributs 
		private String RefName = "RefFamille";	// primary  key
		private String NameName = "Nom";        // Name 


		/// <summary>
		/// Delete a Famille Row in Database
		/// </summary>
		/// <param name="Objet"></param>
		/// <returns></returns>
		public override bool Delete(Famille Objet) // TO-DO
		{
			Console.WriteLine("u try to delete something, it's bad, shame on U,... Don''t do that pls ;(");
			
			return ExecuteUpdate("DELETE FROM Familles WHERE RefFamille = " + Objet.RefFamille);
		}

		/// <summary>
		/// Get all element in Familles Table
		/// </summary>
		/// <returns></returns>
		public override HashSet<Famille> GetAll()
		{
			OpenConnection();
			HashSet<Famille> Liste = new HashSet<Famille>();
			var Result = ExecuteSelect("SELECT * FROM Familles");
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
				return ExecuteUpdate("INSERT INTO "+ClassName+" ("+RefName+","+NameName+") VALUES (" + Objet.RefFamille + ",'" + Objet.Nom + "')");
			else
			{
				Famille Family = GetLastInserted();
				// Pseodo Auto-Increment
				return ExecuteUpdate("INSERT INTO "+ClassName+"("+RefName+", "+NameName+") VALUES (" + (Family.RefFamille + 1) + ",'" + Objet.Nom + "')");
			}
			throw new NotImplementedException();
		}

		/// <summary>
		/// Return the last inserted (with the max id)
		/// </summary>
		/// <returns></returns>
		public Famille GetLastInserted()
		{
			OpenConnection();
			var Result = ExecuteSelect("SELECT MAX("+RefName+"), "+NameName+" FROM "+ClassName);
			Famille Family;
			if (Result.Read())
			{
				Console.WriteLine(Result.GetString(1));
				Family = new Famille(Result.GetString(1), Result.GetInt32(0));
			}
			else
				Family = null;

			CloseConnection();
			return Family;
		}

		/// <summary>
		/// Update Famille element
		/// </summary>
		/// <param name="Objet"></param>
		/// <returns></returns>
		public override bool Update(Famille Objet)
		{
			if (Objet != null && Objet.RefFamille > 0)
				return ExecuteUpdate("UPDATE Familles SET Nom = '" + Objet.Nom + "' WHERE RefFamille = " + Objet.RefFamille);
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
			var Result = ExecuteSelect("SELECT * FROM Familles WHERE RefFamille = " + Ref);
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
