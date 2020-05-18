using System;

// ReSharper disable CommentTypo
// ReSharper disable InvalidXmlDocComment

namespace Tree
{
    //Класс "Внутреннее звено"
    public abstract class InternalNode<T> : TreeNode<T> where T : IComparable
    {
        public IExtendedCollection<TreeNode<T>> Children;
        protected ITreeNodeFactory<T> Factory;
        public int Factor { get; protected set; }

        /// <summary>
        /// Рекурсивное удаление ключа из узла. Внутренние узлы
        /// передают управление листьевым, откуда и производится
        /// удаление. Возможна перестройка структуры дерева из-за
        /// нехватки ключей.
        /// </summary>
        /// <param name="key">Удаляемый ключ</param>
        /// <returns>
        /// Узел дерева, который станет новым корнем, если в текущем корне
        /// не останется ключей.
        /// </returns>
        public override TreeNode<T> Remove(T key)
        {
            TreeNode<T> child = GetChild(key);
            child.Remove(key);
            if (child.IsUnderFlow())
            {
                TreeNode<T> childLeftSibling = GetChildLeftSibling(key);
                TreeNode<T> childRightSibling = GetChildRightSibling(key);
                TreeNode<T> left = childLeftSibling ?? child;
                TreeNode<T> right = childLeftSibling != null ? child : childRightSibling;
                left.Merge(right);
                
                DeleteChild(right);

                if (left.IsOverflow())
                {
                    TreeNode<T> sibling = left.Split();
                    InsertChild(sibling.GetFirstLeafKey(), sibling);
                }

                return left;
            }
            
            int updateIndex = Keys.IndexOf(key);
            if (updateIndex >= 0) Keys[updateIndex] = Children[updateIndex + 1].GetFirstLeafKey();

            return null;
        }

        /// <summary>
        /// Рекурсивное добавление ключа в узел. Внутренние узлы
        /// передают управление листьевым, где и производится
        /// добавление. Возможна перестройка структуры дерева из-за
        /// переполнения ключей.
        /// </summary>
        /// <param name="key">Добавляемый ключ.</param>
        public override void Add(T key)
        {
            TreeNode<T> child = GetChild(key);
            child.Add(key);
            if (child.IsOverflow())
            {
                TreeNode<T> sibling = child.Split();
                InsertChild(sibling.GetFirstLeafKey(), sibling);
            }
        }

        /// <summary>
        /// Слияние двух узлов.
        /// </summary>
        /// <param name="sibling">Брат, с которым происходит слияние.</param>
        public override void Merge(TreeNode<T> sibling)
        {
            InternalNode<T> node = (InternalNode<T>) sibling;
            //Спускает Separator сверху
            Keys.Add(node.GetFirstLeafKey());
            Keys.AddRange(node.Keys);
            Children.AddRange(node.Children);
        }

        /// <summary>
        /// Деление узла.
        /// </summary>
        /// <returns>Появившийся в результате деления узел.</returns>
        public override TreeNode<T> Split()
        {
            int from = Keys.Count / 2 + 1;
            int count = Keys.Count - from;
            InternalNode<T> sibling = Factory.CreateInternalNode(Factor);
            sibling.Keys.AddRange(Keys.GetRange(from, count));
            sibling.Children.AddRange(Children.GetRange(from, count + 1));

            Keys = Keys.GetRange(0, from - 1);
            Children = Children.GetRange(0, from);
            return sibling;
        }

        /// <summary>
        /// Проверка на переполнение ключей.
        /// </summary>
        /// <returns>Переполнен узел или нет.</returns>
        public override bool IsOverflow()
        {
            return Keys.Count >= Factor * 2;
        }

        /// <summary>
        /// Проверка на нехватку ключей.
        /// </summary>
        /// <returns>Есть нехватка ключей или нет.</returns>
        public override bool IsUnderFlow()
        {
            return Keys.Count < Factor - 1;
        }

        /// <summary>
        /// Возвращает самый левый (т.е. наименьший) ключ,
        /// находящийся на листьевом уровне.
        /// </summary>
        /// <returns>Ключ.</returns>
        public override T GetFirstLeafKey()
        {
            return Children[0].GetFirstLeafKey();
        }

        /// <summary>
        /// Возвращает самый первый (т.е. самый левый) лист в поддереве
        /// </summary>
        /// <returns>Лист дерева.</returns>
        public override LeafNode<T> GetFirstLeaf()
        {
            return Children[0].GetFirstLeaf();
        }

        /// <summary>
        /// По ключу находит потомка, в котором может находиться
        /// переданный ключ. Для подробностей реализации см.
        /// описание метода IndexInSorted в классе LinkedCollection/ArrayCollection.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Потомок.</returns>
        private TreeNode<T> GetChild(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return Children[childIndex];
        }

        /// <summary>
        /// Аналог GetChild, но возвращающий левого брата того
        /// потомка, где может находиться переданный ключ.
        /// Используется при нехватке ключей, чтобы "одолжить"
        /// ключи у брата, или слить брата и потомка в один узел.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Левый брат потомка, где находится переданный ключ.</returns>
        private TreeNode<T> GetChildLeftSibling(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return childIndex > 0 ? Children[childIndex - 1] : null;
        }

        /// <summary>
        /// Аналог GetChild, но возвращающий правого брата того
        /// потомка, где может находиться переданный ключ.
        /// Используется при нехватке ключей, чтобы "одолжить"
        /// ключи у брата, или слить брата и потомка в один узел.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Правый брат потомка, где находится переданный ключ.</returns>
        private TreeNode<T> GetChildRightSibling(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return childIndex < Keys.Count ? Children[childIndex + 1] : null;
        }

        /// <summary>
        /// Удаление потомка и связанного с ним ключа.
        /// </summary>
        /// <param name="key">Ключ.</param>
        private void DeleteChild(TreeNode<T> child)
        {
            int index = Children.IndexOf(child);

            bool result = index >= 0;
            if (result)
            {
                Keys.RemoveAt(index - 1);
                Children.RemoveAt(index);
            }

        }

        /// <summary>
        /// Добавление ключа и связанного с ним потомка.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <param name="child">Потомок.</param>
        private void InsertChild(T key, TreeNode<T> child)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            if (location >= 0)
            {
                Children[childIndex] = child;
            }
            else
            {
                Keys.Insert(childIndex, key);
                Children.Insert(childIndex + 1, child);
            }
        }

        /// <summary>
        /// Сравнение двух узлов, реализация интерфейса IComparable.
        /// Необходимо, чтобы создать LinkedCollection<LinkedNode<T>>, так как
        /// стоит ограничение на тип Т: IComparable. В самой программе
        /// данный метод не вызывается.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is InternalNode<T> otherNode))
                throw new ArgumentException("Object is not a LinkedNode.");
            return Factor.CompareTo(otherNode.Factor);
        }
    }
}