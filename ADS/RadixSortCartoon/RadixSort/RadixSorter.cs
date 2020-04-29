using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable CommentTypo

namespace RadixSort
{
    public class RadixSorter
    {
        //Внешняя зависимость. Функция, которая выполнится при прохождении одной итерации в сортировке (отрисовка на форме)
        public Func<int, int, int, int, Task> OnIteration { get; }

        //Внешняя зависимость. Функция, которая выполнится при обратном распространении после итерации (отрисовка на форме)
        public Func<int, int, Task> OnBackPropagation { get; }

        //Внешняя зависимость. Функция, которая выполнится после одного блока итераций (отрисовка на форме)
        public Action OnIterationEnd { get; }

        public RadixSorter(Func<int, int, int, int, Task> onIteration, Func<int, int, Task> onBackPropagation,
            Action onIterationEnd)
        {
            OnIteration = onIteration;
            OnBackPropagation = onBackPropagation;
            OnIterationEnd = onIterationEnd;
        }

        /// <summary>
        /// Поразрядная сортировка с основанием системы счисления 10
        /// </summary>
        /// <param name="items">Исходный массив</param>
        /// <param name="length">Максимальная длина числа (в цифрах)</param>
        public async Task RadixSortBase10(int[] items, int length = 2)
        {
            //Основание системы счисления
            const int baseNumeric = 10;

            //Инициализация "ведёрок", в которые будут помещаться числа исходного массива
            var buckets = new List<int>[baseNumeric];
            for (var i = 0; i < baseNumeric; ++i)
            {
                buckets[i] = new List<int>();
            }

            //Цикл по всем разрядам исходных чисел
            for (var step = 0; step < length; ++step)
            {
                for (var i = 0; i < items.Length; i++)
                {
                    //Вычисление индекса ведёрка, в которую будет положено очередное число
                    var index = Math.Abs(items[i]) % (int) Math.Pow(baseNumeric, step + 1) /
                                (int) Math.Pow(baseNumeric, step);
                    buckets[index].Add(items[i]);
                    //Отрисовка изменений на форме
                    await OnIteration(i, buckets[index].Count, index, items[i]);
                }

                //Заполнение исходного массива обратно из готовых вёдер
                var j = 0;
                foreach (var bucket in buckets)
                {
                    foreach (var sortedItem in bucket)
                    {
                        //Отрисовка изменений на форме
                        await OnBackPropagation(j, sortedItem);

                        items[j] = sortedItem;
                        ++j;
                    }
                }

                //Очистка вёдер перед очередной итерацией
                foreach (var bucket in buckets)
                {
                    bucket.Clear();
                }

                //Отрисовка изменений на форме
                OnIterationEnd();
            }

            //Обработка отрицательных чисел 
            for (int i = 0; i < items.Length; i++)
            {
                var index = items[i] < 0 ? 0 : 1;
                buckets[index].Add(items[i]);
                //Отрисовка изменений на форме
                await OnIteration(i, buckets[index].Count, index, items[i]);
            }

            //Располагаем отрицательные числа
            var k = 0;
            for (int i = 0; i < buckets[0].Count; i++)
            {
                //Отрисовка изменений на форме
                await OnBackPropagation(buckets[0].Count - 1 - k, buckets[0][i]);

                items[buckets[0].Count - 1 - k] = buckets[0][i];
                k++;
            }

            //Располагаем положительные числа
            for (int i = 0; i < buckets[1].Count; i++)
            {
                //Отрисовка изменений на форме
                await OnBackPropagation(k, buckets[1][i]);

                items[k] = buckets[1][i];
                k++;
            }

            //Отрисовка изменений на форме
            OnIterationEnd();
        }
    }
}