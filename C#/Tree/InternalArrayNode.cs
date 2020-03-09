//using System.Data;
//
//namespace Tree
//{
//    class InternalArrayNode<T>: Node<T> where T: new()
//    {
//        private Node<T>[] _children;
//        private T[] _keys;
//        public int ChildrenCount { get; private set; }
//        public int KeysCount { get; private set; }
//
//        public InternalArrayNode(int branchingFactor)
//        {
//            KeysCount = 0;
//            ChildrenCount = 0;
//            _keys = new T[2 * branchingFactor - 1];
//            _children = new Node<T>[2 * branchingFactor];
//        }
//
//        public void Remove(T node)
//        {
//            throw new System.NotImplementedException();
//        }
//
//        public void Add(T node)
//        {
//            throw new System.NotImplementedException();
//        }
//
//        public T GetFirstLeafKey()
//        {
//            return _children[0].GetFirstLeafKey();
//        }
//
//        private void AddKey(T node)
//        {
//            if (KeysCount == _keys.Length)
//                //TODO REPLACE
//                throw new ConstraintException("Too much!");
//            _keys[KeysCount] = node;
//            KeysCount++;
//        }
//
////        private void AddChild
//
//        public void Merge(Node<T> sibling)
//        {
//            InternalArrayNode<T> node = (InternalArrayNode<T>) sibling;
//            AddKey(node.GetFirstLeafKey());
////            for (int i = 0; i < UPPER; i++)
////            {
////                
////            }
//        }
//
//        public Node<T> Split()
//        {
//            throw new System.NotImplementedException();
//        }
//
//        public bool IsOverflow()
//        {
//            return ChildrenCount > _children.Length;
//        }
//
//        public bool IsUnderFlow()
//        {
//            return ChildrenCount < (_children.Length + 1) / 2;
//        }
//    }
//}