using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Control;

namespace Bacchus.View
{
    public partial class FormImport : Form
    {

        public FormImport()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddModeBtn_Click(object sender, EventArgs e)
        {
            if (CsvPathText.Text == "")
            {
                DialogResult result = MessageBox.Show(
                    "ERREUR : Veuillez selectionner un fichier csv",
                    "Erreur",
                    MessageBoxButtons.OK);
            }
            else
            {
                if (File.Exists(CsvPathText.Text))
                {
                    FileControl.ImportFile(CsvPathText.Text);
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        "ERREUR : Le fichier csv n'existe pas",
                        "Erreur",
                        MessageBoxButtons.OK);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectCsvBtn_Click(object sender, EventArgs e)
        {
            // change initial directory
            OpenDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                CsvPathText.Text = OpenDialog.FileName;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
