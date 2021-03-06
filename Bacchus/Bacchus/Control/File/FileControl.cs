﻿using Bacchus.Control.File;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.Control
{
	class FileControl : ConstClass
	{
	

		/// <summary>
		/// Import the file in the database
		/// </summary>
		/// <param name="Path"></param>
		/// <returns></returns>
		public static bool ImportFile(String Path, ProgressBar Progress)
		{
            try
            {
                using (var reader = new StreamReader(Path, Encoding.Default))
                {
                    Console.WriteLine("We are importing this file " + Path);
                    
                    ArticleControl ACont = new ArticleControl();
                    FamilleControl FCont = new FamilleControl();
                    SousFamilleControl SFCont = new SousFamilleControl();
                    MarqueControl MCont = new MarqueControl();
                    
                    Progress.Maximum = reader.ReadLine().Count() - 1;// remove the first line

                    while (!reader.EndOfStream)
                    {
                        Progress.PerformStep();
                        Model.Marque Mark = new Model.Marque();
                        Model.Article Artic = new Model.Article();
                        Model.SousFamille SousFam = new Model.SousFamille();
                        Model.Famille Fam = new Model.Famille();
                        /*
						 *Parser 
						 * 
						 */
                        var Line = reader.ReadLine();
                        //Console.WriteLine(line);
                        string[] values = Line.Split(';');

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
                        //Console.WriteLine(Artic.PrixHT);
                        Artic.Description = values[DESCRIPTION];
                        Artic.Marque = Mark;
                        Artic.SousFamille = SousFam;

                        // the Article object need to be update in the Database
                        if (ACont.Exist(Artic))
                        {
                            //Console.WriteLine("Update");
                            ACont.Update(Artic);
                        }
                        else
                        {
                            //Console.WriteLine("Insert");
                            ACont.Insert(Artic);
                        }
                    }
                    Progress.Value = Progress.Maximum;
                }
                return true;
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
		}


		public static bool ExportFile(String Path, ProgressBar Progress)
		{
			bool IsItDone = true;
			/*
				 * Step 0 : initialise DAO Controller and  Variables
				 */
			ArticleControl ACont = new ArticleControl();


			/*
			 * Step 1 : Get All Article 
			 */

			HashSet<Model.Article> ListA = ACont.GetAll();

			/*
			 * Step 2 : Serialise everything  
			 */
			try
			{
				using (var w = new StreamWriter(Path, false, Encoding.Default))
				{
					// Write the first line 
					w.WriteLine("Description;Ref;Marque;Famille;Sous-Famille;Prix H.T.");
					w.Flush();

                    Progress.Maximum = ListA.Count();
                    // Serialise Data
                    foreach (Model.Article AMock in ListA)
					{
                        Progress.PerformStep();
                        var line = string.Format("{" + DESCRIPTION + "};{" + REF + "};{" + MARQUE + "};{" + FAMILLE + "};{" + SOUSFAMILLE + "};{" + PRIXHT + "}",
							AMock.Description,
							AMock.RefArticle,
							AMock.Marque.Nom,
							AMock.SousFamille.Famille.Nom,
							AMock.SousFamille.Nom,
							AMock.PrixHT.ToString("0.00", CultureInfo.InvariantCulture).Replace(".",","));

						
						w.WriteLine(line);
						w.Flush();

					}
				}
			}
			catch(IOException FileUnReacheable)
			{
                Console.WriteLine(FileUnReacheable.StackTrace);
				IsItDone = false;
			}

			
			return IsItDone;		// Job Done
		}

		

		
	}
}
