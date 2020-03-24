namespace TrieTree
{
    static class WordUtils
    {
        /// <summary>
        /// Проверка, что слово состоит
        /// только из русских букв.
        /// </summary>
        /// <param name="word">Проверяемое слово.</param>
        /// <returns></returns>
        public static bool IsRussian(string word)
        {
            bool result = true;
            foreach (char letter in word)
            {
                if (!(result = IsRussian(letter)))
                    break;
            }
            return result;
        }

        /// <summary>
        /// Проверка, что символ является русской буквой
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public static bool IsRussian(char letter)
        {
            return (letter >= 'а') && (letter <= 'я') || (letter == 'ё');
        }
    }
}
