using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

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
            m = MCont.GetLastInserted();
            Console.WriteLine("Insert : " + m.Nom);
            // Change the name in the model
            m.Nom = "QueenStone";
            // Update the name in the DB
            bool u = MCont.Update(m);
            Console.WriteLine("Update : " + MCont.GetLastInserted().Nom);
            // Delete the marque
            bool r = MCont.Delete(m);



            // Launch View Part
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
