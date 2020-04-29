using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// ReSharper disable CommentTypo

namespace RadixSort
{
    public class RadixSorter
    {
        //Количество доступов к массиву (на чтение/запись)
        public int NumberOfArrayAccesses { get; private set; }

        /// <summary>
        /// Поразрядная сортировка с основанием 10
        /// </summary>
        /// <param name="items">Исходный массив</param>
        /// <param name="length">Максимальная длина числа (в цифрах)</param>
        public void LsdRadixSortBase10(int[] items, int length = 10)
        {
            //Количество операций доступа к массиву всегда будет равно 2 * (length + 1) * items.Length
            //(length + 1 из-за дополнительной итерации для знака числа)
            NumberOfArrayAccesses = 0;

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
                    var index = Math.Abs(items[i]) % (int)Math.Pow(baseNumeric, step + 1) /
                                (int)Math.Pow(baseNumeric, step);
                    buckets[index].Add(items[i]);
                    NumberOfArrayAccesses++;
                }

                //Заполнение исходного массива обратно из готовых коробок
                var j = 0;
                foreach (var bucket in buckets)
                {
                    foreach (var sortedItem in bucket)
                    {
                        items[j] = sortedItem;
                        ++j;
                        NumberOfArrayAccesses++;
                    }
                }

                //Очистка коробок перед очередной итерацией
                foreach (var bucket in buckets)
                {
                    bucket.Clear();
                }
            }

            //Обработка отрицательных чисел 
            for (int i = 0; i < items.Length; i++)
            {
                var index = items[i] < 0 ? 0 : 1;
                buckets[index].Add(items[i]);
                NumberOfArrayAccesses++;
            }

            //Располагаем отрицательные числа
            var k = 0;
            for (int i = 0; i < buckets[0].Count; i++)
            {
                items[buckets[0].Count - 1 - k] = buckets[0][i];
                k++;
                NumberOfArrayAccesses++;
            }

            //Располагаем положительные числа
            for (int i = 0; i < buckets[1].Count; i++)
            {
                items[k] = buckets[1][i];
                k++;
                NumberOfArrayAccesses++;
            }
        }

        /// <summary>
        /// Поразрядная сортировка с основанием 2
        /// </summary>
        /// <param name="items">Исходный массив</param>
        public void LsdRadixSortBase2(int[] items)
        {
            const int baseNumeric = 2;
            const int length = sizeof(int) * 8;

            //Количество операций доступа к массиву всегда будет равно 2 * (length) * items.Length
            NumberOfArrayAccesses = 0;

            var buckets = new List<int>[baseNumeric];
            for (var i = 0; i < baseNumeric; ++i)
            {
                buckets[i] = new List<int>();
            }

            for (var step = 0; step < length - 1; ++step)
            {
                foreach (var item in items)
                {
                    int index = (item & (1 << step)) > 0 ? 1 : 0;
                    buckets[index].Add(item);
                    NumberOfArrayAccesses++;
                }

                var j = 0;
                foreach (var bucket in buckets)
                {
                    foreach (var sortedItem in bucket)
                    {
                        items[j] = sortedItem;
                        ++j;
                        NumberOfArrayAccesses++;
                    }
                }

                foreach (var bucket in buckets)
                {
                    bucket.Clear();
                }
            }

            //Обработка отрицательных чисел,
            //проверка первого бита, который отвечает за знак
            foreach (var item in items)
            {
                int index = (item & (1 << length - 1)) != 0 ? 0 : 1;
                buckets[index].Add(item);
                NumberOfArrayAccesses++;
            }

            var k = 0;
            foreach (var bucket in buckets)
            {
                foreach (var sortedItem in bucket)
                {
                    items[k] = sortedItem;
                    ++k;
                    NumberOfArrayAccesses++;
                }
            }
        }
    }
}