﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.Model
{
    /// <summary>
    /// Represent a article object in the database
    /// </summary>
    public class Article
    {
        public string RefArticle { get; set; }
        public string Description { get; set; }
        public SousFamille SousFamille { get; set; }
        public Marque Marque { get; set; }
        public float PrixHT { get; set; }
        public int Quantite { get; set; }

        public Article(string Ref, string Descrip, float Price, int Quantity, Marque Brand, SousFamille ChildFamily)
        {
            RefArticle = Ref;
            Description = Descrip;
            PrixHT = Price;
            Quantite = Quantity;
            Marque = Brand;
            SousFamille = ChildFamily;
        }

		public Article()
		{
			Quantite = 0;
		}
	}
}
