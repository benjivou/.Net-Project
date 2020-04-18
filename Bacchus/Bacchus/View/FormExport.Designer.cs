namespace Bacchus.View
{
    partial class FormExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ExportLab = new System.Windows.Forms.Label();
            this.ExportProgress = new System.Windows.Forms.ProgressBar();
            this.BackBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SaveCsvBtn = new System.Windows.Forms.Button();
            this.CsvName = new System.Windows.Forms.TextBox();
            this.FileLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.ExportLab, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ExportProgress, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.BackBtn, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.81818F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.18182F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(356, 74);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // ExportLab
            // 
            this.ExportLab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportLab.Location = new System.Drawing.Point(3, 0);
            this.ExportLab.Name = "ExportLab";
            this.ExportLab.Size = new System.Drawing.Size(350, 25);
            this.ExportLab.TabIndex = 0;
            this.ExportLab.Text = "Veuillez choisir un nom ainsi qu\'un répertoire";
            this.ExportLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExportProgress
            // 
            this.ExportProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportProgress.Location = new System.Drawing.Point(3, 28);
            this.ExportProgress.Name = "ExportProgress";
            this.ExportProgress.Size = new System.Drawing.Size(350, 13);
            this.ExportProgress.TabIndex = 1;
            // 
            // BackBtn
            // 
            this.BackBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BackBtn.Location = new System.Drawing.Point(140, 48);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 2;
            this.BackBtn.Text = "Retour";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.91667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.08334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.Controls.Add(this.SaveCsvBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CsvName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FileLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.29167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(356, 43);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // SaveCsvBtn
            // 
            this.SaveCsvBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SaveCsvBtn.Location = new System.Drawing.Point(266, 10);
            this.SaveCsvBtn.Name = "SaveCsvBtn";
            this.SaveCsvBtn.Size = new System.Drawing.Size(65, 23);
            this.SaveCsvBtn.TabIndex = 0;
            this.SaveCsvBtn.Text = "Enregistrer";
            this.SaveCsvBtn.UseVisualStyleBackColor = true;
            this.SaveCsvBtn.Click += new System.EventHandler(this.SelectCsvBtn_Click);
            // 
            // CsvName
            // 
            this.CsvName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CsvName.Location = new System.Drawing.Point(89, 11);
            this.CsvName.Name = "CsvName";
            this.CsvName.Size = new System.Drawing.Size(171, 20);
            this.CsvName.TabIndex = 2;
            // 
            // FileLabel
            // 
            this.FileLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FileLabel.Location = new System.Drawing.Point(5, 10);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(78, 23);
            this.FileLabel.TabIndex = 1;
            this.FileLabel.Text = "Nom du fichier:";
            this.FileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(356, 0);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // SaveDialog
            // 
            this.SaveDialog.FileName = "exported.csv";
            this.SaveDialog.Filter = "CSV documents (.csv)|*.csv";
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 115);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.MaximizeBox = false;
            this.Name = "FormExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exporter";
            this.Load += new System.EventHandler(this.FormExport_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label ExportLab;
        private System.Windows.Forms.ProgressBar ExportProgress;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SaveCsvBtn;
        private System.Windows.Forms.TextBox CsvName;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
    }
}