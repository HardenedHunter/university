// ReSharper disable CommentTypo

using System;
using Tree;
using TreeType = Tree.LinkedTree<int>;

namespace Tree_GUI
{
    class Presenter
    {
        private readonly IView _view;
        private TreeType _arrayTree = new TreeType();

        public Presenter(IView view)
        {
            _view = view;
            _view.AddNode += OnAddNode;
            _view.DeleteNode += OnDeleteNode;
            _view.Clear += OnClear;
            _view.Reload += OnReload;
            RefreshView();
        }

        private void OnAddNode(object sender, EventArgs e)
        {
            if (Int32.TryParse(_view.InputAdd, out int result))
            {
                _arrayTree.Add(result);
                RefreshView();
            }
        }

        private void OnDeleteNode(object sender, EventArgs e)
        {
            if (Int32.TryParse(_view.InputDelete, out int result))
            {
                _arrayTree.Remove(result);
                RefreshView();
            }
        }

        private void OnClear(object sender, EventArgs e)
        {
            _arrayTree.Clear();
            // RefreshView();

            _arrayTree.Add(1);
            _arrayTree.Add(2);
            _arrayTree.Add(3);
            _arrayTree.Add(4);
            _arrayTree.Add(5);
            _arrayTree.Add(6);
            _arrayTree.Add(7);
            _arrayTree.Add(8);
            _arrayTree.Add(9);
            _arrayTree.Add(10);

            // _arrayTree.Remove(10);
            // _arrayTree.Remove(9);
            // _arrayTree.Remove(1);
            // _arrayTree.Remove(2);
            // _arrayTree.Remove(3);
            // _arrayTree.Remove(6);
            RefreshView();
        }

        private void OnReload(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            _view.DrawTree(_arrayTree.Draw);
        }
    }
}