﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bacchus.Model;

namespace Bacchus.Control
{
    class SousFamilleControl : AutoIncrementBaseControl<SousFamille>
    {
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
            // TODO Cascade
            if (Objet == null)
                return false;
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
            if (Objet == null || !CheckFamille(Objet.Famille) || Exist(Objet.Nom))
                return false;
            if (Objet.RefSousFamille > 0)
                return ExecuteUpdate("INSERT INTO " + TableName + " (" + RefName + ",Nom,RefFamille) VALUES (" + Objet.RefSousFamille + ",'" + Objet.Nom + "' , " + Objet.Famille.RefFamille + ")");
            else
            {
                // Pseodo Auto-Increment
                return ExecuteUpdate("INSERT INTO " + TableName + "(" + RefName + " ,Nom,RefFamille) VALUES (" + (GetMaxRef() + 1) + ",'" + Objet.Nom + "'," + Objet.Famille.RefFamille + ")");
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
        /// Check If the famille exist 
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
    }
}
