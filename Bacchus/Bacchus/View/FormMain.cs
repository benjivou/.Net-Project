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
    }
}
