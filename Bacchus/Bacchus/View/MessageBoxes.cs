using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.View
{
    static class MessageBoxes
    {
        public static DialogResult DispError(string Message)
        {
            return MessageBox.Show(
                Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static DialogResult DispInfo(string Message)
        {
            return MessageBox.Show(
                Message,
                "Confirmation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static DialogResult DispConfirmation(string Message)
        {
            return MessageBox.Show(
                Message,
                "Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
        }
    }
}
