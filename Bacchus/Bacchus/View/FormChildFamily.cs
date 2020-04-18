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
    /// <summary>
    /// Window to create or modify a childFamily
    /// </summary>
    public partial class FormChildFamily : Form
    {
        private SousFamilleControl SFCont = new SousFamilleControl();
        private FamilleControl FCont = new FamilleControl();
        /// <summary>
        /// Ref brefore modification
        /// </summary>
        private string InitialName;
        /// <summary>
        /// Ref before modification
        /// </summary>
        private int InitialRef = -1;
        /// <summary>
        /// If the user valide his choice
        /// </summary>
        public bool IsApplicated = false;

        /// <summary>
        /// Constructor for create window
        /// </summary>
        public FormChildFamily()
        {
            InitializeComponent();
            InitBoxes();

            InitialName = null;

            this.Text = "Nouvelle Sous-Famille";
        }

        /// <summary>
        /// Constructor for a modification window
        /// </summary>
        /// <param name="ChildFamily"></param>
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

        /// <summary>
        /// Initialize the combobox with existant families
        /// </summary>
        public void InitBoxes()
        {
            HashSet<Famille> FList = FCont.GetAll();
            foreach (Famille Family in FList)
            {
                FamBox.Items.Add(Family);
            }
        }

        /// <summary>
        /// Check if the fields are ok
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get the child family with the input fields
        /// </summary>
        /// <returns></returns>
        public SousFamille GetChildFamily()
        {
            return new SousFamille(NameBox.Text,(Famille) FamBox.SelectedItem, InitialRef);
        }

        /// <summary>
        /// When the Okbtn is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the backbtn is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
