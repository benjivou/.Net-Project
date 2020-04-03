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

        public FormMain()
        {
            InitializeComponent();
            RefreshTree();
            RefreshStatusStrip();
            ClearList();
            DispHelp();
        }

        private void ImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport Frame = new FormImport();
            Frame.ShowDialog();
        }

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

        private void ActualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshTree();
            RefreshStatusStrip();
            ClearList();
            DispHelp();
        }

        private void DispHelp()
        {
            ColumnHeader Header = new ColumnHeader();
            Header.Text = "<-- Sélectionner une section";
            Header.Width = -2;
            DisplayList.Columns.Add(Header);
        }

        private void RefreshStatusStrip()
        {
            NbArticles.Text = "Articles : " + ACont.GetCountRef();
            NbFamilles.Text = "Familles : " + FCont.GetCountRef();
            NbMarques.Text = "Marques : " + MCont.GetCountRef();
            NbSousFamilles.Text = "Sous-Familles : " + SFCont.GetCountRef();
        }

        private void ExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExport Frame = new FormExport();
            Frame.ShowDialog();
        }

        private void TypeTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Clear
            ClearList();

            TreeNode ClickedNode = e.Node;

            if(ClickedNode == TypeTree.Nodes[2])
            {
                DispMarques();
            }
            else
            {
                //TO-DO remove this
                DispHelp();
                ///

                var TypeMarque = ClickedNode.Tag as Marque;
                if (TypeMarque != null)
                {

                }

                var TypeSSFamille = ClickedNode.Tag as SousFamille;
                if (TypeSSFamille != null)
                {

                }

                var TypeFamille = ClickedNode.Tag as Famille;
                if (TypeFamille != null)
                {

                }
            }

            
        }

        private void DispMarques()
        {
            // Header
            ColumnHeader Header = new ColumnHeader();
            Header.Text = "Description";
            Header.Width = -2;
            DisplayList.Columns.Add(Header);

            // Items
            HashSet<Marque> BrandList = MCont.GetAll();
            foreach(Marque Brand in BrandList)
            {
                ListViewItem Item = new ListViewItem(new string[] { Brand.Nom },-1);
                Item.Tag = Brand;
                DisplayList.Items.Add(Item);
            }
        }

        private void ClearList()
        {
            DisplayList.Clear();
            DisplayList.Columns.Clear();
        }

        private void DisplayList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            /*
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont =
                            new Font("Helvetica", 10, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
            */
        }

        private void DisplayList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            /*
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont =
                            new Font("Helvetica", 10, FontStyle.Regular))
                {
                    e.Graphics.DrawString(e.Item.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
            */
        }
    }
}
