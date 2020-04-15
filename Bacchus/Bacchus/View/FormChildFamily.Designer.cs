namespace Bacchus.View
{
    partial class FormChildFamily
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
            this.TopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NameLab = new System.Windows.Forms.Label();
            this.FamLab = new System.Windows.Forms.Label();
            this.FamBox = new System.Windows.Forms.ComboBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.BottPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.TopPanel.SuspendLayout();
            this.BottPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.ColumnCount = 2;
            this.TopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.83221F));
            this.TopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.16779F));
            this.TopPanel.Controls.Add(this.NameLab, 0, 0);
            this.TopPanel.Controls.Add(this.FamLab, 0, 1);
            this.TopPanel.Controls.Add(this.FamBox, 1, 1);
            this.TopPanel.Controls.Add(this.NameBox, 1, 0);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.RowCount = 2;
            this.TopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TopPanel.Size = new System.Drawing.Size(298, 100);
            this.TopPanel.TabIndex = 0;
            // 
            // NameLab
            // 
            this.NameLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameLab.AutoSize = true;
            this.NameLab.Location = new System.Drawing.Point(32, 18);
            this.NameLab.Name = "NameLab";
            this.NameLab.Size = new System.Drawing.Size(38, 13);
            this.NameLab.TabIndex = 0;
            this.NameLab.Text = "Nom : ";
            // 
            // FamLab
            // 
            this.FamLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FamLab.AutoSize = true;
            this.FamLab.Location = new System.Drawing.Point(25, 68);
            this.FamLab.Name = "FamLab";
            this.FamLab.Size = new System.Drawing.Size(45, 13);
            this.FamLab.TabIndex = 1;
            this.FamLab.Text = "Famille :";
            // 
            // FamBox
            // 
            this.FamBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FamBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamBox.FormattingEnabled = true;
            this.FamBox.Location = new System.Drawing.Point(76, 64);
            this.FamBox.Name = "FamBox";
            this.FamBox.Size = new System.Drawing.Size(199, 21);
            this.FamBox.TabIndex = 2;
            // 
            // NameBox
            // 
            this.NameBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NameBox.Location = new System.Drawing.Point(76, 15);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(199, 20);
            this.NameBox.TabIndex = 3;
            // 
            // BottPanel
            // 
            this.BottPanel.ColumnCount = 2;
            this.BottPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BottPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BottPanel.Controls.Add(this.CancelBtn, 1, 0);
            this.BottPanel.Controls.Add(this.OKBtn, 0, 0);
            this.BottPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottPanel.Location = new System.Drawing.Point(0, 97);
            this.BottPanel.Name = "BottPanel";
            this.BottPanel.RowCount = 1;
            this.BottPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BottPanel.Size = new System.Drawing.Size(298, 46);
            this.BottPanel.TabIndex = 1;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelBtn.Location = new System.Drawing.Point(186, 11);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 0;
            this.CancelBtn.Text = "Annuler";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKBtn.Location = new System.Drawing.Point(37, 11);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "Appliquer";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // FormChildFamily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 143);
            this.Controls.Add(this.BottPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "FormChildFamily";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormChildFamily";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TopPanel;
        private System.Windows.Forms.Label NameLab;
        private System.Windows.Forms.Label FamLab;
        private System.Windows.Forms.ComboBox FamBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TableLayoutPanel BottPanel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
    }
}