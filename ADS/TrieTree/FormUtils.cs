﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
// ReSharper disable CommentTypo

namespace TrieTree
{
    static class FormUtils
    {
        /// <summary>
        /// Выбор файла на жестком диске.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns>Был ли выбран файл.</returns>
        public static bool ChooseFile(ref string filename)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"txt files (*.txt)|*.txt", FilterIndex = 1, RestoreDirectory = true
            };

            var result = openFileDialog.ShowDialog() == DialogResult.OK;
            if (result) filename = openFileDialog.FileName;
            return result;
        }


        /// <summary>
        /// Чтение из файла слов, записанных в одну строку через пробел.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns>Список прочитанных слов.</returns>
        public static List<string> GetWordsFromFile(string filename)
        {
            string content = File.ReadAllText(filename);
            var result = new List<string>();
            var words = content.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < words.Length; ++i)
            {
                if (WordUtils.IsWord(words[i] = words[i].Trim()))
                    result.Add(words[i]);
                else
                    throw new ArgumentException("Ошибка! Недопустимое слово.");
            }
            return result;
        }

        /// <summary>
        /// Заполнение TreeView из сильно ветвящегося дерева.
        /// </summary>
        /// <param name="node">Текущее обрабатываемое звено.</param>
        /// <param name="viewNodes">Текущий заполняемый сегмент TreeView.</param>
        /// <param name="index">Индекс заполняемого сегмента.</param>
        public static void FillTreeView(TreeNode node, TreeNodeCollection viewNodes, int index)
        {
            if (node.IsWord)
                viewNodes[index].Text += '*';
            var letterCounter = 0;
            for (int i = 0; i < TreeNode.LetterCount; i++)
            {
                if (node.Children[i] != null)
                {
                    viewNodes[index].Nodes.Add(Convert.ToChar('a' + i).ToString());
                    FillTreeView(node.Children[i], viewNodes[index].Nodes, letterCounter);
                    letterCounter++;
                }
            }
        }
    }
}
