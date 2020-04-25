namespace Bacchus.View
{
    partial class FormArticle
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.QuantityBox = new System.Windows.Forms.NumericUpDown();
            this.ChildFamilyBox = new System.Windows.Forms.ComboBox();
            this.RefBox = new System.Windows.Forms.TextBox();
            this.DescriptionLab = new System.Windows.Forms.Label();
            this.RefLab = new System.Windows.Forms.Label();
            this.BrandLab = new System.Windows.Forms.Label();
            this.ChildFamilyLab = new System.Windows.Forms.Label();
            this.PriceLab = new System.Windows.Forms.Label();
            this.QuantityLab = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.BrandBox = new System.Windows.Forms.ComboBox();
            this.PriceBox = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BackBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.tableLayoutPanel1.Controls.Add(this.QuantityBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ChildFamilyBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.RefBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionLab, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RefLab, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BrandLab, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ChildFamilyLab, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PriceLab, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.QuantityLab, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BrandBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PriceBox, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(287, 351);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // QuantityBox
            // 
            this.QuantityBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.QuantityBox.Location = new System.Drawing.Point(89, 314);
            this.QuantityBox.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(69, 20);
            this.QuantityBox.TabIndex = 11;
            // 
            // ChildFamilyBox
            // 
            this.ChildFamilyBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChildFamilyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChildFamilyBox.FormattingEnabled = true;
            this.ChildFamilyBox.Location = new System.Drawing.Point(89, 204);
            this.ChildFamilyBox.Name = "ChildFamilyBox";
            this.ChildFamilyBox.Size = new System.Drawing.Size(121, 21);
            this.ChildFamilyBox.TabIndex = 9;
            // 
            // RefBox
            // 
            this.RefBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RefBox.Location = new System.Drawing.Point(89, 92);
            this.RefBox.Multiline = true;
            this.RefBox.Name = "RefBox";
            this.RefBox.Size = new System.Drawing.Size(121, 22);
            this.RefBox.TabIndex = 7;
            // 
            // DescriptionLab
            // 
            this.DescriptionLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLab.AutoSize = true;
            this.DescriptionLab.Location = new System.Drawing.Point(17, 10);
            this.DescriptionLab.Name = "DescriptionLab";
            this.DescriptionLab.Size = new System.Drawing.Size(66, 13);
            this.DescriptionLab.TabIndex = 0;
            this.DescriptionLab.Text = "Description :";
            // 
            // RefLab
            // 
            this.RefLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RefLab.AutoSize = true;
            this.RefLab.Location = new System.Drawing.Point(20, 96);
            this.RefLab.Name = "RefLab";
            this.RefLab.Size = new System.Drawing.Size(63, 13);
            this.RefLab.TabIndex = 1;
            this.RefLab.Text = "Référence :";
            // 
            // BrandLab
            // 
            this.BrandLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BrandLab.AutoSize = true;
            this.BrandLab.Location = new System.Drawing.Point(34, 153);
            this.BrandLab.Name = "BrandLab";
            this.BrandLab.Size = new System.Drawing.Size(49, 13);
            this.BrandLab.TabIndex = 2;
            this.BrandLab.Text = "Marque :";
            // 
            // ChildFamilyLab
            // 
            this.ChildFamilyLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ChildFamilyLab.AutoSize = true;
            this.ChildFamilyLab.Location = new System.Drawing.Point(11, 208);
            this.ChildFamilyLab.Name = "ChildFamilyLab";
            this.ChildFamilyLab.Size = new System.Drawing.Size(72, 13);
            this.ChildFamilyLab.TabIndex = 3;
            this.ChildFamilyLab.Text = "Sous-Famille :";
            // 
            // PriceLab
            // 
            this.PriceLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PriceLab.AutoSize = true;
            this.PriceLab.Location = new System.Drawing.Point(53, 264);
            this.PriceLab.Name = "PriceLab";
            this.PriceLab.Size = new System.Drawing.Size(30, 13);
            this.PriceLab.TabIndex = 4;
            this.PriceLab.Text = "Prix :";
            // 
            // QuantityLab
            // 
            this.QuantityLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.QuantityLab.AutoSize = true;
            this.QuantityLab.Location = new System.Drawing.Point(30, 318);
            this.QuantityLab.Name = "QuantityLab";
            this.QuantityLab.Size = new System.Drawing.Size(53, 13);
            this.QuantityLab.TabIndex = 5;
            this.QuantityLab.Text = "Quantité :";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DescriptionBox.Location = new System.Drawing.Point(89, 13);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(187, 58);
            this.DescriptionBox.TabIndex = 6;
            // 
            // BrandBox
            // 
            this.BrandBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BrandBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BrandBox.FormattingEnabled = true;
            this.BrandBox.Location = new System.Drawing.Point(89, 149);
            this.BrandBox.Name = "BrandBox";
            this.BrandBox.Size = new System.Drawing.Size(121, 21);
            this.BrandBox.TabIndex = 8;
            // 
            // PriceBox
            // 
            this.PriceBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PriceBox.DecimalPlaces = 2;
            this.PriceBox.Location = new System.Drawing.Point(89, 260);
            this.PriceBox.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(69, 20);
            this.PriceBox.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BackBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.OKBtn, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 349);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(287, 48);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // BackBtn
            // 
            this.BackBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackBtn.Location = new System.Drawing.Point(177, 12);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 0;
            this.BackBtn.Text = "Annuler";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OKBtn.Location = new System.Drawing.Point(34, 12);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "Appliquer";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // FormArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 397);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormArticle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormArticle";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox ChildFamilyBox;
        private System.Windows.Forms.TextBox RefBox;
        private System.Windows.Forms.Label DescriptionLab;
        private System.Windows.Forms.Label RefLab;
        private System.Windows.Forms.Label BrandLab;
        private System.Windows.Forms.Label ChildFamilyLab;
        private System.Windows.Forms.Label PriceLab;
        private System.Windows.Forms.Label QuantityLab;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.ComboBox BrandBox;
        private System.Windows.Forms.NumericUpDown PriceBox;
        private System.Windows.Forms.NumericUpDown QuantityBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button OKBtn;
    }
}