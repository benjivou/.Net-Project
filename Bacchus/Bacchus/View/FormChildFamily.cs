using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Model;
using Bacchus.Control;

namespace Bacchus.View
{
    public partial class FormChildFamily : Form
    {
        private SousFamilleControl SFCont = new SousFamilleControl();
        private FamilleControl FCont = new FamilleControl();
        private string InitialName;
        private int InitialRef = -1;
        public bool IsApplicated = false;

        public FormChildFamily()
        {
            InitializeComponent();
            InitBoxes();

            InitialName = null;

            this.Text = "Nouvelle Sous-Famille";
        }

        public FormChildFamily(SousFamille ChildFamily)
        {
            InitializeComponent();
            InitBoxes();

            InitialName = ChildFamily.Nom;
            InitialRef = ChildFamily.RefSousFamille;

            this.Text = "Gestion Sous-Famille";

            NameBox.Text = ChildFamily.Nom;
            FamBox.SelectedIndex = FamBox.FindStringExact(ChildFamily.Famille.Nom);
        }

        public void InitBoxes()
        {
            HashSet<Famille> FList = FCont.GetAll();
            foreach (Famille Family in FList)
            {
                FamBox.Items.Add(Family);
            }
        }

        public bool AreInputOK()
        {
            SousFamille Used = SFCont.GetByName(new SousFamille(NameBox.Text));
            if (Used != null && Used.Nom != InitialName)
            {
                MessageBoxes.DispError("Le nom est déjà utilisé.");
                return false;
            }
            if (NameBox.Text.Replace(" ", "") == "" ||
                FamBox.SelectedItem == null)
            {
                MessageBoxes.DispError("Au moins un champs est vide");
                return false;
            }
            return true;
        }

        private SousFamille GetChildFamily()
        {
            return new SousFamille(NameBox.Text,(Famille) FamBox.SelectedItem, InitialRef);
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (AreInputOK())
            {
                IsApplicated = true;

                if (InitialName != null)
                    SFCont.Update(GetChildFamily());
                else
                {
                    SFCont.Insert(GetChildFamily());
                }
                Close();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
