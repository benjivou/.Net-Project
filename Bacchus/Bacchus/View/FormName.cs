using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.View
{
    public partial class FormName : Form
    {
        string Name = null;
        bool IsApplicated = false;

        public FormName(string Title, string ActualName)
        {
            InitializeComponent();
            this.Text = Title;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            IsApplicated = true;
            Name = NameBox.Text;
            this.Close();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            IsApplicated = false;
            this.Close();
        }
    }
}
