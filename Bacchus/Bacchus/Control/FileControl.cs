using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Control
{
	class FileControl
	{

		private static int DESCRIPTION = 0;
		private static int REF = 1;
		private static int MARQUE = 2;
		private static int FAMILLE = 3;
		private static int SOUSFAMILLE = 4;
		private static int PRIXHT = 5;


		/// <summary>
		/// Import the file in the database
		/// </summary>
		/// <param name="Path"></param>
		/// <returns></returns>
		public static bool ImportFile(String Path)
		{
			using (var reader = new StreamReader(Path))
			{

				Console.WriteLine("We are importing this file " + Path);


				

				ArticleControl ACont = new ArticleControl();
				FamilleControl FCont = new FamilleControl();
				SousFamilleControl SFCont = new SousFamilleControl();
				MarqueControl MCont = new MarqueControl();

				reader.ReadLine(); // remove the first line

				while (!reader.EndOfStream)
				{
					Model.Marque Mark = new Model.Marque();
					Model.Article Artic = new Model.Article();
					Model.SousFamille SousFam = new Model.SousFamille();
					Model.Famille Fam = new Model.Famille();
					/*
					 *Parser 
					 * 
					 */
					var line = reader.ReadLine();
					Console.WriteLine(line);
					string[] values = line.Split(';');

					/*
					 * Create a "Marque" in the Database and get the Id
					 */
					
					Mark.Nom = values[MARQUE];
					
					// the "Marque" object is not in the Database
					if (!MCont.Exist(Mark))
					{
						// Create one
						MCont.Insert(Mark);

					}

					// get it 
					Mark = MCont.GetByName(Mark);


					/*
					 * Create a "Famille" in the Database and get the ID 
					 */

					Fam.Nom = values[FAMILLE];

					if (!FCont.Exist(Fam))
					{
						FCont.Insert(Fam);
					}

					Fam = FCont.GetByName(Fam);


					/*
					* Create a "SousFamille" in the Database and get the ID 
					*/
					SousFam.Nom = values[SOUSFAMILLE];
					SousFam.Famille = Fam;
					if (!SFCont.Exist(SousFam))
					{				  
						SFCont.Insert(SousFam);
					}
					SousFam = SFCont.GetByName(SousFam);

					/*
					 * Create the "Article" and stock it in the database
					 */
					Artic.RefArticle = values[REF];
					Artic.PrixHT = float.Parse(values[PRIXHT].Replace('.', ','));
					Artic.Description = values[DESCRIPTION];
					Artic.Marque = Mark;
					Artic.SousFamille = SousFam;

					// the Article object need to be update in the Database
					if (ACont.Exist(Artic))
					{
						Console.WriteLine("Update");
						ACont.Update(Artic);
					}
					else
					{
						Console.WriteLine("Insert");
						ACont.Insert(Artic);
					}


				}


				return true;
			}
		}
	}
}
