﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.Model;

namespace Bacchus.Control
{
    /// <summary>
    /// Control the article management
    /// </summary>
	class ArticleControl : BaseControl<Article>
	{
        /// <summary>
        /// Default Construtor
        /// </summary>
		public ArticleControl()
		{
			TableName = "Articles";
			RefName = "RefArticle";
		}

        /// <summary>
        /// Delete an article in database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
		public override bool Delete(Article Objet)
		{
			if (Objet == null)
				return false;
			return ExecuteUpdate("DELETE FROM " + TableName + " WHERE " + RefName + " = '" + Objet.RefArticle + "'");
		}

        /// <summary>
        /// Get all existant article
        /// </summary>
        /// <returns></returns>
		public override HashSet<Article> GetAll()
		{
			OpenConnection();
			HashSet<Article> Liste = new HashSet<Article>();
			var Result = ExecuteSelect("SELECT * FROM " + TableName);
			SousFamilleControl SFCont = new SousFamilleControl();
			MarqueControl MCont = new MarqueControl();
			while (Result.Read())
			{
				Article Arti = new Article(
					Result.GetString(0),
					Result.GetString(1),
					Result.GetFloat(4),
					Result.GetInt16(5),
					MCont.FindByRef(Result.GetInt16(3)),
					SFCont.FindByRef(Result.GetInt16(2)));
				Liste.Add(Arti);
			}
			CloseConnection();
			return Liste;
		}

        /// <summary>
        /// Insert an article in database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
		public override bool Insert(Article Objet)
		{
			if (Objet == null || !CheckParam(Objet) || ExistantRef(Objet.RefArticle))
				return false;
			return ExecuteUpdate("INSERT INTO " + TableName + " VALUES (" +
					"'" + Objet.RefArticle + "', " +
					"'" + Objet.Description + "', " +
					" " + Objet.SousFamille.RefSousFamille + ", " +
					" " + Objet.Marque.RefMarque + ", " +
					" " + Objet.PrixHT.ToString("0.00", CultureInfo.InvariantCulture) + ", " +
					" " + Objet.Quantite + ")");
		}

        /// <summary>
        /// Update an article in database
        /// </summary>
        /// <param name="Objet"></param>
        /// <returns></returns>
		public override bool Update(Article Objet)
		{
			if (Objet != null && ExistantRef(Objet.RefArticle) && CheckParam(Objet))
			{
				//Console.WriteLine("Article ready to import");
				return ExecuteUpdate("UPDATE " + TableName + " SET " +
					"Description = '" + Objet.Description + "', " +
					"RefSousFamille = " + Objet.SousFamille.RefSousFamille + ", " +
					"RefMarque = " + Objet.Marque.RefMarque + ", " +
					"PrixHT = " + Objet.PrixHT.ToString("0.0", CultureInfo.InvariantCulture) + ", " +
					"Quantite = " + Objet.Quantite + " " +
					"WHERE " + RefName + " = '" + Objet.RefArticle + "'");
			}
			else
				return false;
		}

		/// <summary>
		/// Check Article param except Reference, return true if its ok
		/// </summary>
		/// <param name="Arti"></param>
		/// <returns></returns>
		public bool CheckParam(Article Arti)
		{
			if (Arti == null
				|| Arti.SousFamille == null
				|| Arti.PrixHT < 0
				|| Arti.Quantite < 0
				|| Arti.Marque == null)
				return false;
			MarqueControl MCont = new MarqueControl();
			SousFamilleControl SFCont = new SousFamilleControl();
			if (MCont.FindByRef(Arti.Marque.RefMarque) == null
				|| SFCont.FindByRef(Arti.SousFamille.RefSousFamille) == null)
				return false;
			return true;
		}

        /// <summary>
        /// Check if a reference is already used
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
		public bool ExistantRef(string Name)
		{
			if (Name == null)
				return false;
			OpenConnection();
			var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE " + RefName + " = '" + Name + "'");
			bool state;
			if (Result != null && Result.Read())
				state = true;
			else
				state = false;
			CloseConnection();
			return state;
		}

        /// <summary>
        /// Find an article with the reference
        /// </summary>
        /// <param name="Ref"></param>
        /// <returns></returns>
		public Article FindByRef(string Ref)
		{
			OpenConnection();
			var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE " + RefName + " = '" + Ref + "'");

			Article Arti;
			SousFamilleControl SFCont = new SousFamilleControl();
			MarqueControl MCont = new MarqueControl();
			if (Result.Read())
			{
				Arti = new Article(
					Result.GetString(0),
					Result.GetString(1),
					Result.GetFloat(4),
					Result.GetInt16(5),
					MCont.FindByRef(Result.GetInt16(3)),
					SFCont.FindByRef(Result.GetInt16(2)));
			}
			else
				Arti = null;
			CloseConnection();
			return Arti;
		}

		/// <summary>
		/// Get the list of Articles linked to this "Sous-Famille" Object
		/// </summary>
		/// <param name="Objet"></param>
		/// <returns></returns>
		public HashSet<Article> FindBySousFamille(SousFamille Objet)
		{
			OpenConnection();
			HashSet<Article> Liste = new HashSet<Article>();
			var Result = ExecuteSelect("SELECT * FROM " + TableName + " Where RefSousFamille = " + Objet.RefSousFamille);
			SousFamilleControl SFCont = new SousFamilleControl();
			MarqueControl MCont = new MarqueControl();
			while (Result.Read())
			{
				Article Arti = new Article(
					Result.GetString(0),
					Result.GetString(1),
					Result.GetFloat(4),
					Result.GetInt16(5),
					MCont.FindByRef(Result.GetInt16(3)),
					SFCont.FindByRef(Result.GetInt16(2)));
				Liste.Add(Arti);
			}
			CloseConnection();
			return Liste;
		}

		/// <summary>
		/// Get the list of Articles linked to this "Sous-Famille" Object
		/// </summary>
		/// <param name="Objet"></param>
		/// <returns></returns>
		public HashSet<Article> FindByMarque(Marque Objet)
		{
			OpenConnection();
			HashSet<Article> Liste = new HashSet<Article>();
			var Result = ExecuteSelect("SELECT * FROM " + TableName + " Where RefMarque = " + Objet.RefMarque);

			SousFamilleControl SFCont = new SousFamilleControl();
			MarqueControl MCont = new MarqueControl();

			while (Result.Read())
			{
				Article Arti = new Article(
					Result.GetString(0),
					Result.GetString(1),
					Result.GetFloat(4),
					Result.GetInt16(5),
					MCont.FindByRef(Result.GetInt16(3)),
					SFCont.FindByRef(Result.GetInt16(2)));
				Liste.Add(Arti);
			}
			CloseConnection();
			return Liste;
		}

        /// <summary>
        /// Find article details with an incomplete article object
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
		public override Article GetByName(Article Obj)
		{
			return FindByRef(Obj.RefArticle);
		}
	}

		
}
