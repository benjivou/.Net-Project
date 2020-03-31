using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.Model;

namespace Bacchus.Control
{
    class ArticleControl : BaseControl<Article>
    {
        private string TableName = "Articles";
        private string RefName = "RefArticle";

        public override bool Delete(Article Objet)
        { 
            if (Objet == null)
                return false;
            return ExecuteUpdate("DELETE FROM " + TableName + " WHERE " + RefName + " = '" + Objet.RefArticle + "'");
        }

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

        public override bool Insert(Article Objet)
        {
            if (Objet == null || !isInsertable(Objet))
                return false;
            // Pseodo Auto-Increment
            return ExecuteUpdate("INSERT INTO " + TableName + " VALUES (" +
                    "'" + Objet.RefArticle + "', " +
                    "'" + Objet.Description + "', " +
                    " " + Objet.SousFamille.RefSousFamille + ", " +
                    " " + Objet.Marque.RefMarque + ", " +
                    " " + Objet.PrixHT + ", " +
                    " " + Objet.Quantite + ")");
        }

        public override bool Update(Article Objet)
        {
            if (Objet != null && Exist(Objet.RefArticle) && isInsertable(Objet))
                return ExecuteUpdate("UPDATE " + TableName + " SET " +
                    "Description = '" + Objet.Description + "', " +
                    "RefSousFamille = " + Objet.SousFamille.RefSousFamille + ", " +
                    "RefMarque = " + Objet.Marque.RefMarque + ", " +
                    "PrixHT = " + Objet.PrixHT + ", " +
                    "Quantite = " + Objet.Quantite + " " +
                    "WHERE " + RefName + " = '" + Objet.RefArticle + "'");
            else
                return false;
        }

        public bool isInsertable(Article Arti)
        {
            if (Arti == null
                || Exist(Arti.RefArticle)
                || Arti.Marque == null
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

        public bool Exist(string Name)
        {
            if (Name == null)
                return false;
            OpenConnection();
            var Result = ExecuteSelect("SELECT * FROM " + TableName + " WHERE " + RefName + " = '" + Name + "')");
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
