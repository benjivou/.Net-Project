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

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelectCsvBtn_Click(object sender, EventArgs e)
        {
            if(CsvName.Text == "" || CsvName.Text.Contains(" "))
            {
                DialogResult result = MessageBox.Show(
                    "ERREUR : Le nom du fichier n'est pas valide ou contient des espaces",
                    "Erreur",
                    MessageBoxButtons.OK);
            }
            else
            {
                // change initial directory
                SaveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                SaveDialog.FileName = CsvName.Text + ".csv";
                if (SaveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (FileControl.ExportFile(SaveDialog.FileName))
                    {
                        DialogResult result = MessageBox.Show(
                        "L'export est terminé",
                        "Confirmation",
                        MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                        "Une erreur est survenue.",
                        "Erreur",
                        MessageBoxButtons.OK);
                    }
                }
            }            
        }
    }
}
