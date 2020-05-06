using Bacchus.Control;
using Bacchus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.View
{
    /// <summary>
    /// Window to modify or create an article
    /// </summary>
    public partial class FormArticle : Form
    {
        // Controlers
        private SousFamilleControl SFCont = new SousFamilleControl();
        private MarqueControl MCont = new MarqueControl();
        private ArticleControl ACont = new ArticleControl();

        /// <summary>
        /// Reference before the modification
        /// </summary>
        private string InitialRef;
        /// <summary>
        /// If the user choose to valide his choice
        /// </summary>
        public bool IsApplicated = false;
        
        /// <summary>
        /// Construtor to create an article
        /// </summary>
        public FormArticle()
        {
            InitializeComponent();
            InitBoxes();

            InitialRef = "";

            this.Text = "Nouvel article";
        }

        /// <summary>
        /// Constructor to modifie an article
        /// </summary>
        /// <param name="Arti">Article to modifie</param>
        public FormArticle(Article Arti)
        {
            InitializeComponent();
            InitBoxes();

            InitialRef = Arti.RefArticle;

            this.Text = "Gestion article";

            DescriptionBox.Text = Arti.Description;
            RefBox.Text = Arti.RefArticle;
            BrandBox.SelectedIndex = BrandBox.FindStringExact(Arti.Marque.Nom);
            ChildFamilyBox.SelectedIndex = ChildFamilyBox.FindStringExact(Arti.SousFamille.Nom);
            PriceBox.Value = (Decimal) Arti.PrixHT;
            QuantityBox.Value = (Decimal) Arti.Quantite;
        }

        /// <summary>
        /// Initialize the comboxes with existant Brand and Child Family
        /// </summary>
        public void InitBoxes()
        {
            HashSet<SousFamille> SFList = SFCont.GetAll();
            foreach (SousFamille ChildFamily in SFList)
            {
                ChildFamilyBox.Items.Add(ChildFamily);
            }

            HashSet<Marque> BList = MCont.GetAll();
            foreach (Marque ChildFamily in BList)
            {
                 BrandBox.Items.Add(ChildFamily);
            }

        }

        /// <summary>
        /// Get the article with fields
        /// </summary>
        /// <returns>The article using fields</returns>
        public Article GetArticle()
        {
            Article Arti = new Article();
            Arti.Description = DescriptionBox.Text;
            Arti.RefArticle = RefBox.Text;
            Arti.Marque = (Marque) BrandBox.SelectedItem;
            Arti.SousFamille = (SousFamille) ChildFamilyBox.SelectedItem;
            Arti.PrixHT = (float) PriceBox.Value;
            Arti.Quantite = (int) QuantityBox.Value;
            
            return Arti;
        }
        
        /// <summary>
        /// When OkBtn is pushed
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event arg</param>
        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (AreInputOK())
            {
                IsApplicated = true;

                if (InitialRef == RefBox.Text)
                    ACont.Update(GetArticle());
                else
                {
                    ACont.Insert(GetArticle());
                    if(InitialRef != "")
                        ACont.Delete(new Article(InitialRef, null, 0, 0, null, null));
                }
                Close();
            }
        }

        /// <summary>
        /// Check if the fields are OK
        /// </summary>
        /// <returns>true if ok</returns>
        public bool AreInputOK()
        {
            Article Used = ACont.GetByName(new Article(RefBox.Text, null, 0, 0, null, null));
            if (Used != null && Used.RefArticle != InitialRef)
            {
                MessageBoxes.DispError("La référence est déjà utilisée.");
                return false;
            }
            if(DescriptionBox.Text.Replace(" ","") == "" ||
                RefBox.Text.Replace(" ", "") == "" ||
                BrandBox.SelectedItem == null ||
                ChildFamilyBox.SelectedItem == null)
            {
                MessageBoxes.DispError("Au moins un champs est vide");
                return false;
            }
            return true;
        }

        /// <summary>
        /// When backbtn is pressed
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">event arg</param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
