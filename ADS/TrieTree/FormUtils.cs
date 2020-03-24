using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrieTree
{
    static class FormUtils
    {
        // Обработать входную строку.
        public static List<string> ParseInputLine(string line)
        {
            List<string> result = new List<string>();
            string[] words = line.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; ++i)
            {
                if (WordUtils.IsRussian(words[i] = words[i].Trim()))
                    result.Add(words[i]);
                else
                    throw new ArgumentOutOfRangeException("Ошибка! Недопустимое слово.");
            }
            return result;
        }

        // Заполнить коллекцию "TreeView"
        public static void FillTreeView(TreeNode in_node, TreeNodeCollection view_nodes, int index)
        {
            if (in_node.IsWord)
                view_nodes[index].Text += "*";
            int counter = 0;
            foreach (KeyValuePair<char, TreeNode> child in in_node.Children)
            {
                view_nodes[index].Nodes.Add(child.Key.ToString());
                FillTreeView(child.Value, view_nodes[index].Nodes, counter);
                counter++;
            }
        }

        // Заполнить коллекцию "RichTextBox"
        public static string[] FillTextOutput(List<string> words)
        {
            words.Sort();
            string[] result = words.ToArray();
            return result;
        }

    }
}
