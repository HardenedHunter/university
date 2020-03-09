using System;

namespace Tree
{
    public class LinkedNode<T> : Node<T> where T: IComparable
    {
        public List<Node<T>> Children;
        public int BranchingFactor { get;}


        public LinkedNode(int branchingFactor)
        {
            Keys = new List<T>();
            Children = new List<Node<T>>();
            BranchingFactor = branchingFactor;
        }

        public override void Remove(T key)
        {
            Node<T> child = GetChild(key);
            child.Remove(key);
            if (child.IsUnderFlow())
            {
                Node<T> childLeftSibling = GetChildLeftSibling(key);
                Node<T> childRightSibling = GetChildRightSibling(key);
                Node<T> left = childLeftSibling ?? child;
                Node<T> right = childLeftSibling != null ? child : childRightSibling;
                left.Merge(right);
                DeleteChild(right.GetFirstLeafKey());
                if (left.IsOverflow())
                {
                    Node<T> sibling = left.Split();
                    InsertChild(sibling.GetFirstLeafKey(), sibling);
                }
                //
                // if (_root.Keys.Count == 0)
                //     _root = left;
            }
        }

        public override void Add(T key)
        {
            Node<T> child = GetChild(key);
            child.Add(key);
            if (child.IsOverflow())
            {
                Node<T> sibling = child.Split();
                InsertChild(sibling.GetFirstLeafKey(), sibling);
            }
        }


        public override void Merge(Node<T> sibling)
        {
            LinkedNode<T> node = (LinkedNode<T>) sibling;
            Keys.Add(node.GetFirstLeafKey());
            Keys.AddRange(node.Keys);
            Children.AddRange(node.Children);
        }

        public override Node<T> Split()
        {
            int from = Keys.Count / 2 + 1;
            int count = Keys.Count - from;
            LinkedNode<T> sibling = new LinkedNode<T>(BranchingFactor);
            sibling.Keys.AddRange(Keys.GetRange(from, count));
            sibling.Children.AddRange(Children.GetRange(from, count + 1));

            Keys = Keys.GetRange(0, from - 1);
            Children = Children.GetRange(0, from - 1);
            return sibling;
        }

        public override bool IsOverflow()
        {
            return Children.Count > BranchingFactor;
        }

        public override bool IsUnderFlow()
        {
            return Children.Count < (BranchingFactor + 1) / 2;
        }

        public override T GetFirstLeafKey()
        {
            return Children[0].GetFirstLeafKey();
        }

        public Node<T> GetChildLeftSibling(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return childIndex > 0 ? Children[childIndex - 1] : null;
        }

        public Node<T> GetChild(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return Children[childIndex];
        }

        public Node<T> GetChildRightSibling(T key)
        {
            int location = Keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return childIndex < Keys.Count ? Children[childIndex + 1] : null;
        }

        public void DeleteChild(T key)
        {
            int index = Keys.IndexOf(key);
            if (index >= 0)
            {
                Keys.RemoveAt(index);
                Children.RemoveAt(index + 1);
            }
        }

        public void InsertChild(T key, Node<T> child)
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

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is LinkedNode<T> otherNode))
                throw new ArgumentException("Object is not a Node");
            return BranchingFactor.CompareTo(otherNode.BranchingFactor);
        }
    }
}