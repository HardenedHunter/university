using System;
using System.Collections.Generic;
// ReSharper disable CommentTypo

namespace TrieTree
{
    static class WordUtils
    {
        /// <summary>
        /// Проверка, что слово состоит
        /// только букв.
        /// </summary>
        /// <param name="word">Проверяемое слово.</param>
        /// <returns></returns>
        public static bool IsWord(string word)
        {
            int length = word.Length;
            bool result = word.Length > 0;
            for (var i = 0; i < length && result; i++)
                result = IsLetter(word[i]);
            return result;
        }

        /// <summary>
        /// Проверка, что символ является буквой
        /// </summary>
        /// <param name="symbol">Символ</param>
        /// <returns></returns>
        public static bool IsLetter(char symbol)
        {
            return (symbol >= 'a') && (symbol <= 'z');
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
