using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrieTree
{
    public partial class FormResult : Form
    {
        public FormResult(List<string> words)
        {
            InitializeComponent();
            WordsToListView(words);
        }

        public void WordsToListView(List<string> words)
        {
            ListViewWords.Items.Clear();
            ListViewWords.Columns.Add("");
            ListViewWords.Scrollable = true;
            ListViewWords.View = View.Details;
            ListViewWords.HeaderStyle = ColumnHeaderStyle.None;
            foreach (var word in words)
            {
                var item = new ListViewItem {Text = word};
                ListViewWords.Items.Add(item);
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
