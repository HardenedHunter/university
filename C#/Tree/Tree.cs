using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

// ReSharper disable CommentTypo

namespace Tree
{
    //Класс "Б+ дерево"
    public abstract class Tree<T> : ITree<T>, IEnumerator<T> where T : IComparable
    {
        //Показатель ветвления дерева по умолчанию
        protected const int DefaultFactor = 2;

        //Минимально возможный показатель ветвления дерева
        protected const int MinFactor = 2;

        //Корень дерева
        private TreeNode<T> _root;

        //Количество уровней
        public int Level { get; private set; }

        //Количество элементов
        public int Count => this.Count();

        //Показатель ветвления
        public int Factor { get; set; }

        //Проверка на пустоту
        public bool IsEmpty => Level == 0;

        //Фабрика для производства звеньев дерева
        protected ITreeNodeFactory<T> Factory;

        //Элементы дерева
        public IEnumerable<T> Nodes => this;

        /// <summary>
        /// Добавление элемента в дерево
        /// </summary>
        /// <param name="node">Элемент</param>
        public void Add(T node)
        {
            if (_root == null)
            {
                Level++;
                _root = Factory.CreateLeafNode(Factor);
            }

            _root.Add(node);

            if (_root.IsOverflow())
            {
                Level++;
                var sibling = _root.Split();
                var newRoot = Factory.CreateInternalNode(Factor);
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
            bool result = false;
            using (IEnumerator<T> enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext() && !result)
                {
                    if (Current != null)
                        result = Current.CompareTo(node) == 0;
                }
            }

            return result;
        }

        /// <summary>
        /// Очистка дерева
        /// </summary>
        public void Clear()
        {
            _root = null;
            Level = 0;
        }

        /// <summary>
        /// Отрисовка дерева на форме, обход в ширину через очередь
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.Clear(Color.White);
            if (_root == null || _root.Keys.Count == 0) return;

            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            var font = new Font("Courier New", 16, FontStyle.Bold);
            var symbolSize = g.MeasureString("_", font, new SizeF(), StringFormat.GenericTypographic);

            int blockPadding = 4;
            int symbolsWidthPerItem = 2;
            float blockDividerWidth = symbolSize.Width * 2;
            float blockWidth = symbolSize.Width * (2 * Factor - 1) * symbolsWidthPerItem +
                               symbolSize.Width * (2 * Factor - 2);

            float xMiddle = g.ClipBounds.Width / 2;
            float xCord = xMiddle - blockWidth / 2;
            float yCord = symbolSize.Width * 2;

            int counterCurrent = 1;
            int counterNext = 0;
            int watched = 0;


            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(_root);

            var lineQueue = new Queue<int>();

            var p = new Pen(Color.SeaGreen, 2);
            var fillBrush = new SolidBrush(Color.FromArgb(238, 255, 238));
            var textBrush = new SolidBrush(Color.SeaGreen);
            while (queue.Count > 0)
            {
                var tmpNode = queue.Dequeue();

                string[] tmpArray = tmpNode.Keys.Select(FormatItem).ToArray();
                string keys = string.Join(" ", tmpArray);

                watched++;

                g.FillRectangle(fillBrush, xCord - blockPadding, yCord - blockPadding, blockWidth + blockPadding * 2,
                    symbolSize.Height + blockPadding * 2);
                
                g.DrawRectangle(p, xCord - blockPadding, yCord - blockPadding, blockWidth + blockPadding * 2,
                    symbolSize.Height + blockPadding * 2);
                
                g.DrawString(keys, font, textBrush, xCord, yCord, StringFormat.GenericTypographic);

                xCord += blockWidth + blockDividerWidth;

                if (tmpNode is InternalNode<T> linked)
                {
                    counterNext += linked.Children.Count;

                    lineQueue.Enqueue(linked.Children.Count);


                    foreach (var child in linked.Children)
                    {
                        queue.Enqueue(child);
                    }

                    //Конец уровня
                    if (watched == counterCurrent)
                    {
                        float nextLevelWidth = counterNext * blockWidth + (counterNext - 1) * blockDividerWidth;
                        float x = xMiddle - nextLevelWidth / 2;
                        float y = yCord + symbolSize.Height * 4f;
                        if (queue.Count > 0)
                        {
                            float xTop = xCord - (blockWidth + blockDividerWidth) * counterCurrent + blockPadding / 2;
                            float yTop = yCord + symbolSize.Height + blockPadding;
                            float xBot = x + blockPadding / 2;
                            float yBot = y - blockPadding;

                            int i = 1;
                            while (lineQueue.Count > 0)
                            {
                                g.DrawLine(p, xTop + blockWidth / 2, yTop, xBot + blockWidth / 2, yBot);
                                if (i % lineQueue.Peek() == 0)
                                {
                                    i = 0;
                                    lineQueue.Dequeue();
                                    xTop += blockWidth + blockDividerWidth;
                                }

                                xBot += blockWidth + blockDividerWidth;
                                i++;
                            }
                        }

                        xCord = x;
                        yCord = y;
                        watched = 0;
                        counterCurrent = counterNext;
                        counterNext = 0;
                    }
                }
            }

            p.Dispose();
            fillBrush.Dispose();
            textBrush.Dispose();
        }

        private string FormatItem(T item)
        {
            if (item is int number)
            {
                if (number < 10 && number > 0)
                    return $"0{number}";
            }

            return item.ToString();
        }

        #region IEnumerator and IEnumerable

        private LeafNode<T> _currentNode;
        private int _currentNodePosition;

        void IDisposable.Dispose()
        {
        }

        object IEnumerator.Current => Current;

        public T Current
        {
            get
            {
                try
                {
                    return _currentNode.Keys[_currentNodePosition];
                }
                catch (Exception)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        bool IEnumerator.MoveNext()
        {
            if (_currentNodePosition >= _currentNode.Keys.Count - 1)
            {
                _currentNode = _currentNode.Next;
                _currentNodePosition = 0;
            }
            else
                _currentNodePosition++;

            return _currentNode != null;
        }

        void IEnumerator.Reset()
        {
            _currentNode = _root?.GetFirstLeaf();
        }

        public IEnumerator<T> GetEnumerator()
        {
            _currentNode = Factory.CreateLeafNode(Factor);
            _currentNode.Next = _root?.GetFirstLeaf();
            _currentNodePosition = 0;
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerator and IEnumerable
    }
}