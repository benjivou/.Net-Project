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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tous les articles");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Familles");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Marques");
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActualiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DevelopTool = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeTool = new System.Windows.Forms.ToolStripMenuItem();
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
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            this.RightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FichierToolStripMenuItem,
            this.affichageToolStripMenuItem});
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
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DevelopTool,
            this.MinimizeTool});
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.affichageToolStripMenuItem.Text = "Affichage";
            // 
            // DevelopTool
            // 
            this.DevelopTool.Name = "DevelopTool";
            this.DevelopTool.Size = new System.Drawing.Size(170, 22);
            this.DevelopTool.Text = "Développer l\'arbre";
            this.DevelopTool.Click += new System.EventHandler(this.DevelopTool_Click);
            // 
            // MinimizeTool
            // 
            this.MinimizeTool.Name = "MinimizeTool";
            this.MinimizeTool.Size = new System.Drawing.Size(170, 22);
            this.MinimizeTool.Text = "Minimiser l\'arbre";
            this.MinimizeTool.Click += new System.EventHandler(this.MinimizeTool_Click);
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
            treeNode1.Name = "AllNode";
            treeNode1.Text = "Tous les articles";
            treeNode2.Name = "FamilyNode";
            treeNode2.Text = "Familles";
            treeNode3.Name = "BrandNode";
            treeNode3.Text = "Marques";
            this.TypeTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
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
            this.DisplayList.ContextMenuStrip = this.RightClickMenu;
            this.DisplayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DisplayList.HideSelection = false;
            this.DisplayList.Location = new System.Drawing.Point(0, 0);
            this.DisplayList.Name = "DisplayList";
            this.DisplayList.Size = new System.Drawing.Size(344, 410);
            this.DisplayList.TabIndex = 0;
            this.DisplayList.UseCompatibleStateImageBehavior = false;
            this.DisplayList.View = System.Windows.Forms.View.Details;
            this.DisplayList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.DisplayList_ColumnClick);
            this.DisplayList.DoubleClick += new System.EventHandler(this.DisplayList_DoubleClick);
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.Size = new System.Drawing.Size(130, 70);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 456);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            this.RightClickMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DevelopTool;
        private System.Windows.Forms.ToolStripMenuItem MinimizeTool;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
    }
}

