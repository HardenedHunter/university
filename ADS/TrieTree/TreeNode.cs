using System.Collections.Generic;

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
        /// Добавить строку в поддерево с заданного индекса.
        /// </summary>
        /// <param name="word">Строка</param>
        /// <param name="index">Индекс текущей буквы</param>
        public void AddWord(ref string word, int index)
        {
            if (word.Length == index)
                IsWord = true;
            else
            {
                char letter = word[index];
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

        // Найти ячейку, которая является концом заданного слова.
        public TreeNode SearchEnding(ref string word, int current_index)
        {
            TreeNode result = null;
            if (current_index == word.Length)
                result = this;
            else
                if (_children.ContainsKey(word[current_index]))
                    result = _children[word[current_index]].SearchEnding(ref word, current_index + 1);
            return result;
        }

        // Очистить поддерево.
        public void Clear()
        {
            _children.Clear();
        }
    }
}
