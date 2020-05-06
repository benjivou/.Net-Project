using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.View
{
    /// <summary>
    /// Class to create message box shortly
    /// </summary>
    static class MessageBoxes
    {
        /// <summary>
        /// Create an error messagebox
        /// </summary>
        /// <param name="Message">Message to display</param>
        /// <returns>Result of dialog</returns>
        public static DialogResult DispError(string Message)
        {
            return MessageBox.Show(
                Message,
                "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Create an Info messagebox
        /// </summary>
        /// <param name="Message">Message to display</param>
        /// <returns>Result of dialog</returns>
        public static DialogResult DispInfo(string Message)
        {
            return MessageBox.Show(
                Message,
                "Confirmation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Create a Confirmation warning messagebox
        /// </summary>
        /// <param name="Message">Message to display</param>
        /// <returns>Result of dialog</returns>
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
