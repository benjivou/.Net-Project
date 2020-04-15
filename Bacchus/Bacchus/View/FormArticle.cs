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
    public partial class FormArticle : Form
    {
        private SousFamilleControl SFCont = new SousFamilleControl();
        private MarqueControl MCont = new MarqueControl();
        private ArticleControl ACont = new ArticleControl();
        private string InitialRef;
        public bool IsApplicated = false;

        public FormArticle()
        {
            InitializeComponent();
            InitBoxes();

            InitialRef = "";

            this.Text = "Nouvel article";
        }

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

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
