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
        public FormMain()
        {
            InitializeComponent();
            RefreshTree();
        }

        private void ImporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImport Frame = new FormImport();
            Frame.ShowDialog();
        }

        private void RefreshTree()
        {
            MarqueControl MCont = new MarqueControl();
            FamilleControl FCont = new FamilleControl();
            SousFamilleControl SFCont = new SousFamilleControl();

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
                FamilyNodes.Nodes.Add(Family.Nom);
            }
            Root.Add(FamilyNodes);

            // Add all brands
            TreeNode BrandNodes = new TreeNode("Marques");
            BrandList = MCont.GetAll();
            foreach(Marque Brand in BrandList)
            {
                TreeNode BrandNode = new TreeNode(Brand.Nom);
                BrandNode.Tag = Brand;
                BrandNodes.Nodes.Add(Brand.Nom);
            }
            Root.Add(BrandNodes);

        }
    }
}
