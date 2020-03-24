using System;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace TrieTree
{
    class TreeNode
    {
        // Указатели на ячейки-потомки.
        private Dictionary<char, TreeNode> _children;

        // Проверка на пустоту.
        public bool IsEmpty => _children.Count == 0;

        // Проверка на конец слова в этой ячейке
        public bool IsWord { get; private set; }

        // Указатели на ячейки-потомки.
        public Dictionary<char, TreeNode> Children => _children;

        /// Конструктор
        public TreeNode()
        {
            _children = new Dictionary<char, TreeNode>();
            IsWord = false;
        }

        /// <summary>
        /// Добавить слово в поддерево с заданного индекса.
        /// Слова добавляются в перевенутом виде!
        /// </summary>
        /// <param name="word">Слово</param>
        /// <param name="index">Индекс текущей буквы</param>
        public void AddWord(ref string word, int index)
        {
            if (word.Length == index)
                IsWord = true;
            else
            {
                char letter = word[word.Length - 1 - index];
                if (!_children.ContainsKey(letter))
                    _children.Add(letter, new TreeNode());
                _children[letter].AddWord(ref word, index + 1);
            }
        }

        /// <summary>
        /// Получить все слова в поддереве.
        /// </summary>
        /// <returns>Слова</returns>
        public List<string> GetAllWords()
        {
            var result = new List<string>();
            if (IsWord)
                result.Add("");
            foreach (var pair in _children)
            {
                var tmp = pair.Value.GetAllWords();
                foreach (string word in tmp)
                {
                    result.Add(pair.Key + word);
                }
            }
            return result;
        }

        /// <summary>
        /// Очистка поддерева.
        /// </summary>
        public void Clear()
        {
            _children.Clear();
        }

        /// <summary>
        /// Получить все слова с заданным окончанием.
        /// </summary>
        /// <param name="ending">Окончание.</param>
        /// <param name="currentIndex">Индекс текущего символа окончания.</param>
        /// <returns>Список слов.</returns>
        public List<string> GetWordsWithEnding(string ending, int currentIndex)
        {
            List<string> result;
            if (ending.Length != currentIndex)
            {
                result = new List<string>();
                // ending.Length - 1 - currentIndex, так как слова нужно искать с конца
                // (дерево содержит перевёрнутые слова из файла)
                var currentLetter = ending[ending.Length - 1 - currentIndex];
                if (Children.ContainsKey(currentLetter))
                {
                    var tmp = Children[currentLetter].GetWordsWithEnding(ending, currentIndex + 1);
                    foreach (var word in tmp)
                    {
                        result.Add(currentLetter + word);
                    }
                }
            }
            else
            {
                result = GetAllWords();
            }
            return result;
        }
    }
}
