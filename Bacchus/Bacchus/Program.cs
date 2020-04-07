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

            
   //         /// MARQUES
           Control.MarqueControl MCont = new Control.MarqueControl();
   //         HashSet<Model.Marque> List = MCont.GetAll();
   //         if(List != null)    // Display all Marques
   //         {
   //             foreach (Model.Marque Brand in List)
   //             {
   //                 // Display all differents brands
   //                 Console.WriteLine(Brand.Nom);
   //             }
   //         }
   //         // Display Marque name with id = 1
   //         //Console.WriteLine("find name with id 1 : " + MCont.FindByRef(1).Nom);
   //         // Create a new marque in the model
   //         Model.Marque m = new Model.Marque("Kingston");
   //         // Insert this new marque into the DB
   //         MCont.Insert(m);
   //         // Update the marque in the model with the new attributed id
   //         m = MCont.FindByRef(MCont.GetMaxRef());
   //         Console.WriteLine("Insert : " + m.Nom);
   //         // Change the name in the model
   //         m.Nom = "QueenStone";
   //         // Update the name in the DB
   //         bool u = MCont.Update(m);
   //         Console.WriteLine("Update : " + MCont.FindByRef(MCont.GetMaxRef()).Nom);
   //         // Delete the marque
   //         bool r = MCont.Delete(m);

   //         /// FAMILLE
            FamilleControl FCont = new FamilleControl();
   //         HashSet<Famille> ListF = FCont.GetAll();
   //         if (ListF != null)    // Display all 
   //         {
   //             foreach (Famille Fami in ListF)
   //             {
   //                 // Display all differents 
   //                 Console.WriteLine(Fami.Nom);
   //             }
   //         }
   //         FCont.Insert(new Famille("Grande"));
   //         FCont.Insert(new Famille("Moyenne"));
   //         FCont.Insert(new Famille("Petite"));
   //         Console.WriteLine("max : " + FCont.GetMaxRef());
   //         ListF = FCont.GetAll();
   //         if (ListF != null)    // Display all 
   //         {
   //             foreach (Famille Fami in ListF)
   //             {
   //                 // Display all differents 
   //                 Console.WriteLine(Fami.RefFamille + " " + Fami.Nom);
   //                 Fami.Nom = "Changed";
   //                 FCont.Update(Fami);
   //                 Famille Fam2 = FCont.FindByRef(Fami.RefFamille);
   //                 Console.WriteLine(Fam2.RefFamille + " " + Fam2.Nom);
   //                 FCont.Delete(Fami);
   //             }
   //         }
   //         Console.WriteLine("max : " + FCont.GetMaxRef());

   //         /// SS-FAMILLE
            SousFamilleControl SFCont = new SousFamilleControl();
   //         Console.WriteLine("\nMax sous-famille : " + SFCont.GetMaxRef());
   //         Famille f = new Famille("La Ch-tite Famille");
   //         FCont.Insert(f);
   //         f = FCont.FindByRef(FCont.GetMaxRef());
   //         SousFamille sf = new SousFamille("Sous race 1", f);
   //         SousFamille sfb = new SousFamille("Sous race 2", f);
   //         r = SFCont.Insert(sf);
   //         r = SFCont.Insert(sfb);
   //         Console.WriteLine("Inserts\nMax sous-famille : " + SFCont.GetMaxRef());
   //         HashSet<SousFamille> ListSF = SFCont.GetAll();
   //         if (ListSF != null)    // Display all 
   //         {
   //             foreach (SousFamille SFam in ListSF)
   //             {
   //                 // Display all differents 
   //                 Console.WriteLine(SFam.RefSousFamille + " " + SFam.Nom);
   //                 SFam.Nom = "Changed";
   //                 SFCont.Update(SFam);
   //                 SousFamille SFam2 = SFCont.FindByRef(SFam.RefSousFamille);
   //                 Console.WriteLine(SFam2.RefSousFamille + " " + SFam2.Nom);

			//		// Test of the GetByName on a SF
			//		SousFamille SFMock = SFCont.GetByName(SFam);
			//		Console.WriteLine("test Get FullObject \n SFMock name = " + SFMock.Nom);
			//		SFam.Nom = "Not In the Database";
			//		SFMock = SFCont.GetByName(SFam);
			//		if (SFMock == null) Console.WriteLine("Done");
			//		SFCont.Delete(SFam);
   //             }
   //         }
			

			//FCont.Delete(f);
   //         Console.WriteLine("Deletes\nMax sous-famille : " + SFCont.GetMaxRef());

   //         /// ARTICLES 
            ArticleControl ACont = new ArticleControl();
          
			//         // Create famille first
			//         Famille Fam = new Famille("Pere");
			//         FCont.Insert(Fam);
			//         Fam.RefFamille = FCont.GetMaxRef();
			//         // Then create SousFamilles
			//         SousFamille sf1 = new SousFamille("Fils",Fam);
			//         SousFamille sf2 = new SousFamille("Fille",Fam);
			//         SFCont.Insert(sf1);
			//         sf1.RefSousFamille = SFCont.GetMaxRef();
			//         SFCont.Insert(sf2);
			//         sf2.RefSousFamille = SFCont.GetMaxRef();
			//         //Create Marque
			//         Marque Mark = new Marque("Vroom");
			//         MCont.Insert(Mark);
			//         Mark.RefMarque = MCont.GetCountRef();
			//         Marque Mark2 = new Marque("Nitro");
			//         MCont.Insert(Mark2);
			//         Mark2.RefMarque = MCont.GetMaxRef();
			//         Console.WriteLine("\nArticle :\n" + MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles");
			//         //Articles
			//         Article a1 = new Article("007","Secret Pen",88,2,Mark,sf1);
			//         ACont.Insert(a1);
			//         Article ac = new Article("008", "Secret copieur", 71, 12, Mark2, sf2);
			//         ACont.Insert(ac);
			//         HashSet<Article> Alist = ACont.GetAll();
			//         if(Alist != null)
			//         {
			//             foreach(Article Art in Alist)
			//             {
			//                 Console.WriteLine(Art.RefArticle + " " + Art.Description + " " + Art.Marque.Nom + " " + Art.SousFamille.Nom);
			//                 Art.Description = "Secret changed ";
			//                 Art.Marque = Mark2;
			//                 Art.SousFamille = sf2;
			//                 ACont.Update(Art);
			//                 Article Updated = ACont.FindByRef(Art.RefArticle);
			//                 Console.WriteLine(Updated.RefArticle + " " + Updated.Description + " " + Updated.Marque.Nom + " " + Updated.SousFamille.Nom);
			//                 ACont.Delete(Updated);
			//             }
			//         }


			////Delete

			//ACont.Insert(a1);

			//ACont.Insert(ac);
			//Console.WriteLine(MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles / " + ACont.GetCountRef() + " Articles ");
			//MCont.Delete(Mark);
			//         MCont.Delete(Mark2);
			//Console.WriteLine(MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles / " + ACont.GetCountRef() + " Articles ");
			//FCont.Delete(Fam);
			//   

            ////Delete

            //ACont.Insert(a1);

            //ACont.Insert(ac);
            //Console.WriteLine(MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles / " + ACont.GetCountRef() + " Articles ");
            //MCont.Delete(Mark);
            //         MCont.Delete(Mark2);
            //Console.WriteLine(MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles / " + ACont.GetCountRef() + " Articles ");
            //FCont.Delete(Fam);
            //         Console.WriteLine(MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles / " + ACont.GetCountRef() + " Articles ");


			Console.WriteLine(MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles / " + ACont.GetCountRef() + " Articles ");
			FileControl.ImportFile("C:\\Users\\Foxinow\\Desktop\\net\\.Net-Project\\Bacchus\\Bacchus\\Data_to_integrate.csv");
			Console.WriteLine(MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles / " + ACont.GetCountRef() + " Articles ");
			FileControl.ExportFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\toto.csv");
			ACont.FlushTable();
			MCont.FlushTable();
			FCont.FlushTable();
			Console.WriteLine(MCont.GetCountRef() + " Marques / " + SFCont.GetCountRef() + " ssFamilles / " + FCont.GetCountRef() + " Familles / " + ACont.GetCountRef() + " Articles ");

			// Launch View Part
			
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
		}


    }
}
