using System;
using System.Windows.Forms;

namespace TrieTree
{
    public partial class TreeForm : Form
    {
        private Tree _tree;

        public TreeForm()
        {
            _tree = new Tree();
            InitializeComponent();
        }

        /// <summary>
        /// Очистка TreeView и самого дерева.
        /// </summary>
        private void ClearTree()
        {
            _tree.Clear();
            TrieTreeView.Nodes.Clear();
        }

        /// <summary>
        /// Заполнение дерева из текстового файла.
        /// </summary>
        /// <param name="tree">Дерево.</param>
        private void FillTreeFromFile(Tree tree)
        {
            var filename = "";
            if (FormUtils.ChooseFile(ref filename))
            {
                ClearTree();
                var words = FormUtils.GetWordsFromFile(filename);
                foreach (var word in words)
                    tree.AddWord(word);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearTree();
        }

        private void ButtonFill_Click(object sender, EventArgs e)
        {
            try
            {
                FillTreeFromFile(_tree);
                TrieTreeView.Nodes.Add("Слова (перевёрнутые)");
                FormUtils.FillTreeView(_tree.Root, TrieTreeView.Nodes, 0);
                TrieTreeView.ExpandAll();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ButtonTask_Click(object sender, EventArgs e)
        {
            var ending = TextBoxEnding.Text;
            if (ending.Length > 0 && TrieTreeView.Nodes.Count > 0)
            {
                var list = _tree.GetWordsWithEnding(ending);
                var formResult = new FormResult(list);
                formResult.Show();
            }
        }
    }
}
