using Bacchus.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bacchus.Model;
using Bacchus.Control;
using System.Collections;

namespace Bacchus
{
    public partial class FormMain : Form
    {
        MarqueControl MCont = new MarqueControl();
        FamilleControl FCont = new FamilleControl();
        SousFamilleControl SFCont = new SousFamilleControl();
        ArticleControl ACont = new ArticleControl();

        private bool IsRunningXPOrLater = OSFeature.Feature.IsPresent(OSFeature.Themes);

        ListViewGrouper Grouper;

        private int SelectedColumn;

        // The column we are currently using for sorting.
        // private ColumnHeader SortingColumn = null;

        /// <summary>
        /// Initialize window
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            Grouper = new ListViewGrouper(DisplayList);

            RefreshTree();
            RefreshStatusStrip();
            ClearList();
            DispHelp();

            SelectedColumn = 0;
        }

        /// <summary>
        /// Open Import Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport Frame = new FormImport();
            Frame.ShowDialog();
            RefreshAllData();
        }

        /// <summary>
        /// Refresh the treeview
        /// </summary>
        private void RefreshTree()
        {

            HashSet<Marque> BrandList;
            HashSet<Famille> FamilyList;
            HashSet<SousFamille> ChildFamilyList;

            TreeNodeCollection Root = TypeTree.Nodes;
            Root.Clear();

            Root.Add("Tous les articles");

            //Add Families
            TreeNode FamilyNodes = new TreeNode("Familles");
            FamilyList = FCont.GetAll();
            foreach (Famille Family in FamilyList)
            {
                TreeNode FamilyNode = new TreeNode(Family.Nom);
                FamilyNode.Tag = Family;

                //Add Child Families
                ChildFamilyList = SFCont.FindByFamily(Family);
                foreach (SousFamille ChildFamily in ChildFamilyList)
                {
                    TreeNode ChildFamilyNode = new TreeNode(ChildFamily.Nom);
                    ChildFamilyNode.Tag = ChildFamily;
                    FamilyNode.Nodes.Add(ChildFamilyNode);
                }

                FamilyNodes.Nodes.Add(FamilyNode);
            }
            Root.Add(FamilyNodes);

            // Add all brands
            TreeNode BrandNodes = new TreeNode("Marques");
            BrandList = MCont.GetAll();
            foreach(Marque Brand in BrandList)
            {
                TreeNode BrandNode = new TreeNode(Brand.Nom);
                BrandNode.Tag = Brand;
                BrandNodes.Nodes.Add(BrandNode);
            }
            Root.Add(BrandNodes);

            //TypeTree.ExpandAll();
        }

        /// <summary>
        /// Refresh both list and tree views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        private void RefreshAllData()
        {
            RefreshTree();
            RefreshStatusStrip();
            ClearList();
            DispHelp();
        }

        /// <summary>
        /// Display to the user that he can select a node in the tree
        /// </summary>
        private void DispHelp()
        {
            ColumnHeader Header = new ColumnHeader();
            Header.Text = "<-- Sélectionner une section";
            Header.Width = -2;
            DisplayList.Columns.Add(Header);
        }

        /// <summary>
        /// Resfresh the status strip in the bottom
        /// </summary>
        private void RefreshStatusStrip()
        {
            NbArticles.Text = "Articles : " + ACont.GetCountRef();
            NbFamilles.Text = "Familles : " + FCont.GetCountRef();
            NbMarques.Text = "Marques : " + MCont.GetCountRef();
            NbSousFamilles.Text = "Sous-Familles : " + SFCont.GetCountRef();
        }

        /// <summary>
        /// Open Export Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExport Frame = new FormExport();
            Frame.ShowDialog();
        }

        /// <summary>
        /// Event when a node is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshDisplayList();
        }

        /// <summary>
        /// Display all articles in list view
        /// </summary>
        private void DispAllArticles()
        {
            // Items
            HashSet<Article> ArticleList = ACont.GetAll();
            foreach (Article Article in ArticleList)
            {
                ListViewItem Item = new ListViewItem(new string[] {
                    Article.Description,
                    Article.SousFamille.Famille.Nom,
                    Article.SousFamille.Nom,
                    Article.Marque.Nom,
                    Article.Quantite.ToString()
                    }, -1);
                Item.Tag = Article;
                DisplayList.Items.Add(Item);
            }

            // Columns
            SetArticleColumns();
        }

        /// <summary>
        /// Display all articles in list view with a specific child family
        /// </summary>
        /// <param name="ChildFamily"></param>
        private void DispArticles(SousFamille ChildFamily)
        {
            // Items
            HashSet<Article> ArticleList = ACont.FindBySousFamille(ChildFamily);
            foreach (Article Article in ArticleList)
            {
                ListViewItem Item = new ListViewItem(new string[] {
                    Article.Description,
                    Article.SousFamille.Famille.Nom,
                    Article.SousFamille.Nom,
                    Article.Marque.Nom,
                    Article.Quantite.ToString()
                    }, -1);
                Item.Tag = Article;
                DisplayList.Items.Add(Item);
            }

            // Columns
            SetArticleColumns();
        }

        /// <summary>
        /// Display all articles in list view with a specific brand
        /// </summary>
        /// <param name="Brand"></param>
        private void DispArticles(Marque Brand)
        {
            // Items
            HashSet<Article> ArticleList = ACont.FindByMarque(Brand);
            foreach (Article Article in ArticleList)
            {
                ListViewItem Item = new ListViewItem(new string[] {
                    Article.Description,
                    Article.SousFamille.Famille.Nom,
                    Article.SousFamille.Nom,
                    Article.Marque.Nom,
                    Article.Quantite.ToString()
                    }, -1);
                Item.Tag = Article;
                DisplayList.Items.Add(Item);
            }

            // Columns
            SetArticleColumns();
        }

        /// <summary>
        /// Display all brand in the list view
        /// </summary>
        private void DispMarques()
        {
            // Header
            SetDescriptionColumn();

            // Items
            HashSet<Marque> BrandList = MCont.GetAll();
            foreach(Marque Brand in BrandList)
            {
                ListViewItem Item = new ListViewItem(new string[] { Brand.Nom },-1);
                Item.Tag = Brand;
                DisplayList.Items.Add(Item);
            }
        }

        /// <summary>
        /// Display all child Family in the list view
        /// </summary>
        /// <param name="Family"></param>
        private void DispChildFamilies(Famille Family)
        {
            // Header
            SetDescriptionColumn();

            // Items
            HashSet<SousFamille> ChildFamilyList = SFCont.FindByFamily(Family);
            foreach (SousFamille ChildFamily in ChildFamilyList)
            {
                ListViewItem Item = new ListViewItem(new string[] { ChildFamily.Nom }, -1);
                Item.Tag = ChildFamily;
                DisplayList.Items.Add(Item);
            }
        }

        /// <summary>
        /// Display all family in the list view
        /// </summary>
        private void DispFamilies()
        {
            // Header
            SetDescriptionColumn();

            // Items
            HashSet<Famille> FamilyList = FCont.GetAll();
            foreach (Famille Family in FamilyList)
            {
                ListViewItem Item = new ListViewItem(new string[] { Family.Nom }, -1);
                Item.Tag = Family;
                DisplayList.Items.Add(Item);
            }
        }

        /// <summary>
        /// Update column of list view to display articles
        /// </summary>
        private void SetArticleColumns()
        {
            ColumnHeader DescHeader = new ColumnHeader();
            DescHeader.Text = "Description";
            DisplayList.Columns.Add(DescHeader);

            ColumnHeader FamilyHeader = new ColumnHeader();
            FamilyHeader.Text = "Familles";
            DisplayList.Columns.Add(FamilyHeader);

            ColumnHeader ChildFamilyHeader = new ColumnHeader();
            ChildFamilyHeader.Text = "Sous-familles";
            DisplayList.Columns.Add(ChildFamilyHeader);

            ColumnHeader BrandHeader = new ColumnHeader();
            BrandHeader.Text = "Marques";
            DisplayList.Columns.Add(BrandHeader);

            ColumnHeader QuantityHeader = new ColumnHeader();
            QuantityHeader.Text = "Quantité";
            DisplayList.Columns.Add(QuantityHeader);

            AutoResizeColumns();
        }

        /// <summary>
        /// Resize column automaticly 
        /// </summary>
        public void AutoResizeColumns()
        {
            // Auto resize take time and make "noises", so we hide list during loading
            DisplayList.Visible = false;
            DisplayList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            DisplayList.Visible = true;
        }

        /// <summary>
        /// Update column of list view to display families / brand / child family
        /// </summary>
        private void SetDescriptionColumn()
        {
            ColumnHeader Header = new ColumnHeader();
            Header.Text = "Description";
            Header.Width = -2;
            DisplayList.Columns.Add(Header);
        }

        /// <summary>
        /// Clear the list view items and columns
        /// </summary>
        private void ClearList()
        {
            DisplayList.Clear();
            DisplayList.Columns.Clear();
        }
        
        /// <summary>
        /// Event when the window is resized, resize column sizes of the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
           // AutoResizeColumns();
        }

        private void DisplayList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SelectedColumn = e.Column;
            // Set the sort order to ascending when changing
            // column groups; otherwise, reverse the sort order.
            if (DisplayList.Sorting == SortOrder.Descending ||
                (IsRunningXPOrLater && (e.Column != Grouper.GroupColumn)))
            {
                DisplayList.Sorting = SortOrder.Ascending;
            }
            else
            {
                DisplayList.Sorting = SortOrder.Descending;
            }
            Grouper.GroupColumn = e.Column;

            // Set the groups to those created for the clicked column.
            if (IsRunningXPOrLater)
            {
                Grouper.SetGroups(e.Column);
            }
        }

        private void DevelopTool_Click(object sender, EventArgs e)
        {
            TypeTree.ExpandAll();
        }

        private void MinimizeTool_Click(object sender, EventArgs e)
        {
            TypeTree.CollapseAll();
        }

        private void DeleteSelectedItems()
        {
            int NbItem = DisplayList.SelectedItems.Count;
            if (NbItem == 0)
            {
                MessageBoxes.DispError("ERREUR : Vous devez sélectionner au moins un élément avant de le supprimer");
            }
            else
            {
                var Arti = DisplayList.SelectedItems[0].Tag as Article;
                var Brand = DisplayList.SelectedItems[0].Tag as Marque;
                var ChildFamily = DisplayList.SelectedItems[0].Tag as SousFamille;
                var Family = DisplayList.SelectedItems[0].Tag as Famille;

                // Check if it's not an article and alert the user
                if (Arti == null &&
                    MessageBoxes.DispConfirmation("ATTENTION : Les éléments liés à cette sélection seront aussi supprimés")
                    == DialogResult.Cancel)
                {
                    return;
                }

                // For each article selected
                foreach (ListViewItem Item in DisplayList.SelectedItems)
                {
                    Arti = Item.Tag as Article;
                    Brand = Item.Tag as Marque;
                    ChildFamily = Item.Tag as SousFamille;
                    Family = Item.Tag as Famille;

                    if (Arti != null)
                    {
                        ACont.Delete(Arti);
                    }
                    if (Brand != null)
                    {
                        MCont.Delete(Brand);
                    }

                    if (ChildFamily != null)
                    {
                        SFCont.Delete(ChildFamily);
                    }

                    if (Family != null)
                    {
                        FCont.Delete(Family);
                    }
                }
                //Refresh list
                RefreshDisplayList();
                if (Arti == null)
                {
                    //Refresh Tree
                    RefreshTree();
                }
                // Refresh status Bar
                RefreshStatusStrip();
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedItems();
        }

        public void RefreshDisplayList()
        {
            ClearList();
            // No node selected
            if(TypeTree.SelectedNode == null)
            {
                DispHelp();
                return;
            }

            var Brand = TypeTree.SelectedNode.Tag as Marque;
            var ChildFamily = TypeTree.SelectedNode.Tag as SousFamille;
            var Family = TypeTree.SelectedNode.Tag as Famille;

            // Brand node selected
            if (Brand != null)
                DispArticles(Brand);
            // CF Node selected
            else if (ChildFamily != null)
                DispArticles(ChildFamily);
            // F node selected
            else if (Family != null)
                DispChildFamilies(Family);
            // Root node selected
            else
            {
                if (TypeTree.SelectedNode == TypeTree.Nodes[0])
                    DispAllArticles();
                else if (TypeTree.SelectedNode == TypeTree.Nodes[1])
                    DispFamilies();
                else if (TypeTree.SelectedNode == TypeTree.Nodes[2])
                    DispMarques();
                else DispHelp();
            }
            if (IsRunningXPOrLater)
            {
                // Create the groupsTable array and populate it with one 
                // hash table for each column.
                Grouper.GroupTables = new Hashtable[DisplayList.Columns.Count];
                for (int column = 0; column < DisplayList.Columns.Count; column++)
                {
                    // Create a hash table containing all the groups 
                    // needed for a single column.
                    Grouper.GroupTables[column] = Grouper.CreateGroupsTable(column);
                }

                // Start with the groups created for the Title column.
                Grouper.SetGroups(SelectedColumn);
            }
        }
        

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedItems();
            if (e.KeyCode == Keys.F5)
                RefreshAllData();
            if (e.KeyCode == Keys.Enter)
                ModifieSelectedItem();
        }

        private void ModifieSelectedItem()
        {
            int NbItem = DisplayList.SelectedItems.Count;
            if (NbItem != 1)
            {
                MessageBoxes.DispError("ERREUR : Vous devez sélectionner un seul élément");
            }
            else
            {
                var Arti = DisplayList.SelectedItems[0].Tag as Article;
                var Brand = DisplayList.SelectedItems[0].Tag as Marque;
                var ChildFamily = DisplayList.SelectedItems[0].Tag as SousFamille;
                var Family = DisplayList.SelectedItems[0].Tag as Famille;
                
                if (Arti != null)
                {
                    FormArticle ModifiedArticle = new FormArticle(Arti);
                    ModifiedArticle.ShowDialog();
                    if( ModifiedArticle.IsApplicated == true)
                        RefreshDisplayList();
                }
                else if (ChildFamily != null)
                {
                    FormChildFamily ModifiedCF = new FormChildFamily(ChildFamily);
                    ModifiedCF.ShowDialog();
                    if (ModifiedCF.IsApplicated == true)
                    {
                        RefreshDisplayList();
                        RefreshTree();
                    }
                }
                else
                {
                    FormName NameAsked;
                    if (Brand != null)
                    {
                        NameAsked = new FormName("Gestion Marque", Brand.Nom);
                        NameAsked.ShowDialog();
                        if (NameAsked.IsApplicated)
                        {
                            if (Brand.Nom != NameAsked.NewName && MCont.GetByName(new Marque(NameAsked.NewName)) != null)
                            {
                                MessageBoxes.DispError("Le nom est déjà utilisé");
                                NameAsked.IsApplicated = false;
                            }
                            else
                            {
                                Brand.Nom = NameAsked.NewName;
                                MCont.Update(Brand);
                            }
                        }
                    }
                    else if (Family != null)
                    {
                        NameAsked = new FormName("Gestion Famille", Family.Nom);
                        NameAsked.ShowDialog();
                        if (NameAsked.IsApplicated)
                        {
                            if (FCont.GetByName(new Famille(NameAsked.NewName)) != null)
                            {
                                MessageBoxes.DispError("Le nom est déjà utilisé");
                                NameAsked.IsApplicated = false;
                            }
                            else
                            {
                                Family.Nom = NameAsked.NewName;
                                FCont.Update(Family);
                            }
                        }
                    }
                    else
                        return;
                    if (NameAsked.IsApplicated)
                    {
                        RefreshDisplayList();
                        RefreshTree();
                    }
                }
            }
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifieSelectedItem();
        }
       

        private void DisplayList_DoubleClick(object sender, EventArgs e)
        {
            ModifieSelectedItem();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNodeSelected() == false)
                return;
            var Brand = TypeTree.SelectedNode.Tag as Marque;
            var ChildFamily = TypeTree.SelectedNode.Tag as SousFamille;
            var Family = TypeTree.SelectedNode.Tag as Famille;

            // Brand node selected
            if (Brand != null)
                NewArticle();
            // CF Node selected
            else if (ChildFamily != null)
                NewArticle();
            // F node selected
            else if (Family != null)
                NewChildFamily();
            // Root node selected
            else
            {
                if (TypeTree.SelectedNode == TypeTree.Nodes[0])
                    NewArticle();
                else if (TypeTree.SelectedNode == TypeTree.Nodes[1])
                {
                    NewFamily();
                }
                else if (TypeTree.SelectedNode == TypeTree.Nodes[2])
                {
                    NewMarque();
                }
                else DispHelp();
            }
            RefreshStatusStrip();
        }

        public bool IsNodeSelected()
        {
            if(TypeTree.SelectedNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void NewArticle()
        {
            FormArticle CreateForm = new FormArticle();
            CreateForm.ShowDialog();
            if (CreateForm.IsApplicated == true)
                RefreshDisplayList();
        }

        private void NewChildFamily()
        {
            FormChildFamily CreateForm = new FormChildFamily();
            CreateForm.ShowDialog();
            if (CreateForm.IsApplicated == true)
            {
                RefreshDisplayList();
                RefreshTree();
            }
        }

        private void NewMarque()
        {
            FormName NameAsked = new FormName("Nouvelle Marque", null);
            NameAsked.ShowDialog();
            if (NameAsked.IsApplicated)
            {
                if (MCont.GetByName(new Marque (NameAsked.NewName)) == null)
                {
                    MCont.Insert(new Marque(NameAsked.NewName));
                    RefreshDisplayList();
                    RefreshTree();
                }
                else
                {
                    MessageBoxes.DispError("Ce nom est déjà utilisé.");
                }
            }
        }

        private void NewFamily()
        {
            FormName NameAsked = new FormName("Nouvelle Famille", null);
            NameAsked.ShowDialog();
            if (NameAsked.IsApplicated)
            {
                if (FCont.GetByName(new Famille (NameAsked.NewName)) == null)
                {
                    bool a = FCont.Insert(new Famille(NameAsked.NewName));
                    RefreshDisplayList();
                    RefreshTree();
                }
                else
                {
                    MessageBoxes.DispError("Ce nom est déjà utilisé.");
                }
            }
        }
    }
}
