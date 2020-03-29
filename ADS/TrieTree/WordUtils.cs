using System;
using System.Collections.Generic;
// ReSharper disable CommentTypo

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

        /// <summary>
        /// Переворачивает переданное слово.
        /// </summary>
        /// <param name="word">Слово.</param>
        /// <returns>Перевёрнутое слово</returns>
        public static string ReverseWord(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Переворачивает все слова в списке.
        /// </summary>
        /// <param name="list">Целевой список.</param>
        public static void ReverseWordList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = ReverseWord(list[i]);
            }
        }

    }
}
