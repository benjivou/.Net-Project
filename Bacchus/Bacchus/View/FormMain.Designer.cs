namespace Bacchus
{
    partial class FormMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Tous les articles");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Familles");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Marques");
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActualiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.NbArticles = new System.Windows.Forms.ToolStripStatusLabel();
            this.NbFamilles = new System.Windows.Forms.ToolStripStatusLabel();
            this.NbSousFamilles = new System.Windows.Forms.ToolStripStatusLabel();
            this.NbMarques = new System.Windows.Forms.ToolStripStatusLabel();
            this.Splitter = new System.Windows.Forms.SplitContainer();
            this.TypeTree = new System.Windows.Forms.TreeView();
            this.DisplayList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FichierToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(548, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // FichierToolStripMenuItem
            // 
            this.FichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActualiserToolStripMenuItem,
            this.ImporterToolStripMenuItem,
            this.ExporterToolStripMenuItem});
            this.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem";
            this.FichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.FichierToolStripMenuItem.Text = "Fichier";
            // 
            // ActualiserToolStripMenuItem
            // 
            this.ActualiserToolStripMenuItem.Name = "ActualiserToolStripMenuItem";
            this.ActualiserToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ActualiserToolStripMenuItem.Text = "Actualiser";
            this.ActualiserToolStripMenuItem.Click += new System.EventHandler(this.ActualiserToolStripMenuItem_Click);
            // 
            // ImporterToolStripMenuItem
            // 
            this.ImporterToolStripMenuItem.Name = "ImporterToolStripMenuItem";
            this.ImporterToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ImporterToolStripMenuItem.Text = "Importer";
            this.ImporterToolStripMenuItem.Click += new System.EventHandler(this.ImporterToolStripMenuItem_Click);
            // 
            // ExporterToolStripMenuItem
            // 
            this.ExporterToolStripMenuItem.Name = "ExporterToolStripMenuItem";
            this.ExporterToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ExporterToolStripMenuItem.Text = "Exporter";
            this.ExporterToolStripMenuItem.Click += new System.EventHandler(this.ExporterToolStripMenuItem_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NbArticles,
            this.NbFamilles,
            this.NbSousFamilles,
            this.NbMarques});
            this.StatusStrip.Location = new System.Drawing.Point(0, 434);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(548, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "StatusStrip";
            // 
            // NbArticles
            // 
            this.NbArticles.Name = "NbArticles";
            this.NbArticles.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.NbArticles.Size = new System.Drawing.Size(65, 17);
            this.NbArticles.Text = "Articles : ";
            // 
            // NbFamilles
            // 
            this.NbFamilles.Name = "NbFamilles";
            this.NbFamilles.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.NbFamilles.Size = new System.Drawing.Size(66, 17);
            this.NbFamilles.Text = "Familles :";
            // 
            // NbSousFamilles
            // 
            this.NbSousFamilles.Name = "NbSousFamilles";
            this.NbSousFamilles.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.NbSousFamilles.Size = new System.Drawing.Size(99, 17);
            this.NbSousFamilles.Text = "Sous-Familles : ";
            // 
            // NbMarques
            // 
            this.NbMarques.Name = "NbMarques";
            this.NbMarques.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.NbMarques.Size = new System.Drawing.Size(72, 17);
            this.NbMarques.Text = "Marques : ";
            // 
            // Splitter
            // 
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter.Location = new System.Drawing.Point(0, 24);
            this.Splitter.Name = "Splitter";
            // 
            // Splitter.Panel1
            // 
            this.Splitter.Panel1.Controls.Add(this.TypeTree);
            this.Splitter.Panel1MinSize = 200;
            // 
            // Splitter.Panel2
            // 
            this.Splitter.Panel2.Controls.Add(this.DisplayList);
            this.Splitter.Size = new System.Drawing.Size(548, 410);
            this.Splitter.SplitterDistance = 200;
            this.Splitter.TabIndex = 2;
            // 
            // TypeTree
            // 
            this.TypeTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeTree.Location = new System.Drawing.Point(0, 0);
            this.TypeTree.Name = "TypeTree";
            treeNode4.Name = "AllNode";
            treeNode4.Text = "Tous les articles";
            treeNode5.Name = "FamilyNode";
            treeNode5.Text = "Familles";
            treeNode6.Name = "BrandNode";
            treeNode6.Text = "Marques";
            this.TypeTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.TypeTree.Size = new System.Drawing.Size(200, 410);
            this.TypeTree.TabIndex = 0;
            this.TypeTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TypeTree_AfterSelect);
            // 
            // DisplayList
            // 
            this.DisplayList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.DisplayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayList.GridLines = true;
            this.DisplayList.HideSelection = false;
            this.DisplayList.Location = new System.Drawing.Point(0, 0);
            this.DisplayList.Name = "DisplayList";
            this.DisplayList.Size = new System.Drawing.Size(344, 410);
            this.DisplayList.TabIndex = 0;
            this.DisplayList.UseCompatibleStateImageBehavior = false;
            this.DisplayList.View = System.Windows.Forms.View.Details;
            this.DisplayList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.DisplayList_ColumnClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 456);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application";
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripMenuItem FichierToolStripMenuItem;
        private System.Windows.Forms.SplitContainer Splitter;
        private System.Windows.Forms.TreeView TypeTree;
        private System.Windows.Forms.ListView DisplayList;
        private System.Windows.Forms.ToolStripMenuItem ActualiserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel NbArticles;
        private System.Windows.Forms.ToolStripStatusLabel NbFamilles;
        private System.Windows.Forms.ToolStripStatusLabel NbSousFamilles;
        private System.Windows.Forms.ToolStripStatusLabel NbMarques;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

