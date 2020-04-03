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
		/// <summary>
		/// Import the file in the database
		/// </summary>
		/// <param name="Path"></param>
		/// <returns></returns>
		public static bool ImportFile(String Path)
		{
			using (var reader = new StreamReader(@"C:\test.csv"))
			{
				
				while (!reader.EndOfStream)
				{
					/*
					 *Parser 
					 * 
					 */
					var line = reader.ReadLine();
					var values = line.Split(';');

					/*
					 * Create a "Marque" in the Database and get the Id
					 */


					/*
					 * Create a "Famille" in the Database and get the ID 
					 */
					/*
					* Create a "SousFamille" in the Database and get the ID 
					*/

					/*
					 * Create the "Article" and stock it in the database
					 */

					

				}


				return true;
			}
		}
	}
}
