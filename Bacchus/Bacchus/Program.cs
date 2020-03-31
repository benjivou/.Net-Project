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
            FamilleControl Fcont = new FamilleControl();
            HashSet<Famille> ListF = Fcont.GetAll();
            if (ListF != null)    // Display all 
            {
                foreach (Famille Fam in ListF)
                {
                    // Display all differents 
                    Console.WriteLine(Fam.Nom);
                }
            }
            Fcont.Insert(new Famille("Grande"));
            Fcont.Insert(new Famille("Moyenne"));
            Fcont.Insert(new Famille("Petite"));
            Console.WriteLine("max : " + Fcont.GetMaxRef());
            ListF = Fcont.GetAll();
            if (ListF != null)    // Display all 
            {
                foreach (Famille Fam in ListF)
                {
                    // Display all differents 
                    Console.WriteLine(Fam.RefFamille + " " + Fam.Nom);
                    Fam.Nom = "Changed";
                    Fcont.Update(Fam);
                    Console.WriteLine(Fam.RefFamille + " " + Fam.Nom);
                    Fcont.Delete(Fam);
                }
            }
            Console.WriteLine("max : " + Fcont.GetMaxRef());

            // Launch View Part
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
