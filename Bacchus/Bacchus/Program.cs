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
            /// TESTS - EXAMPLE ///
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


            // Launch View Part
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
