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

namespace Bacchus
{
    public partial class FormMain : Form
    {
        MarqueControl MCont = new MarqueControl();
        FamilleControl FCont = new FamilleControl();
        SousFamilleControl SFCont = new SousFamilleControl();
        ArticleControl ACont = new ArticleControl();

        /// <summary>
        /// Initialize window
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
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
        public void AutoResizeColumns() { DisplayList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); }

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
            AutoResizeColumns();
        }
    }
}
