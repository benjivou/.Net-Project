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
        MarqueControl MCont = new MarqueControl();
        FamilleControl FCont = new FamilleControl();
        public FormImport()
        {
            InitializeComponent();
        }

        private void InitProgressBar()
        {
            ImportProgress.Minimum = 1;
            ImportProgress.Value = 1;
            ImportProgress.Step = 1;
            ImportProgress.Visible = true;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckPath()
        {
            if (CsvPathText.Text == "" || CsvPathText.Text.Contains(" "))
            {
                MessageBoxes.DispError("ERREUR : Le nom du fichier n'est pas valide ou contient des espaces");
                return false;
            }
            return true;
        }

        private void AddModeBtn_Click(object sender, EventArgs e)
        {
            if (CheckPath())
            {
                if (File.Exists(CsvPathText.Text))
                {
                    InitProgressBar();
                    ImportLab.Text = "Importation de la nouvelle base de données en cours...";
                    ImportLab.Visible = true;
                    LaunchImport();
                }
                else
                {
                    MessageBoxes.DispError("ERREUR : Le fichier csv n'existe pas");
                }
            }
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

        private void EcrasementBtn_Click(object sender, EventArgs e)
        {
            if (CheckPath())
            {
                if (File.Exists(CsvPathText.Text))
                {
                    InitProgressBar();
                    ImportLab.Text = "Suppression de tout les éléments actuels en cours...";
                    ImportLab.Visible = true;
                    MCont.FlushTable();
                    FCont.FlushTable();
                    ImportLab.Text = "Importation de la nouvelle base de données en cours...";
                    ImportLab.Refresh();
                    LaunchImport();
                }
                else
                {
                    MessageBoxes.DispError("ERREUR : Le fichier csv n'existe pas");
                }
            }
        }

        public void LaunchImport()
        {
            if (FileControl.ImportFile(CsvPathText.Text, ImportProgress))
            {
                MessageBoxes.DispInfo("L'ajout est terminé");
                this.Close();
            }
            else
            {
                MessageBoxes.DispError(
                    "Une erreur est survenue lors de l'import. " +
                    "Le fichier est suremement utilisé par une autre application ou le format n'est pas correct");
                ImportLab.Text = "L'opération a été intérompu, veuillez réessayer";
            }
        }
    }
}
