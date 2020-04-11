using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus.View
{
    class ListViewGrouper
    {
        // Declare a Hashtable array in which to store the groups.
        public Hashtable[] GroupTables;
        // Declare a variable to store the current grouping column.
        public int GroupColumn = 0;
        // The list we work on
        private ListView DisplayList;

        public ListViewGrouper(ListView List)
        {
            DisplayList = List;
            DisplayList.Sorting = SortOrder.Ascending;
        }
        
        // Sets myListView to the groups created for the specified column.
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
                        subItemText = subItemText.Substring(0, 1);
                    }

                    // Assign the item to the matching group.
                    item.Group = (ListViewGroup)groups[subItemText];
                }
            }
        }

        // Sorts ListViewGroup objects by header value.
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

        // Creates a Hashtable object with one entry for each unique
        // subitem value (or initial letter for the parent item)
        // in the specified column.
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
    }
}
