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
    public partial class FormExport : Form
    {
        public FormExport()
        {
            InitializeComponent();

        }

        private void InitProgressBar()
        {
            ExportProgress.Minimum = 1;
            ExportProgress.Value = 1;
            ExportProgress.Step = 1;
            ExportProgress.Visible = true;
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectCsvBtn_Click(object sender, EventArgs e)
        {
            if(CsvName.Text == "" || CsvName.Text.Contains(" "))
            {
                MessageBoxes.DispError("ERREUR : Le nom du fichier n'est pas valide ou contient des espaces");
            }
            else
            {
                // change initial directory
                SaveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                SaveDialog.FileName = CsvName.Text + ".csv";
                if (SaveDialog.ShowDialog() == DialogResult.OK)
                {
                    InitProgressBar();
                    ExportLab.Text = "Exportation de la base de données en cours...";
                    ExportLab.Visible = true;
                    if (FileControl.ExportFile(SaveDialog.FileName,ExportProgress))
                    {
                        MessageBoxes.DispConfirmation("L'export est terminé");
                        this.Close();
                    }
                    else
                    {
                        MessageBoxes.DispError("Une erreur est survenue lors de l'exportation");
                        ExportLab.Text = "L'opération a été intérompu, veuillez réessayer";
                    }
                }
            }            
        }
    }
}
