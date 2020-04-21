using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    /// <summary>
    /// Window to import a csv file in tha database
    /// </summary>
    public partial class FormImport : Form
    {
        MarqueControl MCont = new MarqueControl();
        FamilleControl FCont = new FamilleControl();

        /// <summary>
        /// Last path used for export or import
        /// </summary>
        private string LastPath;

        /// <summary>
        /// If the import is a success
        /// </summary>
        public bool ImportSucess = false;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormImport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize progress bar
        /// </summary>
        private void InitProgressBar()
        {
            ImportProgress.Minimum = 1;
            ImportProgress.Value = 1;
            ImportProgress.Step = 1;
            ImportProgress.Visible = true;
        }

        /// <summary>
        /// When the okbtn is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Check if the path give by the user is correct
        /// </summary>
        /// <returns></returns>
        private bool CheckPath()
        {
            if (CsvPathText.Text == "" || CsvPathText.Text.Contains(" "))
            {
                MessageBoxes.DispError("ERREUR : Le nom du fichier n'est pas valide ou contient des espaces");
                return false;
            }
            return true;
        }

        /// <summary>
        /// When the add mode is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the selectcsv btn is pressed, open a select file dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCsvBtn_Click(object sender, EventArgs e)
        {
            // change initial directory
            OpenDialog.InitialDirectory = LastPath;
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                CsvPathText.Text = OpenDialog.FileName;
                // save the path
                LastPath = CsvPathText.Text;
                SaveLastPath();
            }
        }

        /// <summary>
        /// Save the last path used form the import
        /// </summary>
        private void SaveLastPath()
        {
            var Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // We will use custom settings
            Config.AppSettings.Settings["DefaultPath"].Value = "0";
            Config.AppSettings.Settings["LastPath"].Value = LastPath;
            // Final Save
            Config.Save(ConfigurationSaveMode.Full);
        }

        /// <summary>
        /// When ecresement mode is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Launch the importation
        /// </summary>
        private void LaunchImport()
        {
            if (FileControl.ImportFile(CsvPathText.Text, ImportProgress))
            {
                MessageBoxes.DispInfo("L'ajout est terminé");
                ImportSucess = true;
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

        /// <summary>
        /// Load form settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormImport_Load(object sender, EventArgs e)
        {
            var Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (int.Parse(Config.AppSettings.Settings["DefaultPath"].Value) != 1)
            {
                LastPath = Config.AppSettings.Settings["LastPath"].Value;
            }
            else
            {
                LastPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
        }
    }
}
