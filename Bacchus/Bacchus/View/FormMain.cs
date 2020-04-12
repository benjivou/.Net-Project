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

        private bool isRunningXPOrLater = OSFeature.Feature.IsPresent(OSFeature.Themes);

        ListViewGrouper Grouper;

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
            /*
            // Loading could take a little bit time, that's why we hide list during loading to don't show "noises"
            DisplayList.Visible = false;
            // Clear
            ClearList();

            TreeNode ClickedNode = e.Node;

            if (ClickedNode == TypeTree.Nodes[0])   // All Articles
            {
                DispAllArticles();
                
            }
            else if (ClickedNode == TypeTree.Nodes[1])  // All Families
            {
                DispFamilies();
            }
            else if (ClickedNode == TypeTree.Nodes[2])  // All Brands
            {
                DispMarques();
            }
            else
            {
                var TypeMarque = ClickedNode.Tag as Marque;
                var TypeSSFamille = ClickedNode.Tag as SousFamille;
                var TypeFamille = ClickedNode.Tag as Famille;
                if (TypeMarque != null) // Article with a specific Brand
                {
                    DispArticles((Marque)ClickedNode.Tag);
                }
                else if (TypeSSFamille != null) // Article with a specific Child Family
                {
                    DispArticles((SousFamille)ClickedNode.Tag);
                }
                else if (TypeFamille != null)   // Child Family with a specific Family
                {
                    DispChildFamilies((Famille) ClickedNode.Tag);
                }
                // No node selected
                else
                {
                    DispHelp();
                }
            }
            if (isRunningXPOrLater)
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
                Grouper.SetGroups(0);
                
            }
            DisplayList.Visible = true;
            */
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
            // Set the sort order to ascending when changing
            // column groups; otherwise, reverse the sort order.
            if (DisplayList.Sorting == SortOrder.Descending ||
                (isRunningXPOrLater && (e.Column != Grouper.GroupColumn)))
            {
                DisplayList.Sorting = SortOrder.Ascending;
            }
            else
            {
                DisplayList.Sorting = SortOrder.Descending;
            }
            Grouper.GroupColumn = e.Column;

            // Set the groups to those created for the clicked column.
            if (isRunningXPOrLater)
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

        private void DeleteItem()
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
            DeleteItem();
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
            if (isRunningXPOrLater)
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
                Grouper.SetGroups(0);
            }
        }
        

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteItem();
        }
    }
}
