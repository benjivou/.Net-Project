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
    /// Window to choose a name, new one or modify one
    /// </summary>
    public partial class FormName : Form
    {
        /// <summary>
        /// New name written by the user
        /// </summary>
        public string NewName = null;
        /// <summary>
        /// Name before modification
        /// </summary>
        private string InitialName;
        /// <summary>
        /// If the user valide his choice
        /// </summary>
        public bool IsApplicated = false;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="ActualName"></param>
        public FormName(string Title, string ActualName)
        {
            InitializeComponent();
            this.Text = Title;
            NameBox.Text = ActualName;
            InitialName = ActualName;
        }

        /// <summary>
        /// When okbtn is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKBtn_Click(object sender, EventArgs e)
        {
            if(AreInputOK() == false)
            {
                MessageBoxes.DispError("Le champs ne peut pas etre vide");
            }
            else
            {
                NewName = NameBox.Text;
                if (InitialName != NewName)
                    IsApplicated = true;
                this.Close();
            }
        }

        /// <summary>
        /// When backbtn is pressed, close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            IsApplicated = false;
            this.Close();
        }
        
        /// <summary>
        /// Check if input are correct
        /// </summary>
        /// <returns></returns>
        public bool AreInputOK()
        {
            if (NameBox.Text.Replace(" ", "") == "")
                return false;
            return true;
        }
    }
}
