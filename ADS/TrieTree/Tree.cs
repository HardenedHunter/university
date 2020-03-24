using System;
using System.Collections.Generic;

namespace TrieTree
{
    class Tree
    {
        /// Корень дерева
        public TreeNode Root { get; private set; }

        /// Проверка на пустоту
        public bool IsEmpty => Root.IsEmpty;

        /// Получение всех слов, хранящихся в дереве
        public List<string> Words => Root.GetAllWords();

        /// Конструктор
        public Tree()
        {
            Root = new TreeNode();
        }

        /// <summary>
        /// Добавление слова в дерево
        /// </summary>
        /// <param name="word">Слово</param>
        public void AddWord(string word)
        {
            if (!WordUtils.IsRussian(word))
                throw new ArgumentOutOfRangeException("Ошибка! Некорректное слово.");
            Root.AddWord(ref word, 0);
        }

        // Получить похожие слова (отличающиеся на n последних символов).
        public List<string> GetSimilarWords(string word, int ending_length)
        {
            if ((ending_length < 0) || (ending_length >= word.Length))
                throw new ArgumentException("Ошибка! Некорректное слово.");
            string basis = word.Substring(0, word.Length - ending_length);
            List<string> result = new List<string>();
            TreeNode ending_node = Root.SearchEnding(ref basis, 0);
            if (ending_node != null)
            {
                List<string> endings = ending_node.GetAllWords();
                foreach(string ending in endings)
                {
                    result.Add(basis + ending);
                }
            }
            return result;
        }

        // Очистить дерево.
        public void Clear()
        {
            Root.Clear();
        }

    }
}
