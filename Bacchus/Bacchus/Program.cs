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
            if(List != null)    // If the table is not empty
            {
                foreach (Model.Marque Brand in List)
                {
                    // Display all differents brands
                    Console.WriteLine(Brand.Nom);
                }
            }
            Console.WriteLine("find name with id 1 : " + MCont.FindByRef(1).Nom);
            Model.Marque m = new Model.Marque("Kingston");
            MCont.Insert(m);
            // Update with the new id
            m = MCont.GetLastInserted();
            Console.WriteLine("Insert : " + m.Nom);
            // Change the name + update SQL
            m.Nom = "QueenStone";
            bool u = MCont.Update(m);
            Console.WriteLine("Update : " + MCont.GetLastInserted().Nom);
            // Delete
            bool r = MCont.Delete(m);



            // Launch View Part
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
