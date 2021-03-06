﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Control.File
{
	class FileCheck : ConstClass
	{
		/*
		 * Constraint of the file
		 */
		private static int CONSTRAINT_LENGTH = 6;

		/*
		 * Error Message
		 */
		private static String ERROR_LENGTH = "Le format est invalide";
		private static String ERROR_INVALID = "Cellule invalide";
		private static String ERROR_PRIXHT = "Le prix HT est invalide";

		public static bool CheckFile(String Path)
		{
			try
			{
				using (var reader = new StreamReader(Path, Encoding.Default))
				{

					int CurrentItem = 0;  // The item counter it say what is the current element we are studying
					reader.ReadLine(); // Remove the last element


					while (!reader.EndOfStream)
					{

						CurrentItem++; // Move the cursor

						/*
						 *Parser 
						 * 
						 */
						var Line = reader.ReadLine();

						//Console.WriteLine(line);
						string[] Values = Line.Split(';');

						/*
						 * Test 1 : Length Of the item
						 */
						if (Values.Length != CONSTRAINT_LENGTH ) // the element is empty but there is just ,
						{
							throw (new ExceptionFile(CreateErrorMsg(ERROR_LENGTH, CurrentItem)));
							
						}
						Console.WriteLine(Values.Length);
						/*
						 *	Test 2 : Is Valid Fields
						 */

						// Not empty
						foreach (String Val in Values)
						{
							// Empty element "" or just , at the end
							if (Val == ""  )
							{
								throw new ExceptionFile(CreateErrorMsg(ERROR_INVALID, CurrentItem));
							}

						}

						/*
						 * Test 3 : The price is a float
						 */
						try { float.Parse(Values[PRIXHT].Replace('.', ',')); }
						catch (Exception Error)
						{
							Error.ToString(); // just to remove the warning

							throw new ExceptionFile(CreateErrorMsg(ERROR_PRIXHT, CurrentItem));
						}

					}

				}
				return true;
			}
			catch (Exception Excep)
			{
                throw Excep;
            }
		}

		private static String CreateErrorMsg(String Msg, int Line)
		{
			return "Erreur : " + Msg + " à la ligne " + Line;
		}
	}

	class ExceptionFile : Exception{
		public String FileErrorMsg { get; }

		public ExceptionFile(String Msg)
		{
			FileErrorMsg = Msg;
		}
	}
}
