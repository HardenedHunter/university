using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

// ReSharper disable CommentTypo

namespace Tree
{
    public class LinkedTree<T> : ITree<T> where T : IComparable
    {
        //Показатель ветвления дерева по умолчанию
        private const int DefaultFactor = 2;

        //Минимально возможный показатель ветвления дерева
        private const int MinFactor = 2;

        //Корень дерева TODO private
        public Node<T> _root;

        //Количество уровней
        public int Level { get; private set; }

        //Количество элементов
        public int Count { get; }

        //Показатель ветвления
        public int Factor { get; }

        //Проверка на пустоту
        public bool IsEmpty => _root.Keys.Count == 0;

        //Элементы дерева
        public IEnumerable<T> Nodes => this;


        public LinkedTree(int factor = DefaultFactor)
        {
            if (factor < MinFactor)
                throw new ArgumentOutOfRangeException(); //TODO REPLACE
            Factor = factor;
            Clear();
        }

        /// <summary>
        /// Добавление элемента в дерево
        /// </summary>
        /// <param name="node">Элемент</param>
        public void Add(T node)
        {
            if (_root == null)
            {
                Level++;
                _root = new LinkedLeafNode<T>(Factor);
            }

            _root.Add(node);
            
            if (_root.IsOverflow())
            {
                Level++;
                var sibling = _root.Split();
                var newRoot = new LinkedNode<T>(Factor);
                newRoot.Keys.Add(sibling.GetFirstLeafKey());
                newRoot.Children.Add(_root);
                newRoot.Children.Add(sibling);
                _root = newRoot;
            }
        }

        /// <summary>
        /// Удаление элемента из дерева
        /// </summary>
        /// <param name="node">Удаляемый элемент</param>
        public void Remove(T node)
        {
            if (_root == null) return;

            var newRoot = _root.Remove(node);
            if (_root.IsUnderFlow())
            {
                Level--;
                _root = newRoot;
            }
        }
        
        /// <summary>
        /// Проверка на содержание в дереве переданного элемента
        /// </summary>
        /// <param name="node">Искомый элемент</param>
        /// <returns></returns>
        public bool Contains(T node)
        {
            return false;
            // return _root.Contains(node);
        }

        /// <summary>
        /// Очистка дерева
        /// </summary>
        public void Clear()
        {
            _root = null;
            Level = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Draw(Graphics g)
        {
            //сделать так, чтобы шрифт подстраивался под размер самого большого уровня
            g.Clear(SystemColors.Control);
            if (_root == null || _root.Keys.Count == 0) return;

            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            var font = new Font("Courier New", 24);
            var symbolSize = g.MeasureString("_", font, new SizeF(), StringFormat.GenericTypographic);
            float dividerWidth = font.Size / 2;
            float blockWidth = symbolSize.Width * (4 * Factor - 3);

            using (var p = new Pen(Color.SeaGreen, 3))
            {
                // g.ClipBounds.Width
                float xMiddle = g.ClipBounds.Width / 2;
                float xCord = xMiddle;
                float yCord = symbolSize.Width * 2;

                int counterCurrent = 1;
                int counterNext = 0;
                int watched = 0;


                var queue = new Queue<Node<T>>();
                queue.Enqueue(_root);

                //Цикл for по уровням

                while (queue.Count > 0)
                {
                    //Get the tree node
                    var tmp = queue.Dequeue();

                    string keys = tmp.Keys.ToString();

                    watched++;

                    g.FillRectangle(Brushes.DarkSeaGreen, xCord, yCord, blockWidth, symbolSize.Height);
                    g.DrawRectangle(p, xCord, yCord, blockWidth, symbolSize.Height);
                    g.DrawString(keys, font, Brushes.Black, xCord, yCord, StringFormat.GenericTypographic);

                    xCord += blockWidth + symbolSize.Width;

                    if (tmp is LinkedNode<T> linked)
                    {
                        foreach (var child in linked.Children)
                            queue.Enqueue(child);

                        counterNext += linked.Children.Count;
                        //Конец уровня
                        if (watched == counterCurrent)
                        {
                            float nextLevelWidth = counterNext * blockWidth + (counterNext - 1) * symbolSize.Width;
                            xCord = xMiddle - nextLevelWidth / 2 + blockWidth / 2;
                            yCord += symbolSize.Height * 2.5f;
                            watched = 0;
                            counterCurrent = counterNext;
                            counterNext = 0;
                        }

                        //сделай числа как 0001 0002 и тд и ограничение на ввод
                    }
                }
            }
        }
    }
}