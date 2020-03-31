using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.Model;

namespace Bacchus.Control
{
    class SousFamilleControl : BaseControl<SousFamille>
    {
        private string TableName = "SousFamilles";
        private string RefName = "RefSousFamille";

        public override bool Delete(SousFamille Objet)
        {
            // TODO Cascade
            if (Objet == null)
                return false;
            return ExecuteUpdate("DELETE FROM " + TableName + " WHERE " + RefName + " = " + Objet.RefSousFamille);
        }

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

        public override bool Insert(SousFamille Objet)
        {
            if (Objet == null || !CheckFamille(Objet.Famille))
                return false;
            if (Objet.RefSousFamille > 0)
                return ExecuteUpdate("INSERT INTO " + TableName + " (" + RefName + ",Nom,RefFamille) VALUES (" + Objet.RefSousFamille + ",'" + Objet.Nom + "' , " + Objet.Famille.RefFamille + ")");
            else
            {
                // Pseodo Auto-Increment
                return ExecuteUpdate("INSERT INTO " + TableName + "(" + RefName + " ,Nom,RefFamille) VALUES (" + (GetMaxRef() + 1) + ",'" + Objet.Nom + "'," + Objet.Famille.RefFamille + ")");
            }
        }

        public override bool Update(SousFamille Objet)
        {
            if (Objet != null && Objet.Famille != null && Objet.RefSousFamille > 0) 
                return ExecuteUpdate("UPDATE " + TableName + " SET Nom = '" + Objet.Nom + "', RefFamille = " + Objet.Famille.RefFamille + " WHERE " + RefName + " = " + Objet.RefSousFamille);
            else
                return false;
        }
        
        public SousFamille FindByRef(int Ref)
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
    }
}
