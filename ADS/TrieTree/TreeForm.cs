using System;
using System.Windows.Forms;
// ReSharper disable CommentTypo
// ReSharper disable LocalizableElement
// ReSharper disable StringLiteralTypo

namespace TrieTree
{
    public partial class TreeForm : Form
    {
        //Trie-дерево
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
        private bool FillTreeFromFile(Tree tree)
        {
            var filename = "";
            bool result = FormUtils.ChooseFile(ref filename);
            if (result)
            {
                ClearTree();
                var words = FormUtils.GetWordsFromFile(filename);
                foreach (var word in words)
                    tree.AddWord(word);
            }
            return result;
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearTree();
        }

        private void ButtonFill_Click(object sender, EventArgs e)
        {
            try
            {
                if (FillTreeFromFile(_tree))
                {
                    TrieTreeView.Nodes.Add("Слова (перевёрнутые)");
                    FormUtils.FillTreeView(_tree.Root, TrieTreeView.Nodes, 0);
                    TrieTreeView.ExpandAll();
                }
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
                if (list.Count > 0)
                {
                    var formResult = new FormResult(list);
                    formResult.Show();
                }
                else
                {
                    MessageBox.Show("Слова с заданным окончанием не найдены.", "", MessageBoxButtons.OK);
                }
                
            }
        }
    }
}
