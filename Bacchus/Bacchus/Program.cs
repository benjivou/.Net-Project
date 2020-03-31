using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using Bacchus.Control;
using Bacchus.Model;

namespace Bacchus
{
    /// <summary>
    /// Main thread, first file executed
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// TESTS BDD - EXAMPLE ///
            
            /// MARQUES
            Control.MarqueControl MCont = new Control.MarqueControl();
            HashSet<Model.Marque> List = MCont.GetAll();
            if(List != null)    // Display all Marques
            {
                foreach (Model.Marque Brand in List)
                {
                    // Display all differents brands
                    Console.WriteLine(Brand.Nom);
                }
            }
            // Display Marque name with id = 1
            Console.WriteLine("find name with id 1 : " + MCont.FindByRef(1).Nom);
            // Create a new marque in the model
            Model.Marque m = new Model.Marque("Kingston");
            // Insert this new marque into the DB
            MCont.Insert(m);
            // Update the marque in the model with the new attributed id
            m = MCont.FindByRef(MCont.GetMaxRef());
            Console.WriteLine("Insert : " + m.Nom);
            // Change the name in the model
            m.Nom = "QueenStone";
            // Update the name in the DB
            bool u = MCont.Update(m);
            Console.WriteLine("Update : " + MCont.FindByRef(MCont.GetMaxRef()).Nom);
            // Delete the marque
            bool r = MCont.Delete(m);

            /// FAMILLE
            FamilleControl FCont = new FamilleControl();
            HashSet<Famille> ListF = FCont.GetAll();
            if (ListF != null)    // Display all 
            {
                foreach (Famille Fam in ListF)
                {
                    // Display all differents 
                    Console.WriteLine(Fam.Nom);
                }
            }
            FCont.Insert(new Famille("Grande"));
            FCont.Insert(new Famille("Moyenne"));
            FCont.Insert(new Famille("Petite"));
            Console.WriteLine("max : " + FCont.GetMaxRef());
            ListF = FCont.GetAll();
            if (ListF != null)    // Display all 
            {
                foreach (Famille Fam in ListF)
                {
                    // Display all differents 
                    Console.WriteLine(Fam.RefFamille + " " + Fam.Nom);
                    Fam.Nom = "Changed";
                    FCont.Update(Fam);
                    Famille Fam2 = FCont.FindByRef(Fam.RefFamille);
                    Console.WriteLine(Fam2.RefFamille + " " + Fam2.Nom);
                    FCont.Delete(Fam);
                }
            }
            Console.WriteLine("max : " + FCont.GetMaxRef());

            /// SS-FAMILLE
            SousFamilleControl SFCont = new SousFamilleControl();
            Console.WriteLine("\nMax sous-famille : " + SFCont.GetMaxRef());
            Famille f = new Famille("La Ch-tite Famille");
            FCont.Insert(f);
            f = FCont.FindByRef(FCont.GetMaxRef());
            SousFamille sf = new SousFamille("Sous race 1", f);
            SousFamille sfb = new SousFamille("Sous race 2", f);
            r = SFCont.Insert(sf);
            r = SFCont.Insert(sfb);
            Console.WriteLine("Inserts\nMax sous-famille : " + SFCont.GetMaxRef());
            HashSet<SousFamille> ListSF = SFCont.GetAll();
            if (ListSF != null)    // Display all 
            {
                foreach (SousFamille SFam in ListSF)
                {
                    // Display all differents 
                    Console.WriteLine(SFam.RefSousFamille + " " + SFam.Nom);
                    SFam.Nom = "Changed";
                    SFCont.Update(SFam);
                    SousFamille SFam2 = SFCont.FindByRef(SFam.RefSousFamille);
                    Console.WriteLine(SFam2.RefSousFamille + " " + SFam2.Nom);
                    SFCont.Delete(SFam);
                }
            }
            FCont.Delete(f);
            Console.WriteLine("Deletes\nMax sous-famille : " + SFCont.GetMaxRef());


            // Launch View Part
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
            */
        }
    }
}
