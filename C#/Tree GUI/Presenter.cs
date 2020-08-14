// ReSharper disable CommentTypo

using System;
using System.Windows.Forms;
using Tree;
using static System.Int32;

namespace Tree_GUI
{
    class Presenter
    {
        private readonly IView _view;
        private ITree<int> _tree;
        private ITreeCreator<int> _creator;

        public Presenter(IView view)
        {
            _view = view;
            _view.AddNode += OnAddNode;
            _view.DeleteNode += OnDeleteNode;
            _view.Clear += OnClear;
            _view.ChangeFactor += OnChangeFactor;
            _view.Reload += OnReload;
            _view.SelectLinked += OnSelectLinked;
            _view.SelectArray += OnSelectArray;
            _view.SortByEven += OnSortByEven;
            _view.SortByOdd += OnSortByOdd;
            _view.FillTestData += OnFillTestData;
            _view.MakeImmutable += OnMakeImmutable;

            _creator = new LinkedTreeCreator<int>();
            _tree = _creator.CreateTree();
            RefreshView();
        }

        private void OnAddNode(object sender, EventArgs e)
        {
            if (TryParse(_view.InputAdd, out int result))
            {
                try
                {
                    _tree.Add(result);
                    RefreshView();
                }
                catch (ImmutableTreeException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void OnDeleteNode(object sender, EventArgs e)
        {
            if (TryParse(_view.InputDelete, out int result))
            {
                try
                {
                    _tree.Remove(result);
                    RefreshView();
                }
                catch (ImmutableTreeException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void OnChangeFactor(object sender, EventArgs e)
        {
            if (TryParse(_view.InputFactor, out int newFactor) && newFactor >= 2)
            {
                var newTree = _creator.CreateTree(newFactor);
                foreach (var item in _tree)
                    newTree.Add(item);
                _tree = newTree;
                RefreshView();
            }
        }

        private void OnClear(object sender, EventArgs e)
        {
            try
            {
                _tree.Clear();
                RefreshView();
            }
            catch (ImmutableTreeException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void OnReload(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void OnSelectLinked(object sender, EventArgs e)
        {
            _creator = new LinkedTreeCreator<int>();
            _tree = _creator.CreateTree(_tree.Factor);
            RefreshView();
        }

        private void OnSelectArray(object sender, EventArgs e)
        {
            _creator = new ArrayTreeCreator<int>();
            _tree = _creator.CreateTree(_tree.Factor);
            RefreshView();
        }

        private void OnSortByOdd(object sender, EventArgs e)
        {
            var result = TreeUtils.FindAll(_tree, node => node % 2 != 0, _creator.CreateTree);
            _tree = result;
            RefreshView();
        }

        private void OnSortByEven(object sender, EventArgs e)
        {
            var result = TreeUtils.FindAll(_tree, node => node % 2 == 0, _creator.CreateTree);
            _tree = result;
            RefreshView();
        }

        private void OnFillTestData(object sender, EventArgs e)
        {
            try
            {
                _tree.Clear();
                _tree.Add(1);
                _tree.Add(2);
                _tree.Add(3);
                _tree.Add(4);
                _tree.Add(5);
                _tree.Add(6);
                _tree.Add(7);
                _tree.Add(8);
                _tree.Add(9);
                _tree.Add(10);
                RefreshView();
            }
            catch (ImmutableTreeException exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void OnMakeImmutable(object sender, EventArgs e)
        {
            _tree = new ImmutableTree<int>(_tree);
        }

        private void RefreshView()
        {
            if (_tree == null || _tree.IsEmpty)
                _view.DrawEmpty();
            else
                _view.DrawTree(_tree.Draw);
        }
    }
}