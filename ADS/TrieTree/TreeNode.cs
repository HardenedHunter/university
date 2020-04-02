using System.Collections.Generic;
// ReSharper disable CommentTypo

namespace TrieTree
{
    class TreeNode
    {
        // Символы и соответствующие указатели на ячейки-потомки.
        public TreeNode[] Children { get; }

        // Проверка на конец слова в этой ячейке
        public bool IsWord { get; private set; }

        //Кол-во букв в алфавите
        public static int LetterCount = 26;

        /// Конструктор
        public TreeNode()
        {
            Children = new TreeNode[LetterCount];
            IsWord = false;
        }

        /// <summary>
        /// Добавить слово в поддерево с заданного индекса.
        /// Слова добавляются в перевернутом виде!
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
                if (Children[letter - 'a'] == null)
                    Children[letter - 'a'] = new TreeNode();
                Children[letter - 'a'].AddWord(ref word, index + 1);
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
            for (int i = 0; i < LetterCount; i++)
            {
                if (Children[i] != null)
                {
                    var tmp = Children[i].GetAllWords();
                    foreach (var word in tmp)
                    {
                        result.Add((char)('a' + i) + word);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Очистка поддерева.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < LetterCount; i++)
            {
                Children[i] = null;
            }
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
                // Передается ending.Length - 1 - currentIndex, так как слова нужно
                // искать с конца (дерево содержит перевёрнутые слова из файла)
                var currentLetter = ending[ending.Length - 1 - currentIndex];
                if (Children[currentLetter - 'a'] != null)
                {
                    var tmp = Children[currentLetter - 'a'].GetWordsWithEnding(ending, currentIndex + 1);
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
