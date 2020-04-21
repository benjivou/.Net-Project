using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.View
{
    /// <summary>
    /// Class to manage group in a list view
    /// </summary>
    class ListViewGrouper
    {
        /// <summary>
        /// Declare a Hashtable array in which to store the groups.
        /// </summary>
        public Hashtable[] GroupTables;
        /// <summary>
        /// Declare a variable to store the current grouping column
        /// </summary>
        public int GroupColumn = 0;

        /// <summary>
        /// The list we work on
        /// </summary>
        private ListView DisplayList;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="List"></param>
        public ListViewGrouper(ListView List)
        {
            DisplayList = List;
            DisplayList.Sorting = SortOrder.Ascending;
        }

        /// <summary>
        /// Sets myListView to the groups created for the specified column.
        /// </summary>
        /// <param name="column"></param>
        public void SetGroups(int column)
        {
            // Remove the current groups.
            DisplayList.Groups.Clear();

            // Column 4 is for the quantity, so we don't use group for this column
            if(column != 4)
            {
                // Retrieve the hash table corresponding to the column.
                Hashtable groups = (Hashtable)GroupTables[column];

                // Copy the groups for the column to an array.
                ListViewGroup[] GroupsArray = new ListViewGroup[groups.Count];
                groups.Values.CopyTo(GroupsArray, 0);

                // Sort the groups and add them to myListView.
                Array.Sort(GroupsArray, new ListViewGroupSorter(DisplayList.Sorting));
                DisplayList.Groups.AddRange(GroupsArray);


                // Iterate through the items in myListView, assigning each 
                // one to the appropriate group.
                foreach (ListViewItem item in DisplayList.Items)
                {
                    // Retrieve the subitem text corresponding to the column.
                    string subItemText = item.SubItems[column].Text;

                    // For the Title column, use only the first letter.
                    if (column == 0)
                    {
                        if(subItemText.Length > 0)
                            subItemText = subItemText.Substring(0, 1);
                    }

                    // Assign the item to the matching group.
                    item.Group = (ListViewGroup)groups[subItemText];
                }
            }
            else
            {
                // For quantity with no group
                DisplayList.ListViewItemSorter = new ListViewComparer(column, DisplayList.Sorting);
            }
        }

        /// <summary>
        /// Sorts ListViewGroup objects by header value.
        /// </summary>
        private class ListViewGroupSorter : IComparer
        {
            private SortOrder order;

            // Stores the sort order.
            public ListViewGroupSorter(SortOrder theOrder)
            {
                order = theOrder;
            }

            // Compares the groups by header value, using the saved sort
            // order to return the correct value.
            public int Compare(object x, object y)
            {
                int result = String.Compare(
                    ((ListViewGroup)x).Header,
                    ((ListViewGroup)y).Header
                );
                if (order == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }

        /// <summary>
        /// Creates a Hashtable object with one entry for each unique
        /// subitem value (or initial letter for the parent item)
        /// in the specified column.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public Hashtable CreateGroupsTable(int column)
        {
            // Create a Hashtable object.
            Hashtable groups = new Hashtable();

            // Iterate through the items in myListView.
            foreach (ListViewItem item in DisplayList.Items)
            {
                // Retrieve the text value for the column.
                string subItemText = item.SubItems[column].Text;

                // Use the initial letter instead if it is the first column.
                if (column == 0)
                {
                    if(subItemText.Length > 0)
                        subItemText = subItemText.Substring(0, 1);
                }

                // If the groups table does not already contain a group
                // for the subItemText value, add a new group using the 
                // subItemText value for the group header and Hashtable key.
                if (!groups.Contains(subItemText))
                {
                    groups.Add(subItemText, new ListViewGroup(subItemText,
                        HorizontalAlignment.Left));
                }
            }

            // Return the Hashtable object.
            return groups;
        }

        /// <summary>
        /// Compares two ListView items based on a selected column only (no group)
        /// </summary>
        public class ListViewComparer : System.Collections.IComparer
        {
            private int ColumnNumber;
            private SortOrder SortOrder;

            public ListViewComparer(int column_number,
                SortOrder sort_order)
            {
                ColumnNumber = column_number;
                SortOrder = sort_order;
            }

            // Compare two ListViewItems.
            public int Compare(object object_x, object object_y)
            {
                // Get the objects as ListViewItems.
                ListViewItem item_x = object_x as ListViewItem;
                ListViewItem item_y = object_y as ListViewItem;

                // Get the corresponding sub-item values.
                string string_x;
                if (item_x.SubItems.Count <= ColumnNumber)
                {
                    string_x = "";
                }
                else
                {
                    string_x = item_x.SubItems[ColumnNumber].Text;
                }

                string string_y;
                if (item_y.SubItems.Count <= ColumnNumber)
                {
                    string_y = "";
                }
                else
                {
                    string_y = item_y.SubItems[ColumnNumber].Text;
                }

                // Compare them.
                int result;
                double double_x, double_y;
                if (double.TryParse(string_x, out double_x) &&
                    double.TryParse(string_y, out double_y))
                {
                    // Treat as a number.
                    result = double_x.CompareTo(double_y);
                }
                else
                {
                    DateTime date_x, date_y;
                    if (DateTime.TryParse(string_x, out date_x) &&
                        DateTime.TryParse(string_y, out date_y))
                    {
                        // Treat as a date.
                        result = date_x.CompareTo(date_y);
                    }
                    else
                    {
                        // Treat as a string.
                        result = string_x.CompareTo(string_y);
                    }
                }

                // Return the correct result depending on whether
                // we're sorting ascending or descending.
                if (SortOrder == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }
    }
}
