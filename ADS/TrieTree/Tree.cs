using System;
using System.Collections.Generic;
// ReSharper disable CommentTypo

namespace TrieTree
{   
    /// <summary>
    /// Сильно ветвящееся дерево,
    /// слова заполняются в перевернутом виде. 
    /// </summary>
    class Tree
    {
        /// Корень дерева.
        public TreeNode Root { get; }

        /// Конструктор
        public Tree()
        {
            Root = new TreeNode();
        }

        /// <summary>
        /// Очистка дерева.
        /// </summary>
        public void Clear()
        {
            Root.Clear();
        }

        /// <summary>
        /// Добавление слова в дерево
        /// </summary>
        /// <param name="word">Слово</param>
        public void AddWord(string word)
        {
            if (!WordUtils.IsWord(word))
                throw new ArgumentOutOfRangeException("Ошибка! Некорректное слово.");
            Root.AddWord(ref word, 0);
        }

        /// <summary>
        /// Получение слов, имеющих заданное окончание.
        /// </summary>
        /// <param name="ending">Заданное окончание.</param>
        /// <returns>Список из слов.</returns>
        public List<string> GetWordsWithEnding(string ending)
        {
            var list = Root.GetWordsWithEnding(ending, 0);
            WordUtils.ReverseWordList(list);
            return list;
        }
    }
}
