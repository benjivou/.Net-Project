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
            this.ImportLab = new System.Windows.Forms.Label();
            this.ImportProgress = new System.Windows.Forms.ProgressBar();
            this.BackBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SelectCsvBtn = new System.Windows.Forms.Button();
            this.CsvPathText = new System.Windows.Forms.TextBox();
            this.FileLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.EcrasementBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.ImportLab, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ImportProgress, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.BackBtn, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 109);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.37931F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.62069F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(337, 74);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // ImportLab
            // 
            this.ImportLab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportLab.Location = new System.Drawing.Point(3, 0);
            this.ImportLab.Name = "ImportLab";
            this.ImportLab.Size = new System.Drawing.Size(331, 14);
            this.ImportLab.TabIndex = 0;
            this.ImportLab.Text = "Importation :";
            this.ImportLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImportProgress
            // 
            this.ImportProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportProgress.Location = new System.Drawing.Point(3, 17);
            this.ImportProgress.Name = "ImportProgress";
            this.ImportProgress.Size = new System.Drawing.Size(331, 14);
            this.ImportProgress.TabIndex = 1;
            // 
            // BackBtn
            // 
            this.BackBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BackBtn.Location = new System.Drawing.Point(131, 48);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 2;
            this.BackBtn.Text = "Retour";
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.91667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.08334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.SelectCsvBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.CsvPathText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FileLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.29167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(337, 43);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // SelectCsvBtn
            // 
            this.SelectCsvBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SelectCsvBtn.Location = new System.Drawing.Point(259, 7);
            this.SelectCsvBtn.Name = "SelectCsvBtn";
            this.SelectCsvBtn.Size = new System.Drawing.Size(65, 28);
            this.SelectCsvBtn.TabIndex = 0;
            this.SelectCsvBtn.Text = "Ouvrir";
            this.SelectCsvBtn.UseVisualStyleBackColor = true;
            // 
            // CsvPathText
            // 
            this.CsvPathText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CsvPathText.Location = new System.Drawing.Point(87, 11);
            this.CsvPathText.Name = "CsvPathText";
            this.CsvPathText.Size = new System.Drawing.Size(166, 20);
            this.CsvPathText.TabIndex = 2;
            // 
            // FileLabel
            // 
            this.FileLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FileLabel.Location = new System.Drawing.Point(3, 10);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(78, 23);
            this.FileLabel.TabIndex = 1;
            this.FileLabel.Text = "Fichier csv :";
            this.FileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.EcrasementBtn, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(337, 66);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // EcrasementBtn
            // 
            this.EcrasementBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EcrasementBtn.Location = new System.Drawing.Point(112, 6);
            this.EcrasementBtn.Name = "EcrasementBtn";
            this.EcrasementBtn.Size = new System.Drawing.Size(113, 53);
            this.EcrasementBtn.TabIndex = 1;
            this.EcrasementBtn.Text = "Exporter";
            this.EcrasementBtn.UseVisualStyleBackColor = true;
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 183);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "FormExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exporter";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label ImportLab;
        private System.Windows.Forms.ProgressBar ImportProgress;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SelectCsvBtn;
        private System.Windows.Forms.TextBox CsvPathText;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button EcrasementBtn;
    }
}